/*n^mを計算する関数*/
int Pow(int n, int m)
{
    int ans = 1;//掛け算ができるように１を入れておく。

    for (int i = 0; i < m; i++)
    {
        ans *= m;
    }

    return ans;
}

//関数の実行
Console.WriteLine("/*n^mを計算する関数*/");
int ansInt;
ansInt = Pow(3, 3);
Console.WriteLine(ansInt);


/*配列の合計値を出す関数*/
int SumArr(int[] input)
{
    int ans = 0;

    foreach (int temp in input)
    {
        ans += temp;
    }


    return ans;
}

//関数の実行
Console.WriteLine("/*配列の合計値を出す関数*/");
int ans;
int[] input = { 1, 2, 3, 4, 5 };
ans = SumArr(input);
Console.WriteLine(ans);


/*break文*/
Console.WriteLine("/*break文*/");
for (int i=0;i<100;i++)
{
    Console.WriteLine("{0}",i);
    if(i==10)
    {
        break;
    }
}