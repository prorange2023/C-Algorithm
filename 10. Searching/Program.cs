namespace _10._Searching
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// 순차탐색
			int[] array = { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };

			int indexof = Array.IndexOf(array, 2); //배열엔 기본적으로 순차탐색 구현되있음.
			Console.WriteLine(indexof);

			Console.Write("순차탐색 배열 : ");
			foreach (int i in array) Console.Write($"{i,2}");

			int sequentialIndex = Searching.SequentialSearch(array, 2);
			Console.WriteLine();
			Console.WriteLine($"순차탐색 결과 위치 : {sequentialIndex}");
			Console.WriteLine();


			// 이진탐색
			// 반드시 정렬된 것에만 써야함

			Console.WriteLine("정렬 전");
			int binarySearch = Array.BinarySearch(array, 2);
			Console.WriteLine($"정렬 전 이진탐색 결과 : {binarySearch}"); // 결과 이상하게 뜸
			int result2 = Searching.BinarySearch(array, 2);
			Console.WriteLine($"정렬 전 구현한 이진탐색 결과 : {result2}");

			Array.Sort(array); // 정렬

			Console.WriteLine("정렬 후");
			binarySearch= Array.BinarySearch(array, 2);
			Console.WriteLine($"정렬 후 이진탐색 결과 : {binarySearch}"); // 제대로 나옴
			result2 = Searching.BinarySearch(array, 2);
			Console.WriteLine($"정렬 후 구현한 이진탐색 결과 : {result2}");



			bool[,] graph = new bool[8, 8]
			{
				{ false,  true, false, false, false, false, false, false },
				{  true, false,  true, false, false,  true, false, false },
				{ false,  true, false, false,  true,  true, false, false },
				{ false, false, false, false, false,  true, false, false },
				{ false, false,  true, false, false, false,  true,  true },
				{ false,  true,  true,  true, false, false, false, false },
				{ false, false, false, false,  true, false, false, false },
				{ false, false, false, false,  true, false, false, false },
			};


			// DFS 탐색
			Searching.DFS(in graph, 0, out bool[] dfsVisited, out int[] dfsPath);
			Console.WriteLine("<DFS>");
			PrintGraphSearch(dfsVisited, dfsPath);
			Console.WriteLine();


			// BFS 탐색
			Searching.BFS(in graph, 0, out bool[] bfsVisited, out int[] bfsPath);
			Console.WriteLine("<BFS>");
			PrintGraphSearch(bfsVisited, bfsPath);
			Console.WriteLine();
		}

		private static void PrintGraphSearch(bool[] visited, int[] path)
		{
			Console.WriteLine($"{"Vertex",8}{"Visit",8}{"Path",8}");

			for (int i = 0; i < visited.Length; i++)
			{
				Console.WriteLine($"{i,8}{visited[i],8}{path[i],8}");
			}
		}
	}
}
