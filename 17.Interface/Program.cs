using System.Threading.Tasks.Dataflow;

namespace _17.Interface
{
    internal class Program
    {
        //인터페이스(Interface)
        // 인터페이스는 맴버를 가질 수 있지만 직접 구현하지 않음.단지 정의만을 가짐.
        // 인터페이스를 가지는 클래스에서 반드시 인터페이스의 정의를 구현해야함.
        // 이를 반대로 표현하자면 인터페이스를 포함하는 클레스는
        // 반드시 인터페이스의 구성요소들을 구현했다는 것을 보장함.
        // Can-a 관계 : 클래스가 해당 행동을 할 수 있는 경우 적합함.


        // <인터페이스의 정의>
        // 일반적으로 인터페이스의 이름은 I로 시작함. - 국룰!
        // 인터페이스의 함수는 직접 구현하지 않고 정의만 진행.
        public interface IEnterable     // 인터페이스 선언
        {
            public void Enter();        // 구현하지 않고 정의만 함
        }

        public interface IOpenable
        {
            public void Open();
        }


        public class Enterance
        {
            // 로딩 기능 추가
            // 플레이어 위치 이동시키기
            public void Join() { }
        }

        public class LockPick
        {
            // 열쇠 기능
            // 열려있는지 여부 확인기능
            // 열렸을때 이펙트
            public void Open() { }
        }

        public class Door : IEnterable, IOpenable   // 인터페이스는 다중 상속 가능하다.
        {
            public void Enter()     // 인터페이스는 구현이 강제 된다.
            {
                // 문을 열때 이펙트
                Console.WriteLine("문을 열고 들어갔습니다.");
            }
            public void Open()     // 인터페이스는 구현이 강제 된다.
            {
                // 문을 열때 이펙트
                Console.WriteLine("문이 열렸습니다.");
            }
        }


        public class Dungeon : IEnterable
        {
            public void Enter()     // 인터페이스 상속시 구현이 강제 된다.
            {
                // 던전 입장시 이펙트
                Console.WriteLine("던전에 입장했습니다.");
            }
        }

        public class Chest : IOpenable
        {
            public void Open()     // 인터페이스 상속시 구현이 강제 된다.
            {
                // 보물상자 열릴때 이펙트
                Console.WriteLine("보물상자가 열렸습니다.");
            }
        }



        public class Player
        {
            public void Enter(IEnterable enterable)     // 들어갈수 있으면 들어갈게.
            {
                enterable.Enter();
            }

            public void Open(IOpenable openable)    // 열수 있으면 열게.
            {
                openable.Open();
            }

        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Dungeon dungeon = new Dungeon();
            Chest chest = new Chest();

            player.Enter(dungeon);      // 던전에 입장했습니다
            player.Open(chest);         // 보물상자가 열렸습니다. 

            Door door = new Door();     // Door 클래스는 IEnterable, IOpenable 인터페이스를 모두 구현하고 있음.
            player.Enter(door);         // 문을 열고 들어갔습니다.
            player.Open(door);          // 문이 열렸습니다.



        }
    }
}
