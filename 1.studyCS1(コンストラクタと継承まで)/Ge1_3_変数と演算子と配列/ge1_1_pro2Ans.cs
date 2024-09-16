using System;

/*演習2*/
//配列の宣言
int[] arrInt = new int[2];
float[] arrFloat = { 0.4f, 0.8f, 1.2f };
string[] arrString = { "one", "two", "three", " " };

//値の挿入
arrInt[0] = 0; arrInt[1] = 1;
arrFloat[2] = 0.6f;
arrString[1] = "heyhey";

//表示
Console.WriteLine("arrInt: {0} {1}", arrInt[0], arrInt[1]);
Console.WriteLine("arrFloat: {0} {1} {2}", arrFloat[0], arrFloat[1], arrFloat[2]);
Console.WriteLine("arrString: {0} {1} {2} {3}", arrString[0], arrString[1], arrString[2], arrString[3]);