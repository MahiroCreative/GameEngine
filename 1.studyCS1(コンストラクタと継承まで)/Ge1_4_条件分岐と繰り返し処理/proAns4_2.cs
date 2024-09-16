
//変数
string input;
int num;
int sum = 0;//合計値
int count = 2;
bool flag = true;

/*入力*/
do
{
    Console.WriteLine("0以上の自然数を入力してください。");
    input = Console.ReadLine();//宣言と同時に取得もできる。
    num = int.Parse(input);//同上

} while (num < 1);

//与えられた値まで１から順に計算させる処理
for (int i=2;i<=num;i++)
{

    //値が素数か判定する処理
    while (count < i)
    {
        //与えられた入力値まで毎回割って、
        //num % count == 0;//tureなら、割れてるので素数じゃない

        if (i % count == 0)
        {
            //素数じゃない
            flag = false;

        }

        //カウンタの更新
        count++;
    }
    //素数だったら、表示
    if(flag)
    {
        Console.WriteLine("{0}",i);
        sum = sum + i;
    }

    //カウンタの初期化
    count = 2;
    //フラグの初期化
    flag = true;

}

//素数の合計の表示
Console.WriteLine("素数の合計の表示:{0}",sum);






/*
while()
{
    //値が素数か判定する処理
    while()
    {

    }
}*/
