namespace 크로아티아_알파벳
{
    internal class AtticYellow
    {
        static void Main(string[] args)
        {
            int answer = 0;
            int i = 0;

            string str = Console.ReadLine();

            while (i < str.Length)
            {
                switch (str[i])
                {
                    // l, n의 경우는 j가 뒤에 붙으면 하나의 문자로 취급
                    case 'l':
                    case 'n':
                        {
                            if (i + 1 < str.Length && str[i + 1] == 'j')
                            {
                                i += 2;
                            }
                            else
                            {
                                i++;
                            }
                            break;
                        }

                    // d의 경우는 z가 뒤에 붙으면 하나의 문자로 취급
                    case 'd':
                        {
                            if (i + 1 < str.Length && str[i + 1] == '-')
                            {
                                i += 2;
                            }
                            else if (i + 2 < str.Length && str[i + 1] == 'z' && str[i + 2] == '=')
                            {
                                i += 3;
                            }
                            else
                            {
                                i++;
                            }
                            break;
                        }

                    // c의 경우는 =, -가 뒤에 붙으면 하나의 문자로 취급
                    case 'c':
                        {
                            if (i + 1 < str.Length && (str[i + 1] == '=' || str[i + 1] == '-'))
                            {
                                i += 2;
                            }
                            else
                            {
                                i++;
                            }
                            break;
                        }

                    // s, z의 경우는 =가 뒤에 붙으면 하나의 문자로 취급
                    case 's':
                    case 'z':
                        {
                            if (i + 1 < str.Length && str[i + 1] == '=')
                            {
                                if (str[i] == 'z' && i > 0 && str[i - 1] == 'd')
                                {
                                    i++; // dz=의 z는 이미 처리된 것이므로 무시
                                }
                                else
                                {
                                    i += 2;
                                }
                            }
                            else
                            {
                                i++;
                            }
                            break;
                        }

                    // 기타 문자들은 하나의 문자로 취급
                    default:
                        {
                            i++;
                            break;
                        }
                }

                answer++;
            }

            Console.WriteLine(answer);
        }
    }
}
