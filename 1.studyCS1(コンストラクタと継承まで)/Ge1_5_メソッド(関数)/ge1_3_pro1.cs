/*問題1*/
//素数を判定する関数
using System.IO.Pipes;

bool CheckPrime(int n)
{
    bool ans = true;

    //素数の定義：
    //2以上の自然数で、正の約数が1と自分自身のみであるもののこと。
    //なので、2~(n-1)の数全てで割り切れなければよい。
    for (int i = 2; i <= n - 1; i++)
    {
        /*自分で書こう！*/
    }

    return ans;
}
//関数の実行
Console.WriteLine(CheckPrime(17));
Console.WriteLine(CheckPrime(27));
Console.WriteLine(CheckPrime(3511));

/*問題2*/
int Gcd(int n, int m)
{
    int ans = 0;
    int max = 0;

    //最大公約数の定義：
    //2つ以上の正の整数に共通な約数（公約数）のうち、
    //最大のものを最大公約数といいます。
    //例：18と12の公約数は1,2,3,6で、6が最大公約数。

    //余りが0になる計算は入力値の小さい方までで良い。
    if (n <= m)
    {
        /*自分で書こう！*/
    }
    else
    {
        /*自分で書こう！*/
    }

    //1~maxまで順に割っていき、
    //両社とも余りが0になる最大値が最大公約数
    for (int i = 1; i <= max; i++)
    {
        /*自分で書こう！*/
    }

    return ans;
}
//関数の実行
Console.WriteLine(Gcd(18, 12));
Console.WriteLine(Gcd(180, 127));
Console.WriteLine(Gcd(80, 64));