namespace _71695_2_4;

public class JS_71695_UserInteraction
{
    // greet the user using the predefined message
    static void JS_71695_GreetUser()
    {
        Console.WriteLine("Hello and welcome to LZW compression and decompression program!\n");
    }

    public static void JS_71695_RunProgram()
    {
        // greet the user using the predefined message
        JS_71695_GreetUser();
        // run the standard user dialog for the whole duration of the program
        do
        {
            // compress the string for the user and ask if the user wants to see the results
            JS_71695_InteractionForCompression(JS_71695_AskUserForValidResponse());
        }
        // while the user still wants to use the program, continue executing the algorithm
        while (JS_71695_UserWantsToUseProgram());
    }

    static string JS_71695_AskUserForValidResponse()
    {
        // initialize an empty string to keep the user input
        string JS_71695_input;
        // until the user enters a valid string, ask him to enter a response
        do
        {
            Console.WriteLine("Enter your input of choice to compress into the field below: ");
            JS_71695_input = Console.ReadLine();
            Console.WriteLine();
        }
        // check if the input from the user is valid
        while (!JS_71695_Checker.JS_71695_IsValidForCompression(JS_71695_input));
        // return the aquired string from the user
        return JS_71695_input;
    }

    // ask the user if he wants to continue using the program and return his answer as a bool
    static bool JS_71695_UserWantsToUseProgram()
    {
        // get the bool from the user answer
        bool JS_71695_runProgram = JS_71695_InteractionForRunningProgram();
        return JS_71695_runProgram;
    }

    // ask the user if he wants to keep running the program
    static bool JS_71695_InteractionForRunningProgram()
    {
        Console.WriteLine("Would you like to use the program again? (Y/N): ");
        while (true)
        {
            // keep the pressed key in a variable
            ConsoleKey JS_71695_key = Console.ReadKey(true).Key;
            // if the pressed key is Y, continue using the program
            if (JS_71695_key == ConsoleKey.Y)
            {
                Console.WriteLine("I'm so glad! Let's do compressing once again!");
                Console.WriteLine();
                return true;
            }
            // if the pressed key is N, say goodbye to the user and exit the program
            if (JS_71695_key == ConsoleKey.N)
            {
                Console.WriteLine("Goodbye! Have a beautiful day and don't forget to smile! :D");
                return false;
            }
            // else, make the user know he pressed the wrong button
            Console.WriteLine("You have pressed an incorrect key! Please try again (Y/N): ");
        }
    }

    // handle the compression interaction for the user
    static void JS_71695_InteractionForCompression(string JS_71695_input)
    {
        // get the list of compressed indexes
        List<int> JS_71695_indexes = JS_71695_Compressor.JS_71695_GetCompressedIndexesList(JS_71695_input);
        // get the predefined dictionary containing each unique letter in the string
        List<string> JS_71695_predefinedDictionary = JS_71695_Dictionary.JS_71695_CreatePredefinedDictionary(JS_71695_input);
        // manage the users interaction when prompted with the compressed result
        JS_71695_InteractionAfterCompression(ref JS_71695_indexes, ref JS_71695_predefinedDictionary);
        // ask the user if he would like to decompress the string and later check for differences
        JS_71695_InteractionForDecompression(ref JS_71695_indexes, ref JS_71695_predefinedDictionary, ref JS_71695_input);
    }

    // handle the decompression interaction for the user
    static void JS_71695_InteractionForDecompression(
        ref List<int> JS_71695_indexes, 
        ref List<string> JS_71695_predefinedDictionary, 
        ref string JS_71695_input
        )
    {
        Console.WriteLine("Would you like to use the decompression algorithm? (Y/N): ");
        while (true)
        {
            ConsoleKey JS_71695_key = Console.ReadKey(true).Key;
            
            if (JS_71695_key == ConsoleKey.Y)
            {
                // decompress the input and save it into this list
                List<string> JS_71695_decompressedResult = JS_71695_Decompressor.JS_71695_Decompress(JS_71695_predefinedDictionary, JS_71695_indexes);
                // print out the decompressed result
                Console.Write("Decompressed string: ");
                foreach (string JS_71695_s in JS_71695_decompressedResult)
                {
                    Console.Write(JS_71695_s);
                }
                Console.WriteLine("\n");
                // ask the user if he would like to validate the result of the decompression
                InteractionAfterDecompression(ref JS_71695_input, ref JS_71695_decompressedResult);
                // exit the while loop
                break;
            }

            if (JS_71695_key == ConsoleKey.N)
            {
                Console.WriteLine("I've worked so hard on this algorithm... well...");
                Console.WriteLine();
                break;
            }
            
            Console.WriteLine("You have pressed an incorrect key! Please try again (Y/N): ");
        }
    }

    static void InteractionAfterDecompression(ref string JS_71695_input, ref List<string> JS_71695_decompressedResult)
    {
        Console.WriteLine("Would you like to check if the decompression was successful? (Y/N): ");
        while (true)
        {
            ConsoleKey JS_71695_key2 = Console.ReadKey(true).Key;
    
            if (JS_71695_key2 == ConsoleKey.Y)
            {
                Console.WriteLine("Side by side comparison of characters:");
                for (int JS_71695_i = 0; JS_71695_i < JS_71695_input.Length; JS_71695_i++)
                {
                    Console.WriteLine($"char index: {JS_71695_i}, input char: {JS_71695_input[JS_71695_i]}, " +
                                      $"output char: {string.Join("", JS_71695_decompressedResult)[JS_71695_i]}");
                }

                Console.WriteLine();
                if (JS_71695_input != string.Join("", JS_71695_decompressedResult))
                {
                    Console.WriteLine("There are differences in the string!");
                    for (int JS_71695_i = 0; JS_71695_i < JS_71695_input.Length; JS_71695_i++)
                    {
                        if (JS_71695_input[JS_71695_i] != string.Join("", JS_71695_decompressedResult)[JS_71695_i])
                        {
                            Console.WriteLine($"char index: {JS_71695_i}, input char: {JS_71695_input[JS_71695_i]}, " +
                                              $"output char {string.Join("", JS_71695_decompressedResult)[JS_71695_i]}");
                        }
                    }
                }
                else Console.WriteLine("There are no differences! Compression and decompression successful!");
                Console.WriteLine();
                // exit the while loop
                break;
            }

            if (JS_71695_key2 == ConsoleKey.N)
            {
                Console.WriteLine("Oh you...");
                Console.WriteLine();
                break;
            } 
            Console.WriteLine("You have pressed an incorrect key! Please try again (Y/N): ");
        }
    }

    static void JS_71695_InteractionAfterCompression(
        ref List<int> JS_71695_indexes, 
        ref List<string> JS_71695_predefinedDictionary
        )
    {
        Console.WriteLine("Your string has been compressed! Would you like to see the results? (Y/N): ");
        while (true)
        {
            ConsoleKey JS_71695_key = Console.ReadKey(true).Key;
            
            if (JS_71695_key == ConsoleKey.Y)
            {
                // print out the indexes list
                Console.Write("compressed indexes list: [");
                for (int JS_71695_i = 0; JS_71695_i < JS_71695_indexes.Count; JS_71695_i++)
                {
                    if (JS_71695_i == JS_71695_indexes.Count - 1) Console.WriteLine($"{JS_71695_indexes[JS_71695_i]}]");
                    else Console.Write($"{JS_71695_indexes[JS_71695_i]}, ");
                }
                // print out the dictionary
                Console.Write("predefined dictionary: [");
                for (int JS_71695_i = 0; JS_71695_i < JS_71695_predefinedDictionary.Count; JS_71695_i++)
                {
                    if (JS_71695_i == JS_71695_predefinedDictionary.Count - 1)
                    {
                        Console.WriteLine($"{JS_71695_predefinedDictionary[JS_71695_i]}]");
                    }
                    else Console.Write($"{JS_71695_predefinedDictionary[JS_71695_i]}, ");
                }

                Console.WriteLine();
                // exit the while loop
                break;
            }

            if (JS_71695_key == ConsoleKey.N)
            {
                Console.WriteLine("You don't want to see the result of my work? Aww...");
                Console.WriteLine();
                break;
            }
            Console.WriteLine("You have pressed an incorrect key! Please try again (Y/N): ");
        }
    }
}