/*入力*/
string input = Console.ReadLine();//宣言と同時に取得もできる。
int num = int.Parse(input);//同上

/*while文*/
Console.WriteLine("[while文]");
int count = 0;
while(count<num)
{
    Console.WriteLine(count);
    count++;
}

/*do~while文*/
Console.WriteLine("[do~while文]");
count= 0;
do
{
    Console.WriteLine(count);
    count++;
}while(count<num);

/*for文*/
Console.WriteLine("[for文]");
for (int i = 0; i < num; i++)
{
    Console.WriteLine(i);
}

/*foreach文*/
//配列の作成
int[] arr = { 0,1,2,3,4,5};
Console.WriteLine("[foreach文{0,1,2,3,4,5}]");
foreach (var n in arr)
{
    Console.WriteLine(n);
}
