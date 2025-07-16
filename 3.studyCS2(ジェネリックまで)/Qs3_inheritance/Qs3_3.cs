using System;

namespace Qs3_inheritance
{
    internal class Qs3_3
    {
        static void Main(string[] args)
        {
            /*ポリモーフィズム*/
            //Vector型の変数でVector2とVector3のインスタンスを扱える事が分かる。
            //オーバーライドしておけば、派生クラスで定義したメンバも使用できる。
            Vector v1 = new Vector();
            Vector v2 = new Vector2();
            Vector v3 = new Vector3();

            //継承の確認
            Console.WriteLine("【継承の確認】");
            v1.Check();
            v2.Check();
            v3.Check();

            //オーバーロード
            Console.WriteLine("【オーバーロードの確認】");
            v1 = new Vector2(1, 2);
            v2 = new Vector2(v1);
            v3 = new Vector2(v2);
            v1.Show();
            v2.Show();
            v3.Show();

            //オーバーライド
            Console.WriteLine("【オーバーライドの確認】");
            v1 = new Vector(1, 2);
            v2 = new Vector2(v1);
            v3 = new Vector3(v2);
            v1.Show();
            v2.Show();
            v3.Show();

        }
    }

    /*ポリモーフィズム*/
    //継承・オーバーロード・オーバーライドなどを用いて、
    //同じ名称でも違った機能を持たせる事である。 
    //ゲームにおいては似たような名前で別の機能を持つオブジェクトが必要になる。
    //(スライムでもスライムの種類によって動きが微妙に違うが、それぞれのために別々に実装する作るのは困難)
    //口頭で説明するのはこれ以上は困難なので、実戦で使いこなして感じていって欲しい。
    public class Vector
    {
        protected float X { get; private set; }
        protected float Y { get; private set; }
        protected float Z { get; private set; }

        public Vector() { X = 0; Y = 0; Z = 0; }
        public Vector(float x, float y) : this() { X = x; Y = y; }
        public Vector(float x, float y, float z) : this() { X = x; Y = y; Z = z; }
        public Vector(Vector v) : this() { X = v.X; Y = v.Y; Z = v.Z; }

        public virtual void Show()
        {
            Console.WriteLine("x:" + X);
        }
        public void Check()
        {
            Console.WriteLine("継承されてます。");
        }

    }
    public class Vector2 : Vector
    {
        public Vector2() : base() { }
        public Vector2(float x, float y) : base(x, y) { }
        public Vector2(Vector v) : base(v) { }

        public override void Show()
        {
            Console.WriteLine("x:" + this.X + ",y:" + this.Y);
        }
    }
    public class Vector3 : Vector
    {
        public Vector3() : base() { }
        public Vector3(float x, float y, float z) : base(x, y, z) { }
        public Vector3(Vector v) : base(v) { }

        public override void Show()
        {
            Console.WriteLine("x:" + this.X + ",y:" + this.Y + ",z:" + this.Z);
        }
    }
}
