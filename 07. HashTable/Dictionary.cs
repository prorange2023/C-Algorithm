using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	// 키는 중복되면 안됨.
	// IEquatable 은 같은지 안같은지 확인하는 인터페이스
	public class Dictionary<TKey/*키타입*/, TValue/*밸류타입*/> where TKey : IEquatable<TKey>
	{

		// 테이블 크기는 소수인게 좋다. 분산이 잘 되기 때문에.

		private const int DefaultCapacity = 1000;

		// 키값과 밸류값을 다담기위해 만드는 구조체
		private struct Entry
		{

			//상황설정 {집어 넣은적 없는 주소지인지, 사용중인 주소지인지, 지워진 주소지인지}
			public enum State { None, Using, Deleted }

			// 지금 이 테이블에 있는 엔트리 상태 표시하는곳
			public State state;
			public TKey key;
			public TValue value;
		}
		// 키와 밸류를 보관할 테이블
		private Entry[] table;
		// 테이블에 있는 데이터의 수
		private int usedCount;

		public Dictionary()
		{
			// 해시테이블 카파시티는 기본적으로 크게. 효율을 높이기 위해서.
			table = new Entry[DefaultCapacity];
			usedCount = 0;
		}

		public TValue this[TKey key] // 인덱서
		{
			get
			{
				if (Find(key, out int index))
				{
					return table[index].value;
				}
				else
				{
					throw new KeyNotFoundException();
				}
			}
			set
			{
				if (Find(key, out int index))
				{
					table[index].value = value;
				}
				else
				{
					if (usedCount > table.Length * 0.7f)
					{
						ReHashing();
					}

					table[index].key = key;
					table[index].value = value;
					table[index].state = Entry.State.Using;
					usedCount++;
				}
			}
		}

		public void Add(TKey key, TValue value)
			//키값을 집어넣는 밸류
		{
			if (Find(key, out int index)) // 우선 있는지 확인해본다
			{
				throw new InvalidOperationException(); // 있었으면 dictionary는 추가를 허용하지 않으므로 
			}
			else
			{
				// 키값이 없었던 경우
				if (usedCount > table.Length * 0.7f)
				{
					ReHashing();
				}

				table[index].key = key; 
				table[index].value = value;
				table[index].state = Entry.State.Using;
				usedCount++;
			}
		}

		public void Clear()
		{
			table = new Entry[DefaultCapacity];
			usedCount = 0;
		}

		public bool ContainsKey(TKey key)
		{
			if (Find(key, out int index))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool Remove(TKey key) // 지우는거 성공했으면 True, 실패했으면 False
		{
			if (Find(key, out int index))
			{
				table[index].state = Entry.State.Deleted;
				return true;
			}
			else
			{
				return false; // 이 키값에 해당하는 값을 못찾았으니까
			}
		}

		private bool Find(TKey key, out int index)
			//키값 있는지 없는지?
		{
			if (key == null)
				throw new ArgumentNullException();

			index = Hash(key); // 해싱
			for (int i = 0; i < table.Length; i++) // 테이블 갯수만큼은 돌 수 있고(효율은 안좋아진다.) 다돌아도 못찾으면 제일아래, 
			{
				if (table[index].state == Entry.State.None)// 그 테이블 위치에 있는지부터 확인하자
				{
					return false; // 데이터가 없었으면 false
				}
				else if (table[index].state == Entry.State.Using && // 누가 쓰고 있는 상황이면서, 그 키값이 지금 찾는 키값이랑 동일하면 (사용중인게 나면)
					key.Equals(table[index].key))
				{
					return true; // 트루 반환
				}
				index = Hash2(index);
				// else if (table(index).state == Entry.State.Deleted) // 지워진 상황. 충돌 때문에 재활용은 안되므로 다음칸으로 가야함.
			}

			index = -1;
			throw new InvalidOperationException(); // 위에서 이어서 오류반환.
		}

		private int Hash(TKey key)
			// 키값을 가지고 해시하는 경우 int로 나온다
		{
			// GetHachCode -> 키값의 해시코드 가져옴
			// math.Abs 절대값주는 함수
			return Math.Abs(key.GetHashCode() % table.Length);
			// 나머지 구하는 식
			// C#의 GetHachCode는 음수도 포함이다. 그래서 절대값주는 함수 넣는것.앱솔루트!
		}

		private int Hash2(int index) // 충돌 후 탐사하는 경우에 쓰임
		{
			// 선형 탐사, 인덱스위치에서 한칸 뒤꺼
			return (index + 1) % table.Length;

			// 제곱 탐사
			// return (index + 1) * (index + 1) % table.Length; // 여기 +1인 이유는 인덱스가 1의 제곱이 되서 무한히 머무르게 될까봐.

			// 이중 해싱
			// return Math.Abs((index + 1).GetHashCode() % table.Length);
		}

		private void ReHashing() // 데이터를 크게 만들어주는경우
		{
			Entry[] oldTable = table;
			table = new Entry[table.Length * 2];
			usedCount = 0;

			for (int i = 0; i < oldTable.Length; i++)
			{
				Entry entry = oldTable[i];
				if (entry.state == Entry.State.Using) //  사용중인것만 복사하고 비어있는것, 지워진것 냅둔다
				{
					Add(entry.key, entry.value);
				}
			}
		}
	}
}
