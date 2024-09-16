using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //インスタンスの作成
            Test tes1 = new Test();
            Test tes2 = new Test();
            //インスタンスを使って処理を行う
            tes1.Count();
            tes1.Count();
            tes1.Count();
            tes2.Count();
            tes2.Count();
            tes1.DelCount();
            tes2.DelCount();
            //確認
            Console.Write("tes1:");
            tes1.OutCount();
            Console.Write("tes2:");
            tes2.OutCount();
        }
    }

    public class Test
    {
        //メンバ変数
        int a = 0;
        //メンバ関数(メソッド)
        public void Count()
        {
            a++;
        }
        public void OutCount()
        {
            Console.WriteLine(a);
        }
        public void DelCount()
        {
            a--;
        }
    }
}