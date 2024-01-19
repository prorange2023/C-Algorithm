using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
	internal class DivideAndConquer
	{

		/*************************************************************************
         * 분할정복 (Divide and Conquer)
         * 
         * 큰 문제를 작은 문제로 나눠서 푸는 하향식 접근 방식
         * 분할을 통해서 해결하기 쉬운 작은 문제로 나눈 후 정복한 후 병합하는 과정
         **************************************************************************/
		/* 큰 문제를 풀어낼 때에 너무 커서 감이 안오면 작은문제로 쪼개면 된다
		 * 문제를 쪼개다보면 해결가능한 쉬운문제가 될 것이다.
		 * 이걸 해결하고나면 이걸 다시 모아서 큰 문제를 해결 가능할 것이다
		 * 그래서 분할 정복
		 */


		// 예시 - 거듭 제곱

		// 2^ 16 -> 4^8 -> 8^4-> 16^4 -> 256^2
		// 문제를 해결하기 쉽게 만든다. 이것이 분할 정복


		int Pow(int x, int n) // 분할정복, 이렇게하면 시간복잡도가 O(log n) 2^ 16승이면 연산횟수 9 이런식으로 줄어듬
		{
			if (n == 1)
			{
				return x;
			}

			if (n % 2 == 0)
			{
				return Pow(x * x, n / 2);
			}
			else
			{
				return Pow(x * x, n / 2) * x;
			}
		}

		int Power(int x, int n)  // 이렇게 하면 시간복잡도가 O(n) 2 ^ 16승이면 연산횟수 15
		{
			int result = 1;
			for (int i = 0; i < n; i++)
			{
				result *= x;

			}
			return result;
		}

		int Power2(int x, int n)  // 동적계획법
		{
			
		}
	}
}
