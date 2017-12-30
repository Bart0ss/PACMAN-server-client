using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Customly_Edited_Pacman;

namespace server
{
    class ServerCore
    {
        public static string getIPv4()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }
        static void Main(string[] args)
        {
            IPAddress IPv4 = IPAddress.Parse(getIPv4());
            int port = 1337;
            DataSerializer.FillDictionary();

            try
            {
                TcpListener Listener = new TcpListener(IPv4, port);
                Listener.Start();

                Console.WriteLine("The local End point is: " + Listener.LocalEndpoint);
                Socket socket = Listener.AcceptSocket();
                Console.WriteLine("Connection accepted from " + socket.RemoteEndPoint);

                Core.InitializeGame();

                /* 
                Task.Factory.StartNew
                (
                    () => Customly_Edited_Pacman.Core.GameRunner()
                );
                */
                while (true)
                {
                    try
                    {
                        byte[] b = new byte[10000];
                        int k = socket.Receive(b);
                        string temp="";
                        for (int i = 0; i < k; i++)
                        {
                            temp += Convert.ToChar(b[i]);
                        }
                        Console.Clear();
                        if (Core.gameIsOver)
                        {
                            Core.ResetGame();
                            Core.gameIsOver = false;
                        }

                        Console.WriteLine(Core.player.getCoorsX() + " " + Core.player.getCoorsY());
                        Game.Direction direction = Movement.DetermineDirection(temp);
                        if (temp=="escape")
                        {
                            Core.ResetGame();
                        }
                        Movement.PlayerMovement(Core.player, direction);

                        Console.WriteLine(Core.player.ToString() + " Moved: "+direction);

                        string dataToSend = DataSerializer.Convert_Game_Data_to_string();

                        ASCIIEncoding asen = new ASCIIEncoding();
                        socket.Send(asen.GetBytes(dataToSend));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }

                #pragma warning disable CS0162 // Unreachable code detected
                 Console.ReadKey();
                #pragma warning restore CS0162 // Unreachable code detected
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadKey();
            }
        }
    }
}
