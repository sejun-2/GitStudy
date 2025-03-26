namespace ConsoleApp1
{
    public abstract class Pokemon
    {
        public string Name { get; set; }
        public abstract void Attack();
    }

    public class FirePokemon : Pokemon
    {
        public override void Attack()
        {
            Console.WriteLine($"{Name}이(가) 화염방사!!!");
        }
    }

    public class WaterPokemon : Pokemon
    {
        public override void Attack()
        {
            Console.WriteLine($"{Name}이(가) 물대포!!!");
        }
    }

    public class ElectricPokemon : Pokemon
    {
        public override void Attack()
        {
            Console.WriteLine($"{Name}이(가) 백만볼트!!!");
        }
    }

    public class GhostPokemon : Pokemon
    {
        public override void Attack()
        {
            Console.WriteLine($"{Name}이(가) 최면술!!!");
        }
    }

    public class GrassPokemon : Pokemon
    {
        public override void Attack()
        {
            Console.WriteLine($"{Name}이(가) 씨뿌리기!!!");
        }
    }

    public class RockPokemon : Pokemon
    {
        public override void Attack()
        {
            Console.WriteLine($"{Name}이(가) 바위공격!!!");
        }
    }

    public class Trainer
    {
        public string Name { get; }
        private Pokemon[] pokemons = new Pokemon[6];
        private Pokemon currentPokemon;

        public Trainer(string name)
        {
            Name = name;
            Console.WriteLine($"트레이너 {Name}을(를) 생성했습니다.");
        }

        public void SetPokemons(Pokemon[] pokemonList)
        {
            if (pokemonList.Length != 6)
            {
                Console.WriteLine("포켓몬은 6마리만 등록할 수 있습니다.");
                return;
            }
            pokemons = pokemonList;
        }

        public void Pick(int index)
        {
            if (index < 0 || index >= pokemons.Length || pokemons[index] == null)
            {
                Console.WriteLine("올바르지 않은 선택입니다.");
                return;
            }
            currentPokemon = pokemons[index];
            Console.WriteLine($"{Name}이(가) {currentPokemon.Name}을(를) 선택했습니다!");
        }

        public void Print()
        {
            Console.WriteLine($"{Name}의 포켓몬 목록:");
            foreach (var pokemon in pokemons)
            {
                if (pokemon != null)
                    Console.WriteLine($"- {pokemon.Name}");
            }
        }

        public void Attack()
        {
            if (currentPokemon == null)
            {
                Console.WriteLine("현재 선택된 포켓몬이 없습니다!");
                return;
            }
            currentPokemon.Attack();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pokemon fire = new FirePokemon { Name = "파이리" };
            Pokemon water = new WaterPokemon { Name = "꼬부기" };
            Pokemon electric = new ElectricPokemon { Name = "피카츄" };
            Pokemon ghost = new GhostPokemon { Name = "고오스" };
            Pokemon grass = new GrassPokemon { Name = "이상해씨" };
            Pokemon rock = new RockPokemon { Name = "꼬마돌" };

            Trainer ash = new Trainer("지우");
            ash.SetPokemons(new Pokemon[] { fire, water, electric, ghost, grass, rock });

            ash.Print();
            ash.Pick(2); // 피카츄 선택
            ash.Attack(); // 피카츄의 공격 실행
        }
    }
}
