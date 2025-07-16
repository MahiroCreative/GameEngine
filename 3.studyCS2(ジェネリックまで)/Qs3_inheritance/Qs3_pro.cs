using System;
using System.Security.Cryptography.X509Certificates;

/*問題1*/
//基本クラスBaseVector継承した派生クラスVector3を作成せよ。
//それぞれの機能に関しては提示した実行結果から予想して、実装せよ。

/*問題2*/
//抽象クラスAbstVectorを継承した派生クラスAbVector3を作成せよ。
//それぞれの機能に関しては提示した実行結果から予想して、実装せよ。

/*問題3*/
//複数のinterfaceから派生クラスGameObjectを作成せよ。
//それぞれの機能に関しては提示した実行結果から予想して、実装せよ。


namespace Qs3_inheritance
{
    internal class Qs3_pro
    {
        static void Main(string[] args)
        {
            /*問題１*/
            Console.WriteLine("【問題１】");
            BaseVector v1 = new Vector3(0.5f, 1.5f, 2.5f);
            Vector3 v2 = new Vector3(1.5f, 2.5f, 3.5f);
            //ポリモーフィズムとoverrideを確認
            v1.Show();
            //newキーワードの確認
            v1.Count();
            v2.Count();
            //長さの計算
            Console.WriteLine("v3の長さ:{0}", v1.GetMagnitude());
            Console.WriteLine("v4の長さ:{0}", v2.GetMagnitude());

            /*問題2*/
            Console.WriteLine("【問題２】");
            AbVector3 av = new AbVector3();
            av.X = 1.2f;
            av.Y = 1.3f;
            av.Z = 0;
            av.Show();
            Console.WriteLine(av.GetMgunitude());

            /*問題3*/
            Console.WriteLine("【問題３】");
            GameObject gameObject = new GameObject();
            gameObject.X = 2.7f;
            gameObject.Y = 2.4f;
            gameObject.X = 3.2f;
            gameObject.FileName = "Slime.png";
            gameObject.ShowPos();
            gameObject.ShowFileName(); ;
            gameObject.MovePos();
        }
    }

    //基本クラスBaseVector
    //Qs4_3_3で作成したものを拡張している。
    public class BaseVector
    {
        protected float X { get; private set; }
        protected float Y { get; private set; }
        protected float Z { get; private set; }
        //static.
        protected static int Num { get; private set; }

        public BaseVector() { X = 0; Y = 0; Z = 0; Num++; }
        public BaseVector(float x, float y) : this() { X = x; Y = y; }
        public BaseVector(float x, float y, float z) : this() { X = x; Y = y; Z = z; }
        public BaseVector(BaseVector v) : this() { X = v.X; Y = v.Y; Z = v.Z; }

        //method.
        public virtual void Show()
        {
            Console.WriteLine("x:" + X);
        }
        public virtual float GetMagnitude()
        {
            float ans = 0;
            //何もしない
            return ans;
        }
        public void Count()
        {
            Console.WriteLine("BaseVectorのインスタンス数は:{0}", Num);
        }
    }

    //抽象クラス
    abstract class AbstVector
    {
        abstract public float X { get; set; }
        abstract public float Y { get; set; }
        abstract public float Z { get; set; }

        //method.
        abstract public void Show();
        abstract public float GetMgunitude();
    }

    //interface1
    interface Position
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        void ShowPos();
    }
    //interface2
    interface Grafic
    {
        public string FileName { get; set; }
        void ShowFileName();
    }
    //interface3
    interface Move
    {
        void MovePos();
    }
}
