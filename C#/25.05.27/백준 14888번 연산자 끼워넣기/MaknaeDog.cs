

// See https://aka.ms/new-console-template for more information

//N개의 수로 이루어진 수열 A1, A2, ..., AN이 주어진다. 또, 수와 수 사이에 끼워넣을 수 있는 N-1개의 연산자가 주어진다.
//연산자는 덧셈(+), 뺄셈(-), 곱셈(×), 나눗셈(÷)으로만 이루어져 있다.

//우리는 수와 수 사이에 연산자를 하나씩 넣어서, 수식을 하나 만들 수 있다. 이때, 주어진 수의 순서를 바꾸면 안 된다.

//예를 들어, 6개의 수로 이루어진 수열이 1, 2, 3, 4, 5, 6이고,
//주어진 연산자가 덧셈(+) 2개, 뺄셈(-) 1개, 곱셈(×) 1개, 나눗셈(÷) 1개인 경우에는 총 60가지의 식을 만들 수 있다.
//예를 들어, 아래와 같은 식을 만들 수 있다.
//1 + 2 + 3 - 4×5÷6
//1÷2 + 3 + 4 - 5×6
//1 + 2÷3×4 - 5 + 6
//1÷2×3 - 4 + 5 + 6
//식의 계산은 연산자 우선 순위를 무시하고 앞에서부터 진행해야 한다.
//또, 나눗셈은 정수 나눗셈으로 몫만 취한다. 음수를 양수로 나눌 때는 C++14의 기준을 따른다.
//즉, 양수로 바꾼 뒤 몫을 취하고, 그 몫을 음수로 바꾼 것과 같다. 이에 따라서, 위의 식 4개의 결과를 계산해보면 아래와 같다.

//1+2+3-4×5÷6 = 1
//1÷2+3+4-5×6 = 12
//1+2÷3×4-5+6 = 5
//1÷2×3-4+5+6 = 7
//N개의 수와 N-1개의 연산자가 주어졌을 때, 만들 수 있는 식의 결과가 최대인 것과 최소인 것을 구하는 프로그램을 작성하시오.

//입력
//첫째 줄에 수의 개수 N(2 ≤ N ≤ 11)가 주어진다.
//둘째 줄에는 A1, A2, ..., AN이 주어진다. (1 ≤ Ai ≤ 100)
//셋째 줄에는 합이 N-1인 4개의 정수가 주어지는데, 차례대로 덧셈(+)의 개수, 뺄셈(-)의 개수, 곱셈(×)의 개수, 나눗셈(÷)의 개수이다.

//출력
//첫째 줄에 만들 수 있는 식의 결과의 최댓값을, 둘째 줄에는 최솟값을 출력한다. 연산자를 어떻게 끼워넣어도 항상 -10억보다 크거나 같고, 10억보다 작거나 같은 결과가 나오는 입력만 주어진다. 또한, 앞에서부터 계산했을 때, 중간에 계산되는 식의 결과도 항상 -10억보다 크거나 같고, 10억보다 작거나 같다.


using System;

class Program
{
    static int[] numbers;  // 수열
    static int[] operators;  // 연산자 개수
    static int maxResult = int.MinValue;  // 최댓값
    static int minResult = int.MaxValue;  // 최솟값

    static void Main()
    {
        // 첫 번째 입력: 수의 개수 N
        int N = int.Parse(Console.ReadLine());

        // 두 번째 입력: 수열 A1, A2, ..., AN
        numbers = new int[N];
        string[] inputNumbers = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            numbers[i] = int.Parse(inputNumbers[i]);
        }

        // 세 번째 입력: 연산자 개수 (덧셈, 뺄셈, 곱셈, 나눗셈)
        string[] inputOperators = Console.ReadLine().Split();
        int plusCount = int.Parse(inputOperators[0]);
        int minusCount = int.Parse(inputOperators[1]);
        int multiplyCount = int.Parse(inputOperators[2]);
        int divideCount = int.Parse(inputOperators[3]);

        // 연산자 배열 생성
        operators = new int[] { plusCount, minusCount, multiplyCount, divideCount };

        // 연산자 배열을 이용해 가능한 모든 계산을 해보자.
        Backtrack(1, numbers[0], plusCount, minusCount, multiplyCount, divideCount);

        // 최댓값과 최솟값 출력
        Console.WriteLine(maxResult);
        Console.WriteLine(minResult);
    }

    // Backtracking을 통해 가능한 모든 경우의 수를 구해보는 함수
    static void Backtrack(int index, int currentResult, int plusCount, int minusCount, int multiplyCount, int divideCount)
    {
        // 모든 연산자가 사용되었으면
        if (index == numbers.Length)
        {
            maxResult = Math.Max(maxResult, currentResult);
            minResult = Math.Min(minResult, currentResult);
            return;
        }

        // 덧셈 연산
        if (plusCount > 0)
        {
            Backtrack(index + 1, currentResult + numbers[index], plusCount - 1, minusCount, multiplyCount, divideCount);
        }

        // 뺄셈 연산
        if (minusCount > 0)
        {
            Backtrack(index + 1, currentResult - numbers[index], plusCount, minusCount - 1, multiplyCount, divideCount);
        }

        // 곱셈 연산
        if (multiplyCount > 0)
        {
            Backtrack(index + 1, currentResult * numbers[index], plusCount, minusCount, multiplyCount - 1, divideCount);
        }

        // 나눗셈 연산
        if (divideCount > 0)
        {
            int result = currentResult;
            if (result < 0 && numbers[index] > 0)
            {
                // 나누는 값이 음수일 때 몫을 양수로 만든 뒤 계산
                result = -(Math.Abs(result) / numbers[index]);
            }
            else
            {
                result /= numbers[index];
            }
            Backtrack(index + 1, result, plusCount, minusCount, multiplyCount, divideCount - 1);
        }
    }
}














