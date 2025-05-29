using System.Text;

namespace 별_찍기___10
{
    internal class AtticYellow_ver2
    {
        static char[,] map; // 2차원 배열로 맵을 저장

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()); // 입력값 N을 받음
            map = new char[N, N]; // N x N 크기의 2차원 배열 초기화
            StringBuilder sb = new StringBuilder();

            DrawStars(0, 0, N, false);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sb.Append(map[i, j]); // 각 위치에 저장된 문자를 출력
                }
                sb.AppendLine(); // 각 행의 끝에 줄바꿈 추가
            }

            Console.Write(sb.ToString()); // 한 번에 출력
        }

        static void DrawStars(int x, int y, int size, bool isBlank)
        {
            // 현재 위치가 비어 있어야 하는 경우
            if (isBlank)
            {
                for (int i = x; i < x + size; i++)
                {
                    for (int j = y; j < y + size; j++)
                    {
                        map[i, j] = ' '; // 해당 위치를 공백으로 설정
                    }
                }
                return;
            }

            // 별을 그릴 크기가 1인 경우
            if (size == 1)
            {
                map[x, y] = '*';
                return;
            }

            int newSize = size / 3; // 새로운 크기 계산
            int count = 0; // 별을 그리는 카운트 변수

            // 3x3 영역으로 나누어 별을 그리기
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    count++;
                    bool nextBlank = (count == 5);
                    DrawStars(x + i * newSize, y + j * newSize, newSize, nextBlank);
                }
            }
        }
    }
}
