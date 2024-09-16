using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ge1_6_inheritance
{
    internal class ge1_6_check
    {
        static void Main(string[] args)
        {
            //インスタンスの作成
            Vector2 v1 = new Vector2(1, 2);
            Vector3 v2 = new Vector3(1, 2, 3);

            //確認
            v1.Show();
            v2.Show();

            //加算
            Vector2 v3 = new Vector2(1, 2);
            Vector3 v4 = new Vector3(1, 2, 3);
            v1 = Vector2.Add(v1, v3);//staticメンバの使用
            v2 = Vector3.Add(v2, v4);//staticメンバの使用

            //確認
            v1.Show();
            v2.Show();
        }
    }


    public class Vector2 : BaseVector
    {
        public int Y;

        //引数付きコンストラクタ作る際には、
        //引数無しコンストラクタも作成しなければならない。
        //(そうでないと、引数なしコンストラクタがエラーになる)
        public Vector2() { }
        public Vector2(int x, int y) { /*自分で記述*/ }

        //通常のクラスでもスタティックメンバを持つことが出来ます。
        public static Vector2 Add(Vector2 a, Vector2 b)
        {
            Vector2 ans = new Vector2();

            /*自分で記述*/

            return ans;
        }

        public override void Show()
        {
            /*自分で記述*/
        }
    }
    public class Vector3 : BaseVector
    {
        public int Y, Z;
        public Vector3() { }
        public Vector3(int x, int y, int z) { /*自分で記述*/ }

        //通常のクラスでもスタティックメンバを持つことが出来ます。
        public static Vector3 Add(Vector3 a, Vector3 b)
        {
            Vector3 ans = new Vector3();

            /*自分で記述*/

            return ans;
        }

        public override void Show()
        {
            /*自分で記述*/
        }

    }
    public class BaseVector
    {
        public int X;

        public virtual void Show()
        {
            Console.WriteLine("x:{0}", X);
        }
    }

}
