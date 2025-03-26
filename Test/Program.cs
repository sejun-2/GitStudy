namespace Test
{
    internal class Program
    {

        public class Monster
        {
            public string name;
            public int level;

            public Monster(string name, int level)  // 이름, 레벨 : 객체의 인스턴스 생성 시 new할당에서 이름과 레벨을 입력받을 수 있도록 구현
            {
                this.name = name;
                this.level = level;
            }

            public void Print()
            {
                Console.WriteLine($"몬스터 이름: {name}, 레벨: {level}");
            }
        }

        public class Trainer
        {
            public string name;
            public Monster[] monsters = new Monster[6]; // 몬스터를 보관할 수 있는 크기 6의 배열

            public Trainer(string name)
            {
                this.name = name;
                Console.WriteLine($"트레이너 {name}이(가) 생성되었습니다.");
            }

            // Add() : 매개변수로 몬스터를 하나 입력받아 배열의 빈 자리에 추가. 빈 자리가 없다면 추가되지 않음
            public void Add(Monster monster)    
            {
                for (int i = 0; i < monsters.Length; i++)
                {
                    if (monsters[i] == null)
                    {
                        monsters[i] = monster;
                        Console.WriteLine($"{monster.name}이(가) 추가되었습니다.");
                        return;
                    }
                }
                Console.WriteLine("몬스터를 추가할 공간이 없습니다!");
            }

            //Remove() : 매개변수로 몬스터를 하나 입력받아 동일한 이름을 가진 몬스터를 배열에서 삭제. 이름에 해당하는 몬스터가 없거나 배열에 몬스터가 한마리도 없는 경우 아무 기능도 수행하지 않음.
            public void Remove(string monsterName)
            {
                for (int i = 0; i < monsters.Length; i++)
                {
                    if (monsters[i] != null && monsters[i].name == monsterName)
                    {
                        Console.WriteLine($"{monsters[i].name}이(가) 삭제되었습니다.");
                        monsters[i] = null; // 배열에서 삭제
                        return;
                    }
                }
                Console.WriteLine("해당 이름의 몬스터를 찾을 수 없습니다.");
            }

            // PrintAll() : 자신이 가지고 있는 모든 포켓몬에 대한 정보를 출력
            public void PrintAll()
            {
                Console.WriteLine($"{name} 의 몬스터 목록:");

                for (int i = 0; i < monsters.Length; i++)
                {
                    if (monsters[i] != null)
                    {
                        monsters[i].Print();
                    }
                    
                }
                if (monsters[0] == null)
                {
                    Console.WriteLine("현재 몬스터가 없습니다.");
                }

            }
        }

        static void Main(string[] args)
        {
            Console.Write("트레이너의 이름을 입력하세요: "); // 플레이어 이름, 프로그램 시작 시 입력하도록 구현
            string trainerName = Console.ReadLine();
            Trainer trainer = new Trainer(trainerName);

            Monster pikachu = new Monster("피카츄", 5); // 이름, 레벨: 객체의 인스턴스 생성 시 new할당에서 이름과 레벨을 입력받을 수 있도록 구현
            Monster charmander = new Monster("파이리", 7);
            Monster squirtle = new Monster("꼬부기", 6);

            trainer.Add(pikachu);
            trainer.Add(charmander);
            trainer.Add(squirtle);

            trainer.PrintAll();

            trainer.Remove("파이리");

            trainer.PrintAll();
        }
    }
}
