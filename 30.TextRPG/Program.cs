namespace _30.TextRPG
{
    internal class Program
    {
        /*
            자... 게임 만들자..
            1. 깃 설정 (백업!! 중요!!)
            2. 간이 기획과 프로젝트 구조 설계 (객체지향에서는 설계가 필요!!)
            3. 


                - Text RPG 는
            (1) 상황 설명이 주어지고
            (2) 선택지를 제시
            (3) 선택지 입력을 대기
            (4) 선택한 선택지에 따라서 결과를 출력
            (5) 다음으로 넘어가기 대기 (아무키나 누르세요)
            (6) 다음 상황으로 전환
         */

        static void Main(string[] args)
        {
            Game.Start();
            Game.Run();
            Game.End();
            

        }
    }
}
