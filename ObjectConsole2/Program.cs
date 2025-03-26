using System.Net.Security;

namespace ObjectConsole2
{
    internal class Program
    {
        public class Monster
        {
            public string name;
            public int hp;
            public int Level;

            // <클래스 생성자>
            // 반환형이 없는 클래스이름의 함수를 생성자라 하며 클래스의 인스턴스를 만들 때 호출되는 역할로 사용
            // 인스턴스의 생성자는 new 키워드를 통해서 사용

            // 기본생성자 : 생성자가 하나도 없을 때 자동으로 생성되는 생성자
            //public Monster()
            //{
            //}


            // 생성자 오버로딩 : 생성자를 여러개 만들어서 다양한 방법으로 인스턴스를 생성할 수 있음
            public Monster()
            {
                Console.WriteLine("몬스터 생성자.");
                name = "몬스터";
                hp = 100;
                Level = 1;
            }

            public Monster(string _name)
            {
                name = _name;

                switch(name)
                {
                    case "슬라임":
                        hp = 100;
                        Level = 1;
                        break;
                    case "오크":
                        hp = 200;
                        Level = 3;
                        break;
                    case "드래곤":
                        hp = 500;
                        Level = 10;
                        break;  
                }
            }

            public Monster(string _name, int _hp, int _Level)
            {
                Console.WriteLine("몬스터 생성자.");
                name = _name;
                hp = _hp;
                Level = _Level;
            }
        }
        static void Main(string[] args)
        {
            // 클래스 생성자
            
            Monster monster = new Monster();    // 클래스의 인스턴스가 생성될 때 자동으로 호출되는 메서드

            Monster orc = new Monster("오크");    // 생성자 오버로딩

            Monster slime = new Monster("슬라임", 100, 3);    // 생성자 오버로딩
        }
    }
}
