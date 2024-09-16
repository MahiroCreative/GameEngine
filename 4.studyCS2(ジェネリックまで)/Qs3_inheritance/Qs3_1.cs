using System;

namespace Qs3_inheritance
{
    internal class Qs3_1
    {
        static void Main(string[] args)
        {
            /*継承の基本*/
            //Baseを継承しているのでBaseのコンストラクタを実行してから
            //Derivedのコンストラクタが実行される。
            Console.WriteLine("【Baseのコンストラクタ後にDerivedのコンストラクタが実行】");
            Derived x = new Derived();

            //Baseを継承しているので、Baseのメソッドが使える
            Console.WriteLine("【Baseを継承しているので、Baseのメソッドが使える】");
            x.Show();

            //派生クラス内で、基本クラスのメソッドを使える
            Console.WriteLine("【派生クラス内で、基本クラスのメソッドを使える】");
            x.ShowPlus();

            //基本クラスの変数で派生クラスのインスタンスを扱える
            //ただし、基本クラスのメンバーしか使えない。
            Console.WriteLine("【基本クラスの変数で派生クラスのインスタンスを扱える】");
            Base y = x;
            y.Show();
            //y.ShowPlus(); ←　エラーになる。
        }
    }

    /*継承*/
    //既に存在するクラスの機能を新しいクラスに引き継ぐ機能
    //継承するクラスを基本クラス。継承先を派生クラスと呼びます。
    //(※呼び方は様々存在しますが、ここでは上記で統一)
    //C#ではC++と違い、多重継承が禁止されています(C++でもしない方が無難)。
    public class Base
    {
        public Base()
        {
            Console.WriteLine("Baseクラス（基本クラス）のコンストラクタ実行");
        }

        public void Show()
        {
            Console.WriteLine("HELLO!");
        }
    }
    //派生：Derived
    public class Derived : Base
    {
        public Derived()
        {
            Console.WriteLine("Derivedクラス（派生クラス）のコンストラクタ実行");
        }

        public void ShowPlus()
        {
            //Baseのメソッドを自分のメソッドのように使える
            Show();
            Console.WriteLine("HELLO PLUS!");
        }
    }
}


