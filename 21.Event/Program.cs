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
            public Action OnDied;


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

            player.OnDied();

            /* *************************************** */

            player.OnHpChanged += playerHpBar.SetHpBar;     // Action<int> 인트형이라 OnHpChanged 를 써야함.

            player.SetHp(100);
            player.SetHp(50);
            player.SetHp(10);


        }
    }
}
