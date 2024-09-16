using System;

/*変数の作成(宣言)*/
int inum;//整数小
long lnum;//整数大
float fnum;//実数小
double dnum;//実数大
bool flag;//ブール代数(True or False しかない)
string str;
//ans用
int ians;
float fans;
string sans;
bool bans;

/*変数への代入*/
inum = 8;
lnum = 8888888888888;
fnum = 8.8f;//実数は何も付けないとdoubleだと判断されるので、fを付ける。
dnum = 8.8;
flag = false;
str = "Hello";

/*五則演算*/
Console.WriteLine("【五則演算:】");
//[+]:足し算
ians = inum + inum;
fans = fnum + fnum;
Console.WriteLine(ians);
Console.WriteLine(fans);
//[-]:引き算
ians = inum - 2;
fans = fnum - 2.2f;
Console.WriteLine(ians);
Console.WriteLine(fans);
//[*]:掛け算
ians = inum * inum;
fans = fnum * fnum;
Console.WriteLine(ians);
Console.WriteLine(fans);
//[/]:割り算
ians = inum / 2;
fans = fnum / 2.2f;
Console.WriteLine(ians);
Console.WriteLine(fans);
//[%]:余りの計算
ians = inum % 3;
fans = fnum % 3;
Console.WriteLine(ians);
Console.WriteLine(fans);

/*条件判定*/
int left = 8, right = 8;
Console.WriteLine("【条件判定:】");
//[==]：左辺と右辺が一致してればTrue
bans = (8 == 8);//()無くてもイイですが、普通付けます。
Console.WriteLine(bans);
//[!=]：左辺と右辺が一致してなければFalse
bans = (8 != 8);
Console.WriteLine(bans);
//[==]：変数でも可
bans = (left == right);
Console.WriteLine(bans);
//[!=]：変数でも可
bans = (left != right);
Console.WriteLine(bans);

/*文字列*/
Console.WriteLine("【文字列:】");
Console.WriteLine(str);
Console.WriteLine(str + "World!");
sans = str + "Unity!";
Console.WriteLine(sans);
Console.WriteLine("{0}World!", str);
Console.WriteLine("整数：{0}実数：{1}", inum, fnum);

/*キャスト*/
string s = "8";
Console.WriteLine("【キャスト変換:】");
ians = int.Parse(s);//stringからintへ
fans = float.Parse(s);//stringからfloatへ
sans = inum.ToString();//intからstringへ
sans = fnum.ToString();//floatからstringへ
ians = (int)fnum;//floatからintへ
fans = (float)inum;//intからfloatへ
Console.WriteLine("キャストは正常に行われました。");

/*文字の入力*/
string input;
Console.WriteLine("【文字の入力:】");
input = Console.ReadLine();
Console.WriteLine("文字列として{0}が入力されました。", input);
ians = int.Parse(input) + 1;//キャストして足す。
Console.WriteLine("入力値に1足すと{0}です。", ians);