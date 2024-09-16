using System;

namespace Ge1_5_ClassStruct
{
    internal class ge1_5_checkAns
    {
        static void Main(string[] args)
        {
            //Playerの作成
            Player p1 = new Player();
            Player p2 = new Player();
            //ステータス入力
            p1.inputState("tanaka", 80, 4);
            p2.inputState("takeshita", 120, 3);
            //ダメージ
            Console.WriteLine("input d1's at:");
            int d1 = Input.GetInt();
            Console.WriteLine("input d2's at:");
            int d2 = Input.GetInt();
            p1.Damege(d1);
            p2.Damege(d2);
            //確認
            p1.ShowState();
            p2.ShowState();
        }
    }

    //入力値をintやflotに変換してくれるクラス
    static class Input
    {
        //staticメンバ関数
        //int用
        public static int GetInt()
        {
            int ans;
            string input;

            //入力させてintにキャスト
            /*自分で書く */

            return ans;
        }
    }
    //Playerクラスの作成
    public class Player
    {
        //メンバ変数
        string name = "";
        int hp = 0;
        int at = 0;
        //メンバ関数
        public void inputState(string _name, int _hp, int _at)
        {
            /*自分で書く*/
        }
        public void Damege(int d)
        {
            /*自分で書く*/
        }
        public void ShowState()
        {
            /*自分で書く*/
        }
    }
}
