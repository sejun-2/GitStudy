namespace _34.DesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 스테이지 1-1
            MonsterFactory level1Factory = new MonsterFactory();
            level1Factory.upLevel = 0; // 몬스터 레벨 증가량 초기화
            level1Factory.rate = 1; // 몬스터 hp 100%

            // 1. 처음 맵 만들어 졌을 떄 -> 몬스터 3마리
            for (int i = 0; i < 3; i++)
            {
                Monster monster = level1Factory.Create("슬라임");
                Console.WriteLine($"몬스터 생성 : {monster.name} , 레벨 : {monster.level}");
            }

            // 2. 다음 장소로 이동했을 때 -> 몬스터 5마리
            Monster monster1 = level1Factory.Create("슬라임");
            Monster monster2 = level1Factory.Create("슬라임");
            Monster monster3 = level1Factory.Create("슬라임");
            Monster monster4 = level1Factory.Create("고블린", 5); // 이 고블린만 레벨 5
            Monster monster5 = level1Factory.Create("고블린");

            // 3. 보스룸 입장하면 -> 몬스터 2마리
            Monster bossMonster = level1Factory.Create("오크족장");
            Monster subMonster1 = level1Factory.Create("고블린");
            Monster subMonster2 = level1Factory.Create("고블린");



            // 스테이지 2-1
            MonsterFactory level2Factory = new MonsterFactory();    // level2 factory 생성
            level2Factory.upLevel = 5; // 몬스터 레벨 증가량
            level2Factory.rate = 1.1f; // 몬스터 hp 증가량 110%
            Monster level2monster1 = level2Factory.Create("슬라임");
            Monster level2monster2 = level2Factory.Create("슬라임");

            // 스테이지 3-1
            MonsterFactory level3Factory = new MonsterFactory();    // level3 factory 생성
            level3Factory.upLevel = 10; // 몬스터 레벨 증가량
            level3Factory.rate = 1.2f; // 몬스터 hp 증가량 120%


        }
    }

    public class MonsterFactory
    {
        public int upLevel; // 몬스터 레벨 증가량
        public float rate; // 몬스터 hp 증가량
        public Monster Create(string name)
        {
            Monster monster; // 몬스터 객체를 초기화
            switch (name)
            {
                case "슬라임":
                    return new Monster("슬라임", 1 + upLevel, 100);
                case "고블린":
                    return new Monster("고블린", 3 + upLevel, 200);
                case "오크":
                    return new Monster("오크", 5 + upLevel, 500);    // 나중에 쉽게 추가도 가능
                case "오크족장":
                    return new Monster("오크족장", 10 + upLevel, 2000);
                default:
                    return null; // 몬스터가 없을 경우 null 리턴
            }

            monster.hp = (int)(monster.hp * rate); // 몬스터 hp 업스케일링
            return monster; // 몬스터 객체 리턴
        }

        public Monster Create(string name, int level)   // 오버로딩
        {
            Monster monster = Create(name);
            monster.level = level;
            return monster;
        }
    }

    public class  Monster
    {
        public string name;
        public int level;
        public int hp;

        public Monster(string name, int level, int hp)
        {
            this.name = name;
            this.level = level;
            this.hp = hp;
        }
    }








}
