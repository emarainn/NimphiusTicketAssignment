


//How would I label them through a loop so that rather then typing in the Ticket number it just happens

namespace TicketingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {

            FileManager dataManager = new FileManager();

            string filename = "tickets.txt";

            //menu
            string menu;

            do
            {
                Console.WriteLine("\n1. Write data to file:");
                Console.WriteLine("2. Read data from file:");
                Console.WriteLine("3. Exit");
                menu = Console.ReadLine();

                if (menu == "1")
                {
                    dataManager.Write(filename);
                }
                else if (menu == "2")
                {
                    Console.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                    dataManager.Read(filename);
                }

            } while (menu != "3");
        }

        public class FileManager
        {
            public void Write(string filename)
            {

                StreamWriter sw = new StreamWriter(filename, true);

                Console.WriteLine("Enter Ticket ID: ");
                var ticketID = Console.ReadLine();

                Console.WriteLine("Enter Ticket Summary: ");
                var summary = Console.ReadLine();

                Console.WriteLine("Enter Priority: ");
                var priority = Console.ReadLine();

                Console.WriteLine("Enter Submitter: ");
                var submitter = Console.ReadLine();

                Console.WriteLine("Enter Assigned: ");
                var assigned = Console.ReadLine();



                Console.WriteLine("Enter Number of Watchers: ");
                var num = Convert.ToInt32(Console.ReadLine());

                string[] watcher = new string[num];

                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine("Type in Watcher: ");
                    watcher[i] = Console.ReadLine();
                }


                sw.WriteLine($"{ticketID}, {summary}, {priority}, {submitter}, {assigned}, {string.Join("|", watcher)}");


                sw.Close();
            }

            public void Read(string filename)
            {
                if (File.Exists(filename))
                {
                    StreamReader sr = new StreamReader(filename);

                    while (sr.EndOfStream != true)
                    {
                        var line = sr.ReadLine();
                        Console.WriteLine($"your line is: {line}");
                    }

                }
            }
        }
    }
}

