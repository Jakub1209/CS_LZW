namespace _71695_2_4;

public class Compressor
{
    // create a predefined dictionary which contains every unique character from the input string
    public static List<string> CreatePredefinedDictionary(string input)
    {
        // define a list of chars for each unique character
        List<string> predefinedDictionary = new List<string>();
        // iterate over the whole input string and look for unique characters
        foreach (char c in input)
        {
            // change the type from char to string
            string s = c.ToString();
            // if a unique character is found, add it to the predefined dictionary list
            if (!predefinedDictionary.Contains(s)) predefinedDictionary.Add(s);
        }
        // return the list containing the list of unique characters from the input string
        return predefinedDictionary;
    }

    // get the full dictionary containing all the matching pairs
    public static (List<string> predefinedDictionaryWithPairs, List<int> compressedIndexes) GetFullDictionaryAndIndexes(string input)
    {
        // create the predefined dictionary which will contain the matched pairs
        List<string> predefinedDictionaryWithPairs = CreatePredefinedDictionary(input);
        // create a list which will contain the compressed indexes
        List<int> compressedIndexes = new List<int>();
        // loop through the input string and look for the longest match in the dictionary
        for (int i = 0; i < input.Length; i++)
        {
            // initialize an empty string to contain the longest match
            string maxMatchedCharacters = "";
            // loop through the input once again, checking for a match in the dictionary
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

            if (!predefinedDictionaryWithPairs.Contains(maxMatchedCharacters))
            {
                // Console.WriteLine($"added: {maxMatchedCharacters}, maxMatchedCharacters.length: {maxMatchedCharacters.Length}"); // debug
                // add the longest match to the current dictionary
                predefinedDictionaryWithPairs.Add(maxMatchedCharacters);
            }
            else
            {
                compressedIndexes.Add(predefinedDictionaryWithPairs.IndexOf(maxMatchedCharacters) + 1);
                // Console.WriteLine($"Found a match outside of the loop on the index: {predefinedDictionaryWithPairs.IndexOf(maxMatchedCharacters) + 1}"); // debug
            }
            
            // for some reason the program breaks if we don't check for the length of the maxMatchedCharacters
            if (maxMatchedCharacters.Length > 1) i += maxMatchedCharacters.Length - 2;
        }
        // return both the dictionary and the list containing the indexes
        return (predefinedDictionaryWithPairs, compressedIndexes);
    }
}