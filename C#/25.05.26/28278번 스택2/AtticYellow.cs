using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

namespace Stack2
{
    internal class AtticYellow
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()); // 명령의 수 입력
            Stack<int> stacks = new Stack<int>(); // 스택을 생성 (정수형 스택)
            StringBuilder output = new StringBuilder(); // 출력 결과를 저장할 StringBuilder 객체


            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(); // 입력을 공백으로 분리하여 배열에 저장

                switch(input[0])
                {
                    // 스택에 정수 추가
                    case "1": 
                        {
                            stacks.Push(int.Parse(input[1])); // 입력된 정수를 스택에 추가
                        }
                        break;

                    // 스택에서 정수 제거
                    case "2": 
                        {
                            output.AppendLine(stacks.Count == 0 ? "-1" : stacks.Pop().ToString()); // 스택에서 정수를 제거하고 출력, 스택이 비어있으면 -1 출력
                        }
                        break;

                    // 스택에 있는 정수의 개수 출력
                    case "3": 
                        {
                            output.AppendLine(stacks.Count.ToString()); // 스택에 있는 정수의 개수를 출력
                        }
                        break;

                    // 스택이 비어있는지 확인
                    case "4": 
                        {
                            output.AppendLine(stacks.Count == 0 ? "1" : "0"); // 스택이 비어있으면 1, 아니면 0 출력
                        }
                        break;

                    // 스택의 가장 위에 있는 정수 출력
                    case "5": 
                        {
                            output.AppendLine(stacks.Count == 0 ? "-1" : stacks.Peek().ToString()); // 스택의 가장 위에 있는 정수를 출력, 스택이 비어있으면 -1 출력
                        }
                        break;
                }
            }

            Console.Write(output.ToString()); // StringBuilder에 저장된 결과를 출력

        }
    }
}
