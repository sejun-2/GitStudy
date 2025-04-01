using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30.TextRPG.Scenes
{
    internal class TitleScene : Scene       // 마우스 오른쪽 버튼 -> 빠른 작업 및 리펙터링 (쉽게 추상 메소드 작성)
    {

        public override void Render()   // 처음 화면 
        {
            Console.WriteLine("******************************");
            Console.WriteLine("*          레전드 RPG         *");
            Console.WriteLine("******************************");
            Console.WriteLine("");
        }

        public override void Result()
        {
        }

        public override void Choice()
        {
            Console.WriteLine("1. 게임 시작");
            Console.WriteLine("2. 불러오기 (미구현)");
            Console.WriteLine("3. 게임 종료");
        }

        public override void Wait()
        {
        }

        public override void Next()
        {
            // TODO : 다음 씬으로 전환 구현 필요
            // todo (투두 주석) -> 작업 목록에서 볼 수 있음. (보기 -> 작업목록)

            switch (input)
            {
                case ConsoleKey.D1:
                    Game.ChangeScene("Town");
                    break;
            }
        }
    }
}
