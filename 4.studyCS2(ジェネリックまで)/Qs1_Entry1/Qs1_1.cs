using System;

namespace Qs1_Entry1
{
    internal class Qs1_1
    {
        static void Main()
        {
            /*コーディング規約に関して(Main()関数内)*/
            //・変数名：キャメルケース(例:temp string なら tempString)
            //・関数名：パスカルケース(例:show string なら ShowString)

            /*変数の宣言と初期化*/
            //C++と同じように宣言と同時に初期化を行えます。
            //初期化せずに使うこともできますが、環境によって入る値が変化する場合があるので
            //初期化することをお勧めします。

            //int型(小：-2147483648　～　2147483647, ±10桁)
            int ansInt = 0, tempInt = 0;
            //long型(大：-922337203685477508　～　922337203685477507, ±18桁)
            long ansLong = 0, tempLong = 0;
            //float型(±1.5 x 10^−45 ～ ±3.4 x 10^38,　-6~9桁）
            float ansFloat = 0, tempFloat = 0;
            //double型(±5.0 × 10^−324 ～ ±1.7 × 10^308, -15~17桁）
            double ansDouble = 0, tempDouble = 0;
            //decimal型(10進数の実数,±1.0 x 10^28 から ±7.9228 x 10^28,　±28桁)
            decimal ansDecimal = 0, tempDecimal = 0;
            //char型(小：一文字だけ）
            char ansChar = '\0', tempChar = '\0';
            //string型(大：複数文字）
            string ansString = "", tempString = "";


            /*変数の代入*/
            //基本的にC++と同じ
            ansInt = 1;
            ansLong = 1L;
            ansFloat = 1.0f;
            ansDouble = 1.0d;
            ansDecimal = 1.0m;
            ansChar = 'あ';
            ansString = "あいうえお";


            /*データの表示(基本)*/
            Console.WriteLine("【データの表示(基本)：】");
            //改行して表示
            Console.WriteLine("hey");
            //改行せずに表示
            Console.Write("hey1");
            Console.Write("hey2");
            Console.WriteLine("");//改行用


            /*データの表示(変数の表示)*/
            //{引数の番号}で、指定した引数が表示される。
            Console.WriteLine("【データの表示(変数の表示)：】");
            //変数ansIntの中身が表示される
            Console.WriteLine(ansInt);
            //変数ansIntが{0}に、変数ansLongが{1}に表示される
            Console.WriteLine("{0},{1}", ansInt, ansLong);
            //変数ansCharが{0}に、変数ansStringが{1}に表示される
            Console.WriteLine("あばば　{0}　あばべ　{1}", ansInt, ansString);
            //a+bの計算結果が表示される（つまり計算結果を表示できる）
            Console.WriteLine(ansInt + ansLong);


            /*基本の計算*/
            //計算(整数でやるが、実数も同じ)
            int ans = 0, val1 = 9, val2 = 2;
            Console.WriteLine("【基本の計算：】");
            //足し算
            ans = val1 + val2;
            Console.WriteLine("{0}+{1}={2}", val1, val2, ans);
            //引き算
            ans = val1 - val2;
            Console.WriteLine("{0}-{1}={2}", val1, val2, ans);
            //掛け算
            ans = val1 * val2;
            Console.WriteLine("{0}*{1}={2}", val1, val2, ans);
            //割り算
            ans = val1 / val2;
            Console.WriteLine("{0}/{1}={2}", val1, val2, ans);
            //余りの計算
            ans = val1 % val2;
            Console.WriteLine("{0}%{1}={2}", val1, val2, ans);


            /*配列の作成*/
            //配列の作成(整数でやるが、実数も同じ)
            int[] ar;
            //配列の初期化(要素５の配列を作成)
            ar = new int[5];
            //配列の宣言と初期化を同時に行う
            //中身の無い配列をつくる場合
            int[] ar2 = new int[5];
            //中身も同時に作る場合
            int[] ar3 = { 1, 2, 3, 4, 5 };


            /*配列の使い方*/
            Console.WriteLine("【配列の使い方：】");
            Console.WriteLine("a[0]:{0}, a[1]:{1}, a[2]:{2}", ar[0], ar[1], ar[2]);
            Console.WriteLine("配列の要素数(サイズ)：{0}", ar.Length);


            /*条件分岐(if文)*/
            Console.WriteLine("【条件分岐(if分)：】");
            Console.Write("数値を入力して下さい:");
            //int.Parse()は文字列を整数に変換するメソッド
            int num = int.Parse(Console.ReadLine());
            if (num == 0)
            {
                Console.WriteLine("入力された値は0です。");
            }
            else if (num == 1)
            {
                Console.WriteLine("入力された値は1です。");
            }
            else
            {
                Console.WriteLine("入力された値:{0}", num);
            }


            /*条件分岐(switch文)*/
            Console.WriteLine("【条件分岐(switch文)：】");
            Console.Write("数値を入力して下さい(0~3):");
            num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 0:
                case 1:
                case 2:
                    Console.WriteLine("0~2です。");
                    break;
                case 3:
                    Console.WriteLine("3です。");
                    break;
                default:
                    Console.WriteLine("0~3以外です。");
                    break;

            }


            /*繰り返し(while文)*/
            Console.WriteLine("【繰り返し(while文)：】");
            int count = 0;//ループカウンタとして作成
            while (count < 5)//5回ループ
            {
                count++;
                Console.WriteLine("while:{0}回目", count);
            }


            /*繰り返し(do~while文)*/
            Console.WriteLine("【繰り返し(do~while文)：】");
            int count2 = 0;//ループカウンタとして作成
            do
            {
                count2++;
                Console.WriteLine("do~while:{0}回目", count2);
            } while (count2 < 5);



            /*繰り返し(for文)*/
            Console.WriteLine("【繰り返し(for文)：】");
            for (int s = 0; s < 5; s++)
            {
                Console.WriteLine("for:{0}回目", s);
            }


            /*繰り返し(foreach文1)*/
            Console.WriteLine("【繰り返し(foreach文1)：】");
            //C++の範囲for文のようなものだが、それよもずっと便利
            int[] ar4 = { 1, 2, 3 };
            //ar4の要素数は3なので3周する。
            //varはvariable型であり、=の右辺の型が決まった時に型が決まる。
            //例：var i= 1; と入れればiは整数型。その後に実数を入れることはできない。
            //何でも入力できる変数ではないので、注意(javascriptとかphpとは違う)。
            foreach (var v in ar4)
            {
                //v: 1週目はar4[0], 2週目はar4[1], 3週目はar4[2]
                Console.WriteLine("foreach1:{0}", v);
            }


            /*繰り返し(foreach文2)*/
            Console.WriteLine("【繰り返し(foreach文2)：】");
            int[,] ar5 = { { 1, 2, 3 }, { 2, 4, 6 } };
            foreach (var v in ar5)
            {
                Console.WriteLine("foreach2:{0}", v);
            }


            /*繰り返し(foreach文2)*/
            Console.WriteLine("【繰り返し(foreach文3)：】");
            string tempStr = "春夏秋冬";
            //stringを一文字ずつcharにしてる(inは要素を群として判断してる)
            foreach (var v in tempStr)
            {
                Console.WriteLine("foreach3:{0}", v);
            }

        }
    }
}
