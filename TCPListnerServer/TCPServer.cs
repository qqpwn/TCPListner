using System.Net.Sockets;
using System.Configuration.Assemblies;
using System.Reflection;
using System.ComponentModel;

class TCPServer
{
    static TcpListener _listener;
    const int _limit = 5;

    public static List<Employee> _employeesList = new List<Employee> 
    { new Employee("Jens", "Manager"), new Employee("Maxi", "CEO"), new Employee("Taber", "GulvSlikker") };
   
    
    public static void Main()
    {
        _listener = new TcpListener(11111);
        _listener.Start();

        Console.WriteLine("Server Is Lubed up and Ready on Port: 11111");

        for (int i = 0; i < _limit; i++)
        {
            Thread t = new Thread(new ThreadStart(Service));
            t.Start();
        }
        
    }

    public static void Service()
    {
        Socket sock = _listener.AcceptSocket();

        Console.WriteLine("Connected: {0}", sock.RemoteEndPoint);

        try
        {
            Stream s = new NetworkStream(sock);
            StreamReader sr = new StreamReader(s);
            StreamWriter sw = new StreamWriter(s);
            sw.AutoFlush = true;
            sw.WriteLine("{0} Employees available", _employeesList.Count);

            string name = sr.ReadLine();
            Console.WriteLine("Recived name = {0}", name);
            if (_employeesList.Count > 0 && name != null && name != "")
            {
                Employee a = _employeesList.FirstOrDefault(x => x.Name == name);
                sw.WriteLine(a.Job);
            }

            string test = Console.ReadKey().ToString();
            if (test == "qqqq")
            {
                s.Close();
                sock.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
     
    }
}

public class Employee
{
    public string Name { get; set; }
    public string  Job { get; set; }

    public Employee(string name, string job)
    {
        Name = name;
        Job = job;
    }

}