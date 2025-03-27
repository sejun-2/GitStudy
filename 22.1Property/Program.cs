namespace _22._1Property
{
    internal class Program
    {
        public class Player
        {
            private int hp = 100;     // private로 외부에서 마음대로 바꿀 수 없도록 방지.

            public event Action<int> OnHpChanged;

            // <Getter Setter>
            // 읽고 쓰는 권한을 따로 부여
            // 맴버변수가 외부객체와 상호작용하는 경우 Get & Set 함수를 구현해 주는 것이 일반적
            // 1. Get & Set 함수의 접근제한자를 설정하여 외부에서 맴버변수의 접근을 캡슐화함
            // 2. Get & Set 함수를 거쳐 맴버변수에 접근할 경우 호출스택에 함수가 추가되어 변경시점을 확인 가능
            public int GetHP()
            {
                return hp;
            }
            private void SetHP(int hp)
            {
                this.hp = hp;
                OnHpChanged(hp);        // hp에 변화가 있을시 이벤트 가능
                if (hp < 0) 
                {
                    //Die();
                }
            }

            // <속성 (Property)>
            // Get & Set 함수의 선언을 간소화
            private int mp;
            public int MP                       // mp 맴버변수의 Get & Set 속성
            {
                get { return mp; }              // get : Get함수와 역할동일
                set { mp = value; }             // set : Set함수와 역할동일, 매개변수는 value
            }

            // <속성 (Property)> 요약사용
            // Get & Set 함수의 선언을 간소화
            public int AP { get; set; }         // AP 맴버변수를 선언과 동시에 Get & Set 속성
            public int DP { get; private set; } // 속성의 접근제한자를 통한 캡슐화
            public int SP { get; } = 10;        // 읽기전용 속성(상수처럼 사용가능)
            public int HP => GetHP();           // 읽기전용 속성(람다처럼 사용가능)

            // 선생님이 습관처럼 쓰던 방법!!!!
            public int WP;
            public int Wp { get { return WP; } set { WP = value; OnWpChanged?.Invoke(value); } }
            public event Action<int> OnWpChanged;

            public bool IsDead => hp <= 0; // 죽었는지
            public bool IsAlive => hp > 0; // 살아있다.
        }

        public class NetworkGame
        {
            private bool isInRoom;
            private bool isReady;
            private bool isSelectChar;
            private bool isEqualTeamMember;

            public bool IsStartabl => isInRoom && isReady && isSelectChar && isEqualTeamMember;
        }


        static void Main(string[] args)
        {
            Player player = new Player();
            //player.HP = 10;               // private 읽기 전용으로 외부에서 셋팅 불가능!!
            Console.WriteLine(player.HP);   // 읽기는 가능

            int playerHP = player.GetHP();
            // player.SetHP(10);            // error : SetHP는 private로 Player의 hp는 외부에서 변경불가

            int playerMP = player.MP;       // 프로퍼티를 이용한 mp get 접근
            player.MP = 20;                 // 프로퍼티를 이용한 mp set 접근

            int playerAP = player.AP;       // 프로퍼티를 이용한 AP get 접근
            player.AP = 20;                 // 프로퍼티를 이용한 AP set 접근

            int playerDP = player.DP;       // 프로퍼티를 이용한 DP get 접근
            // player.DP = 20;              // error : DP의 set은 private로 외부에서 변경불가

            int playerSP = player.SP;       // 프로퍼티를 이용한 SP get 접근
            // player.SP = 30;              // error : SP는 set이 없어 변경불가



            NetworkGame networkGame = new NetworkGame();

            if (networkGame.IsStartabl) 
            {
            }


        }
    }
}
