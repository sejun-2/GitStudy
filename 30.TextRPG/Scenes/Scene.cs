using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30.TextRPG.Scenes
{
    internal abstract class Scene    // 장면 -> abstract(추상함수 - 상속) 로 여러 장면을 만들어서 다른 상황을 입력.
    {
        // 입력을 받아줄 변수
        protected ConsoleKey input; // 모든 Scene 에서 쓸거니 protected
        
        public abstract void Render();
        public abstract void Choice();
        public void Input()    // 모든 Scene 에서 쓸거니 다 쓸수 있도록 구현
        {
            input = Console.ReadKey(true).Key;
        }
        public abstract void Result();
        public abstract void Wait();
        public abstract void Next();

    }
}
