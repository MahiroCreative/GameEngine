using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qs4_Generic
{
    internal class Qs4_2
    {
        static void Main(string[] args)
        {
            /*ジェネリック*/
            //C++ではテンプレートと呼ばれる機能です。
            //作成した機能で使用するデータ型を、使用時に任意に決定できる機能です。
            //コレクションもこのジェネリックによって実装されています。
            //任意に決定できる型を『メソッド名名<T>』で指定する。

            //ジェネリックメソッド
            void swap<T>(ref T a,ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
            //確認
            Console.WriteLine("[ジェネリックメソッド:]");
            float a = 1.2f, b = 1.7f;
            Console.WriteLine("a={0},b={1}", a, b);
            swap<float>(ref a,ref b);
            Console.WriteLine("a={0},b={1}",a,b);

            //ジェネリッククラス
            Tuple<string, int> user1 = new Tuple<string, int>();
            Tuple<string, int> user2 = new Tuple<string, int>();
            user1.Item1 = "tanaka"; user1.Item2 = 78;
            user2.Item1 = "tanaka"; user2.Item2 = 88;
            //以下のような使われ方をする事が多い
            //ID,名前,得点 と考える
            Tuple<int,Tuple<string,int>> userData1 = new Tuple<int, Tuple<string, int>>();
            Tuple<int, Tuple<string, int>> userData2 = new Tuple<int, Tuple<string, int>>();
            userData1.Item1 = 1;
            userData1.Item2 = user1;
            userData2.Item1 = 2;
            userData2.Item2 = user2;
            //確認
            Console.WriteLine("ID:{0},name:{1},score:{2}",userData1.Item1,userData1.Item2.Item1,userData1.Item2.Item2);
            Console.WriteLine("ID:{0},name:{1},score:{2}", userData2.Item1, userData2.Item2.Item1, userData2.Item2.Item2);

        }
        //ジェネリッククラス
        //クラス内で使われる方を実装時に任意で設定できる。
        //任意に設定する型を『クラス名<T>』で指定する。
        //また、以下のような単純に複数の値を入れるようなクラスは
        //Tupleと一般的に呼ばれます。
        class Tuple<T1,T2>
        {
            public T1 Item1 { get; set; }
            public T2 Item2 { get; set; }
        }
    }
}
