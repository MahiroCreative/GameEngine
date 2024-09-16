using System;

namespace Ge1_6_inheritance
{
    internal class ge1_6_sample1
    {
        static void Main(string[] args)
        {
            /*インスタンスの作成*/
            //引数無しコンストラクタ
            Test a = new Test(); 
            //引数有りコンストラクタ
            Test b = new Test(8);
            /*確認*/
            a.Show();
            b.Show();
        }
    }
    public class Test
    {
        //メンバ変数
        int state=0;//private int state=0;
        /*コンストラクタ*/
        //引数無しコンストラクタ
        public Test() { }
        //引数有りコンストラクタ
        public Test(int input)
        {
            state = input;
        }
        //メンバ関数
        public void Show()
        {
            Console.WriteLine(state);
        }
    }
}
