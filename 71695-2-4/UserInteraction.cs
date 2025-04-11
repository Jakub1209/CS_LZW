namespace _71695_2_4;

public class UserInteraction
{
    public static void GreetUser()
    {
        Console.WriteLine("Hello and welcome to LZW compression and decompression program!\n");
    }

    public static void RunProgram()
    {
        do
        {
            // initialize an empty string to keep the user input
            string input;
            // until the user enters a valid string, ask him to enter a response
            do
            {
                Console.WriteLine("Enter your input of choice to compress into the field below: ");
                input = Console.ReadLine();
                Console.WriteLine();
            }
            // check if the input from the user is valid
            while (!JS_71695_Checker.JS_71695_IsValidForCompression(input));

            // compress the string for the user and ask if the user wants to see the results
            InteractionForCompression(input);
        } 
        while (UserWantsToUseProgram());
    }

    static bool UserWantsToUseProgram()
    {
        bool runProgram = InteractionForRunningProgram();
        
        return runProgram;
    }

    static bool InteractionForRunningProgram()
    {
        Console.WriteLine("Would you like to use the program again? (Y/N): ");
        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            
            if (key == ConsoleKey.Y)
            {
                Console.WriteLine("I'm so glad! Let's do compressing once again!");
                Console.WriteLine();
                break;
            }

            if (key == ConsoleKey.N)
            {
                Console.WriteLine("I've worked so hard on this algorithm... well...");
                Console.WriteLine();
                break;
            }
            
            Console.WriteLine("You have pressed an incorrect key! Please try again (Y/N): ");
        }
        return true;
    }

    static void InteractionForCompression(string input)
    {
        // get the list of compressed indexes
        List<int> indexes = Compressor.GetCompressedIndexesList(input);
        // get the predefined dictionary containing each unique letter in the string
        List<string> predefinedDictionary = Dictionary.CreatePredefinedDictionary(input);
        // manage the users interaction when prompted with the compressed result
        InteractionAfterCompression(ref indexes, ref predefinedDictionary);
        // ask the user if he would like to decompress the string and later check for differences
        InteractionForDecompression(ref indexes, ref predefinedDictionary, ref input);
    }

    static void InteractionForDecompression(ref List<int> indexes, ref List<string> predefinedDictionary, ref string input)
    {
        Console.WriteLine("Would you like to use the decompression algorithm? (Y/N): ");
        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            
            if (key == ConsoleKey.Y)
            {
                // decompress the input and save it into this list
                List<string> decompressedResult = Decompressor.Decompress(predefinedDictionary, indexes);
                // print out the decompressed result
                Console.Write("Decompressed string: ");
                foreach (string s in decompressedResult)
                {
                    Console.Write(s);
                }
                Console.WriteLine("\n");
                // ask the user if he would like to validate the result of the decompression
                InteractionAfterDecompression(ref input, ref decompressedResult);
                // exit the while loop
                break;
            }

            if (key == ConsoleKey.N)
            {
                Console.WriteLine("I've worked so hard on this algorithm... well...");
                Console.WriteLine();
                break;
            }
            
            Console.WriteLine("You have pressed an incorrect key! Please try again (Y/N): ");
        }
    }

    static void InteractionAfterDecompression(ref string input, ref List<string> decompressedResult)
    {
        Console.WriteLine("Would you like to check if the decompression was successful? (Y/N): ");
        while (true)
        {
            ConsoleKey key2 = Console.ReadKey(true).Key;
    
            if (key2 == ConsoleKey.Y)
            {
                Console.WriteLine("Side by side comparison of characters:");
                for (int i = 0; i < input.Length; i++)
                {
                    Console.WriteLine($"char index: {i}, input char: {input[i]}, output char: {string.Join("", decompressedResult)[i]}");
                }

                Console.WriteLine();
                if (input != string.Join("", decompressedResult))
                {
                    Console.WriteLine("There are differences in the string!");
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] != string.Join("", decompressedResult)[i])
                        {
                            Console.WriteLine($"char index: {i}, input char: {input[i]}, output char {string.Join("", decompressedResult)[i]}");
                        }
                    }
                }
                else Console.WriteLine("There are no differences! Compression and decompression successful!");
                Console.WriteLine();
                // exit the while loop
                break;
            }

            if (key2 == ConsoleKey.N)
            {
                Console.WriteLine("Oh you...");
                Console.WriteLine();
                break;
            } 
            Console.WriteLine("You have pressed an incorrect key! Please try again (Y/N): ");
        }
    }

    static void InteractionAfterCompression(ref List<int> indexes, ref List<string> predefinedDictionary)
    {
        Console.WriteLine("Your string has been compressed! Would you like to see the results? (Y/N): ");
        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            
            if (key == ConsoleKey.Y)
            {
                // print out the indexes list
                Console.Write("compressed indexes list: [");
                for (int i = 0; i < indexes.Count; i++)
                {
                    if (i == indexes.Count - 1) Console.WriteLine($"{indexes[i]}]");
                    else Console.Write($"{indexes[i]}, ");
                }
                // print out the dictionary
                Console.Write("predefined dictionary: [");
                for (int i = 0; i < predefinedDictionary.Count; i++)
                {
                    if (i == predefinedDictionary.Count - 1) Console.WriteLine($"{predefinedDictionary[i]}]");
                    else Console.Write($"{predefinedDictionary[i]}, ");
                }

                Console.WriteLine();
                // exit the while loop
                break;
            }

            if (key == ConsoleKey.N)
            {
                Console.WriteLine("You don't want to see the result of my work? Aww...");
                Console.WriteLine();
                break;
            }
            Console.WriteLine("You have pressed an incorrect key! Please try again (Y/N): ");
        }
    }
}