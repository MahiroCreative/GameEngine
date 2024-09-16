using System;

namespace Ge1_5_ClassStruct
{
    internal class ge1_5_sample1
    {
        static void Main(string[] args)
        {
            Test.OutCount();
            Test.OutCount();
            Test.DelCount();
            Test.DelCount();
            Test.OutCount();
        }
    }

    public static class Test
    {
        //メンバ変数
        static int a=0;

        //メンバ関数(メソッド)
        public static void OutCount()
        {
            a++;
            Console.WriteLine(a);
        }
        public static void DelCount()
        {
            a-- ;
        }
    }

}
