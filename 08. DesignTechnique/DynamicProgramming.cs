using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
	internal class DynamicProgramming
	{
		/**********************************************************************************
         * 동적계획법 (Dynamic Programming)
         * 
         * 작은문제의 해답을 큰문제의 해답의 부분으로 이용하는 상향식 접근 방식
         * 주어진 문제를 해결하기 위해 부분 문제에 대한 답을 계속적으로 활용해 나가는 기법
         * 작은 문제의 해법을 기록(메모라이징)해두는 특징이 있음
         * 필연적으로 저장소가 필요함.
         * 메모이제이션 이라고도 함
         ***********************************************************************************/
		/*
		 * 분할정복은 큰 문제를 작은문제로 쪼개는 하향식, 이건 상향식. 
		 * 정의를 큰문제에 맞추면 분할정복, 작은문제에 맞추면 동적계획법
		 * 어떤 알고리즘 설계 기법이 효율적인가? 는 당연히 문제마다 다르다.
		 */


		// 예시 - 피보나치 수열
		int Fibonachi(int x)  // 동적계획법 O(n)
		{
			int[] fibonachi = new int[x + 1];
			fibonachi[1] = 1;
			fibonachi[2] = 1;

			// 전거와 전전꺼를 알아야 이번값을 구함. 전형적인 동적계획법
			// 작은 문제의 해답을 알면 큰문제를 풀떄 이용해서 푼다

			for (int i = 3; i <= x; i++)
			{
				fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
			}

			return fibonachi[x];
		}

		int fibonachi(int x) // 분할정복 O(n^2) 
		{
			if (x == 1)
				return 1;
			else if (x == 2)
				return 1;

			return fibonachi(x - 1) + fibonachi(x - 2);
		}

	}
}
