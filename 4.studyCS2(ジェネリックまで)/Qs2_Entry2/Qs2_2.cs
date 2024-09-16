using System;

namespace Qs2_Entry2
{
    internal class Qs2_2
    {
        static void Main(string[] args)
        {
            /*インデクサを持つクラス*/
            Console.WriteLine("【インデクサを持つクラス】");
            EnemyName eneName = new EnemyName();
            eneName[0] = "スライム";
            eneName[1] = "ドラキー";
            eneName[2] = "アントベア";
            for (int i = 0; i < 3; i++)
            {
                //思い出したように使ってますが、
                //+演算子での文字合成はそれなりにコストがかかるため、以下の形が良いです。
                Console.WriteLine("eneName{0}:{1}", i, eneName[i]);
            }


            /*演算子のオーバーロード*/
            Console.WriteLine("【演算子のオーバーロード】");
            Vector2 v1 = new Vector2(1.2f, 1.8f);
            Vector2 v2 = new Vector2(0.6f, 0.6f);
            Vector2 tempV;

            //オーバーロードの確認
            tempV = v1 + v2;
            Console.WriteLine("v1 + v2 : {0}", tempV.OutString());
            tempV = v1 - v2;
            Console.WriteLine("v1 - v2 : {0}", tempV.OutString());
            tempV = v1 * 2.0f;
            Console.WriteLine("v1 * 2 : {0}", tempV.OutString());
            tempV = v1 / 2.0f;
            Console.WriteLine("v1 / 2 : {0}", tempV.OutString());

        }
    }
}


/*インデクサを持つクラス*/
//インスタンスに配列のようなインデックスを付けることができます。
public class EnemyName
{
    private string[] name = new string[100];
    public string this[int i]
    {
        get { return name[i]; }
        set { name[i] = value; }
    }
}


/*演算子のオーバーロード*/
//C++と同じく演算子のオーバーロードが出来ます。
//ただし、C++より制限が多くオーバーロード出来ない演算子があります。
//(詳細はMicrosoftのリファレンスを見てください)
//大体五則演算(+.-.*,/,%)が出来れば良いはずです。
//本来のC#であれば乱用禁止(インテリジェンスにも出ない)ですが、
//ゲーム開発では乱用気味です。
public class Vector2
{
    private float _x = 0;
    private float _y = 0;

    public float X
    {
        get { return _x; }
    }
    public float Y
    {
        get { return _y; }
    }

    public Vector2() { }
    public Vector2(float x, float y)
    {
        this._x = x;
        this._y = y;
    }

    //演算子オーバーロード
    public static Vector2 operator +(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X + right.X, left.Y + right.Y);
    }
    public static Vector2 operator -(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X - right.X, left.Y - right.Y);
    }
    //実数倍
    public static Vector2 operator *(Vector2 left, float right)
    {
        return new Vector2(left.X * right, left.Y * right);
    }
    //実数割り
    public static Vector2 operator /(Vector2 left, float right)
    {
        return new Vector2(left.X / right, left.Y / right);
    }

    //自分の値を文字列にして返す
    public string OutString()
    {
        return "X:" + X.ToString() + ", Y:" + Y.ToString();
    }
}
