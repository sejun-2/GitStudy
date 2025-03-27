namespace _21.Callback
{
    internal class Program
    {
        /*
            콜백함수
            델리게이트를 이용하여 특정 조건에서 반응하는 함수를 구현
            함수의 호출(Call)이 아닌 역으로 호출받을 때 반응을 참조하여 역호출(Callback)
         */

        public class File
        {
            public void Save()
            {
                Console.WriteLine("저장하기 합니다.");
            }

            public void Load()
            {
                Console.WriteLine("불러오기 합니다.");
            }
        }

        public class Button
        {
            public delegate void ClickListener();
            public ClickListener clickListener;

            public void Click()
            {
                if (clickListener != null)
                {
                    clickListener();
                }
            }
        }

        public class Player
        {
            public void Jump()
            {
                Console.WriteLine("플레이어가 점프합니다");
            }
        }


        static void Main(string[] args)
        {
            File file = new File();

            Button saveButton = new Button();
            saveButton.clickListener = file.Save;

            Button loadButton = new Button();
            loadButton.clickListener = file.Load;

            saveButton.Click();     // 저장하기
            loadButton.Click();     // 불러오기


            Player player = new Player();
            Button jumpbutton = new Button();
            jumpbutton.clickListener = player.Jump;
            jumpbutton.Click();     // 점프하기


        }
        
    }
}
