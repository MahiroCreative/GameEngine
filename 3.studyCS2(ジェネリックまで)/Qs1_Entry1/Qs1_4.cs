using System;


namespace Qs1_Entry1
{
    /*構造体*/
    //構造体は参照型ではなく、値型である。
    //C#において、intやfloatなどの値型の型は
    //enum(列挙型)を除き全て構造体で作られている。
    //だからフィールド(メンバ変数)とかメソッド（メンバ関数）とか持つ。
    //例：int.Parse(), 配列名.Length　など。

    //・使いどころ
    //参照型の機能が必要ない場合、クラスより構造体として定義した方が効率的です。
    //同じ機能のクラスと構造体を100万個ずつインスタンス化した場合、
    //単純にインスタンス化するだけならクラスが約100msに対して構造体では30msと処理時間が短くなります。
    //例えば3次元の点座標を大量に扱う（ゲームの大量ポップする雑魚キャラみたいな）場合は構造体を用いた方が効率的です。

    //・構造体が出来ないこと
    //継承・フィールド初期化子の使用・デフォルトコンストラクタ（引数無し）の定義・デストラクタの定義
    //(※Main()内での作成と実行もできない)

    internal class Qs1_4
    {
        static void Main()
        {
            //Enemyの作成
            Enemy enemy;
            //変数ごとに初期化
            enemy.X = 1;
            enemy.Y = 2;
            enemy.Z = 3;
            Console.WriteLine("【enemyの確認：】");
            Console.WriteLine("x:" + enemy.X + ", y:" + enemy.Y + ", z:" + enemy.Z);
            Console.WriteLine("AllAdd:" + enemy.AllAdd());

            //引数付きコンストラクタを用いて一括で初期化する。
            Enemy enemy2 = new Enemy(2, 3, 4);
            Console.WriteLine("【enemy2の確認：】");
            Console.WriteLine("x:" + enemy2.X + ", y:" + enemy2.Y + ", z:" + enemy2.Z);
            Console.WriteLine("AllAdd:" + enemy2.AllAdd());

            //クラスと違い参照型（ポインタを扱う型）ではないので、
            //参照型のようにアドレスを渡すことができない。
            Enemy enemy3 = enemy2;//enemy2をenemy3にコピーして渡している。
            Console.WriteLine("【値渡しであることの確認：】");
            //実行結果を確認すると、enemy2の値は変わっていない事が分かる。
            //であるので、構造体は参照型でなく値型であると分かる。
            Console.WriteLine("enemy3(初期化前):" + " x:" + enemy3.X + ", y:" + enemy3.Y + ", z:" + enemy3.Z);
            //初期化
            enemy3.X = 0;
            enemy3.Y = 0;
            enemy3.Z = 0;
            Console.WriteLine("enemy3:" + " x:" + enemy3.X + ", y:" + enemy3.Y + ", z:" + enemy3.Z);
            Console.WriteLine("enemy2:" + " x:" + enemy2.X + ", y:" + enemy2.Y + ", z:" + enemy2.Z);


            /*ここでのポイント！*/
            //・構造体はシンプルなクラスのようなもの
            //・単純にインスタンスを沢山作成するだけなら、構造体のほうが倍以上高速
            //・ただし、構造体は値型(値型はそのものを渡せせず、コピーするしかない)
            //・多様なメソッドに渡して処理、というような操作をするときは遅くなる（毎回コピーするため）
            //・単純な値の出し入れを繰り返すなどなら構造体
            //・変数そのものをどんどん渡していくような処理(参照をする処理)なら、クラス


            /*構造体か？　クラスか？　の例*/
            //このような処理なら、構造体
            Enemy enemy4 = new Enemy(2, 3, 4);
            int temp = 0;
            //値を出し入れしてるだけ。エネミーの値だけを渡してるので軽い。
            //クラスで同じことをする場合より早い。
            enemy4.X = temp;
            temp = enemy4.Y;
            temp = 0;
            enemy4.Z = temp;

            //このような処理なら、クラス
            Enemy tempEnemy;
            //tempEnemyに各エネミー全体が毎回コピーされてて重い
            //クラスなら、この処理はアドレスを渡すだけで済ませられる。
            tempEnemy = enemy;
            tempEnemy = enemy2;
            tempEnemy = enemy3;
            tempEnemy = enemy4;

        }

        /*大量ポップの雑魚を構造体で作成*/
        public struct Enemy
        {
            public int X;
            public int Y;
            public int Z;
            //public int z = 1;//フィールド初期化子は使えない

            //コンストラクタの作成
            public Enemy(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            //メソッドの作成
            public float AllAdd()
            {
                return X + Y + Z;
            }
        }
    }
}
