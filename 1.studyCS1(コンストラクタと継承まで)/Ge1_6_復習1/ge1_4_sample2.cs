//【関数(メソッド)の作成】
//関数は引数を渡し、返り値を得る
//例えば、足し算をする関数Aがあるとすると、
//Aに引数：１,２を渡せば、返り値：３を得る
//というような事である。
//【以下、文法】
//返り値の型　関数名(引数の型 引数名){処理}
//【文法終了】
//整数の足し算を行う関数
int IAdd(int a, int b)
{
    int ans;
    ans = a + b;
    return ans;
}
//整数の引き算を行う関数
int ISub(int a, int b)
{
    int ans;
    ans = a - b;
    return ans;
}
//実数の足し算
double DAdd(double a, double b)
{
    double ans;
    ans = a + b;
    return ans;
}
//実数の引き算
double DSub(double a, double b)
{
    double ans;
    ans = a - b;
    return ans;
}
//文字列の足し算
string SAdd(string a, string b)
{
    string ans;
    ans = a + b;
    return ans;
}
//配列の値の合計
int ASUM(int[] a)
{
    int ans = 0;
    //forでも書けるが、foreachだと超楽
    foreach (int s in a)
    {
        ans += s;
    }
    return ans;
}

//【関数の実行】
int i_kaerichi;
double d_kaerichi;
string s_kaerichi;
//IADD
i_kaerichi = IAdd(1, 2);//Addの処理でreturnした結果(ans)をkaerichiに入れてる
Console.WriteLine(i_kaerichi);
//ISub
d_kaerichi = ISub(2, 1);
Console.WriteLine(d_kaerichi);
//DADD
d_kaerichi = DAdd(1.24, 2.4);//Addの処理でreturnした結果(ans)をkaerichiに入れてる
Console.WriteLine(d_kaerichi);
//DSub
d_kaerichi = DSub(2.45, 0.43);
Console.WriteLine(d_kaerichi);
//SAdd
s_kaerichi = SAdd("age", "Age");
Console.WriteLine(s_kaerichi);
//ASUM
int[] arr = { 1, 2, 3 };
i_kaerichi = ASUM(arr);
Console.WriteLine(i_kaerichi);
