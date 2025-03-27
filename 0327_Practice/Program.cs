using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace _0327_Practice
{
    internal class Program
    {
        // 게임 장비 착용 시스템
        public class Player
        {
            private int hp = 100;
            private int defense = 10;

            private Armor armor;

            public event Action OnTakeDamaged;

            public void TakeDamage(int damage)
            {
                Console.WriteLine("플레이어가 타격을 받습니다.");
                int totalDamage = defense > damage ? 0 : damage - defense;
                hp -= totalDamage;

                OnTakeDamaged?.Invoke();
            }

            public void Equip(Armor armor)
            {
                Console.WriteLine("플레이어가 장비를 착용합니다.");
                this.armor = armor;
                defense += armor.Defense;
                Console.WriteLine("플레이어의 방어력이 {0} 이 되었습니다.", defense);

                OnTakeDamaged += armor.TakeDamage;
                armor.OnBreaked += UnEquip;
            }

            public void UnEquip()
            {
                if (armor != null)
                {
                    Console.WriteLine("플레이어가 장비를 해제합니다.");
                    armor.OnBreaked -= UnEquip;
                    OnTakeDamaged -= armor.TakeDamage;

                    defense -= armor.Defense;
                    this.armor = null;
                    Console.WriteLine("플레이어의 방어력이 {0} 이 되었습니다.", defense);
                }
            }
        }

        public class Armor
        {
            private int durability = 3;
            private int defense = 10;
            public int Defense { get { return defense; } private set { defense = value; } }

            public event Action OnBreaked;

            public void TakeDamage()
            {
                Console.WriteLine("장비가 내구도가 닳습니다.");
                durability--;
                Console.WriteLine("장비의 내구도가 {0} 이 되었습니다.", durability);
                if (durability <= 0)
                {
                    Break();
                }
            }

            private void Break()
            {
                Console.WriteLine("갑옷이 부셔집니다.");

                OnBreaked?.Invoke();
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Armor armor = new Armor();

            player.Equip(armor);

            player.TakeDamage(1);
            player.TakeDamage(1);
            player.TakeDamage(1);
            player.TakeDamage(1);
        }

    }
}
