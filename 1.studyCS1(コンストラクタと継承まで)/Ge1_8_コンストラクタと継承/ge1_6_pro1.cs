using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ge1_6_inheritance
{
    internal class ge1_6_pro1
    {
        static void Main(string[] args)
        {
            //インスタンスの作成
            Vector2 v1 = new Vector2();
            Vector2 v2 = new Vector2(1.2f,1.5f);
            Vector2 ans;
            //確認
            v1.Show();
            v2.Show();
            //計算
            ans = Vector2.Add(v1, v2);
            ans.Show();
            ans = Vector2.Sub(v1, v2);
            ans.Show();
            //長さの表示
            ans.Length();
        }
    }

    class Vector2
    {
        //メンバ変数
        public float x, y;

        //コンストラクタ
        public Vector2() { x = 0; y = 0; }
        public Vector2(float a, float b) { x = a; y = b; }

        //メンバ関数
        public void Show()
        {
            Console.WriteLine("x:{0},y:{1}", x, y);
        }
        public void Length()
        {
            float ans;

            ans = x*x + y*y;//x^2+y^2
            ans = MathF.Sqrt(ans);//ルート

            Console.WriteLine("サイズ:{0}",ans);
        }


        //staticメンバ関数
        public static Vector2 Add(Vector2 v1, Vector2 v2)
        {
            Vector2 temp = new Vector2();

            temp.x = v1.x + v2.x;
            temp.y = v1.y + v2.y;

            return temp;
        }
        public static Vector2 Sub(Vector2 v1, Vector2 v2)
        {
            Vector2 temp = new Vector2();

            temp.x = v1.x - v2.x;
            temp.y = v1.y - v2.y;

            return temp;
        }
    }
}
