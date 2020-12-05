using System;
using System.IO.Ports;

namespace ArduinoSketch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("#######################################################\n");
            Console.WriteLine(@"
██████   ██████  ██████  ████████ ██ ████████ 
██   ██ ██    ██ ██   ██    ██    ██    ██    
██████  ██    ██ ██████     ██    ██    ██    
██      ██    ██ ██   ██    ██    ██    ██    
██       ██████  ██   ██    ██    ██    ██    
                                                                                         
");
            Console.WriteLine("[+]Coded By         :Ali Cem Sönmez\n[+]Github           :github.com/snmzcm" + "\n[+]Contact          :AliCemsonmez98@gmail.com");
            Console.WriteLine("#######################################################\n");
            string[] portNames = SerialPort.GetPortNames();
            string portChoose = "Kullanmak istediğiniz portu seçiniz";
            string line = "__________________________________";
            Console.WriteLine(portChoose);
            Console.WriteLine(line);
            //liste index numarası ile port isimlerini yazdır
            foreach (string port in portNames)
            {


                if (port == null)
                {
                    Console.WriteLine("Aktif port girişi algılanamadı");
                }
                else
                {
                    Console.WriteLine(port);
                }
            }
            Console.WriteLine(line);
            string comNumber = Console.ReadLine();
            Console.WriteLine(line);
            Console.WriteLine("Bir Baud Değeri Seçiniz:\n1. 300\n2. 1200\n3. 2400\n4. 4800\n5. 9600\n6. 19200\n7. 38400\n8. 57600\n9. 74880\n10. 115200\n11. 230400\n12. 250000\n13. 500000\n14. 1000000\n15. 2000000");
            Console.WriteLine(line);
            string Baud = Console.ReadLine();
            int BaudRate;
            switch (Baud)
            {
                case "1":
                    BaudRate = 300;
                    break;
                case "2":
                    BaudRate = 1200;
                    break;
                case "3":
                    BaudRate = 2400;
                    break;
                case "4":
                    BaudRate = 4800;
                    break;
                case "5":
                    BaudRate = 9600;
                    break;
                case "6":
                    BaudRate = 19200;
                    break;
                case "7":
                    BaudRate = 38400;
                    break;
                case "8":
                    BaudRate = 57600;
                    break;
                case "9":
                    BaudRate = 74880;
                    break;
                case "10":
                    BaudRate = 115200;
                    break;
                case "11":
                    BaudRate = 230400;
                    break;
                case "12":
                    BaudRate = 250000;
                    break;
                case "13":
                    BaudRate = 500000;
                    break;
                case "14":
                    BaudRate = 1000000;
                    break;
                case "15":
                    BaudRate = 2000000;
                    break;
                default:
                    BaudRate = 9600;
                    break;
            }
            SerialPort seriPort = new SerialPort(comNumber, BaudRate, Parity.None, 8, StopBits.One);
            
            
            try
            {
                if (seriPort.IsOpen == false)
                {
                    seriPort.Open();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} Baud ile Bağlantı Başarılı", BaudRate.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(line);
                }
            }
            catch (Exception hata1)
            {

                Console.WriteLine("Bir hata gerçekleşti: {0}", hata1.Message);
            }


            while (true)
            {
                string message = seriPort.ReadLine().ToString();
                Console.WriteLine("=> Port Yanıtı: " + message); Console.WriteLine(line);
                string commands = Console.ReadLine();
                seriPort.Write(commands);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                Console.WriteLine(commands);
                Console.WriteLine(line);
                


            }






        }
    }
}

