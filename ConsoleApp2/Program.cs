using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsgPack;
using MsgPack.Serialization;
using System.Collections;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        //static List<string> opts = new List<String>() { "Katya", "Gelya" };
       // static MemoryStream optStream;
        static void Main(string[] args)
        {
            List<string> opts = new List<String>() { "Katya", "Gelya" };
            var optStream = new MemoryStream();
            Console.WriteLine("To watch command list enter S");
            Console.WriteLine("Enter command");   
            var serializer = MessagePackSerializer.Get<List<string>>();
            serializer.Pack(optStream, opts);
            optStream.Position = 0;
           // var value = serializer.Unpack(optStream);            
            string buk = Console.ReadLine();
            while (buk != "E")
            {
                if (buk == "N")
                {
                    Console.WriteLine("Enter Name");
                    var value = serializer.Unpack(optStream);
                    string ooops = Console.ReadLine();
                    value.Add(ooops);
                    optStream = new MemoryStream();
                    serializer.Pack(optStream, value);
                    optStream.Position = 0;
                }
                if (buk == "D")
                {
                    Console.WriteLine("Enter what you'd like to remove");
                    var value = serializer.Unpack(optStream);
                    string ooops = Console.ReadLine();
                    value.Remove(ooops);
                    optStream = new MemoryStream();ы
                    serializer.Pack(optStream, value);
                    optStream.Position = 0;
                }
                if (buk == "V")
                {
                    Console.WriteLine("Table:");
                    Console.WriteLine();
                    var value = serializer.Unpack(optStream);
                    value.ForEach(delegate (String name)
                    {
                        Console.WriteLine(name);
                    });
                    optStream = new MemoryStream();
                    serializer.Pack(optStream, value);
                    optStream.Position = 0;
                    Console.WriteLine();
                }
                if (buk == "S")
                {
                    Console.WriteLine("Enter N to add the component");
                    Console.WriteLine("Enter D to remove the component");
                    Console.WriteLine("Enter V to look at the components");
                    Console.WriteLine("Enter E to exit");
                }
                buk = Console.ReadLine();
            }
        }
    }
}
