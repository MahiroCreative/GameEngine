using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ge1_5_ClassStruct
{
    internal class ge1_5_pro2
    {
        static void Main(string[] args)
        {
            //インスタンスの作成
            Vector2 a = new Vector2();
            Vector2 b = new Vector2();
            Vector2 c;
            Vector2 d;
            //数値の代入
            a.x = 1.2f;
            a.y = 1.8f;
            b.x = 1.6f;
            b.y = 2.2f;
            //確認
            a.Show();
            b.Show();
            //足し算
            c = Vector2.Add(a, b);
            c.Show();
            //引き算
            d = Vector2.Sub(a, c);
            d.Show();
        }
    }

    class Vector2
    {
        public float x, y;

        static public Vector2 Add(Vector2 v1, Vector2 v2) 
        {
            Vector2 temp = new Vector2();

            temp.x = v1.x + v2.x;
            temp.y = v1.y + v2.y;

            return temp;
        }
        static public Vector2 Sub(Vector2 v1, Vector2 v2)
        {
            Vector2 temp = new Vector2();

            temp.x = v1.x - v2.x;
            temp.y = v1.y - v2.y;

            return temp;
        }

        public void Show()
        {
            Console.WriteLine("x:{0},y:{1}",x,y);
        }
    }
}
