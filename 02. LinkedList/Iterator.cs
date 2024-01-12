﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList
{
	internal class Iterator
	{
		void main1()
		{
			List<int> list = new List<int>();
			LinkedList<int> linkedlist = new LinkedList<int>();
			SortedSet<int> set = new SortedSet<int>();


			for (int i = 0; i < 10; i++)
			{
				list.Add(i);
				linkedlist.AddLast(i);
			}

			for (int i = 0;i < 10;i++)
			{
				Console.WriteLine(list[i]);
			}

			for (LinkedListNode<int> node = linkedlist.First; node != null; node = node.Next)
			{
				Console.WriteLine($"{node.Value}");
			}
			
			// 연결리스트는 출력하려면 이렇게 해야됨.index 개념이 없으니까. 근데 이러면 문제가 있음
			// 자료구조마다 골때리므로 처음부터 끝까지 반복하고 싶으면 foreach 써봐

			foreach (int value in linkedlist)
			{
				Console.WriteLine($"{value}");
			}
			// 이거 써
			foreach (int value in list)// foreach 반복이 가능한것만 가능한데 그 걸 정의 하는게 IEnumerable
			{
				Console.WriteLine($"{value}");
			}
			// 내부구조 몰라도 처음부터 끝까지 반복 가능

			foreach(int value in Func())
			{
				Console.WriteLine($"{value}");
			}

			
		}
		//public static float Average(IEnumerable<int> container)
		//{
		//	float average = 0;
		//	int count = 0;
		//	foreach(int value in container)
		//	{
		//		average += value;
		//		count++;
		//	}

		//	return average / count;
		//}
		public static IEnumerable<int> Func()
		{
			yield return 10;
			yield return 20;
			yield return 30;
			// yield 가 없었으면 함수 끝까지 바로감, 있으면 있을떄 멈춤
		}


	}
}
