using System.Xml.Linq;
using static Pocatmon.Program;

namespace Pocatmon
{
    internal class Program
    {
        public abstract class Pocatmon
        {
            public string name;

            public abstract void Attack();
 
        }

        public class FirePocatmon : Pocatmon
        {
 
            public override void Attack()
            {
                Console.WriteLine($"{name} 이(가) 화염방사!!!.");
            }
        }

        public class WaterPocatmon : Pocatmon
        {

            public override void Attack()
            {
                Console.WriteLine($"{name} 이(가) 물대포!!!.");
            }
        }

        public class ElectronicPocatmon : Pocatmon
        {
            public override void Attack()
            {
                Console.WriteLine($"{name} 이(가) 백만볼트!!!.");
            }
        }

        public class GhostPocatmon : Pocatmon
        {
            public override void Attack()
            {
                Console.WriteLine($"{name} 이(가) 최면술!!!.");
            }
        }

        public class GrassPocatmon : Pocatmon
        {
            public override void Attack()
            {
                Console.WriteLine($"{name} 이(가) 씨뿌리기!!!.");
            }
        }

        public class RockPocatmon : Pocatmon
        {
            public override void Attack()
            {
                Console.WriteLine($"{name} 이(가) 바위공격!!!.");
            }
        }

        public class Trainer
        {
            public string name;
            public Pocatmon[] pocatmons = new Pocatmon[6];
            public Pocatmon currentPokemon;

            public Trainer(string name)
            {
                this.name = name;
                Console.WriteLine($"트레이너 {name}님을 생성합니다.");
            }


            public void Pick(int num)
            {
                if (num < 0 || num >= pocatmons.Length || pocatmons[num] == null)
                {
                    Console.WriteLine("바르지 않은 선택입니다.");
                    return;
                }
                currentPokemon = pocatmons[num-1];
                Console.WriteLine($"{name} 이(가) {currentPokemon.name} 을(를) 선택했습니다!");
            }

            public void Print()
            {
                Console.WriteLine($"{name} 의 포켓몬 목록: ");

                for (int i = 0; i < pocatmons.Length; i++)
                {
                    if (pocatmons[i] != null)
                    {
                        Console.WriteLine($" {i+1}. {pocatmons[i].name}");
                    }
                }
                
            }

            public void Attack()
            {
                if (currentPokemon == null)
                {
                    Console.WriteLine("선택된 포켓몬이 없습니다!");
                    return;
                }
                currentPokemon.Attack();
            }


        }



        static void Main(string[] args)
        {

            FirePocatmon fire = new FirePocatmon();
            fire.name = "파이리";

            WaterPocatmon water = new WaterPocatmon();
            water.name = "꼬부기";

            ElectronicPocatmon electronic = new ElectronicPocatmon();
            electronic.name = "피카츄";

            GhostPocatmon ghost = new GhostPocatmon();
            ghost.name = "고오스";

            GrassPocatmon grass = new GrassPocatmon();
            grass.name = "이상해씨";

            RockPocatmon rock = new RockPocatmon();
            rock.name = "꼬마돌";


            Trainer trainer = new Trainer("지우");

            trainer.pocatmons[0] = fire;
            trainer.pocatmons[1] = water;
            trainer.pocatmons[2] = electronic;
            trainer.pocatmons[3] = ghost;
            trainer.pocatmons[4] = grass;
            trainer.pocatmons[5] = rock;

            trainer.Print();
            trainer.Pick(3);
            trainer.Attack();


        }
    }
}
