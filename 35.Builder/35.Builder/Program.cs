using System.Text;

namespace _35.Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();  // 스트링 빌더를 사용하여 문자열을 조합함
            stringBuilder.AppendLine("안녕하세요")   // AppendLine() 한줄 붙이기
                .AppendLine("반갑습니다.")   // AppendLine() 메소드를 사용하여 줄바꿈을 추가함
                .Append("저는 ")
                .Append("Name")             // Append() 메소드를 사용하여 줄바꿈 없이 붙이기
                .AppendLine("라고 합니다.")
                .Replace("Name", "김전사");   // Replace() 메소드를 사용하여 문자열을 바꿈

            Console.WriteLine(stringBuilder.ToString());   // ToString() 메소드를 사용하여 최종 문자열을 출력함


            GameObject gameObject = new GameObject();

            gameObject.SetX(10).SetY(5).SetZ(3);    // 아래의 return this; 를 사용하여 체인 메소드를 구현함


            MonsterBuilder orcArcherBuilder = new MonsterBuilder();
            orcArcherBuilder.SetName("오크 궁수")   // 체인 메소드를 사용하여 MonsterBuilder 를 설정함
                .SetWeapon("나무 활")
                .SetArmor("가죽갑옷");

            MonsterBuilder orcWarriorBuilder = new MonsterBuilder();
            orcWarriorBuilder.SetName("오크 전사")   // 체인 메소드를 사용하여 MonsterBuilder 를 설정함
                .SetWeapon("철 검")
                .SetArmor("철 갑옷");

            Monster orcArcher = orcArcherBuilder.Build();
            Console.WriteLine("이름 : {0}, 무기 : {1}, 갑옷 : {2}", orcArcher.name, orcArcher.weapon, orcArcher.armor);

            Monster orcWarrior = orcWarriorBuilder.Build();
            Console.WriteLine("이름 : {0}, 무기 : {1}, 갑옷 : {2}", orcWarrior.name, orcWarrior.weapon, orcWarrior.armor);


            HambergerBuilder chickbergerBuilder = new HambergerBuilder();
            chickbergerBuilder           // 체인 메소드를 사용하여 HambergerBuilder 를 설정함
                .SetSource("매운양념")
                .SetPatty("치킨 패티");

            HambergerBuilder bigmacBuilder = new HambergerBuilder();
            bigmacBuilder.SetBread("참깨빵")   // 체인 메소드를 사용하여 HambergerBuilder 를 설정함
                .SetPatty("순쇠고기패티두장")
                .SetSource("특별한 소스")
                .SetVegetable("양상추");

            HambergerBuilder shirimpbergerBuilder = new HambergerBuilder();
            shirimpbergerBuilder.SetBread("호밀빵")   // 체인 메소드를 사용하여 HambergerBuilder 를 설정함
                .SetPatty("새우 패티")
                .SetSource("마요네즈");

            Hamberger chickberger = chickbergerBuilder.Build();
            Console.WriteLine("빵 : {0}, 소스 : {1}, 패티 : {2}, 야채 : {3}", chickberger.bread, chickberger.source, chickberger.patty, chickberger.vegetable);
        }

    }

    public class GameObject
    {
        public int x;
        public int y;
        public int z;

        public GameObject SetX(int x)
        {
            this.x = x;
            return this;    // this 는 gameObject.SexX(10) 의 gameObject 를 의미함
        }

        public GameObject SetY(int y)
        {
            this.y = y;
            return this;    // this 는 gameObject.SetX(10).SetY(5) 의 gameObject 를 의미함
        }

        public GameObject SetZ(int z)
        {
            this.z = z;
            return this;    // this 는 gameObject.SetX(10).SetY(5).SetZ(3) 의 gameObject 를 의미함
        }
    }

    public class MonsterBuilder
    {
        public string name;
        public string weapon;
        public string armor;

        public MonsterBuilder()
        {
            name = "몬스터";
            weapon = "기본무기";
            armor = "기본갑옷";
        }
        public Monster Build()
        {
            Monster monster = new Monster();
            monster.name = this.name;
            monster.weapon = this.weapon;
            monster.armor = this.armor;
            return monster;
        }
        public MonsterBuilder SetName(string name)
        {
            this.name = name;
            return this;    
        }
        public MonsterBuilder SetWeapon(string weapon)
        {
            this.weapon = weapon;
            return this;    
        }
        public MonsterBuilder SetArmor(string armor)
        {
            this.armor = armor;
            return this;    
        }
    }
    public class Monster
    {
        public string name;
        public string weapon;
        public string armor;
    }


    public class HambergerBuilder
    {
        public string bread;
        public string source;
        public string patty;
        public string vegetable;
        public HambergerBuilder()
        {
            bread = "기본빵";
            source = "캐찹";
            patty = "기본패티";
            vegetable = "양상추";
        }
        public Hamberger Build()
        {
            Hamberger hamberger = new Hamberger();
            hamberger.bread = this.bread;
            hamberger.source = this.source;
            hamberger.patty = this.patty;
            hamberger.vegetable = this.vegetable;
            return hamberger;
        }
        public HambergerBuilder SetBread(string bread)
        {
            this.bread = bread;
            return this;    
        }
        public HambergerBuilder SetSource(string source)
        {
            this.source = source;
            return this;
        }
        public HambergerBuilder SetPatty(string patty)
        {
            this.patty = patty;
            return this;
        }
        public HambergerBuilder SetVegetable(string vegetable)
        {
            this.vegetable = vegetable;
            return this;
        }
    }
    public class Hamberger
    {
        public string bread;
        public string source;
        public string patty;
        public string vegetable;
    }

}