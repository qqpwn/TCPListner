
using System.Net;

class ShowIP
{

    public static void Main(string[] args)
    {
        //Hvis args er mindre en 1 så hent HostName (og sæt den til index 0 i args??) eller return args's index 0
        string name = (args.Length < 1) ? Dns.GetHostName() : args[0];

        try
        {
            int i = 0;
            IPAddress[] address = Dns.GetHostEntry(name).AddressList;
            foreach (IPAddress ip in address)
            {
                
                Console.WriteLine("{0} / {1}", name, address[i]);
                i++;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }


        Console.ReadLine();
    }
}