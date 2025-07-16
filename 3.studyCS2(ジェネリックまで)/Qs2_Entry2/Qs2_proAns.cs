using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qs2_Entry2
{
    internal class Qs2_proAns
    {
        static void Main(string[] args)
        {
            /*問題1(等速運動と等加速度運動)*/
            Console.WriteLine("【問題1(等速運動と等加速度運動)：】");
            Vector2 obj = new Vector2();
            Vector2 speed = new Vector2(1.2f, 1.4f);//初速。秒速(/s)
            Vector2 accel = new Vector2(0.1f, 0.2f);//加速度
            Vector2 temp;
            //計算
            temp = obj + speed * 3;
            Console.WriteLine("・初速speed(1.2f,1.4f)で3秒間等速運動:\n" + temp.OutString());
            temp = speed * 3 + (accel * 3 * 3) / 2;
            Console.WriteLine("・初速speed(1.2f,1.4f), 加速度accel(0.1f,0.2f)で3秒間等加速度運動:\n" + temp.OutString());


            /*問題2(放物線運動)*/
            Console.WriteLine("【問題2(放物線運動)：】");
            Vector2 gravity = new Vector2(0, -9.8f);
            speed.Set(1.0f, 24.0f);//(/s)
            accel.Set(0.0f, 0.0f);//(/s)

            //60fpsの世界にする
            gravity = gravity / 60;
            accel = accel / 60;

            //計算
            for (int time = 1; true; time++)
            {
                //現在の速度
                speed = speed + gravity + accel;

                //現在のオブジェクトの位置
                obj = obj + speed;

                //obj位置
                //Console.WriteLine(speed.OutString() + " " + (float)time / 60);

                //地面に付いたかの判定                
                if (speed.Y <= 0.0f)
                {
                    Console.WriteLine("物体が地面に付くのに{0}秒以上掛かりました。", (float)time / 60);
                    break;
                }


            }


        }
    }

    /*問題1(2Dゲーム向けベクタークラスの作成)*/
    //UnityリファレンスのVector2を再現できる範囲で再現してます。
    //(再現してない部分は、実際に物体を動かさないと理解が難しいものと)
    //(現状の知識では再現できないものです)
    public class Vector2
    {
        //フィールド
        private float _x = 0;
        private float _y = 0;
        float _magnitude = 0;//ベクトルの長さ
        float _sqrMagnitude = 0;//ベクトルの二乗の長さ
        Vector2 _normalized;//単位ベクトル

        //staticフィールド
        public static Vector2 zero = new Vector2();//ゼロベクトル
        public static Vector2 one = new Vector2(1, 1);
        public static Vector2 up = new Vector2(0, 1);
        public static Vector2 down = new Vector2(0, -1);
        public static Vector2 left = new Vector2(-1, 0);
        public static Vector2 right = new Vector2(0, 1);

        //プロパティ
        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public float Magnitude { get; }//長さ
        public float SqrMagnitude { get; }//長さの二乗
        public Vector2 Nomalized { get; }//単位ベクトル

        //コンストラクタ
        public Vector2()
        {
            SetMagnitude();
            SetSqrtMagnitude();
        }
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
            SetMagnitude();
            SetSqrtMagnitude();
        }


        //public Method.
        public void Set(float x, float y)
        {
            _x = x;
            _y = y;
            SetMagnitude();
            SetSqrtMagnitude();
        }
        //ベクトルの情報をコンソールに表示
        //これはUnityのものとは内容が違います。
        public string OutString()
        {
            return "x:" + this._x + ", y:" + this._y + ", magnitude:" + this._magnitude;
        }
        public void Normalized()
        {
            _normalized = new Vector2(this.X / this.Magnitude, this.Y / this.Magnitude);
        }


        //private Method.
        //長さの計算
        private void SetMagnitude()
        {
            _magnitude = MathF.Sqrt(this._x * this._x + this._y * this._y);
        }
        //長さの二乗(ルートの計算をしない)
        private void SetSqrtMagnitude()
        {
            _sqrMagnitude = this._x * this._x + this._y * this._y;
        }


        //static method.
        //角度
        public static float Angle(Vector2 v1, Vector2 v2)
        {
            float cosTheta = 0;
            float angle = 0;

            //コサインシータを出す。
            cosTheta = Dot(v1, v2) / (v1.Magnitude * v2.Magnitude);
            //コサインシータから角度を出す
            angle = MathF.Acos(cosTheta);

            return angle;
        }
        //距離
        //2点感の距離なので、2点を結ぶベクトルの長さと同じ
        public static float Distance(Vector2 v1, Vector2 v2)
        {
            //tempV = v1- v2; retrun temp.Mgnitude;と同じ
            return (v1 - v2).Magnitude;
        }
        //内積(a1*b1 + a2*b2 ただし、 a(a1,a2),b(b1,b2)のとき)
        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        //垂直な 2D ベクトルを返す。
        //反時計回りに90度回転させたベクトル
        public static Vector2 Perpendicular(Vector2 v1)
        {
            //yの値の符号を反転させて、そのうえでxとyの値を入れ替える。
            //すると垂直なベクトルを求められる(2Dのみ)
            //二次元ベクトルの回転の公式が、以下。
            //x = x * cosθ - y * sinθ
            //y = x * sinθ + y * cosθ
            //ここでθにそれぞれ90を入れると
            //x = x * 0 - y * 1
            //y = x * 1 + y * 0
            //なので、正しい。
            return new Vector2(-v1.Y, v1.X);
        }
        //法線を基準にしてベクトルの反射したベクトル。
        //第2引数の法線ベクトルは正規化されていないといけない。
        public static Vector2 Reflect(Vector2 v1, Vector2 nVecNormalized)
        {
            //反射するための法線ベクトルの作成
            Vector2 nVec = v1 * Dot(v1, nVecNormalized);

            return 2 * nVec - v1;
        }
        //2 つのベクトルの各成分の乗算(アダマール積)
        //拡大縮小とかに使う(等倍・等縮じゃない場合にも使える)
        public static Vector2 Scale(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
        }


        //演算子オーバーロード
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left._x + right._x, left._y + right._y);
        }
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left._x - right._x, left._y - right._y);
        }
        public static Vector2 operator *(Vector2 left, float right)
        {
            return new Vector2(left._x * right, left._y * right);
        }
        public static Vector2 operator *(float left, Vector2 right)
        {
            return new Vector2(left * right._x, left * right._y);
        }
        public static Vector2 operator /(Vector2 left, float right)
        {
            return new Vector2(left._x / right, left._y / right);
        }
        public static Vector2 operator /(float left, Vector2 right)
        {
            return new Vector2(left / right._x, left / right._y);
        }
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            bool ans = false;
            if ((left._x == right._x) && (left._y == right._y))
            {
                ans = true;
            }
            return ans;
        }
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }

    }

}


