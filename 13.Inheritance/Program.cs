namespace _13.Inheritance
{
    internal class Program
    {
        // 상속(Inheritance)
        // 부모클래스의 모든 기능을 가지는 자식클래스를 설계하는 방법
        // is-a 관계 : 부모클래스가 자식클래스를 포함하는 상위개념일 경우 상속관계가 적합함

        // <상속>
        // 부모클래스를 상속하는 자식클래스에게 부모클래스의 모든 기능을 부여
        // class 자식클래스 : 부모클래스

        // 상속 사용의미1
        // 상속을 진행하는 경우 부모클래스의 소스가 자식클래스에서 모두 적용됨
        // 부모클래스와 자식클래스의 상속관계가 적합한 경우 부모클래스에서의 기능 구현이 자식클래스에서도 어울림

        //상속 사용의미2
        // 업캐스팅을 통해 자식클래스는 부모클래스로 형변환이 가능합
        // 자식클래스는 부모클래스를 요구하는 곳에서 동일한 기능을 수행할 수 있음

        class Monster
        {
            protected string name;      // protected : 자식클래스에서는 접근 가능. 외부에서는 접근 불가능
            public int hp;
            public float speed;

            public void Move()      // 상속하는 자식클래스에게 부모클래스의 모든 기능을 부여
            {
                Console.WriteLine("{0} 이/가 {1} 속도로 움직입니다.", name, speed);
            }

            public void TakeDamage(int damage)
            {
                hp -= damage;
                if (hp <= 0)
                {
                    Console.WriteLine("{0} 몬스터가 죽었습니다.", name);
                }
            }

        }

        // 100 종류의 몬스터가 있다고 가정
        class Slime : Monster
        {
            public Slime()
            {
                name = "슬라임";
                hp = 10;
                speed = 3.5f;
            }
            public void Split()     // 자식클래스에서 자식클래스 만의 기능을 추가할 수 있음
            {
                Console.WriteLine("몸체를 두개로 분리합니다.");
            }
        }

        class Dragon : Monster
        {
            //public float flyingSpeed;
           // public float speed;             // 부모 클래스와 똑같은 이름의 변수 사용가능.

            public Dragon()
            {
                name = "드래곤";
                hp = 100;
                speed = 10.0f;
                //base.speed = 10f;          // 부모클래스의 변수에 접근할 때 base 키워드 사용
                //this.speed = 5.5f;         // 자식클래스의 변수에 접근할 때 this 키워드 사용
            }
            public void Breath()
            {
                Console.WriteLine("브래스를 뿜습니다.");
            }
        }



        class Car
        {
            public string name;
            public float speed;

            public Car(string name, float speed)
            {
                Console.WriteLine("부모클래스 생성자 호출");
                this.name = name;
                this.speed = speed;
            }
        }

        class Truck : Car
        {
            public int capacity;

            public Truck() : base("트럭", 10.0f)      // 부모클래스의 생성자 호출
            {
                Console.WriteLine("자식클래스 생성자 호출");
                capacity = 10;
            }

            public Truck(string name, float speed, int capacity) : base(name, speed)
            {
                this.capacity = capacity;
            }
        }





        static void Main(string[] args)
        {
            Truck truck = new Truck();      // 부모클래스 생성자가 먼저 호출되고 자식클래스 생성자가 호출됨



            /*********************************************************************************/

            //Slime slime = new Slime();
            //Dragon dragon = new Dragon();

            //부모클래스 Monster를 상속한 자식클래스는 모두 부모클래스의 기능을 가지고 있음
            //slime.Move();
            //dragon.Move();

            // 자식클래스는 부모클래스의 기능에 더해 자식만의 고유 기능을 추가하여 구현 가능
            //slime.Split();
            ///dragon.Breath();

            // 업캐스팅(자동으로 가능) : 자식클래스는 부모클래스 자료형으로 암시적 형변환 가능
            Monster monster = new Slime();
            Monster monster2 = new Dragon();
            //monster2.Breath();      // 부모클래스로 형변환했을 때 자식클래스의 고유 기능은 사용 불가능
            //monster.Split();        // 부모클래스로 형변환했을 때 자식클래스의 고유 기능은 사용 불가능

            //Item[] inventory = new Item[20];
            //inventory[0] = new Potion();
            //inventory[1] = new Weapon();

            // 다운캐스팅 (불가능한 경우가 있기 때문에 확인 후에 변환 가능)
            // is : 형변환이 가능하면 true, 불가능하면 false 반환
            if (monster is Slime)       // monster가 Slime이 맞는지 확인
            {
                Slime slime = (Slime)monster;      
                slime.Split();
            }
            else if (monster is Dragon)     // monster가 Dragon이 맞는지 확인
            {
                Dragon dragon = (Dragon)monster;
                dragon.Breath();
            }

            // as : 형변환이 가능하면 해당 자료형으로 변환, 불가능하면 null 반환
            Dragon dragon1 = monster as Dragon;





            Player player = new Player();
            //player.Attack(slime);
            //player.Attack(dragon);

            
            player.Test(10);
            player.Test(3.5f);

            Console.WriteLine("텍스트");       // 오버로딩의 예시
            Console.WriteLine(153);
            Console.WriteLine(true);
            Console.WriteLine(2.593);

        }
     


        sealed class Player             // sealed : 상속을 막는 키워드
        {
            public int attackPoint;

            public void Attack(Monster monster)
            {
                monster.TakeDamage(attackPoint);
            }

            public void Attack(Item item)
            {
                Console.WriteLine("아이템 파괴.");
            }

            // 함수 오버로딩 -> 함수 이름은 같지만 매개변수의 타입이나 개수가 다른 함수를 여러개 만들 수 있음
            public void Test(float value) { }
            public void Test(int value) { }

            public void UseItem(Item item)
            {

            }

            //public void UseSkill(Skill skill)
            //{
            //}


        }

        //class AdvancedPlayer : Player   // sealed 로 인해 상속 불가능. 오류
        //{
        //}


        class Item
        {
            public string name;
            public string icon;
            public int weight;
        }

        class Potion : Item { }

        class Weapon : Item { }


    }

    






}
