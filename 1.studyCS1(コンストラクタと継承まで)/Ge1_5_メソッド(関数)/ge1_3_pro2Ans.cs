/*課題１*/
int getPos (int firstX,int firstSpeed,int accel,int second)
{
    int pos = 0;

    //物理で習う式のまま
    pos = firstX + firstSpeed * second + accel * second * second / 2;

    return pos;
}

/*入力1*/
Console.WriteLine("初期位置：");
int firstX = int.Parse(Console.ReadLine());
Console.WriteLine("初速度：");
int firstSpeed = int.Parse(Console.ReadLine());
Console.WriteLine("加速度：");
int accel = int.Parse(Console.ReadLine());
Console.WriteLine("秒数：");
int second  = int.Parse(Console.ReadLine());

int ans = getPos(firstX,firstSpeed,accel,second);

Console.WriteLine("物体の位置:{0}",ans);
