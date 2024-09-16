/*問題2*/
//入力された値に含まれる素数を全て表示し、
//その合計を出力するプログラムを作成せよ。

//変数
string input;
int num;
int sum = 0;//合計値
bool judge = true;

/*入力*/
do
{
    Console.WriteLine("0以上の自然数を入力してください。");
    input = Console.ReadLine();//宣言と同時に取得もできる。
    num = int.Parse(input);//同上

} while (num < 1);

//素数の合計の計算
for (int i = 1; i <= num; i++)//自分自身が素数の場合は足すためにi<=num
{
    //素数の判定
    for (int s = 2; s < i; s++)//自分自身では割らないようにs<i
    {
        //1と自分自身以外で割り切れたら素数ではない
        if (i % s == 0)
        {
            judge = false;
        }

    }

    //素数なら足す
    if (judge == true)
    {
        //ただし、1は素数ではない
        if (i != 1)
        {
            Console.WriteLine("{0}", i);
            sum += i;
        }

    }

    //bool値の初期化
    judge = true;
}

//改行
Console.WriteLine();

//合計表示
if (sum == 0)
{
    Console.WriteLine("入力された値の中には素数はありません。");
}
else
{
    Console.WriteLine("素数の合計は{0}", sum);
}