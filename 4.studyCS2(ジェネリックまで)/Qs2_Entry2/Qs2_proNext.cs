using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qs2_Entry2
{
    internal class Qs2_proNext
    {
        static void Main(string[] args)
        {
            /*問題3(UnityのVector2の再現)*/
            //リファレンスは以下
            //https://docs.unity3d.com/ja/2018.4/ScriptReference/Vector2.html
            //頑張って再現し、すべての機能を確認できるコードを書け！
            //Main内のコードも考えよ。
        }
    }

    /*問題3(2Dゲーム向けベクタークラスの作成)*/
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
            //実装する
        }
        public Vector2(float x, float y)
        {
            //実装する
        }


        //public Method.
        public void Set(float x, float y)
        {
            //実装する
        }
        //ベクトルの情報をコンソールに表示
        //これはUnityのものとは内容が違います。
        public string OutString()
        {
            return "x:" + this._x + ", y:" + this._y + ", magnitude:" + this._magnitude;
        }
        public void Normalized()
        {
            //実装する
        }


        //private Method.
        //長さの計算
        private void SetMagnitude()
        {
            //実装する
        }
        //長さの二乗(ルートの計算をしない)
        private void SetSqrtMagnitude()
        {
            //実装する
        }


        //static method.
        //角度
        public static float Angle(Vector2 v1, Vector2 v2)
        {
            //実装する
        }
        //距離
        //2点感の距離なので、2点を結ぶベクトルの長さと同じ
        public static float Distance(Vector2 v1, Vector2 v2)
        {
            //実装する
        }
        //内積(a1*b1 + a2*b2 ただし、 a(a1,a2),b(b1,b2)のとき)
        public static float Dot(Vector2 v1, Vector2 v2)
        {
            //実装する
        }
        //垂直な 2D ベクトルを返す。
        //反時計回りに90度回転させたベクトル
        public static Vector2 Perpendicular(Vector2 v1)
        {
            //実装する
        }
        //法線を基準にしてベクトルの反射したベクトル。
        //第2引数の法線ベクトルは正規化されていないといけない。
        public static Vector2 Reflect(Vector2 v1, Vector2 nVecNormalized)
        {
            //実装する
        }
        //2 つのベクトルの各成分の乗算(アダマール積)
        //拡大縮小とかに使う(等倍・等縮じゃない場合にも使える)
        public static Vector2 Scale(Vector2 v1, Vector2 v2)
        {
            //実装する
        }


        //演算子オーバーロード
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            //実装する
        }
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            //実装する
        }
        public static Vector2 operator *(Vector2 left, float right)
        {
            //実装する
        }
        public static Vector2 operator *(float left, Vector2 right)
        {
            //実装する
        }
        public static Vector2 operator /(Vector2 left, float right)
        {
            //実装する
        }
        public static Vector2 operator /(float left, Vector2 right)
        {
            //実装する
        }
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            //実装する
        }
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            //実装する
        }

    }
}
