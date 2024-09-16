/*入力*/
string input = Console.ReadLine();
int num = int.Parse(input);

/*while*/
int ans = 0;
int count = 0;
while (count <= num)
{
    ans = ans + count;
    count++;
}
Console.WriteLine("while:0~{0}までの合計は{1}",num,ans);

/*do~while*/
ans = 0;
count = 0;
do
{
    ans = ans + count;
    count++;
} while(count <= num);
Console.WriteLine("do~while:0~{0}までの合計は{1}", num, ans);

/*for*/
ans= 0;
for(int i=0;i<=num;i++)
{
    ans = ans + i;
}
Console.WriteLine("for:0~{0}までの合計は{1}", num, ans);

/*foreach*/
ans=0;
int[] arr = { 1, 2, 3, 4 };
foreach(var n in arr)
{
    ans = ans + n;
}
Console.WriteLine("配列arrの要素数は{0}であり、要素の合計は{1}", arr.Length, ans);