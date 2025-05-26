namespace STUDY_250526
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    // See https://aka.ms/new-console-template for more information

    /*문제
    정수를 저장하는 스택을 구현한 다음, 입력으로 주어지는 명령을 처리하는 프로그램을 작성하시오.

    명령은 총 다섯 가지이다.

    1 X: 정수 X를 스택에 넣는다. (1 ≤ X ≤ 100,000)
    2: 스택에 정수가 있다면 맨 위의 정수를 빼고 출력한다. 없다면 -1을 대신 출력한다.
    3: 스택에 들어있는 정수의 개수를 출력한다.
    4: 스택이 비어있으면 1, 아니면 0을 출력한다.
    5: 스택에 정수가 있다면 맨 위의 정수를 출력한다. 없다면 -1을 대신 출력한다.
    입력
    첫째 줄에 명령의 수 N이 주어진다. (1 ≤ N ≤ 1,000,000)

    둘째 줄부터 N개 줄에 명령이 하나씩 주어진다.

    출력을 요구하는 명령은 하나 이상 주어진다.

    출력
    출력을 요구하는 명령이 주어질 때마다 명령의 결과를 한 줄에 하나씩 출력한다.*/

    class Program
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();
            int N;
            string input;
            string[] parts;
            int cmd;
            int X;
            int output;

            StringBuilder sb = new StringBuilder();

            input = Console.ReadLine();
            N = int.Parse(input);

            if (1 <= N && N <= 1000000)
            {
                for (int a = 0; a < N; a++)
                {
                    input = Console.ReadLine();
                    parts = input.Split();
                    cmd = int.Parse(parts[0]);

                    switch (cmd)
                    {
                        // 1 X: 정수 X를 스택에 넣는다. (1 ≤ X ≤ 100,000)
                        case 1:
                            X = int.Parse(parts[1]);
                            if (1 <= X && X <= 100000)
                            {
                                stack.Push(X);
                            }
                            break;
                          
                        //2: 스택에 정수가 있다면 맨 위의 정수를 빼고 출력한다. 없다면 -1을 대신 출력한다.
                        case 2:
                            if (stack.Count > 0)
                            {
                                sb.AppendLine(stack.Pop().ToString());
                            }
                            else
                            {
                                sb.AppendLine("-1");
                            }
                            break;
                        // 3: 스택에 들어있는 정수의 개수를 출력한다.
                        case 3:
                            sb.AppendLine(stack.Count.ToString());
                            break;

                        //4: 스택이 비어있으면 1, 아니면 0을 출력한다.
                        case 4:
                            sb.AppendLine(stack.Count == 0 ? "1" : "0");
                           
                            break;

                        // 5: 스택에 정수가 있다면 맨 위의 정수를 출력한다. 없다면 -1을 대신 출력한다.
                        case 5:
                            sb.AppendLine(stack.Count > 0 ? stack.Peek().ToString() : "-1");

                            break;
                    }
                }
               Console.WriteLine(sb.ToString());
            }
            
        }
    }
}
