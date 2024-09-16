using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Ge1_6_inheritance
{
    internal class ge1_6_sample2
    {
        static void Main(string[] args)
        {
            Vector2 v1 = new Vector2();
            Vector3 v2 = new Vector3();

            //vec2
            v1.x = 1; v1.y = 2;
            //vec3
            v2.x = 1; v2.y = 2; v2.z = 3;

            //確認
            v1.Vec2Show();
            v2.Vec2Show();//継承しているので、これもこちらも使える
            v2.Vec3Show();
        }
    }
    /*継承*/
    //Vector2継承してVector3を作成
    //Vector2の機能も持ったVector3が作られている。
    public class Vector3 : Vector2
    {
        public int z;

        public override void Vec3Show()
        {
            Console.WriteLine("x:{0},y:{1},z:{0}", x, y, z);
        }
    }
    //継承元
    //親クラスと呼ばれる
    public class Vector2
    {
        public int x, y;

        public virtual void Vec2Show()
        {
            Console.WriteLine("x:{0},y:{1}", x, y);
        }
    }
}
