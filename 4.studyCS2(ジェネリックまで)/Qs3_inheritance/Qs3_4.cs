using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qs3_inheritance
{
    internal class Qs3_4
    {
        static void Main(string[] args)
        {
            /*抽象クラス*/
            Console.WriteLine("【抽象クラス：】");
            Slime ene1 = new Slime();
            Goblin ene2 = new Goblin();
            ene1.Show();
            ene1.Attack();
            ene2.Show();
            ene2.Attack();

            /*インターフェース*/
            Console.WriteLine("【インターフェース：】");
            IHp[] hps = { new CreePeer(),new Block()};
            foreach(IHp hp in hps)
            {
                hp.Damage(1);
                hp.Show();
                hp.Damage(2);
                hp.Show();
            }

        }
    }


    /*抽象クラス*/
    //抽象クラスとは実装の無いメンバーを含むクラスで、継承すること前提のクラスです。
    //つまり抽象クラスのまま使われることは無く、派生クラスになってから使用されるクラスです。
    //例えばスライムとゴブリンというクラスと作るとします。
    //スライムもゴブリンも等しく攻撃というメソッドを持つので、攻撃というメソッドは共通化できます。
    //(※しかし、与えるダメージの計算式は違うはずです)
    //このような場合は、Enemyという抽象クラスで攻撃というメソッドを作成しておき、
    //それを継承して継承後に必要な計算式を追加する、という形になります。
    //ここまでで分かると思いますが、抽象クラスはインスタンスを作れません。
    //何故なら、継承して使う事前提だからです。
    //C++でも同様の概念がありますが、書き方が大きく違います。
    abstract class Enemy
    {
        //抽象プロパティなので、継承後に実装
        abstract public string Name { get; }
        abstract public int Level { get; }

        //抽象メソッドなので、継承後に実装　
        public abstract void Attack();

        //通常メソッドなので、この場で実装
        public void Show()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Level);
        }
    }
    class Slime : Enemy
    {
        public override string Name { get { return "スライム"; } }
        public override int Level { get { return 8; } }
        public override void Attack()
        {
            Console.WriteLine("28のダメージ！");
        }
    }
    class Goblin : Enemy
    {
        public override string Name { get { return "ゴブリン"; } }
        public override int Level { get { return 12; } }
        public override void Attack()
        {
            Console.WriteLine("38のダメージ！");
        }
    }


    /*インターフェース*/
    //・解説
    //インターフェースは、C++では概念だけが存在して機能としては存在しないものでした。
    //C#では機能としてインターフェースというものが存在します。
    //どういうときに使用するかというと、多重継承をしたいときに使用します。
    //C++と違い、C#ではクラスの多重継承が禁止されています。
    //そのため、多重継承的な事をする際にはインターフェースを使用する必要があります。
    //また、インターフェースという名前から分かるように、
    //役割や機能が大きく違うオブジェクト同士でも一部機能の仕様を統一したいときにも利用します。
    //ゲームの例だと、マインクラフトにはブロックにもエネミーにもHpというものが存在します。
    //(HPが無くなるとエネミーだと消滅しますが、ブロックだとアイテム化します)
    //それらは役割も機能も違いますが、
    //ダメージによりHpが減るという部分だけは同じ仕様にしたいのでインタフェースを用いて作成されています。
    //(※一般的な外部アクセスでも用いられる事が大く、
    //マルチプラットフォームプログラミングやネットワークプログラミングでも比較的使われます)
    //・仕様
    //実装を持つメンバは持てない
    //インスタンスを生成できない
    //継承後にメンバは全て実装しなければならない
    //アクセス修飾子で修飾できない
    //多重継承可能
    //実装する際には、オーバーライドしない
    //インタフェースを定義する際には名前の先頭に『I』と付ける
    interface IHp
    {
        void Damage(int a);
        void Show();
    }
    class CreePeer : IHp
    {
        private int _hp = 10;
        private string _name = "CreePeer";

        public void Damage(int a) { _hp = _hp - a; }
        public void Show()
        {
            Console.WriteLine(_name);
            Console.WriteLine(_hp);
        }
    }
    class Block : IHp
    {
        private int _hp = 10;
        private string _name = "Block";

        public void Damage(int a) { _hp = _hp - a*2; }
        public void Show()
        {
            Console.WriteLine(_name);
            Console.WriteLine(_hp);
        }
    }
}