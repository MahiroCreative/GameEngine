using System;

namespace Qs3_inheritance
{
    internal class Qs3_2
    {
        static void Main(string[] args)
        {
            /*クラスへのアクセス(this(),base())*/
            Console.WriteLine("【クラスへのアクセス(this(),base())】");
            Derived x = new Derived();
            x.Show();
            x.Show2();


            /*オーバーライド*/
            Console.WriteLine("【オーバーライド】");
            Derived2 x2 = new Derived2();
            x2.Show();
            x2.Show2();
            //newは変数依存なので、Derived2ならnew側が。
            //Base2なら、基本クラスの方が実行される。
            Base2 x3 = x2;
            x3.Show();
            x3.Show2();
        }
    }

    /*クラスへのアクセス(this(),base())*/
    //インスタンスを作成する際に、自身の引数無しコンストラクタにアクセスしたり、
    //基本クラスのコンストラクタにアクセスする必要がある場合があります。
    //その際には、this(),base() キーワードを使用します。
    public class Base
    {
        public Base()
        {
            Console.WriteLine("Base.");
        }
        public Base(string name) : this()
        {
            Console.WriteLine("名前付きBase.");
        }

        public void Show()
        {
            Console.WriteLine("Hello.");
        }
    }
    public class Derived : Base
    {
        public Derived() : base("")
        {
            Console.WriteLine("Derive.");
        }

        public void Show2()
        {
            base.Show();//baseで基本クラスにアクセスできる。
            Console.WriteLine("Hello2.");
        }
    }


    /*オーバーライド(オーバーロードとは違います)*/
    //基本クラスのメンバーを派生クラスで書き換える際に使う機能です。
    //基本クラスの書き換えられるかもしれないメンバーに　virtual
    //派生クラスの書き換えたメンバーに override を付けます。
    //その他似たような機能にnewがあります。
    public class Base2
    {
        public virtual void Show()
        {
            Console.WriteLine("Show_Base2.");
        }
        public void Show2()
        {
            Console.WriteLine("Show2_Base2.");
        }
    }
    public class Derived2 : Base2
    {
        public override void Show()
        {
            Console.WriteLine("Show_Derived.");
        }
        //newはオーバーライドしているのではなく、基本クラスのメンバーを隠ぺいして
        //newで作成したメンバだけを使えるようにしている。
        //変数依存なので、同じインスタンスでも別の変数に入れると基本クラスのメンバーの挙動になる。
        public new void Show2()
        {
            Console.WriteLine("Show2_Derived.");
        }
    }

}
