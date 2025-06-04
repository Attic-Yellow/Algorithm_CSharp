namespace 스타트와_링크
{
    internal class AtticYellow
    {
        static int N; // 플레이어의 수
        static int[,] S; // 능력치 행렬
        static bool[] visited; // 팀 선택 여부를 저장하는 배열
        static int minDiff = int.MaxValue; // 최소 능력치 차이

        static void Main()
        {
            N = int.Parse(Console.ReadLine());
            S = new int[N, N];
            visited = new bool[N];

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < N; j++)
                {
                    S[i, j] = int.Parse(input[j]);
                }
            }

            DFS(0, 0);
            Console.WriteLine(minDiff);
        }

        // Depth First Search (DFS)를 사용하여 팀을 선택
        static void DFS(int depth, int idx)
        {
            // 팀이 완성되면 능력치를 계산
            if (depth == N / 2)
            {
                CalculateTeamAbility();
                return;
            }

            // 팀원을 선택하는 반복문
            for (int i = idx; i < N; i++)
            {
                if (!visited[i]) // 현재 플레이어가 선택되지 않은 경우
                {
                    visited[i] = true;
                    DFS(depth + 1, i + 1);
                    visited[i] = false;
                }
            }
        }

        // 팀의 능력치를 계산하고 최소 차이를 업데이트
        static void CalculateTeamAbility()
        {
            int startTeam = 0; // 스타트 팀의 능력치
            int linkTeam = 0; // 링크 팀의 능력치

            // 능력치 계산
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (visited[i] && visited[j]) // 팀이 선택된 경우와 선택되지 않은 경우에 따라 능력치를 계산
                    {
                        startTeam += S[i, j] + S[j, i];
                    }
                    else if (!visited[i] && !visited[j]) // 팀이 선택되지 않은 경우와 선택된 경우에 따라 능력치를 계산
                    {
                        linkTeam += S[i, j] + S[j, i];
                    }
                }
            }

            int diff = Math.Abs(startTeam - linkTeam); // 능력치 차이 계산
            if (diff == 0)
            {
                Console.WriteLine(0); // 능력치 차이가 0이면 바로 출력하고 종료
                Environment.Exit(0); // 능력치 차이가 0이면 바로 종료
            }

            minDiff = Math.Min(minDiff, diff);
        }
    }
}
