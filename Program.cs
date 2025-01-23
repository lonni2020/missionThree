
//Lonni Burdett
// Create a program where you can add, delete, and print out food items
using System.Runtime.InteropServices;
using missionThree;

Console.WriteLine("Welcome to Simple Food Bank Inventory System");

bool check = true;
List<FoodItem> FoodItem = new List<FoodItem>();

//repeats the program until you exit
while (check)
{
    //options
    Console.WriteLine("\nSelect (1) to ADD food item");
    Console.WriteLine("Select (2) to DELETE food item");
    Console.WriteLine("Select (3) to PRINT LIST of food item");
    Console.WriteLine("Select (4) to EXIT");
    int selection = 0;

    selection = int.Parse(Console.ReadLine());

    //ensures valid input
    while (selection < 1 || selection > 4)
    {
        Console.WriteLine("Invalid input: ");

        Console.WriteLine("Select (1) to ADD food item");
        Console.WriteLine("Select (2) to DELETE food item");
        Console.WriteLine("Select (3) to PRINT LIST of food item");
        Console.WriteLine("Select (4) to EXIT\n");

        selection = int.Parse(Console.ReadLine());
    }

    
    //adds food item
    if (selection == 1)
    {
        Console.WriteLine("\nYou selected ADD food item.\nWhat item would you like to add?");
        string itemName = Console.ReadLine();

        Console.WriteLine("What category is " + itemName + "? (e.g., \"Canned Goods\", \"Dairy\", \"Produce\")");
        string category = Console.ReadLine();

   


        //error handling for quantity
        int quantity = 0;
        while (true)
        {
            Console.WriteLine("Quantity of " + itemName);

            string input = Console.ReadLine();

            // Check if the input is an integer
            if (int.TryParse(input, out quantity))
            {
                // Input is valid, break out of the loop
                break;
            }
            else
            {
                // Input is invalid, prompt the user again
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }


        // obtain expiration date
        DateTime expirationDate;
        string format = "MM/dd/yyyy";

        while (true)
        {
            Console.WriteLine("When is the expiration date for these items? (MM/dd/yyyy)");
            string input = Console.ReadLine();

            if (DateTime.TryParseExact(input, format, null, System.Globalization.DateTimeStyles.None, out expirationDate))
            {
                Console.WriteLine($"Expiration date set to: {expirationDate.ToShortDateString()}");
                break; // Exit the loop if the date is valid
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use MM/dd/yyyy.");
            }
        }



      // add new food item to preestablished list
        FoodItem.Add(new FoodItem(itemName, category, quantity, expirationDate));

        Console.WriteLine("\n" +itemName + " has been added.");


    }

    //delete item
    else if (selection == 2)
    {
        if (FoodItem.Count > 0)
        {
            Console.WriteLine("\nWhich food item would you like to delete?");
            for (int i = 0; i < FoodItem.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + FoodItem[i].Name);
            }
            Console.WriteLine("\nEnter the number next to the item you wish to delete");
            int option = int.Parse(Console.ReadLine());

            // ensure they enter a valid option
            while (option > FoodItem.Count || option is < 1)
            {
                Console.WriteLine("Invalid input, please enter a number between 1 and " + FoodItem.Count);
                option = int.Parse(Console.ReadLine());
            }
            option = option - 1;

            FoodItem.RemoveAt(option);
        }
        else
        {
            Console.WriteLine("We have no food items in inventory");
        }
    }

    //print out item names
    else if (selection == 3)
    {
        Console.WriteLine("\nHere is a list of all food items: ");
        for (int i = 0; i < FoodItem.Count; i++)
        {
            Console.WriteLine((i + 1) + ". Name: " + FoodItem[i].Name + ", Category: " + FoodItem[i].Category + ", Quantity: " + FoodItem[i].Quantity + ", Expiration Date: " + FoodItem[i].ExpirationDate);
        }
    }

    //exit program
    else
    {
        Console.WriteLine("Thank you!");
        check = false;
    }
}
