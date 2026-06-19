using System;

namespace MidTermSX33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxEmployees = 10;
            int currentEmployeeCount = 0;

            string[] employeeName = new string[maxEmployees];
            string[] employeeID = new string[maxEmployees];
            string[] employeeGender = new string[maxEmployees];
            string[] employeePosition = new string[maxEmployees];

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("   Employees Management System (EMS)   ");
                Console.WriteLine("=======================================\n");

                Console.WriteLine($"Current Staff Count: {currentEmployeeCount}/{maxEmployees}");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. Remove Existing Employee");
                Console.WriteLine("3. View All Employees\n");

                Console.WriteLine("=======================================");

                Console.Write("Enter (1-3): ");

                string menuChoice = Console.ReadLine();
                Console.WriteLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        if (currentEmployeeCount >= maxEmployees)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Error: Max Employees Count Reached (10/10)");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("=== Add New Employee ===\n");

                            Console.Write("Enter Full Name: ");
                            string newName = Console.ReadLine();

                            string newID = "";
                            while (true)
                            {
                                Console.Write("Assign New ID: ");
                                newID = Console.ReadLine();

                                if (string.IsNullOrEmpty(newID))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("ID cannot be empty.");
                                    Console.ResetColor();
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            Console.Write("Enter Gender: ");
                            string newGender = Console.ReadLine();

                            Console.Write("Enter Position: ");
                            string newPosition = Console.ReadLine();

                            employeeName[currentEmployeeCount] = newName;
                            employeeID[currentEmployeeCount] = newID;
                            employeeGender[currentEmployeeCount] = newGender;
                            employeePosition[currentEmployeeCount] = newPosition;

                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\nSuccessfully Added New Employee!");
                            Console.ResetColor();

                            currentEmployeeCount++;
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("===== Remove Existing Employee =====\n");
                        if (currentEmployeeCount == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Database is empty. Nothing to delete.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("Enter Employee ID to remove: ");
                            string deleteID = Console.ReadLine();
                            int deleteIndex = -1;

                            for (int i = 0; i < currentEmployeeCount; i++)
                            {
                                if (employeeID[i] == deleteID)
                                {
                                    deleteIndex = i;
                                    break;
                                }
                            }
                            if (deleteIndex != -1)
                            {
                                for (int i = deleteIndex; i < currentEmployeeCount - 1; i++)
                                {
                                    employeeName[i] = employeeName[i + 1];
                                    employeeID[i] = employeeID[i + 1];
                                    employeeGender[i] = employeeGender[i + 1];
                                    employeePosition[i] = employeePosition[i + 1];
                                }
                                currentEmployeeCount--;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"\nSuccessfully Removed Employee");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"\nError: Profile with ID '{deleteID}' could not be found.");
                                Console.ResetColor();
                            }
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("================================== Employee's List ===================================\n");
                        if (currentEmployeeCount == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("No Employee in Database!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------------------");
                            Console.WriteLine($"| {"#",-5} | {"Full Name",-20} | {"ID",-10} | {"Gender",-10} | {"Position",-25} |");
                            Console.WriteLine("--------------------------------------------------------------------------------------");

                            for(int i = 0; i < currentEmployeeCount; i++)
                            {
                                Console.WriteLine($"| {i + 1,-5} | {employeeName[i],-20} | {employeeID[i],-10} | {employeeGender[i],-10} | {employeePosition[i],-25} |");
                            }

                            Console.WriteLine("--------------------------------------------------------------------------------------");
                        }
                        break;

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Invalid option code. Choose a value between 1 and 3.");
                        Console.ResetColor();
                        break;
                }

                if (isRunning)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }
}
