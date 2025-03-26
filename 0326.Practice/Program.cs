namespace _0326.Practice
{
    internal class Program
    {
        // 플레이어가 다양한 물체 앞에서 상호작용 키를 누르면 앞 대상에 따라 다양한 방응.
        public interface Interaction    // 상호작용을 인터페이스로 정의
        {
            public void interaction();
        }

        // 1. npc 앞에선 대화
        public class NPC : Interaction  
        {
            public void interaction()   // npc는 상호작용을 인터페이스로 받아 대화를 함
            {
                Console.WriteLine("npc와 대화 합니다.");
            }
        }

        // npc중 상인은 상점 열기
        public class Merchant : NPC
        {
            public void OpenShop()  // 상인은 상호작용을 인터페이스로 받아 상점을 열음
            {
                Console.WriteLine("상점을 엽니다.");
            }
        }

        // 2. 상자 앞에선 아이템 습득
        public class Box : Interaction
        {
            public void interaction()   // 상자는 상호작용을 인터페이스로 받아 아이템 습득을 함
            {
                Console.WriteLine("아이템을 습득 합니다.");
            }
        }

        // 3. 문 앞에선 이동 진행
        public class Door : Interaction
        {
            public void interaction()   // 문은 상호작용을 인터페이스로 받아 이동을 함
            {
                Console.WriteLine("문 안으로 이동합니다.");
            }
        }

        public class Player
        {
            public string Move()
            {
                string input;
                while (true)  // 올바른 입력을 받을 때까지 반복
                {
                    Console.WriteLine("현재 Player가 이동할 대상을 선택해 주세요.");
                    Console.WriteLine("1. npc 2. box 3. door 4. Merchant npc");
                    input = Console.ReadLine();     // 이동할 대상 선택

                    switch (input)      // 선택한 대상으로 이동
                    {
                        case "1":
                            Console.WriteLine("npc 앞으로 이동합니다.");
                            return input;
                        case "2":
                            Console.WriteLine("box 앞으로 이동합니다.");
                            return input;
                        case "3":
                            Console.WriteLine("door 앞으로 이동합니다.");
                            return input;
                        case "4":
                            Console.WriteLine("Merchant npc 앞으로 이동합니다.");
                            return input;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 다시 선택해 주세요.");
                            Console.WriteLine();
                            break;  // while 루프를 계속 반복
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            NPC npc = new NPC();
            Merchant merchant = new Merchant();
            Box box = new Box();
            Door door = new Door();
            Player player = new Player();

            // 올바른 대상이 입력될 때까지 반복하여 입력 받음
            string input = player.Move();
     
            bool Fkey = true;   // F 키의 올바른 입력시 까지 반복하기 위한 매개변수
            while (Fkey) 
            {
                Console.WriteLine("상호작용 키는 F 입니다. F 를 눌러주세요");
                string input2 = Console.ReadLine().ToUpper(); // 대소문자를 따로 인식하는 오류를 막기위해 무조건 대문자로 변환

                if (input2 == "F")      // 상호작용 키를 누르면 상호작용
                {
                    switch (input)
                    {
                        case "1":
                            npc.interaction();
                            Fkey = false;
                            break;
                        case "2":
                            box.interaction();
                            Fkey = false;
                            break;
                        case "3":
                            door.interaction();
                            Fkey = false;
                            break;
                        case "4":
                            merchant.interaction();
                            merchant.OpenShop();
                            Fkey = false;
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;  // 잘못된 입력시 다시 시작.
                    }
                }

            }

            





        }
    }
}
