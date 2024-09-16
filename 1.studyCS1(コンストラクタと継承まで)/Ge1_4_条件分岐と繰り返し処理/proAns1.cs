/*入力*/
string input = Console.ReadLine();
int num = int.Parse(input);

/*条件分岐if~else*/
if(num<3)
{
    Console.WriteLine("3より小さいです。");
}
else if(num<=5)
{
    Console.WriteLine("3~5です。");
}
else
{
    Console.WriteLine("5よりも大きいです。");
}

/*奇数か偶数かのチェック*/
bool flag = ((num % 2) == 1);

/*条件分岐switch文*/
switch(flag)
{
    case true:
        Console.WriteLine("奇数です。");
        break;
    case false:
        Console.WriteLine("偶数です。");
        break;
    default:
        Console.WriteLine("ここには到達できません。");
        break;
}