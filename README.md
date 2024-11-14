*`Event Management System`*
**`Overview`**
The Event Management System is a command-line program built in C# that allows users to manage events. Users can create, update, delete, and view events through a simple text-based interface. This system also provides the option to go back to the main menu at any point during the process and provides error handling for invalid inputs.

**`Features`**
1.	Delete Events: Users can delete events by specifying the event ID.
2.	View Events: Users can list all events or view specific event details.
3.	Back to Menu: At any time, users can type 'back' to return to the main menu or choose to exit the program.
4.	Error Handling: The system handles invalid inputs, such as non-numeric event IDs or incorrect date formats, and provides guidance for valid input.

**`Commands`**
1.	Create Event: Adds a new event to the system.
2.	Update Event: Allows the user to modify event details by entering the event ID.
3.	Delete Event: Deletes an event from the system by providing its ID.
4.	List Events: Displays all events with their IDs and details.
5.	Exit: Closes the program.


**`Error Handling`**
The system is designed to handle invalid inputs gracefully. Here are some common scenarios:

1.Invalid Event ID: If an invalid or non-numeric event ID is entered during update or delete operations, the system will prompt the user to try again.

2.Invalid Date Format: When entering the event date, if the user provides an invalid date format, the system will ask them to enter the date in the correct format (yyyy-MM-dd).

3.Empty Event Name: The system will prompt the user to provide an event name if the name is left empty during event creation.

4.Back to Menu:At any point, users can type back to return to the main menu. This functionality is available during event creation, updating, and other operations, allowing for a smooth user experience.

5.Exit Option:To quit the program, simply type exit at any prompt.
