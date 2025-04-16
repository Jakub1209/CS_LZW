namespace _71695_2_4;

public class JS_71695_Compressor
{ 
    // get the list of indexes that have been matched from the dictionary to the input string
    public static List<int> JS_71695_GetCompressedIndexesList(string JS_71695_input)
    {
        // create the predefined dictionary which will contain the matched pairs
        List<string> JS_71695_predefinedDictionaryWithPairs = JS_71695_Dictionary.JS_71695_CreatePredefinedDictionary(JS_71695_input);
        // create a list which will contain the compressed indexes
        List<int> JS_71695_compressedIndexes = JS_71695_CreateCompressedIndexesList(ref JS_71695_predefinedDictionaryWithPairs, JS_71695_input);
        // return both the dictionary and the list containing the indexes
        return JS_71695_compressedIndexes;
    }

    // look for every unique pair in the input string and add that pair to the dictionary if it isn't already there.
    // keep track of the pairs that have been added by adding their indexes to the list of compressed indexes
    static List<int> JS_71695_CreateCompressedIndexesList(ref List<string> JS_71695_predefinedDictionaryWithPairs, string JS_71695_input)
    {
        // initialize a new list to hold the compressed indexes
        List<int> JS_71695_compressedIndexes = new List<int>();
        // loop through the input string looking for matches in the dictionary and add them to the list
        JS_71695_LoopThroughTheInput(ref JS_71695_predefinedDictionaryWithPairs, ref JS_71695_compressedIndexes, JS_71695_input);
        // return the list of compressed indexes
        return JS_71695_compressedIndexes;
    }

    static void JS_71695_LoopThroughTheInput(ref List<string> JS_71695_predefinedDictionaryWithPairs, ref List<int> JS_71695_compressedIndexes,
        string JS_71695_input)
    {
        for (int JS_71695_i = 0; JS_71695_i < JS_71695_input.Length; JS_71695_i++)
        {
            // initialize a bool for exiting the main for loop when the EOF marker is met
            bool JS_71695_exitMainForLoop = false;
            // initialize an empty string to contain the longest match
            string JS_71695_maxMatchedCharacters = "";
            // loop through the input once again, checking for a match in the dictionary
            JS_71695_CheckForMatchInDictionary(
                ref JS_71695_predefinedDictionaryWithPairs, 
                ref JS_71695_compressedIndexes,
                ref JS_71695_maxMatchedCharacters, 
                ref JS_71695_exitMainForLoop,
                JS_71695_input,
                JS_71695_i
            );
            // notice if several criteria regarding the dictionary pairs are met
            JS_71695_CheckForConditionsOutsideLoop(
                ref JS_71695_predefinedDictionaryWithPairs,
                ref JS_71695_compressedIndexes,
                ref JS_71695_maxMatchedCharacters,
                ref JS_71695_i
            );
            // if the code wants to exit the main loop, do it
            if (JS_71695_exitMainForLoop) break;
        }
    }

    static void JS_71695_CheckForConditionsOutsideLoop(
        ref List<string> JS_71695_predefinedDictionaryWithPairs, 
        ref List<int> JS_71695_compressedIndexes, 
        ref string JS_71695_maxMatchedCharacters,
        ref int JS_71695_i
        )
    {
        // if the matched characters aren't already in the dictionary, add the longest match to it
        if (!JS_71695_predefinedDictionaryWithPairs.Contains(JS_71695_maxMatchedCharacters)) JS_71695_predefinedDictionaryWithPairs.Add(JS_71695_maxMatchedCharacters);
        // if they are, simply add the compressed index to the indexes list
        else JS_71695_compressedIndexes.Add(JS_71695_predefinedDictionaryWithPairs.IndexOf(JS_71695_maxMatchedCharacters) + 1);
        // for some reason the program breaks if we don't check for the length of the maxMatchedCharacters
        if (JS_71695_maxMatchedCharacters.Length > 1) JS_71695_i += JS_71695_maxMatchedCharacters.Length - 2;
    }

    static void JS_71695_CheckForMatchInDictionary(
        ref List<string> JS_71695_predefinedDictionaryWithPairs, 
        ref List<int> JS_71695_compressedIndexes,
        ref string JS_71695_maxMatchedCharacters, 
        ref bool JS_71695_exitMainForLoop,
        string JS_71695_input,
        int JS_71695_i
        )
    {
        for (int JS_71695_j = JS_71695_i; JS_71695_j < JS_71695_input.Length; JS_71695_j++)
        {
            // if the dictionary has inside the highlighted character in the input (input[j]), add that char to the
            // longest match string and then look once again if the string plus the next character is also in the
            // dictionary
            if (JS_71695_predefinedDictionaryWithPairs.Contains(JS_71695_maxMatchedCharacters + JS_71695_input[JS_71695_j]))
            {
                // Console.WriteLine($"exists: maxMatchedCharacters: {maxMatchedCharacters}, input: {input[j]}"); // debug
                // if yes, then add that char to the string
                JS_71695_maxMatchedCharacters += JS_71695_input[JS_71695_j];
                // if the next character that could match would be out of bounds, exit the main for loop
                if (JS_71695_j + 1 >= JS_71695_input.Length)
                {
                    JS_71695_exitMainForLoop = true;
                    break;
                }
            }
            else
            {
                // add the index of the longest found match to the compressed indexes list. Add a 1 since it's a 1 based list
                JS_71695_compressedIndexes.Add(JS_71695_predefinedDictionaryWithPairs.IndexOf(JS_71695_maxMatchedCharacters) + 1);
                // Console.WriteLine($"not exists: maxMatchedCharacters: {maxMatchedCharacters}, input: {input[j]}, index: {predefinedDictionaryWithPairs.IndexOf(maxMatchedCharacters) + 1}"); // debug
                // if not, add the next char to the string so that it can be compressed
                JS_71695_maxMatchedCharacters += JS_71695_input[JS_71695_j];
                break;
            }
        }
    }
}