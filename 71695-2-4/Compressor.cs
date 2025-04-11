namespace _71695_2_4;

public class Compressor
{
    // create a predefined dictionary which contains every unique character from the input string
    public static List<string> CreatePredefinedDictionary(string input)
    {
        // define a list of chars for each unique character
        List<string> predefinedDictionary = new List<string>();
        // add unique chars to the dictionary
        AddUniqueCharsToDictionary(ref predefinedDictionary, input);
        // return the list containing the list of unique characters from the input string
        return predefinedDictionary;
    }

    // add unique chars to the dictionary from the input string
    static void AddUniqueCharsToDictionary(ref List<string> predefinedDictionary, string input)
    {
        // iterate over the whole input string and look for unique characters
        foreach (char c in input)
        {
            // change the type from char to string
            string s = c.ToString();
            // if a unique character is found, add it to the predefined dictionary list
            if (!predefinedDictionary.Contains(s)) predefinedDictionary.Add(s);
        }
    }

    // get the list of indexes that have been matched from the dictionary to the input string
    public static List<int> GetCompressedIndexesList(string input)
    {
        // create the predefined dictionary which will contain the matched pairs
        List<string> predefinedDictionaryWithPairs = CreatePredefinedDictionary(input);
        // create a list which will contain the compressed indexes
        List<int> compressedIndexes = CreateCompressedIndexesList(ref predefinedDictionaryWithPairs, input);
        // return both the dictionary and the list containing the indexes
        return compressedIndexes;
    }

    // look for every unique pair in the input string and add that pair to the dictionary if it isn't already there.
    // keep track of the pairs that have been added by adding their indexes to the list of compressed indexes
    static List<int> CreateCompressedIndexesList(ref List<string> predefinedDictionaryWithPairs, string input)
    {
        List<int> compressedIndexes = new List<int>();
        
        for (int i = 0; i < input.Length; i++)
        {
            // initialize a bool for exiting the main for loop when the EOF marker is met
            bool exitMainForLoop = false;
            // initialize an empty string to contain the longest match
            string maxMatchedCharacters = "";
            // loop through the input once again, checking for a match in the dictionary
            CheckForMatchInDictionary(
                ref predefinedDictionaryWithPairs, 
                ref compressedIndexes,
                ref maxMatchedCharacters, 
                ref exitMainForLoop,
                input,
                i
                );
            // CheckForConditionsOutsideLoop(
            //     ref predefinedDictionaryWithPairs,
            //     ref compressedIndexes,
            //     ref maxMatchedCharacters,
            //     i
            //     );

            if (!predefinedDictionaryWithPairs.Contains(maxMatchedCharacters))
            {
                // Console.WriteLine($"added: {maxMatchedCharacters}, maxMatchedCharacters.length: {maxMatchedCharacters.Length}"); // debug
                // add the longest match to the current dictionary
                predefinedDictionaryWithPairs.Add(maxMatchedCharacters);
            }
            else
            {
                compressedIndexes.Add(predefinedDictionaryWithPairs.IndexOf(maxMatchedCharacters) + 1);
                // Console.WriteLine($"Found a match outside the loop on the index: {predefinedDictionaryWithPairs.IndexOf(maxMatchedCharacters) + 1}"); // debug
            }

            if (exitMainForLoop) break;
            
            // for some reason the program breaks if we don't check for the length of the maxMatchedCharacters
            if (maxMatchedCharacters.Length > 1) i += maxMatchedCharacters.Length - 2;
        }
        
        return compressedIndexes;
    }

    static void CheckForConditionsOutsideLoop(
        ref List<string> predefinedDictionaryWithPairs, 
        ref List<int> compressedIndexes, 
        ref string maxMatchedCharacters,
        int i
        )
    {
        if (!predefinedDictionaryWithPairs.Contains(maxMatchedCharacters))
        {
            // Console.WriteLine($"added: {maxMatchedCharacters}, maxMatchedCharacters.length: {maxMatchedCharacters.Length}"); // debug
            // add the longest match to the current dictionary
            predefinedDictionaryWithPairs.Add(maxMatchedCharacters);
        }
        else
        {
            compressedIndexes.Add(predefinedDictionaryWithPairs.IndexOf(maxMatchedCharacters) + 1);
            // Console.WriteLine($"Found a match outside the loop on the index: {predefinedDictionaryWithPairs.IndexOf(maxMatchedCharacters) + 1}"); // debug
        }
        // for some reason the program breaks if we don't check for the length of the maxMatchedCharacters
        if (maxMatchedCharacters.Length > 1) i += maxMatchedCharacters.Length - 2;
    }

    static void CheckForMatchInDictionary(
        ref List<string> predefinedDictionaryWithPairs, 
        ref List<int> compressedIndexes,
        ref string maxMatchedCharacters, 
        ref bool exitMainForLoop,
        string input,
        int i
        )
    {
        for (int j = i; j < input.Length; j++)
        {
            // if the dictionary has inside the highlighted character in the input (input[j]), add that char to the
            // longest match string and then look once again if the string plus the next character is also in the
            // dictionary
            if (predefinedDictionaryWithPairs.Contains(maxMatchedCharacters + input[j]))
            {
                // Console.WriteLine($"exists: maxMatchedCharacters: {maxMatchedCharacters}, input: {input[j]}"); // debug
                // if yes, then add that char to the string
                maxMatchedCharacters += input[j];
                // if the next character that could match would be out of bounds, exit the main for loop
                if (j + 1 >= input.Length)
                {
                    exitMainForLoop = true;
                    break;
                }
            }
            else
            {
                // add the index of the longest found match to the compressed indexes list. Add a 1 since it's a 1 based list
                compressedIndexes.Add(predefinedDictionaryWithPairs.IndexOf(maxMatchedCharacters) + 1);
                // Console.WriteLine($"not exists: maxMatchedCharacters: {maxMatchedCharacters}, input: {input[j]}, index: {predefinedDictionaryWithPairs.IndexOf(maxMatchedCharacters) + 1}"); // debug
                // if not, add the next char to the string so that it can be compressed
                maxMatchedCharacters += input[j];
                break;
            }
        }
    }
}