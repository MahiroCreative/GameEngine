using System;

/*演習1*/
//変数の宣言
int num1, num2, ans;
string str;
bool flag;
num1 = 8;
num2 = 3;
//表示
Console.WriteLine("【五則演算の表示】");
ans = num1 + num2;
Console.WriteLine("num1 + num2: {0}", ans);
ans = num1 - num2;
Console.WriteLine("num1 - num2: {0}", ans);
ans = num1 * num2;
Console.WriteLine("num1 * num2: {0}", ans);
ans = num1 / num2;
Console.WriteLine("num1 / num2: {0}", ans);
ans = num1 % num2;
Console.WriteLine("num1 % num2: {0}", ans);
//入力
Console.WriteLine("【5を入力して下さい：】");
str = Console.ReadLine();
flag = (str=="5");
Console.WriteLine("入力された値が5であればTrue,違えばFlaseが出力されます。： {0}",flag);


