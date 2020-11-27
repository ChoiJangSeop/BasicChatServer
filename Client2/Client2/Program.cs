using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyContinuousClient cc = new MyContinuousClient();
            cc.Run();
        }
    }

    class MyContinuousClient
    {
        TcpClient client = null;
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("========== CLIENT2 ==========");
                Console.WriteLine("1. 서버 연결하기");
                Console.WriteLine("2. 메세지 전송하기");
                Console.WriteLine("3. 서버 구동 여부 확인");
                Console.WriteLine("============================");

                string key = Console.ReadLine();
                int order = 0;

                // 입력받은 key의 값을 int.TryParse를 사용해 int형으로 형변환해줍니다.
                // 형변환에 성공하면 order에 변화된 값이 저장됩니다.
                // 형변환에 실패하면 false를 리턴합니다.
                if (int.TryParse(key, out order))
                {
                    switch (order)
                    {
                        case 1:
                            {
                                if (client != null)
                                {
                                    Console.WriteLine("이미 서버연결 했거등");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Connect();
                                }
                                break;
                            }

                        case 2:
                            {
                                if (client == null)
                                {
                                    Console.WriteLine("서버부터 연결하셈");
                                    Console.ReadKey();
                                }

                                else
                                {
                                    SendMessage();
                                }

                                break;
                            }

                        case 3:
                            {
                                if (client == null)
                                {
                                    Console.WriteLine("서버부터 연결하셈");
                                    Console.ReadKey();
                                }

                                else
                                {
                                    SendFlag();
                                }

                                break;
                            }
                    }
                }

                else
                {
                    Console.WriteLine("Wrong Input");
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }

        private void SendMessage()
        {
            Console.WriteLine("Input the message to send");
            string message = Console.ReadLine();
            byte[] byteData = new byte[message.Length];
            byteData = Encoding.Default.GetBytes(message);

            client.GetStream().Write(byteData, 0, byteData.Length);
            Console.WriteLine("Success to send!");
            Console.ReadKey();
        }

        private void SendFlag()
        {
            string massage = "!";
            byte[] byteData = new byte[massage.Length];
            byteData = Encoding.Default.GetBytes(massage);

            client.GetStream().Write(byteData, 0, byteData.Length);
            Console.ReadKey();
        }

        private void Connect()
        {
            client = new TcpClient();
            client.Connect("127.0.0.2", 9999);
            Console.WriteLine("Success to connect to server and input your message");
            Console.ReadKey();
        }
    }

}

