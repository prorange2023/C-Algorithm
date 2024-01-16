using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	/******************************************************************
	* 어댑터 패턴 (Adapter)
	* 
	* 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
	* 스택은 리스트를 이용해서 구현
	* 돼지코 생각하면 됨 다른데서 쓰는 걸 쓰려고 변환한것
	******************************************************************/
	internal class Stack<T>
	{
		private List<T> container;

		public Stack()
		{
			container = new List<T>();
		}

		public int Count { get { return container.Count; } }

		public void Push(T item) // 집어넣기
		{
			container.Add(item);
		}

		public T Pop() // 꺼내기
		{
			T item = container[container.Count - 1];
			container.RemoveAt(container.Count - 1);
			return item;
		}

		public T Peek() // 다음으로 꺼내질것, 즉 제일 위에 있는것 확인
		{
			return container[container.Count - 1];
		}
	}
}
