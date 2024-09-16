using System;

namespace Qs2_Entry2
{
    internal class Qs2_3
    {
        static void Main(string[] args)
        {

            /*カプセル化*/
            Console.WriteLine("【カプセル化】");
            Sample sample = new Sample("Ohara", 43, "学校法人となってからの年齢が入ってます。");
            Console.WriteLine("Name: {0}", sample.Name);
            //Console.WriteLine("Name: {0}", sample.Name);error
            Console.WriteLine("Age: {0}", sample.Age);
            //Console.WriteLine("Name: {0}", sample._name);error
            Console.WriteLine("Comment: {0}", sample.Comment);
            //sample.Age = 44;error
            //sample.Name = "o-hara";error
            sample.Comment = "簿記校の創立はもっと前です。";
            Console.WriteLine("Comment: {0}", sample.Comment);


            /*partialクラス*/
            Console.WriteLine("【partialクラス】");
            Echo echo = new Echo();
            echo.Message = "hello";
            echo.ShowMessage();

        }
    }

    /*カプセル化*/
    //アクセス修飾子によりアクセス制限が出来ます(教p319~p321)。
    //それによってカプセル化(隠ぺい)が実現できます。
    //public 制限なし, private 同じクラス(インスタンス)内のみ
    //protected 自身と派生クラス(継承先)
    //internal プロジェクト全体
    //internal protected プロジェクト内の自身と派生クラス
    //public, private, protected を使いこなせるようになりましょう。
    //(internal系は必要になったときに覚えましょう)
    //例は殆どこれまでのおさらいです。
    //継承をしないとカプセル化の本当の意義は分かりません。
    public class Sample
    {
        private string _name = "";
        private int _age = 0;
        public string Comment = "";


        public string Name { get { return _name; } }
        public int Age { get { return _age; } }

        public Sample() { }
        public Sample(string name, int age, string com)
        {
            _name = name;
            _age = age;
            Comment = com;
        }
    }


    /*partialクラス*/
    //クラスの宣言を複数に分けて記述する方法です。
    //partialクラスで提供されたクラスに追加機能を載せる、という使い方が多いです。
    public partial class Echo
    {
        public string Message { get; set; } = "";
    }

    public partial class Echo
    {
        public void ShowMessage()
        {
            Console.WriteLine(Message);
        }
    }
}

