using System;

namespace IntegerTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 삼각형 크기 입력
            int n = int.Parse(Console.ReadLine());

            // 삼각형 숫자 저장할 2차원 배열 생성
            int[][] triangle = new int[n][];

            for (int i = 0; i < n; i++)
            {
                // 각 줄마다 숫자 입력
                string[] inputs = Console.ReadLine().Split(' ');
                triangle[i] = new int[i + 1];

                for (int j = 0; j <= i; j++)
                {
                    triangle[i][j] = int.Parse(inputs[j]);
                }
            }

            // 아래에서 위로 올라가며 최대 합 계산
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    // 아래 두 숫자 중 큰 값 선택 후 현재 숫자와 더하기
                    triangle[i][j] += Math.Max(triangle[i + 1][j], triangle[i + 1][j + 1]);
                }
            }

            // 결과: 맨 위 값이 최대 합
            Console.WriteLine(triangle[0][0]);
        }
    }
}
