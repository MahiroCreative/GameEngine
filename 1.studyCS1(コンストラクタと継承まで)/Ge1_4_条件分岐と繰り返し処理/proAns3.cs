
string input;
int num;

/*入力*/
do
{
    Console.WriteLine("0以上の自然数を入力してください");
    input = Console.ReadLine();
    num = int.Parse(input);

}while (num < 1);

/*計算*/
int count = 2;//カウンタ変数
bool flag = true;

//与えられた入力値まで毎回割って、
//余りが0になる数が一度もなかったら、素数。
while (count < num)
{
    //与えられた入力値まで毎回割って、
    //num % count == 0;//tureなら、割れてるので素数じゃない

    if(num % count == 0)
    {
        //素数じゃない
        flag = false;
    }

    //カウンタの更新
    count++; 
}

/*1は素数じゃないとする*/
if(num==1)
{
    flag = false;
}

/*結果*/
if(flag == true)
{
    Console.WriteLine("入力された値は素数です。");
}
else
{
    Console.WriteLine("入力された値は素数ではない。");
}