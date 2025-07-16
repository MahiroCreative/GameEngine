using System;

namespace Qs2_Entry2
{
    internal class Qs2_1
    {
        static void Main(string[] args)
        {
            /*クラス内でのstatic(静的メンバー)*/
            //staticメンバーはインスタンスを生成せずに使える。
            //通常のメンバと違い、クラスそのものが持っており、クラス名から呼び出す。
            //インスタンス毎には作成されない。
            //なので、どこかでstatic変数の値を更新したら、どのインスタンスからアクセスしても更新されている。
            Console.WriteLine("【クラス内でのstatic(静的メンバー)】");
            //インスタンスの作成
            Enemy.CountEnemy();
            Enemy ene = new Enemy();
            Enemy.CountEnemy();
            Enemy ene2 = new Enemy();
            Enemy.CountEnemy();
            Enemy ene3 = new Enemy();
            Enemy.CountEnemy();

            //疑似的にインスタンスを削除
            //クラス変数は参照型でありアドレスが入るのだが、クラス変数そのものは参照ではない。
            //(アドレスを渡しているが、アドレスを渡す箱は複製されている。中身だけ参照でやり取りしている)
            //なので、作成したクラス変数自体を弄りたいときはrefで参照渡しをする。
            //(C++でのポインタと完全に同じように使いたい場合はref)
            //GCの関係で危険な場合が多い(再現性のないエラーが起こる)、乱用はしないように。
            Enemy.deleteEnemy(ref ene);
            Enemy.CountEnemy();
            Enemy.deleteEnemy(ref ene2);
            Enemy.CountEnemy();


            /*staticクラス*/
            Console.WriteLine("【staticクラス】");
            Console.WriteLine("2の8乗:" + Math.Power(2, 8));
            Console.WriteLine("2の8乗:" + Math.Power(2.8f, 8));
        }
    }

    /*クラス内でのstatic(静的メンバー)*/
    //staticが付いたメンバ変数やメンバ関数は、
    //同じクラスから作られた全てのインスタンスで共有している。
    //private または internal である static フィールドを使用する場合は、s_ プレフィックスを使用
    public class Enemy
    {
        private static int s_enemyCount = 0;

        //エネミーが生成される度に数を増やす
        public Enemy() { s_enemyCount++; }

        //現在のエネミーの数を表示
        public static void CountEnemy()
        {
            Console.WriteLine("現在のエネミーの総数は：" + s_enemyCount);
        }

        //C#だとメモリ開放を明示的にやれないので疑似的なものです。
        public static void deleteEnemy(ref Enemy enemy)
        {
            //参照されなくなり、
            //いずれはGC(ガベレージコレクタ)が消してくれる(いつ消してくれるかは分からない)。
            enemy = null;
            s_enemyCount--;
        }
    }

    /*staticクラス*/
    //インスタンスを作成しないことを前提としたクラスです。
    //オブジェクト的なふるまいを必要としない便利な機能をまとめたりするのに使います。
    //(C++ではなく、C言語の構造体に近い)
    //staticクラスではstaticなメンバ以外を定義する事はできません。
    static class Math
    {
        static private int s_itemp = 0;
        static private float s_ftemp = 0;

        //nのm乗の計算
        static public int Power(int n, int m)
        {
            s_itemp = 1;

            for (int i = 0; i < m; i++)
            {
                s_itemp *= n;
            }

            return s_itemp;
        }
        static public float Power(float n, int m)
        {
            s_ftemp = 1.0f;

            for (int i = 0; i < m; i++)
            {
                s_ftemp *= n;
            }

            return s_ftemp;
        }
    }
}
