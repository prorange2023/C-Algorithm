using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._ShortesPath
{
	internal class Dijkstra
	{
		/********************************************************************
         * 다익스트라? 데이크스트라? 알고리즘 (Dijkstra Algorithm)
         * 
         * 가중치를 고려하여 최단거리를 구할 수 있는 알고리즘
         * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
         * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
         * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
         * 왜 가까운데부터 고르나요? 먼곳부터 고르면 의미가 없으니까
         * 
         * C = 가장 가까운곳 선정
         * ac = ab+bc 이런식으로 대체
         ********************************************************************/

		const int INF = 99999; // 단절

		public static void ShortestPath(in int[,] graph, in int start, out int[] distance, out int[] path)
		{
			int size = graph.GetLength(0);
			bool[] visited = new bool[size];
			distance = new int[size];
			path = new int[size];

			for (int i = 0; i < size; i++)
			{
				distance[i] = INF;
				path[i] = -1;
				visited[i] = false;
			}
			distance[start] = 0;

			for (int i = 0; i < size; i++)
			{
				// 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
				int next = -1; // 방문하지 않은 결과 / 다음으로 탐색할 정점/ 제일 가까운 정점
				int minCost = INF; // 가장 가까운 값
				for (int j = 0; j < size; j++)
				{
					if (!visited[j] && //방문하지 않았으면서
						distance[j] < minCost/*거리가 더 짧은 경우*/)
					{
						next = j;
						minCost = distance[j];
					}
				}

				if (next < 0)
					break;

				// 위까지는 방문하지 않았으면서 가장 가까운 정점을 찾는 과정 

				// 2. 직접연결된 거리보다 거쳐서 더 짧아진다면 갱신.
				for (int j = 0; j < size; j++)
				{
					// distance[j] : 목적지까지 직접 연결된 거리
					// distance[next] : 탐색중인 정점까지 거리
					// graph[next, j] : 탐색중인 정점부터 목적지의 거리
					if (distance[j] > distance[next] + graph[next, j])
					{
						distance[j] = distance[next] + graph[next, j];
						path[j] = next;
					}
				}
				visited[next] = true;
			}
		}

	}
}
