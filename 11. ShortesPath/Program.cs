namespace _11._ShortesPath
{
	internal class Program
	{
		const int INF = 99999;

		static void Main(string[] args)
		{
			int[,] graph = new int[8, 8]
			{
				{ INF, INF,   6,   6, INF, INF, INF, INF},
				{ INF, INF,   9, INF, INF,   3, INF, INF},
				{   6,   9, INF, INF, INF, INF,   9, INF},
				{   6, INF, INF, INF, INF, INF, INF,   4},
				{ INF, INF, INF, INF, INF, INF,   9,   8},
				{ INF,   3, INF, INF, INF, INF, INF,   6},
				{ INF, INF,   9, INF,   9, INF, INF, INF},
				{ INF, INF, INF,   4,   8,   6, INF, INF}

			};

			Dijkstra.ShortestPath(in graph, 0, out int[] distance, out int[] path);

			Console.WriteLine("<Dijkstra>");
			PrintDijkstra(distance, path);

			int[,] graph2 = new int[8, 8]
			{
				{ INF,   9, INF,   1, INF, INF, INF, INF},
				{   9, INF, INF,   7, INF, INF,   4, INF},
				{ INF, INF, INF, INF, INF, INF, INF, INF},
				{   1,   7, INF, INF, INF,   3, INF,   7},
				{ INF, INF, INF, INF, INF, INF,   4,   6},
				{ INF, INF, INF,   3, INF, INF, INF, INF},
				{ INF,   1, INF, INF,   4, INF, INF, INF},
				{ INF, INF, INF,   3, INF, INF,   6, INF}

			};

			Dijkstra.ShortestPath(in graph2, 0, out int[] distance2, out int[] path2);

			Console.WriteLine("<Dijkstra>");
			PrintDijkstra(distance2, path2);
			int size2 = graph2.GetLength(0);
			Console.WriteLine(size2);



		}

		private static void PrintDijkstra(int[] distance, int[] path)
		{
			Console.WriteLine($"{"Vertex",7}{"Visit",7}{"Path",7}");//여기 숫자 데이터 갯수 맞춰서 바꿔야함 

			for (int i = 0; i < distance.Length; i++)
			{
				Console.Write($"{i,7}");

				if (distance[i] >= INF)
				{
					Console.Write($"{"INF",7}");
				}
				else
				{
					Console.Write($"{distance[i],7}");
				}

				Console.WriteLine($"{path[i],7}");
			}
		}
	}
}
