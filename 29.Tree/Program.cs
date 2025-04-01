namespace _29.Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /************************************************************************
            * 그래프 (Graph)
            * 
            * 정점의 모음과 이 정점을 잇는 간선의 모음의 결합
            * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가짐
            * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
            * 간선의 가중치에 따라   연결 그래프, 가중치 그래프가 있음
            ************************************************************************/

            // <인접행렬 그래프>
            // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
            // 2차원 배열을 [출발정점, 도착정점] 으로 표현
            // 장점 : 인접여부 접근이 빠름
            // 단점 : 메모리 사용량이 많음

            /*
            bool[,] graph0 = new bool[8,8];

            graph0[0, 2] = true;
            graph0[2, 0] = true;
            graph0[0, 4] = true;
            graph0[4, 0] = true;
            graph0[1, 2] = true;
            graph0[2, 1] = true;
            graph0[1, 3] = true;
            graph0[3, 1] = true;
            */

            bool[,] graph = new bool[8, 8];

            //graph[0, 1] = 5;  //가중치
            //graph[1, 3] = 6;

            Console.WriteLine("0에서 3으로 연결되어 있는가? {0}", graph[0,3]);

            // 예시 - 양방향 연결 그래프
            bool[,] matrixGraph1 = new bool[5, 5]
            {
            { false, false, false, false,  true },
            { false, false,  true, false, false },
            { false,  true, false,  true, false },
            { false, false,  true, false,  true },
            {  true, false, false,  true, false },
            };

            // [0,2] => 출발정점(0) -> 도착정점(2)
            bool connect = matrixGraph1[0, 2];   // 연결 여부 확인
            matrixGraph1[0, 2] = true;           // 연결추가
            matrixGraph1[0, 2] = false;          // 연결헤제



            const int INF = int.MaxValue;
            // 예시 - 단방향 가중치 그래프 (단절은 최대값으로 표현) INF
            int[,] matrixGraph2 = new int[5, 5]
            {
            {   0, 132, INF, INF,  16 },
            {  12,   0, INF, INF, INF },
            { INF,  38,   0, INF, INF },
            { INF,  12, INF,   0,  54 },
            { INF, INF, INF, INF,   0 },
            };

            // [0,2] => 출발정점(0) -> 도착정점(2)
            int distance = matrixGraph2[0, 2];   // 0에서 2까지 가중치
            matrixGraph2[0, 2] = 10;           // 가중치 변경. 



            // <인접리스트 그래프>
            // 그래프 내의 각 정점의 인접 관계를 표현하는 리스트
            // 인접한 간선만을 리스트에 추가하여 관리
            // 장점 : 메모리 사용량이 적음!!
            // 단점 : 인접여부를 확인하기 위해 리스트 탐색이 필요 (빠르지 않음)

            List<int>[] listGraph = new List<int>[5];
            listGraph[0] = new List<int>() { 2, 4 };
            listGraph[1] = new List<int>() { 2, 3 };
            listGraph[2] = new List<int>() { 0, 1 , 4 };
            listGraph[3] = new List<int>() { 1, 7 };
            listGraph[4] = new List<int>() { 0, 2 };
            listGraph[5] = new List<int>() { 6, 7 };
            listGraph[6] = new List<int>() { 5, 7 };
            listGraph[7] = new List<int>() { 3, 5, 6 };

            listGraph[0].Add(5);        // 연결 추가
            listGraph[5].Add(0);

            listGraph[1].Remove(2);     // 연결 끊기
            listGraph[2].Remove(1);

            bool connect0 = listGraph[0].Contains(1);   // 연결 여부 확인. -> 0에 1이 연결되어있으면 true


            /************************************************************************************/

            GraphNode<int> node0 = new GraphNode<int>(0);
            GraphNode<int> node1 = new GraphNode<int>(1);
            GraphNode<int> node2 = new GraphNode<int>(2);
            GraphNode<int> node3 = new GraphNode<int>(3);
            GraphNode<int> node4 = new GraphNode<int>(4);
            GraphNode<int> node5 = new GraphNode<int>(5);
            GraphNode<int> node6 = new GraphNode<int>(6);
            GraphNode<int> node7 = new GraphNode<int>(7);

            node0.AddEdge(node3);
            node3.AddEdge(node0);
            node0.AddEdge(node4);
            node4.AddEdge(node0);

        }

        public abstract class Graph<T>
        {
            public abstract void AddEdge(int from, int to);
            public abstract void RemoveEdge(int from, int to);
            public abstract void IsConnected(int from, int to);
        }


        public class GraphNode<T>       // 채개적으로 관리 가능. -> 코드가 많이 늘어남.
        {
            private T vertax;

            public T Vertax { get { return vertax; } set { vertax = value; } }

            private List<GraphNode<T>> edges = new List<GraphNode<T>>();

            public GraphNode(T vertex)
            {
                this.vertax = vertex;
            }

            public void AddEdge(GraphNode<T> node) 
            {   
                // 연결 하기
                edges.Add(node);
            }

            public void RemoveEdge(GraphNode<T> node)
            {
                // 연결 끊기
                edges.Remove(node);
            }

            public bool IsConnect(GraphNode<T> node)
            {
                return edges.Contains(node); 
            }



        }



    }
}
