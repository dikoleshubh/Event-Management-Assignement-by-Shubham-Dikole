using Event_Management_Assignement___Shubham_Dikole;

class Program
{
    static void Main()
    {
        EventManager eventManager = new EventManager();
        EventManagementMethods eventCall = new EventManagementMethods();
        Console.WriteLine("Welcome to the  Event Management System!");

        while (true)
        {
            Console.WriteLine("\nPlease enter a command " +
                "\ncreate" +
                "\nlist" +
                "\nget" +
                "\nupdate" +
                "\ndelete" +
                "\nsearch" +
                "\nexit:");
            Console.Write("> ");
            string command = Console.ReadLine()?.ToLower();

            try
            {
                switch (command)
                {
                    case "create":
                        eventCall.CreateEvent(eventManager);
                        break;
                    case "list":
                        eventCall.ListEvents(eventManager);
                        break;
                    case "get":
                        eventCall.GetEvent(eventManager);
                        break;
                    case "update":
                        eventCall.UpdateEvent(eventManager);
                        break;
                    case "delete":
                        eventCall.DeleteEvent(eventManager);
                        break;
                    case "search":
                        eventCall.SearchEvents(eventManager);
                        break;
                    case "exit":
                        Console.WriteLine("Exiting the Event Management System. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing your command: {ex.Message}");
            }
        }
    }
}
