using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ge1_5_ClassStruct
{
    internal class ge1_5_pro1
    {
        static void Main(string[] args)
        {
            //インスタンスの作成
            User u1 = new User();
            User u2 = new User();
            //代入
            u1.name = "tanaka";
            u1.age = 18;
            u1.score = 88.2f;
            u2.name = "sato";
            u2.age = 20;
            u2.score = 78.2f;
            //確認
            u1.Show();
            u2.Show();

        }

        class User
        {
            public string name = "";
            public int age;
            public float score;

            public void Show()
            {
                Console.WriteLine("name:{0}, age:{1}, score:{2} ", name, age, score);
            }

        }
    }
}
