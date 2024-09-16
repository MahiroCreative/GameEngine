
/*if文*/
Console.WriteLine("[if文]");
//入力
string input = Console.ReadLine();//宣言と同時に取得もできる。
int num = int.Parse(input);//同上

//比較演算子6種
if (num == 3)
{
    Console.WriteLine("input is 3");
}
if (num != 3)
{
    Console.WriteLine("input is not 3");
}
if (num > 3)
{
    Console.WriteLine("input is bigger 3");
}
if (num < 3)
{
    Console.WriteLine("input is smaller 3");
}
if (num >= 3)
{
    Console.WriteLine("input is over 3");
}
if (num <= 3)
{
    Console.WriteLine("input is under 3");
}

/*if~elseif~else文*/
Console.WriteLine("[if~elseif~else文]");
//入力
input = Console.ReadLine();//宣言と同時に取得もできる。
num = int.Parse(input);//同上

//条件分岐
if (num < 3)
{
    Console.WriteLine("input is smaller 3");
}
else if (num > 3)
{
    Console.WriteLine("input is bigger 3");
}
else
{
    Console.WriteLine("input is 3");
}

/*swtich文*/
Console.WriteLine("[switch文]");
//入力
input = Console.ReadLine();//宣言と同時に取得もできる。
num = int.Parse(input);//同上

//条件分岐
switch (num)
{
    case 0:
    case 1:
    case 2:
        Console.WriteLine("input is 0~2");
        break;
    case 3:
        Console.WriteLine("input is 3");
        break;
    default:
        Console.WriteLine("input is bigger 3");
        break;
}

/*[&&]カツ、と、[||]オア*/
Console.WriteLine("[&&]カツ、と、[||]オア");
//入力
input = Console.ReadLine();//宣言と同時に取得もできる。
num = int.Parse(input);//同上

//条件分岐
if (num>2 && num<4)
{
    Console.WriteLine("input は2以上かつ4以下なので、3である。");
}
if(num<2 || num>8 )
{
    Console.WriteLine("input は2より小さいか8より大きいので、2~8ではない。");
}