namespace _14.Polymopishm
{
    internal class Program
    {
        // 다형성 (Polymorphism)
        // 객체의 속성이나 기능이 상황에 따라 여러가지 형태를 가질 수 있는 성질

        public class Car
        {
            public string name;
            public int speed;

            public Car(string name, int speed)
            {
                this.name = name;
                this.speed = speed;
            }

            public void Move()
            {
                Console.WriteLine($"{name}이(가) {speed}km/h로 이동합니다.");
            }
        }


        static void Main(string[] args)
        {
            Car sportCar = new Car("스포츠카", 100);
            Car truck = new Car("트럭", 30);

            sportCar.Move();
            truck.Move();
        }



        // <가상함수와 오버라이딩>
        // 가상함수 : 부모클래스의 함수 중 자식클래스에 의해 재정의 할 수 있는 함수를 지정
        // 오버라이딩 : 부모클래스의 가상함수를 같은 함수이름과 같은 매개변수로 재정의하여 자식만의 반응을 구현
        public class Skill
        {
            public string name;
            public float coolTime;

            public virtual void Execute()           // virtual -> 가상함수로 자식클래스에서 재정의 가능
            {
                Console.WriteLine($"{name} 스킬을 사용합니다.");
                Console.WriteLine($"재사용 대기시간 : {coolTime}초");
            }
        }

        public class FireBall : Skill
        {
            public FireBall()
            {
                name = "파이어볼";
                coolTime = 1.5f;
            }

            public override void Execute()          // override -> 같은 이름의 virtual 함수를 재정의 해서 쓰겠다.
            {
                base.Execute();                     // 부모에 있는 Execute 도 쓰겠다.
                Console.WriteLine("화염구 발사.");

            }
        }

        public class Smash : Skill
        {
            public Smash()
            {
                name = "강타";
                coolTime = 3.0f;
            }

            public override void Execute()
            {
                base.Execute();                     // 부모에 있는 Execute 도 쓰겠다.
                Console.WriteLine("전방에 강력한 타격");

            }
        }


        //static void Main(string[] args)
        //{
        //    Skill skill1 = new FireBall();
        //    Skill skill2 = new Smash();
        //    skill1.Execute();
        //    skill2.Execute();

        //}


        // <다형성 사용의미1>
        // 새로운 클래스를 추가하거나 확장할 때 기존 코드에 영향을 최소화함.
        // 새로운 클래스를 만들 때 기존의 소스를 수정하지 않아도 됨

        class Player
        {
            Skill skill;

            public void SetSkill(Skill skill)
            {
                this.skill = skill;
            }

            public void UseSkill()
            {
                skill.Execute();        // skill 클래스의 다형성을 확도한 결과 진행
            }
        }


        // <다형성 사용의미2>
        // 클래스 간의 의존성을 줄여 확장성은 높임
        class SkillContents : Skill
        {
            public override void Execute()
            {
                base.Execute();
                // 프로그램의 확장을 휘해 상위클래스를 상속하는 클래스를 개발
            }
        }



    }
}
