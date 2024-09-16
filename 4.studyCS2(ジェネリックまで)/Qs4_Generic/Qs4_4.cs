using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qs4_Generic
{
    internal class Qs4_4
    {
        static void Main(string[] args)
        {
            //データベースの作成
            Dictionary<int, userData<string,int,int,int>> userList = new Dictionary<int, userData<string, int, int, int>>();
            //ユーザ登録
            userData<string, int, int, int> temp = new userData<string, int, int, int>();
            temp.Data1 = "one"; temp.Data2 = 1; temp.Data3 = 2; temp.Data4 = 3;
            userList.Add(1, temp);

            temp = new userData<string, int, int, int>();
            temp.Data1 = "two"; temp.Data2 = 2; temp.Data3 = 3; temp.Data4 = 4;
            userList.Add(2, temp);

            temp = new userData<string, int, int, int>();
            temp.Data1 = "three"; temp.Data2 = 3; temp.Data3 = 4; temp.Data4 = 5;
            userList.Add(3, temp);


            //確認
            foreach (var item in userList) 
            {
                Console.WriteLine("{0},{1},{2},{3},{4}",item.Key,item.Value.Data1, item.Value.Data2, item.Value.Data3, item.Value.Data4);
            }
            
        }
    }

    /*DB風ジェネリックの作成*/
    public class userData<T1,T2,T3,T4>
    {
        public T1 Data1 { get; set; }
        public T2 Data2 { get; set; }
        public T3 Data3 { get; set; }
        public T4 Data4 { get; set; }
    }
}
