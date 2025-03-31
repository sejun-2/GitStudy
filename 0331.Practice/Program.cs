using static _0331.Practice.Program;

namespace _0331.Practice
{
    internal class Program
    {
        // 그래프 행렬 그려보기

        static void Main(string[] args)
        {
            List<int>[] listGraph = new List<int>[10];

            listGraph[0] = new List<int> { 1, 3, 4 };
            listGraph[1] = new List<int> { 3, 5, 6 };
            listGraph[2] = new List<int> { 6 };
            listGraph[3] = new List<int> { 5, 7 };
            listGraph[5] = new List<int> { 1 };
            listGraph[6] = new List<int> { 2, 5, 7 };
            listGraph[7] = new List<int> { 5, 6 };

            bool contained = listGraph[0].Contains(2);
            Console.WriteLine(contained);



            GraphNode<int> node0 = new GraphNode<int>(0);
            GraphNode<int> node1 = new GraphNode<int>(1);
            GraphNode<int> node2 = new GraphNode<int>(2);
            GraphNode<int> node3 = new GraphNode<int>(3);
            GraphNode<int> node4 = new GraphNode<int>(4);
            GraphNode<int> node5 = new GraphNode<int>(5);
            GraphNode<int> node6 = new GraphNode<int>(6);
            GraphNode<int> node7 = new GraphNode<int>(7);

            node0.AddEdge(node1);
            node0.AddEdge(node3);
            node0.AddEdge(node4);
            node1.AddEdge(node3);
            node1.AddEdge(node5);
            node1.AddEdge(node6);
            node2.AddEdge(node6);
            node3.AddEdge(node5);
            node3.AddEdge(node7);
            node5.AddEdge(node1);
            node6.AddEdge(node2);
            node6.AddEdge(node5);
            node6.AddEdge(node7);
            node7.AddEdge(node5);
            node7.AddEdge(node6);

            
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
