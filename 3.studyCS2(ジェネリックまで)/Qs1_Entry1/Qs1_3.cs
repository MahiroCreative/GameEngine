using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Qs1_Entry1
{
    internal class Qs1_3
    {
        static void Main()
        {
            /*クラスの基本*/
            Console.WriteLine("【クラスの基本：】");
            //左辺で作成されているのは参照型の変数(つまりポインタ)です。
            //右辺でVector2の実態を作成（メモリに配置）し、そのアドレスを左辺の参照型の変数(ポインタ)に渡している。
            Vector2 v1 = new Vector2();
            Vector2 v2 = new Vector2(2.0f, 2.0f);
            Console.WriteLine("v1:" + v1.OutString());
            Console.WriteLine("v2:" + v2.OutString());
            //publicは外からアクセス可能
            v1.X = 1.0f;
            v1.Y = 1.0f;
            Console.WriteLine("v1:" + v1.OutString());
            //メンバ変数を各インスタンスで使える
            Console.WriteLine("v1(長さ):" + v1.Length());
            Console.WriteLine("v2(長さ):" + v2.Length());


            /*Vector2型が値型でなく、参照型であることの確認*/
            Console.WriteLine("【参照型であることの確認：】");
            //参照型ならば、v1とv2は同じものになる。
            //値型ならば、コピーしてるだけ。
            v1 = v2;
            Console.WriteLine("v1(=直後):" + v1.OutString());
            //参照型なので、v2の値を変更するとv1の値も変わる(変数名が違うだけで同じものなので)
            v2.Y = 1.0f;
            Console.WriteLine("v1(v2変更後):" + v1.OutString());


            /*プロパティを持つクラス*/
            Console.WriteLine("【プロパティを持つクラス：】");
            Enemy ene = new Enemy();
            Console.WriteLine("ene(初期値):" + ene.OutString());
            ene.Hp = 6;
            //Hpが減少するとAtも上昇
            Console.WriteLine("ene(Hp減少):" + ene.OutString());
            //ene.At = 8; Atは読み取り専用で、コメント外すとエラー


            /*自動実装プロパティ*/
            Console.WriteLine("【自動実装プロパティ：】");
            Enemy2 ene2 = new Enemy2();
            Console.WriteLine("ene2(初期値):" + ene2.OutString());
            ene2.Hp = 6;
            Console.WriteLine("ene2(Hp減少):" + ene2.OutString());
            //ene.At = 8; Atは読み取り専用で、コメント外すとエラー

        }

    }

    /*クラスの基本*/
    //クラスは基本的には以下の４つで構成されています。
    //・フィールド(メンバ変数)
    //・コンストラクタ
    //・デストラクタ
    //・メソッド(メンバ関数)
    //ここに関してはC++と同じです。
    //C#のクラスで最も注意すべき点は、
    //C++と違って値型がなく、参照型しかないということです。
    //つまり、*とかつけなくても常にクラス変数はポインタです。
    //例外はありますが、基本的に参照渡ししかできませんので注意しましょう。

    //2次元用のベクトルを作るとします。
    public class Vector2
    {
        //フィールド(メンバ変数)
        public float X;
        public float Y;

        //コンストラクタ
        public Vector2()
        {
            X = 0;
            Y = 0;
        }
        //thisは自分自身のポインタです。引数名と名前が被ったりしたときに使用
        //上記のコンストラクタでは付けてないが、付けた方が良心的。
        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
        //デストラクタ
        ~Vector2()
        {
            //メモリ管理を自分で行うC++では
            //大変便利なデストラクタだが、C#では殆ど役に立たない
            //何故ならC#にはガベージコレクションという機能があり、
            //メモリ管理はそれが行うため、いつデストラクタが呼ばれるか予測不能である。
            //なので、必要になった時のために書き方を知っておく程度でよい。
            //(どーせC++で嫌になるほど書くでしょう)
        }

        //メソッド(メンバ関数)
        //ベクトルの長さ
        public float Length()
        {
            //平方根の計算
            return MathF.Sqrt(X * X + Y * Y);
        }

        //自分の値を文字列にして返す
        public string OutString()
        {
            return "X:" + X.ToString() + ", Y:" + Y.ToString();
        }

    }


    /*プロパティを持つクラス*/
    //C#ではクラスはプロパティを持つことが出来ます。
    //プロパティとは
    //クラス外部から見るとメンバー変数のように振る舞い、
    //クラス内部から見るとメソッドのように振舞うものです。
    //つまり、メンバ変数の値を変えたり、与えたりする際に
    //決められてた行動を起こすことが出来ます。
    //C++ではgetterとかsetterという形でメンバ関数で実装されることが多いです。

    //プロパティくを持つクラスの例
    //Hpが減ると攻撃力上がるエネミーを作成します。
    //コンストラクタやデストラクタは省略できます。
    public class Enemy
    {
        private int _hp = 8;
        private int _at = 8;

        //プロパティ
        public int Hp
        {
            //外部に値を渡すとき
            get { return _hp; }

            //外部から値を受け取るとき(valueが外部から受け取った変数)
            set
            {
                _at += _hp - value;//hpが減ると攻撃力も増加する。
                _hp = value;
            }
        }
        public int At
        {
            get { return _at; }
            //setが無いので、外部から_atを変更する事はできない
        }

        //自分の値を文字列にして返す
        public string OutString()
        {
            return "Hp:" + _hp.ToString() + ", At:" + _at.ToString();
        }
    }


    /*自動実装プロパティ*/
    //プロパティは便利ですが、単に値を保持するだけの場合は面倒です。
    //自動実装プロパティを用いることで、より簡単に記述できます。

    //Hpの増減での攻撃力変化が無いエネミー
    public class Enemy2
    {
        //自動実装プロパティ
        //読み取り、書き込み可
        public int Hp { get; set; } = 8;
        //読み取り可、書き込み不可
        public int At { get; } = 8;

        //自分の値を文字列にして返す
        public string OutString()
        {
            return "Hp:" + Hp.ToString() + ", At:" + At.ToString();
        }
    }
}
