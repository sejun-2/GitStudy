namespace _21._1Lambda
{
    internal class Program
    {
        /*
            무명메서드와 람다식
            델리게이트 변수에 할당하기 위한 함수를 소스코드 구문에서 생성하여 전달
            전달하기 위한 함수가 간단하고 일회성으로 사용될 경우에 간단하게 작성
         */
        static void Main(string[] args)
        {
            // <무명메서드>
            // 함수를 통한 연결은 함수가 직접적으로 선언되어 있어야 사용 가능
            // 할당하기 위한 함수가 간단하고 자주 사용될수록 비효율적
            // 간단한 표현식을 통해 함수를 즉시 작성하여 전달하는 방법

            Action<string> action = delegate (string text)
            {
                Console.WriteLine(text);
            };
            // <람다식>
            // 무명메서드의 간단한 표현식
            action = (text) => Console.WriteLine(text);


            //1. Func<int, int, int> pow = Util.Pow;

            Func<int, int, int> pow = delegate (int n, int x)
            {
                int result = 1;
                for (int i = 0; i < n; i++)
                {
                    result *= n;
                }
                return result;

            };

            // <람다식>
            // 무명메서드의 간단한 표현식
            // 간단한 함수 제작
            pow = (n, x) =>
            {
                int result = 1;
                for (int i = 0; i < n; i++)
                {
                    result *= n;
                }
                return result;

            };

            Console.WriteLine("3의 2제곱은 {0}", pow(3, 2));
            Console.WriteLine("4의 2제곱은 {0}", pow(4, 2));
            Console.WriteLine("2의 6제곱은 {0}", pow(2, 6));

            /******************************************************************/

            Player player = new Player();
            SFX sfx = new SFX();

            player.OnTakeDamaaged += (damage) => { sfx.HitSound(); };

        }

        public class Player
        {
            private int hp = 100;
            public Action<int> OnTakeDamaaged;

            public void TakeDamage(int damage)
            {
                hp -= damage;
                Console.WriteLine("플레이어가 {0}의 데미지를 받습니다", damage);

                if (OnTakeDamaaged != null)
                {
                    OnTakeDamaaged(damage);
                }
            }
        }

        public class SFX
        {
            public void HitSound()
            {
                Console.WriteLine("죽는 사운드");
            }


        }

        //1. public class Util
        //{
        //    public static int Pow(int n, int x)
        //    {
        //        int result = 1;
        //        for (int i = 0; i < n; i++)
        //        {
        //            result *= n;
        //        }
        //        return result;
        //    }
        //}
    }
}
