using System;
using System.IO;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";
            StreamWriter writer = new StreamWriter(file, append: true);
            writer.Close();

            int ticketID = System.IO.File.ReadAllLines(file).Length + 1;
            string summary;
            string status = "";
            string priority = "";
            string submitter;
            string assigned;
            string watching = "";

            Console.WriteLine("Enter '1' to create a new ticket.");
            Console.WriteLine("Enter '2' to view tickets.");
            Console.WriteLine("Enter any other key to exit.");
            string selectedOption = Console.ReadLine();

            if(selectedOption == "1")
            {   
                //enter ticket summary
                Console.WriteLine("Your ticketID is: " + '\n' + ticketID + '\n' + 
                "Please enter a summary of your issue:");
                summary = Console.ReadLine();

                //enter ticket status
                Console.WriteLine("Please enter current ticket status:" + '\n' +
                "Enter 'O' for Open." + '\n' + "Enter 'C' for Closed.");
                string statusInput = Console.ReadLine();
                string statusValue = statusInput.ToUpper(); 
                if(statusValue == "O"){status = "Open";}
                else if(statusValue == "C"){status = "Closed";}
                else
                {
                    Console.WriteLine("Invalid input." + '\n' + "Ticket not saved." +
                    '\n' + "Please re-run the program.");
                    System.Environment.Exit(0);
                }

                //enter ticket priority
                Console.WriteLine("Please enter ticket priority:" + '\n' + 
                "Enter 'H' for High." + '\n' + "Enter 'L' for Low.");
                string priorityInput = Console.ReadLine();
                string priorityValue = priorityInput.ToUpper();
                if(priorityValue == "H"){priority = "High";}
                else if(priorityValue == "L"){priority = "Low";}
                else
                {
                    Console.WriteLine("Invalid input." + '\n' + "Ticket not saved." +
                    '\n' + "Please re-run the program.");
                    System.Environment.Exit(0);
                } 

                //enter ticket submitter
                Console.WriteLine("Please enter the ticket submitter:");
                submitter = Console.ReadLine();

                //enter ticket assigned
                Console.WriteLine("Please enter who this ticket is assigned to:");
                assigned = Console.ReadLine();
                
                //enter ticket watcher(s)
                Console.WriteLine("How many people are watching this ticket?");
                string amountWatchingString = Console.ReadLine();
                int amountWatching = 0;
                try{amountWatching = Int32.Parse(amountWatchingString);}
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input." + '\n' + "Ticket not saved." +
                    '\n' + "Please re-run the program.");
                    System.Environment.Exit(0);
                }
                if(amountWatching != 0)
                {
                    string[] watchers = new string[amountWatching];
                    int i;
                    int j = 1;
                    for(i = 0; i < amountWatching; i++, j++)
                    {   
                        Console.WriteLine("Please enter watcher number " + j + ":");
                        watchers[i] = Console.ReadLine();
                    }
                    watching = String.Join("|", watchers);
                }

                writer = new StreamWriter(file, append: true);
                writer.WriteLine(ticketID + "," + summary + "," + status + "," + priority + "," +
                submitter + "," + assigned + "," + watching); 
                Console.WriteLine("Ticket successfully created!" + '\n' + 
                "The following ticket data was entered:" + '\n' + ticketID + "," + summary + 
                "," + status +"," + priority + ","
                + submitter + "," + assigned + "," + watching); 
                writer.Close();

            }
            else if(selectedOption == "2")
            {
                StreamReader reader = new StreamReader(file);
                if(ticketID == 1)
                {
                    reader.Close();
                    Console.WriteLine("There are no tickets.");
                }
                else
                {
                    while(!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                } 
            }
        }
    }
}
