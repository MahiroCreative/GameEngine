using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qs2_Entry2
{
    internal class Qs2_pro
    {
        static void Main(string[] args)
        {
            /*問題1(等速運動と等加速度運動)*/
            Console.WriteLine("【問題1(等速運動と等加速度運動)：】");
            Vector2 obj = new Vector2();
            Vector2 speed = new Vector2(1.2f, 1.4f);//初速。秒速(/s)
            Vector2 accel = new Vector2(0.1f, 0.2f);//加速度
            Vector2 temp;
            //計算
            temp = obj + speed * 3;
            Console.WriteLine("・初速speed(1.2f,1.4f)で3秒間等速運動:\n" + temp.OutString());
            temp = speed * 3 + (accel * 3 * 3) / 2;
            Console.WriteLine("・初速speed(1.2f,1.4f), 加速度accel(0.1f,0.2f)で3秒間等加速度運動:\n" + temp.OutString());


            /*問題2(放物線運動)*/
            Console.WriteLine("【問題2(放物線運動)：】");
            Vector2 gravity = new Vector2(0, -9.8f);
            speed.Set(1.0f, 24.0f);//(/s)
            accel.Set(0.0f, 0.0f);//(/s)

            //60fpsの世界にする
            gravity = gravity / 60;
            accel = accel / 60;

            //計算
            for (int time = 1; true; time++)
            {
                //現在の速度
                speed = speed + gravity + accel;

                //現在のオブジェクトの位置
                obj = obj + speed;

                //obj位置
                //Console.WriteLine(speed.OutString() + " " + (float)time / 60);

                //地面に付いたかの判定                
                if (speed.Y <= 0.0f)
                {
                    Console.WriteLine("物体が地面に付くのに{0}秒以上掛かりました。", (float)time / 60);
                    break;
                }


            }
        }
    }
}