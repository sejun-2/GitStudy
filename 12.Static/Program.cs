namespace _12.Static
{
    internal class Program
    {
        // 시스템 설정 : 볼륨 크기 (0~100), 해상도, 화면밝기

        static class Utill
        {
            public static void Swap(ref int left, ref int right)   // static은 정적 변수로서 데이터 영역에 저장한다.
            {
                int temp = left;
                left = right;
                right = temp;
            }
        }
        

        class Player
        {
            public void Attack()
            {
                Console.WriteLine("{0} 크기로 사운드 이펙트 재생!", Setting.volume);
            }
        }

        class Monster
        {
            public int hp = 100;        // static으로 hp를 선언하면 모든 몬스터가 체력 하나를 공유한다.
            public void TakeDamage(int damage)
            {
                Console.WriteLine("몬스터가 {0}의 데미지를 입었습니다.", damage);
                hp -= damage;
                Console.WriteLine("남은 체력 : {0}", hp);
                //Console.WriteLine("{0} 크기로 피격음 재생!", Setting.volume);
            }

            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("현재 시스템 볼륨은 {0} 입니다.", Setting.volume);

            Player player = new Player();
            player.Attack();

            Monster monster = new Monster();
            Monster monster2 = new Monster();

            monster.TakeDamage(10);
            monster2.TakeDamage(10);


            
        }
    }

    class Setting
    {
        public static int volume = 100;     // static은 1회성 사용에는 추천하지 않는다!
        public static int resolution = 0;
        public static int brightness = 0;
    }

}
/*
static : 고정적인 위치에서 프로그램 시작부터 끝까지 남아있는 메모리 (데이터 영역에 저장된다.)
 1. 프로그램 시작부터 끝까지 유지되야 하는 데이터
 2. 어디서든 가져다 쓸 수 있음 (전역적인 접근이 가능하다)
 3. static은 1회성 사용에는 추천하지 않는다. (메모리 낭비)

 static 함수 : 전역적으로 사용이 가능한 함수 -> 전역함수

 static 클래스 : 모든 뱀버변수와 맴버함수가 static인 클래스. (정적 클래스)
 정적 클래스는 인스턴스로 만들수 없다 . (new를 사용할 수 없다.)
*/
