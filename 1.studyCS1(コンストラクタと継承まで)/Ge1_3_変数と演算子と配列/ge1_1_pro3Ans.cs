using System;

string input;
int num1, num2;

/*入力*/
//入力1
Console.WriteLine("【一つ目の値の入力：】");
input = Console.ReadLine();
num1 = int.Parse(input);
Console.WriteLine((num1 % 2) == 1);
//入力2
Console.WriteLine("【二つ目の値の入力：】");
input = Console.ReadLine();
num2 = int.Parse(input);
Console.WriteLine((num2 % 2) == 1);

/*計算と出力*/
Console.WriteLine("【計算と出力：】");
Console.WriteLine(num1 + num2);
Console.WriteLine(num1 - num2);
Console.WriteLine(num1 * num2);
Console.WriteLine(num1 / num2);
Console.WriteLine(num1 % num2);