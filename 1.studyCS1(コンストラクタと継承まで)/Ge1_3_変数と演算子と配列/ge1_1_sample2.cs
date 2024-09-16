using System;

/*配列の作成(宣言)*/
int[] arrInt = new int[3];
float[] arrFloat = new float[3];
string[] arrString = new string[3];

/*配列への値の挿入*/
arrInt[0] = 0; arrInt[1] = 1; arrInt[2] = 2;//arrInt[3]はエラーとなる。
arrFloat[0] = 0.0f; arrFloat[1] = 1.1f; arrFloat[2] = 2.2f;
arrString[0] = "zero"; arrString[1] = "one"; arrString[2] = "two";

/*配列作成と同時に中身を入れる*/
int[] arrInt2 = { 0, 1, 2 };
float[] arrFloat2 = { 0.0f, 1.1f, 2.2f, 3.3f };
string[] arrString2 = { "zero", "one", "two", "three", "four" };

/*配列の使用*/
Console.WriteLine("【配列の使用：】");
Console.WriteLine("arrInt: {0},{1},{2}", arrInt[0], arrInt[1], arrInt[2]);
Console.WriteLine("arrFloat: {0},{1},{2}", arrFloat[0], arrFloat[1], arrFloat[2]);
Console.WriteLine("arrString: {0},{1},{2}", arrString[0], arrString[1], arrString[2]);

/*配列を用いた計算*/
Console.WriteLine("【配列を用いた計算：】");
Console.WriteLine("arrInt: {0}", arrInt[0] + arrInt[1] + arrInt[2]);
Console.WriteLine("arrFloat: {0}", arrFloat[0] + arrFloat[1] + arrFloat[2]);
Console.WriteLine("arrString: {0}", arrString[0] + arrString[1] + arrString[2]);

/*配列の要素数*/
Console.WriteLine("【配列の要素数：】");
Console.WriteLine("arrInt2: {0}",arrInt2.Length);
Console.WriteLine("arrFloat2: {0}", arrFloat2.Length);
Console.WriteLine("arrString2: {0}", arrString2.Length);