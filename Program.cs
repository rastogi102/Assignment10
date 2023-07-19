using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConAppAssignment10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Perform the selected operation

                Console.WriteLine("Choose an operation: ");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Read ");
                Console.WriteLine("3. Append");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Exit");

                int choice = GetChoiceFromUser();

                switch (choice)
                {
                    case 1:
                        CreateFile();
                        break;
                    case 2:
                        ReadFile();
                        break;
                    case 3:
                        AppendToFile();
                        break;
                    case 4:
                        DeleteFile();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static int GetChoiceFromUser()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                // Keep prompting until the user enters a valid integer choice

                Console.WriteLine("Invalid input. Please enter a valid choice.");
            }
            return choice;
        }

        static void CreateFile()
        {
            Console.WriteLine("Enter the file name: ");
            string fileName = Console.ReadLine();

            Console.WriteLine("Enter the content: ");
            string content = Console.ReadLine();

            try
            {
                // Create a new file with the given name and write the content to it

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(content);
                }
                Console.WriteLine($"File '{fileName}' created successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during file creation

                Console.WriteLine($"Error creating the file: {ex.Message}");
            }
        }

        static void ReadFile()
        {
            Console.WriteLine("Enter the file name to read: ");
            string fileName = Console.ReadLine();

            try
            {
                // Read the content of the specified file and display it to the user

                string content = File.ReadAllText(fileName);
                Console.WriteLine($"Content of '{fileName}':\n{content}");
            }
            catch (FileNotFoundException)

            {
                // Handle the case when the file is not found

                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                // Handle any other errors that occur during file reading

                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }

        static void AppendToFile()
        {
            Console.WriteLine("Enter the file name to append: ");
            string fileName = Console.ReadLine();

            Console.WriteLine("Enter the content to append: ");
            string contentToAppend = Console.ReadLine();

            try
            {
                // Append the provided content to the end of the specified file

                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.Write(contentToAppend);
                }
                Console.WriteLine($"Content appended to '{fileName}' successfully.");
            }
            catch (FileNotFoundException)
            {
                // Handle the case when the file is not found

                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                // Handle any other errors that occur during file appending

                Console.WriteLine($"Error appending to the file: {ex.Message}");
            }
        }

        static void DeleteFile()
        {
            Console.WriteLine("Enter the file name to delete: ");
            string fileName = Console.ReadLine().Trim(); // Trim the input to remove spaces

            try
            {
                if (File.Exists(fileName))
                {
                    // Delete the specified file if it exists

                    File.Delete(fileName);
                    Console.WriteLine($"File '{fileName}' deleted successfully.");
                }
                else
                {
                    // Inform the user when the file is not found
                    Console.WriteLine($"File '{fileName}' not found.");
                }
            }

            // Handle any errors that occur during file deletion
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting the file: {ex.Message}");
            }
        }

    }

}


