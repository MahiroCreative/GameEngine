
////課題１
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine("HelloC#");
//}

////課題2
//Console.Write("整数を入力:");
//int input = int.Parse(Console.ReadLine());

//for (int i = 1; i <= input; i++)
//{
//    //1から順番に割っていって、割り切れたら約数
//    if ((input % i) == 0)
//    {
//        Console.WriteLine(i);
//    }
//}

////課題3
//int a = 1;
//do
//{
//    Console.WriteLine("a={0}", a);
//    a++;
//} while (a <= 10);

////課題4
//int[] a = new int[10];
////1~10の値を入れる
//for (int i = 0; i < 10; i++)
//{
//    a[i] = i + 1;
//}
////表示
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine("a[{0}]={1}", i, a[i]);
//}

////課題5
//void sankaku(int num)
//{
//    //三角形ごとのループ
//    //三角形が、何行かを決めているループ
//    for (int i = 0; i < num; i++)
//    {
//        //三角形それぞれの、行ごとのループ
//        //つまり、1行の中に何回$を表示させるかを決めてるループ
//        for (int s = 0; s <= i; s++)
//        {
//            Console.Write("$");
//        }

//        Console.WriteLine("");
//    }
//    Console.WriteLine("");
//}

//sankaku(3);
//sankaku(4);
//sankaku(5);

//課題6
void kuku(int num)
{
    for(int i=1;i<=9;i++)
    {
        Console.Write("{0},",i*num);
    }
    Console.WriteLine("");
}

kuku(1);
kuku(2);
kuku(3);
kuku(4);
kuku(5);
kuku(6);
kuku(7);
kuku(8);
kuku(9);