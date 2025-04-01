using _30.TextRPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30.TextRPG
{   //static -> 사라지지않고 하나만 존재하면서 게임 클래스 계속 쓸 수 있게.
    internal static class Game  
    {
        // 게임에 필요한 정보들
        private static bool gameOver;

        private static Dictionary<string, Scene> sceneDic;
        private static Scene CurScene;

        private static Player player;
        public static Player Player { get { return player; } }

        // 1. 상황들

        // 게임에 필요한 기능들
        // 1. 게임 시작
        public static void Start()
        {
            // 게임 시작시에 필요한 작업들
            // 게임에 있는 모든 씬들을 보관하고 빠르게 찾아줄 용도로 쓸 자료구조
            sceneDic = new Dictionary<string, Scene>();
            sceneDic.Add("Title", new TitleScene());
            sceneDic.Add("Town", new TownScene());
            sceneDic.Add("Shop", new ShopScene());

            // 처음 시작할 씬을 선정
            CurScene = sceneDic["Title"];

            player = new Player();
            player.Power = 10;
            player.Speed = 8;

        }

        // 2. 게임 종료
        public static void End()
        {
            // 게임 종료시에 필요한 작업들
        }

        // 3. 게임 동작
        public static void Run()
        {
            // 게임 동작시에 필요한 작업들
            while (gameOver == false)
            {
                Console.Clear();    // 화면 초기화

                CurScene.Render();
                Console.WriteLine();
                CurScene.Choice();
                Console.WriteLine();
                CurScene.Input();
                Console.WriteLine();
                CurScene.Result();
                Console.WriteLine();
                CurScene.Wait();
                Console.WriteLine();
                CurScene.Next();
                Console.WriteLine();

            }
        }

        public static void ChangeScene(string sceneName)
        {
            CurScene = sceneDic[sceneName];
        }

        public static void GameOver(string reason)
        {
            Console.Clear();    // 화면 초기화
            Console.WriteLine("******************************");
            Console.WriteLine("*          GameOver         *");
            Console.WriteLine("******************************");
            Console.WriteLine();
            Console.WriteLine(reason);

            gameOver = true;
        }

        public static void PrintInfo()
        {
            Console.WriteLine("******************************");
            Console.WriteLine(" 플레이어 ");
            Console.WriteLine("힘 : {0}\t 속도 : {1}", player.Power, player.Speed);
            Console.WriteLine("******************************");
            Console.WriteLine();
        }
    }
}
