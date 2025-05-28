namespace 정수_삼각형
{
    internal class AtticYellow
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()); // 삼각형의 행 수 입력
            int[][] triangle = new int[N][]; // 삼각형을 저장할 2차원 배열

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(' '); // 각 행의 숫자를 공백으로 분리하여 입력받음
                triangle[i] = new int[i + 1]; // 각 행의 크기는 행 번호 + 1

                for (int j = 0; j <= i; j++)
                {
                    triangle[i][j] = int.Parse(input[j]); // 입력받은 숫자를 정수로 변환하여 저장
                }
            }

            // Bottom-up DP
            for (int i = N - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    triangle[i][j] += Math.Max(triangle[i + 1][j], triangle[i + 1][j + 1]); // 현재 위치의 값에 다음 행의 왼쪽 또는 오른쪽 값 중 큰 값을 더함
                }
            }

            // 최대 경로 합 출력
            Console.WriteLine(triangle[0][0]);
        }
    }
}
