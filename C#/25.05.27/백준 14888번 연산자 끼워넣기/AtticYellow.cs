namespace 연산자_끼워넣기
{
    internal class AtticYellow
    {
        static int N;   // 숫자의 개수

        static int[] numbers;   // 숫자 배열
        static int max = int.MinValue;  // 최대값
        static int min = int.MaxValue;  // 최소값

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());  // 숫자의 개수 입력
            numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);  // 숫자 배열
            int[] operators = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);  // 연산자 배열

            Operation(1, numbers[0], operators[0], operators[1], operators[2], operators[3]);   // 첫 번째 숫자를 기준으로 연산 시작

            // 결과 출력
            Console.WriteLine(max);
            Console.WriteLine(min);
        }

        // 재귀적으로 연산을 수행하는 함수
        static void Operation(int index, int current, int plus, int minus, int multiply, int divide)
        {
            // 종료 조건: 모든 숫자를 사용한 경우
            if (index == N)
            {
                max = Math.Max(max, current);
                min = Math.Min(min, current);
                return;
            }

            int next = numbers[index];  // 다음 숫자

            if (plus > 0)
            {
                Operation(index + 1, current + next, plus - 1, minus, multiply, divide);    // 정수 덧셈 처리
            }
            if (minus > 0)
            {
                Operation(index + 1, current - next, plus, minus - 1, multiply, divide);    // 정수 뺄셈 처리
            }
            if (multiply > 0)
            {
                Operation(index + 1, current * next, plus, minus, multiply - 1, divide);    // 정수 곱셈 처리
            }
            if (divide > 0)
            {
                int result = current < 0 ? -(-current / next) : current / next;     // 정수 나눗셈 처리 (음수일 경우 올림 처리)
                Operation(index + 1, result, plus, minus, multiply, divide - 1);    // 정수 나눗셈 처리
            }
        }
    }
}
