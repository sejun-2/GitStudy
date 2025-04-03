namespace _0403.Practice
{
    internal class Program
    {
        /*
            1. 물리 및 충돌 감지 알고리즘

            AABB 충돌 감지: 두 개의 축 정렬 경계 상자(Axis-Aligned Bounding Box)가 겹치는지 확인하는 알고리즘으로, 
            2D 및 3D 게임에서 간단한 충돌 감지에 사용됩니다.
            단, 객체가 회전하지 않는 경우에 적합합니다.
        */
        public class AABB
        {
            public int X, Y, Width, Height;

            //축 정렬 바운딩 박스 충돌 감지를 수행하려면, 물체의 다음 네 가지 특성이 필요.
            public AABB(int x, int y, int width, int height)
            {
                X = x;
                Y = y;
                Width = width;
                Height = height;
            }

            public bool IsColliding(AABB other)
            {
                return X < other.X + other.Width &&
                       X + Width > other.X &&
                       Y < other.Y + other.Height &&
                       Y + Height > other.Y;
            }
        }


        /*
            2. 경로 탐색 알고리즘
            A 알고리즘*: 최단 경로를 찾는 데 자주 사용되는 알고리즘으로, NPC의 이동 경로나 전략 게임에서 유닛 이동에 활용됩니다.
        */
        public class Node
        {
            public int X, Y;
            public int G, H; // G: 시작점에서 현재 노드까지의 비용, H: 휴리스틱(목표까지의 추정 비용)
            public int F => G + H; // 총 비용
            public Node Parent;

            public Node(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        //  3. 랜덤 및 생성 알고리즘
        //랜덤 맵 생성: 던전 크롤러 게임이나 로그라이크 게임에서 무작위로 맵을 생성하는 알고리즘입니다(예: 퍼린 노이즈, 셀룰러 오토마타).
        public class RandomWalkGenerator
        {
            public bool[,] GenerateMap(int width, int height, int steps)
            {
                bool[,] grid = new bool[width, height];
                Random rnd = new Random();
                int x = rnd.Next(width);
                int y = rnd.Next(height);

                grid[x, y] = true;

                for (int i = 0; i < steps; i++)
                {
                    switch (rnd.Next(4))
                    {
                        case 0: x = Math.Max(0, x - 1); break; // 왼쪽
                        case 1: x = Math.Min(width - 1, x + 1); break; // 오른쪽
                        case 2: y = Math.Max(0, y - 1); break; // 위쪽
                        case 3: y = Math.Min(height - 1, y + 1); break; // 아래쪽
                    }
                    grid[x, y] = true;
                }

                return grid;
            }
        }



        static void Main(string[] args)
        {
            // 1.두개의 인스턴스화 된 객체가 있다면 IsColliding 코드를 사용하여 AABB 충돌 감지  
            AABB box1 = new AABB(0, 0, 30, 30);     //30X30 크기의 박스
            AABB box2 = new AABB(25, 25, 30, 30);   //25x25 위치에서 30X30 크기의 박스 5만큰 겹침
            

            if (box1.IsColliding(box2))
            {
                Console.WriteLine("Collision Detected!");   //충돌 감지
            }

            //  3. 랜덤 및 생성 알고리즘
            // 사용 예시
            RandomWalkGenerator generator = new RandomWalkGenerator();
            bool[,] map = generator.GenerateMap(10, 10, 20);




            /*
                Raycasting: 광선을 쏘아 특정 방향에서 물체와의 충돌 여부를 확인하는 방법으로, FPS 게임의 조준 시스템 등에 활용됩니다.

                물리 시뮬레이션: 중력, 마찰, 반발력 등을 계산하여 오브젝트의 움직임을 자연스럽게 구현합니다. Unity의 물리 엔진(PhysX)과 함께 사용하면 효과적입니다.
            */



            /*
                다익스트라 알고리즘: 가중치가 있는 그래프에서 최단 경로를 찾는 데 사용됩니다. A*와 유사하지만 히유리스틱이 없습니다.

               
                랜덤 이벤트: 아이템 드랍, 적 스폰 등 확률 기반 이벤트를 처리합니다.

                4. 데이터 처리 알고리즘
                정렬 알고리즘: 점수판이나 리더보드에서 데이터를 정렬할 때 사용됩니다(예: 퀵소트, 병합 정렬).

                검색 알고리즘: 대규모 데이터에서 특정 값을 빠르게 찾기 위해 이진 검색이나 해시 테이블을 활용합니다.

                5. AI 관련 알고리즘
                상태 기계(Finite State Machine): NPC의 행동 패턴(예: 공격, 방어, 순찰)을 구현하는 데 사용됩니다.

                미니맥스(Minimax): 체스 같은 턴제 전략 게임에서 최적의 수를 계산하기 위해 사용됩니다.

                강화 학습: AI가 환경과 상호작용하며 스스로 학습하도록 설계된 알고리즘입니다.

                6. 그래픽 및 애니메이션 알고리즘
                LERP(Linear Interpolation): 오브젝트의 위치나 색상을 부드럽게 전환하는 데 사용됩니다.

                파티클 시스템: 폭발 효과, 연기 등 다양한 시각 효과를 구현합니다.

                7. 기본 수학 알고리즘
                벡터 연산: 오브젝트 이동, 회전 등에 필수적입니다.

                삼각 함수: 각도 계산이나 원형 궤도 이동에 활용됩니다.

                행렬 연산: 3D 변환(회전, 이동, 스케일링)을 처리합니다.

                8. 기타 유용한 알고리즘
                이벤트 처리: C#의 이벤트 기반 프로그래밍을 활용해 사용자 입력이나 게임 상태 변화를 관리합니다.

                최적화 알고리즘: 성능 향상을 위해 데이터 캐싱, 메모리 관리(Garbage Collector 활용) 등을 포함합니다.
             */







        }
    }
}
