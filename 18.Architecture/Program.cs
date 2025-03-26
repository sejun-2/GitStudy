namespace _18.Architecture
{
    internal class Program
    {
        /*
            추상클래스와 인터페이스
            인터페이스는 추상클래스의 일종으로 특징이 동일함
            함수에 대한 선언만 정의하고 이를 포함하는 클래스에서 구체화하여 사용
            하지만, 추상클래스와 인터페이스를 통해 얻는 효과는 다르며 다른 역할을 수행함
            개발자는 언터페이스와 추상클래스 중 더욱 상황에 적합한 것으로 구현해야 함.
        */

        //<추상클래스와 인터페이스>
        // 공통점 : 함수에 대한 선언만 정의하고 이를 포함하는 클래스에서 구체화 하여 사용
        // 차이점 : 추상클래스 - 변수, 함수의 구현 포함 가능 / 다중상속 불가
        //          인터페이스 - 변수, 함수의 구현 불가     / 다중포함 가능


        //추상클래스 (A Is B 관계)
        // 상속 관계인 경우, 자식클래스가 부모클래스의 하위분류인 경우
        // 상속을 통해 얻을 수 있는 효과를 얻을 수 있음.
        // 부모클래스의 기능을 통해 자식클래스의 기능을 확장하는 경우 사용

        // 인터페이스 (A Can Do B 관계)
        // 행동 포함인 경우, 클래스가 해당 행동을 할 수 있는 경우
        // 인터페이스를 사용하는 모든 클래스와 상호작용이 가능한 효과를 얻을 수 있음.
        // 인터페이스에 정의된 함수들을 클래스의 목적에 맞게 기능을 구현하는 경우 사용.

        public interface IEnterable
        {
            void Enter();
        }

        // 은행은 건물이다 : OK, 상속관계가 적합
        public abstract class Building : IEnterable
        {
            public void Enter()
            {
                Console.WriteLine("건물에 들어갑니다.");
            }
        }

        // 차는 들어갈 수 있다 : OK, 인터페이스가 적합
        public class Car : IEnterable
        {
            public void Enter()
            {
                Console.WriteLine("차 문을 열고 들어갑니다.");
            }
        }

        /******************************************************************************/


        public interface IDamageable
        {
            public void TakeDamage(int damage);
        }

        public class Player
        {
            public int hp = 100;
            public void TakeDamage(int damage)
            {
                hp -= damage;
                Console.WriteLine("플레이어가 " + damage + "의 데미지를 입었습니다.");
            }

            public void Jump()
            {
                Console.WriteLine("플레이어가 점프합니다.");
            }
        }

        public class Monster
        {
            public int attackPoint = 10;

            public void Attack(IDamageable damageable)  // (Player player)로도 가능 그럴경우 점프 함수 사용 가능
            {
                damageable.TakeDamage(attackPoint);
                //damageable.Jump();       // 인터페이스에는 Jump가 정의 되어 있지 않아 사용 불가
            }
        }


        static void Main(string[] args)
        {
            int[] array = new int[5] { 1, 2, 3, 4, 5};

            IReadOnlyList<int> list = array.AsReadOnly();   // 읽기 전용 리스트로 변환



        }

        static void Test(IReadOnlyList<int> array)
        {
            //array[0] = 1;
            //int value = array[0];   // 읽기만 가능하여 수정 등 불가능
        }
    }
}
