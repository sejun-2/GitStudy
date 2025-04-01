using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30.TextRPG.Scenes
{
    internal class ShopScene : Scene
    {
        public override void Render()
        {
            Console.WriteLine("\"어서오세요\"");
            Console.WriteLine("\"좋은 뭄ㄹ건 많습니다~\"");
            Console.WriteLine("상점에는 다양한 물건들이 늘어져 있다.");
            Console.WriteLine("어떤 물건을 구매하시겠습니까?");
        }

        public override void Choice()
        {
            Console.WriteLine("1. 누가봐도 수상한 저주받은 것 같은 구슬을 산다.");
            Console.WriteLine("2. 상인에게 들려우는 소문이 있는지 묻는다.");
            Console.WriteLine("3. 상인을 위협하고 돈을 갈취 시도한다");
            Console.WriteLine("4. 마을로 돌아간다.");
        }

        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D4:
                    Console.WriteLine("마을로 돌아갑니다.");
                    break;
                default:
                    Console.WriteLine("잘못입력하셨습니다. 다시입력하세요");
                    break;
            }
        }

        public override void Wait()
        {
            Console.WriteLine("계속하려면 아무키나 입력하세요.");
            Console.ReadKey();
        }

        public override void Next()
        {
            switch (input)
            {
                case ConsoleKey.D4:
                    Game.ChangeScene("Town");
                    break;
         
            }
        }


    }
}
