using System.Net;
using System.Net.Sockets;

public class TCPClient
{

    public static void Main(string[] args)
    {
        TcpClient client = new TcpClient(Dns.GetHostName(), 11111);

        try
        {
            Stream s = client.GetStream();
            StreamReader sr = new StreamReader(s);
            StreamWriter sw = new StreamWriter(s);
            sw.AutoFlush = true;
            Console.WriteLine(sr.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();
            sw.WriteLine(name);

            string job = sr.ReadLine();
            Console.WriteLine("{0} job is = {1}", name,job);

            string test = Console.ReadKey().ToString();
            if (test == "qqqq")
            {
                s.Close();
                client.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       
    }

}