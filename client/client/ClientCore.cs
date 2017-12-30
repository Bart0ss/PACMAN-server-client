using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace client
{
    class ClientCore
    {

        static void Main(string[] args)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                tcpclnt.Connect("192.168.1.138", 1337);
                TCPIP_data_manipulation.FillDictionary();
                // use the ipaddress as in the server program

                Console.WriteLine("Connected");
                Console.Write("Enter the string to be transmitted : ");

                while (true)
                {

                    var button = Console.ReadKey().Key;
                    String str = TCPIP_data_manipulation.KeyToString(button);
                    Stream stm = tcpclnt.GetStream();

                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes(str);
                    Console.WriteLine("Waiting for other player's turn");
                    if (str.Length > 0)
                    {
                        stm.Write(ba, 0, ba.Length);
                    }

                    byte[] bb = new byte[10000];
                    int k = stm.Read(bb, 0, 10000);
                    
                    TCPIP_data_manipulation.ConvertByte_TCPIP_Stream_to_GameData_and_apply_it(bb);
                    Map.showMap(Map.map);
                }
                //       tcpclnt.Close();

                #pragma warning disable CS1633
                #pragma  Console.ReadKey();
            }


            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadKey();
            }
        }
    }
}
