namespace _21.Event
{
    internal class Program
    {
        /*
         * 이벤트 (Event)
         * 일련의 사건이 발생했다는 사실을 다른 객체에게 전달
         * 델리게이트의 일부 기능을 제한하여 이벤트의 용도로 사용
         */

        public class Player
        {
            public int level = 1;
            public int hp = 100;

            public Action<int> OnHpChanged;
            public Action OnLevelUped;
            public event Action OnDied;     // 델리게이트에 event를 붙여주면 대입 기능이 막힘. 덮어쓰는 실수가 사라짐.


            public void SetHp(int hp)
            {
                this.hp = hp;
                if (OnHpChanged != null)
                {
                    OnHpChanged(hp);
                }
            }

            public void LevelUp()
            {
                level++;
                if (OnLevelUped != null) 
                {  
                    OnLevelUped(); 
                }
            }

            public void Die()
            {
                Console.WriteLine("플레이어가 쓰러집니다.");

                if (OnDied != null)
                {
                    OnDied();
                }
            }
        }

        public class HpBar
        {
            public void SetHpBar(int hp)
            {
                Console.WriteLine($"체력바 수치를 {hp} 로 설정합니다.");
            }
        }

        public class Monster
        {
            public void Stop()
            {
                Console.WriteLine("몬스터가 더이상 플레이어를 쫓아가지 않습니다.");
            }
        }

        public class Game
        {
            public void GameOver()
            {
                Console.WriteLine("게임오버 UI를 띄웁니다.");
            }
        }

        public class Sfx
        {
            public void DieSound()
            {
                Console.WriteLine("슬픈 음악이 재생됩니다.");
            }
        }


        static void Main(string[] args)
        {
            Player player = new Player();
            Monster monster1 = new Monster();
            Monster monster2 = new Monster();
            Game game = new Game();
            Sfx sfx = new Sfx();
            HpBar playerHpBar = new HpBar();

            player.OnDied += monster1.Stop;
            player.OnDied += monster2.Stop;
            player.OnDied += game.GameOver;
            player.OnDied += sfx.DieSound;


            // monster1 이 죽었어
            player.OnDied -= monster1.Stop;

            player.Die();



            // <델리게이트 체인과 이벤트의 차이점>
            // 델리게이트 또한 체인을 통하여 이벤트로서 구현이 가능
            // 하지만 델리게이트는 두가지 사항 때문에 이벤트로서 사용하기 적합하지 않음
            // 1. = 대입연산을 통해 기존의 이벤트에 반응할 객체 상황이 초기화 될 수 있음
            // 2. 클래스 외부에서 이벤트를 발생시켜 원하지 않는 상황에서 이벤트 발생 가능
            // event 키워드를 추가할 경우 델리게이트에서 위 두가지 기능을 제한하여 이벤트 전용으로 사용을 유도할 수 있음
            // 즉, event 변수는 델리게이트에서 기능을 제한하여 이벤트 전용의 기능만으로 사용하는 기능

            //player.OnDied; // event 사용으로 외부에서 호출 불가능.


            /* *************************************** */

            player.OnHpChanged += playerHpBar.SetHpBar;     // Action<int> 인트형이라 OnHpChanged 를 써야함.

            player.SetHp(100);
            player.SetHp(50);
            player.SetHp(10);


        }
    }
}
