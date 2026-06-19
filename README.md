# Employee Management System (EMS) - Detailed Code Explanation

## Table of Contents
1. [Overview](#overview)
2. [Namespace and Class Declaration](#namespace-and-class-declaration)
3. [Variable Declarations](#variable-declarations)
4. [Main Menu Loop](#main-menu-loop)
5. [Case 1: Add New Employee](#case-1-add-new-employee)
6. [Case 2: Remove Existing Employee](#case-2-remove-existing-employee)
7. [Case 3: View All Employees](#case-3-view-all-employees)
8. [Default Case and Loop Continuation](#default-case-and-loop-continuation)

---

## Overview

This C# console application is an **Employee Management System (EMS)** that allows users to:
- Add new employees (up to 10 maximum)
- Remove existing employees by ID
- View all employees in a formatted table

The program uses **parallel arrays** to store employee data and implements a menu-driven interface.

---

## Namespace and Class Declaration

```csharp
using System;
```
**Line Explanation:**
- `using` is a **directive** that tells the compiler to include the `System` namespace
- `System` is the **fundamental namespace** in .NET that contains basic classes like `Console`, `String`, `Int32`, etc.
- Without this line, you would need to write `System.Console.WriteLine()` instead of just `Console.WriteLine()`

---

```csharp
namespace MidTermSX33
```
**Line Explanation:**
- `namespace` is a keyword used to **organize code** and prevent naming conflicts
- `MidTermSX33` is the **name of the namespace**
- Namespaces act like containers/folders for related classes
- Everything between the `{` and `}` following this declaration belongs to this namespace

---

```csharp
{
    internal class Program
```
**Line Explanation:**
- `{` opens the namespace block
- `internal` is an **access modifier** that restricts access to the class within the same assembly (project)
  - Other access modifiers include: `public`, `private`, `protected`
- `class` is a keyword that defines a **blueprint for objects**
- `Program` is the **name of the class** (conventional name for the main entry point class in C#)

---

```csharp
    {
        static void Main(string[] args)
```
**Line Explanation:**
- `{` opens the class block
- `static` means this method belongs to the **class itself**, not to an instance of the class
  - You don't need to create an object to call a static method
- `void` is the **return type** - this method doesn't return any value
- `Main` is the **method name** - this is the **entry point** of every C# console application
  - The program starts executing from here
- `string[] args` is a **parameter** that receives command-line arguments
  - `string[]` means an array of strings
  - `args` is the parameter name (short for "arguments")
  - Example: running `program.exe hello world` would make `args[0] = "hello"` and `args[1] = "world"`

---

## Variable Declarations

```csharp
        {
            const int maxEmployees = 10;
```
**Line Explanation:**
- `{` opens the Main method block
- `const` is a keyword that makes the variable a **constant** (unchangeable after declaration)
  - Any attempt to modify this value later will cause a **compile-time error**
- `int` is the **data type** for integer (whole numbers)
- `maxEmployees` is the **variable name** following camelCase naming convention
- `= 10` **assigns** the value 10 to this constant
- `;` terminates the statement
- **Purpose:** Sets the maximum capacity of employees the system can store

---

```csharp
            int currentEmployeeCount = 0;
```
**Line Explanation:**
- `int` declares an integer variable
- `currentEmployeeCount` tracks **how many employees are currently stored**
- `= 0` initializes it to zero (no employees at start)
- This acts as a **counter** and also as an **index pointer** for adding new employees

---

```csharp
            string[] employeeName = new string[maxEmployees];
            string[] employeeID = new string[maxEmployees];
            string[] employeeGender = new string[maxEmployees];
            string[] employeePosition = new string[maxEmployees];
```
**Line Explanation:**
- These four lines create **parallel arrays** to store employee data
- `string[]` declares an **array of strings**
- `new string[maxEmployees]` creates a **new array instance** with 10 slots (indices 0-9)
- `new` is the keyword that **allocates memory** for the array on the heap

| Array Name | Purpose | Example Values |
|------------|---------|----------------|
| `employeeName` | Stores full names | "John Doe", "Jane Smith" |
| `employeeID` | Stores unique IDs | "EMP001", "EMP002" |
| `employeeGender` | Stores gender | "Male", "Female", "M", "F" |
| `employeePosition` | Stores job titles | "Manager", "Developer" |

**Parallel Arrays Concept:**
- All arrays share the **same index** for one employee
- Employee at index 0: `employeeName[0]`, `employeeID[0]`, `employeeGender[0]`, `employeePosition[0]`

## Main Menu Loop

```csharp
            bool isRunning = true;
```
**Line Explanation:**
- `bool` is the **boolean data type** (can only be `true` or `false`)
- `isRunning` is a **flag variable** that controls the main loop
- `= true` initializes it to true, meaning the program should keep running
- When set to `false`, the while loop would terminate

---

```csharp
            while (isRunning)
            {
```
**Line Explanation:**
- `while` is a **loop keyword** that repeats code as long as a condition is true
- `(isRunning)` is the **condition** - equivalent to `(isRunning == true)`
- Since `isRunning` is always `true`, this creates an **infinite loop**
- The program runs continuously until manually closed
- `{` opens the while loop block

---

```csharp
                Console.Clear();
```
**Line Explanation:**
- `Console` is a **class** from the System namespace that handles console I/O
- `.Clear()` is a **method** that clears all text from the console window
- This gives a fresh screen at the start of each menu cycle
- Creates a cleaner user experience

---

```csharp
                Console.WriteLine("=======================================");
                Console.WriteLine("   Employees Management System (EMS)   ");
                Console.WriteLine("=======================================\n");
```
**Line Explanation:**
- `Console.WriteLine()` **prints text** to the console and moves to a new line
- The `=` characters create a **visual border/header**
- `\n` is an **escape sequence** for a newline (adds blank line after header)
- These lines create the **title banner** of the application

---

```csharp
                Console.WriteLine($"Current Staff Count: {currentEmployeeCount}/{maxEmployees}");
```
**Line Explanation:**
- `$"..."` enables **string interpolation** - embedding variables directly in strings
- `{currentEmployeeCount}` is replaced with the **actual value** of the variable
- `{maxEmployees}` is replaced with 10
- Example output: `Current Staff Count: 3/10`
- Shows users how much capacity is used

---

```csharp
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. Remove Existing Employee");
                Console.WriteLine("3. View All Employees\n");
```
**Line Explanation:**
- These lines display the **menu options**
- Each option is numbered for easy user input
- `\n` at the end adds spacing before the next section
- Standard console menu design pattern

---

```csharp
                Console.WriteLine("=======================================");

                Console.Write("Enter (1-3): ");
```
**Line Explanation:**
- First line prints a **bottom border** for the menu
- `Console.Write()` prints text **without** moving to a new line
  - This allows user input to appear on the **same line** as the prompt
- Difference: `WriteLine()` adds newline, `Write()` doesn't

---

```csharp
                string menuChoice = Console.ReadLine();
                Console.WriteLine();
```
**Line Explanation:**
- `Console.ReadLine()` **pauses execution** and waits for user input
- It **returns** the text entered by the user (before pressing Enter)
- `string menuChoice` stores the user's input as a string
- `Console.WriteLine()` with no arguments prints a **blank line** for spacing

---

```csharp
                switch (menuChoice)
                {
```
**Line Explanation:**
- `switch` is a **control statement** that executes different code based on a value
- `(menuChoice)` is the **expression being evaluated**
- More efficient than multiple `if-else` statements for matching exact values
- `{` opens the switch block

---

## Case 1: Add New Employee

```csharp
                    case "1":
                        Console.Clear();
```
**Line Explanation:**
- `case "1":` matches when `menuChoice` equals the string "1"
- The colon `:` marks the start of code for this case
- `Console.Clear()` clears the screen for the add employee interface

---

```csharp
                        if (currentEmployeeCount >= maxEmployees)
                        {
```
**Line Explanation:**
- `if` is a **conditional statement**
- `>=` is the **greater than or equal to** comparison operator
- This checks if we've reached maximum capacity (10 employees)
- **Validation check** before allowing new additions

---

```csharp
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Error: Max Employees Count Reached (10/10)");
                            Console.ResetColor();
```
**Line Explanation:**
- `Console.BackgroundColor` sets the **background color** of console text
- `ConsoleColor.Red` is an **enum value** from the ConsoleColor enumeration
- `Console.ForegroundColor` sets the **text color**
- `ConsoleColor.White` makes text white (for contrast on red)
- The error message is displayed with **visual emphasis** (red background)
- `Console.ResetColor()` **restores** default console colors
- This creates a visual "error alert" effect

---

```csharp
                        else
                        {
                            Console.WriteLine("=== Add New Employee ===\n");
```
**Line Explanation:**
- `else` executes when the `if` condition is false (capacity not reached)
- Displays a **section header** for adding employees

---

```csharp
                            Console.Write("Enter Full Name: ");
                            string newName = Console.ReadLine();
```
**Line Explanation:**
- Prompts user for the employee's full name
- `Console.Write()` keeps cursor on same line
- User input is stored in `newName` variable
- No validation here (empty names are allowed)

---

```csharp
                            string newID = "";
                            while (true)
                            {
```
**Line Explanation:**
- `string newID = ""` initializes an empty string for the ID
- `while (true)` creates an **infinite loop** for input validation
- This loop continues until valid input is received

---

```csharp
                                Console.Write("Assign New ID: ");
                                newID = Console.ReadLine();
```
**Line Explanation:**
- Prompts for employee ID
- Stores input in `newID` (overwrites the empty string)

---

```csharp
                                if (string.IsNullOrEmpty(newID))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("ID cannot be empty.");
                                    Console.ResetColor();
                                    continue;
                                }
```
**Line Explanation:**
- `string.IsNullOrEmpty()` is a **static method** that checks if a string is `null` or `""`
- Returns `true` if the string is null or has zero length
- If empty, displays error in **red text**
- `continue` **skips** the rest of the loop iteration and starts over
- Forces user to enter a valid ID

---

```csharp
                                else
                                {
                                    break;
                                }
```
**Line Explanation:**
- `else` executes when ID is valid (not empty)
- `break` **exits** the while loop immediately
- Proceeds to the next input prompt

---

```csharp
                            Console.Write("Enter Gender: ");
                            string newGender = Console.ReadLine();

                            Console.Write("Enter Position: ");
                            string newPosition = Console.ReadLine();
```
**Line Explanation:**
- Collects remaining employee information
- No validation on these fields (accepts any input)
- Standard input pattern: prompt → read → store

---

```csharp
                            employeeName[currentEmployeeCount] = newName;
                            employeeID[currentEmployeeCount] = newID;
                            employeeGender[currentEmployeeCount] = newGender;
                            employeePosition[currentEmployeeCount] = newPosition;
```
**Line Explanation:**
- **Stores data** in the parallel arrays
- `currentEmployeeCount` acts as the **index** for the new employee
- If `currentEmployeeCount = 0`, data goes into index 0 (first slot)
- If `currentEmployeeCount = 5`, data goes into index 5 (sixth slot)
- All four arrays use the **same index** to link data together

---

```csharp
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\nSuccessfully Added New Employee!");
                            Console.ResetColor();

                            currentEmployeeCount++;
                        }
                        break;
```
**Line Explanation:**
- Displays **success message** with green background
- Green color indicates successful operation (UX convention)
- `\n` adds newline before the message
- `currentEmployeeCount++` is the **increment operator** (adds 1)
- `}` closes the else block
- `break` exits the switch statement

## Case 2: Remove Existing Employee

```csharp
                    case "2":
                        Console.Clear();
                        Console.WriteLine("===== Remove Existing Employee =====\n");
```
**Line Explanation:**
- Handles menu option 2 (remove employee)
- Clears screen and displays section header

---

```csharp
                        if (currentEmployeeCount == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Database is empty. Nothing to delete.");
                            Console.ResetColor();
                        }
```
**Line Explanation:**
- `==` is the **equality comparison** operator
- Checks if there are **no employees** in the system
- If empty, shows error message (can't delete from empty database)
- Prevents unnecessary operations on empty data

---

```csharp
                        else
                        {
                            Console.Write("Enter Employee ID to remove: ");
                            string deleteID = Console.ReadLine();
                            int deleteIndex = -1;
```
**Line Explanation:**
- Prompts for the ID of the employee to remove
- `deleteID` stores the ID to search for
- `deleteIndex = -1` initializes to an **invalid index**
  - Arrays use indices 0 and up
  - -1 is used as a **sentinel value** meaning "not found"

---

```csharp
                            for (int i = 0; i < currentEmployeeCount; i++)
                            {
                                if (employeeID[i] == deleteID)
                                {
                                    deleteIndex = i;
                                    break;
                                }
                            }
```
**Line Explanation:**
- `for` loop performs a **linear search** through the employee IDs
- `int i = 0` - initializes counter at 0
- `i < currentEmployeeCount` - loops through **only occupied slots**
- `i++` - increments counter each iteration
- `employeeID[i] == deleteID` - compares each ID to the target
- If found, stores the **index** in `deleteIndex`
- `break` exits the loop early (no need to keep searching)

---

```csharp
                            if (deleteIndex != -1)
                            {
```
**Line Explanation:**
- `!= ` is the **not equal** operator
- Checks if an employee was found (`deleteIndex` changed from -1)
- If -1, no match was found; otherwise, `deleteIndex` contains the position

---

```csharp
                                for (int i = deleteIndex; i < currentEmployeeCount - 1; i++)
                                {
                                    employeeName[i] = employeeName[i + 1];
                                    employeeID[i] = employeeID[i + 1];
                                    employeeGender[i] = employeeGender[i + 1];
                                    employeePosition[i] = employeePosition[i + 1];
                                }
```
**Line Explanation:**
- This performs **array element shifting** to remove the employee
- Starts at `deleteIndex` and goes to `currentEmployeeCount - 1`
- Each element is **overwritten** by the element after it
- Example: If deleting index 2 from [A, B, C, D, E]:
  - i=2: Copy D to position 2 → [A, B, D, D, E]
  - i=3: Copy E to position 3 → [A, B, D, E, E]
- This effectively **removes** the employee by shifting everything left
- The last element becomes a duplicate (but is ignored due to count)

**Visual Representation:**
```
Before: [John, Jane, Bob, Alice, ...]  (removing Jane at index 1)
Step 1: [John, Bob,  Bob, Alice, ...]  (Bob copied to index 1)
Step 2: [John, Bob,  Alice, Alice,...] (Alice copied to index 2)
After decreasing count, only first 3 are "visible"
```

---

```csharp
                                currentEmployeeCount--;
```
**Line Explanation:**
- `--` is the **decrement operator** (subtracts 1)
- Reduces the count since one employee was removed
- The "extra" element at the end is now **outside** the valid range

---

```csharp
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"\nSuccessfully Removed Employee");
                                Console.ResetColor();
                            }
```
**Line Explanation:**
- Success message with **green background**
- Confirms the deletion was successful

---

```csharp
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"\nError: Profile with ID '{deleteID}' could not be found.");
                                Console.ResetColor();
                            }
                        }
                        break;
```
**Line Explanation:**
- Executes when `deleteIndex == -1` (ID not found)
- Shows error with the **specific ID** that wasn't found
- String interpolation `{deleteID}` inserts the searched ID
- `break` exits case 2

---

## Case 3: View All Employees

```csharp
                    case "3":
                        Console.Clear();
                        Console.WriteLine("================================== Employee's List ===================================\n");
```
**Line Explanation:**
- Handles viewing all employees
- Wide header for the table display

---

```csharp
                        if (currentEmployeeCount == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("No Employee in Database!");
                            Console.ResetColor();
                        }
```
**Line Explanation:**
- Checks if database is empty
- Displays appropriate error message if no employees exist

---

```csharp
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------------------");
                            Console.WriteLine($"| {"#",-5} | {"Full Name",-20} | {"ID",-10} | {"Gender",-10} | {"Position",-25} |");
                            Console.WriteLine("--------------------------------------------------------------------------------------");
```
**Line Explanation:**
- Creates a **formatted table header**
- `{"#",-5}` is **composite formatting**:
  - `"#"` is the text to display
  - `-5` means **left-align** in a field of 5 characters
  - Negative numbers = left-align, positive = right-align
- Each column has a **fixed width** for alignment:
  - # : 5 characters
  - Full Name: 20 characters
  - ID: 10 characters
  - Gender: 10 characters
  - Position: 25 characters
- Dashes create horizontal lines

---

```csharp
                            for(int i = 0; i < currentEmployeeCount; i++)
                            {
                                Console.WriteLine($"| {i + 1,-5} | {employeeName[i],-20} | {employeeID[i],-10} | {employeeGender[i],-10} | {employeePosition[i],-25} |");
                            }
```
**Line Explanation:**
- Loops through **all stored employees**
- `i + 1` displays **1-based numbering** (more user-friendly than 0-based)
- Each array value is formatted with the **same width** as the header
- Creates aligned table rows

**Example Output:**
```
| 1     | John Doe             | EMP001     | Male       | Developer                 |
| 2     | Jane Smith           | EMP002     | Female     | Manager                   |
```

---

```csharp
                            Console.WriteLine("--------------------------------------------------------------------------------------");
                        }
                        break;
```
**Line Explanation:**
- Prints **bottom border** of the table
- `}` closes the else block
- `break` exits case 3

---

## Default Case and Loop Continuation

```csharp
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Invalid option code. Choose a value between 1 and 3.");
                        Console.ResetColor();
                        break;
                }
```
**Line Explanation:**
- `default:` catches **any value** not matching cases 1, 2, or 3
- Handles invalid input (e.g., "4", "abc", "")
- Error message in red guides user to valid options
- `}` closes the switch statement

---

```csharp
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
```
**Line Explanation:**
- `if (isRunning)` - always true (condition never changes)
- Sets **inverted colors** (black text on white background) for visibility
- `Console.ReadKey()` **pauses** until user presses any key
  - Different from `ReadLine()` - doesn't need Enter key
- After key press, loop repeats (back to menu)

---

## Summary Table

| Concept | Usage in Code |
|---------|---------------|
| **Constants** | `const int maxEmployees = 10` |
| **Arrays** | `string[] employeeName = new string[10]` |
| **Loops** | `while`, `for` |
| **Conditionals** | `if`, `else`, `switch` |
| **Input/Output** | `Console.ReadLine()`, `Console.WriteLine()` |
| **String Interpolation** | `$"Count: {variable}"` |
| **Formatting** | `{value,-width}` |
| **Console Colors** | `Console.BackgroundColor`, `Console.ForegroundColor` |

---
