namespace _71695_2_4;

public class JS_71695_Decompressor
{
    public static List<string> JS_71695_Decompress(List<string> JS_71695_predefinedDictionary, List<int> JS_71695_compressedIndexes)
    {
        // initialize a list of strings for the decompressed result
        List<string> JS_71695_decompressedResult = new List<string>();
        // initialize a list containing the complete dictionary. This list will be constantly updated during the decompression
        List<string> JS_71695_completeDictionary = JS_71695_predefinedDictionary;
        // for each index in the compressedIndexes list, add the corresponding entry in the dictionary to the output
        for (int JS_71695_i = 0; JS_71695_i < JS_71695_compressedIndexes.Count; JS_71695_i++)
        {
            JS_71695_AddDecompressedStringToOutput(
                ref JS_71695_compressedIndexes, 
                ref JS_71695_completeDictionary, 
                ref JS_71695_decompressedResult, 
                JS_71695_i
                );
        }
        // return the result of the decompression
        return JS_71695_decompressedResult;
    }
    
    static void JS_71695_AddDecompressedStringToOutput(
        ref List<int> JS_71695_compressedIndexes, 
        ref List<string> JS_71695_completeDictionary, 
        ref List<string> JS_71695_decompressedResult, 
        int JS_71695_i
        )
    {
        // keep track of the current index for the dictionary entry
        int JS_71695_compressedIndex = JS_71695_compressedIndexes[JS_71695_i] - 1;
        // keep track of the next compressed index.
        int JS_71695_nextCompressedIndex = 0;
        // initialize a string which will hold the new entry for the dictionary
        string JS_71695_newDictionaryEntry = "";
        // If there aren't any indexes, just add the current index and end the decompression
        if (JS_71695_i + 1 < JS_71695_compressedIndexes.Count)
        {
            JS_71695_AddIndexToDictionary(
                ref JS_71695_compressedIndexes, 
                ref JS_71695_completeDictionary, 
                ref JS_71695_nextCompressedIndex, 
                ref JS_71695_newDictionaryEntry, 
                ref JS_71695_compressedIndex, 
                ref JS_71695_i);
        }
        // add the dictionary entry to the result list
        JS_71695_decompressedResult.Add(JS_71695_completeDictionary[JS_71695_compressedIndex]);
    }

    static void JS_71695_AddIndexToDictionary(
        ref List<int> JS_71695_compressedIndexes, 
        ref List<string> JS_71695_completeDictionary, 
        ref int JS_71695_nextCompressedIndex, 
        ref string JS_71695_newDictionaryEntry, 
        ref int JS_71695_compressedIndex, 
        ref int JS_71695_i
        )
    {
        // if there isn't an entry in the dictionary with this current index
        if (JS_71695_compressedIndexes[JS_71695_i + 1] > JS_71695_completeDictionary.Count)
            // the next compressed index should be the same as the current one
            JS_71695_nextCompressedIndex = JS_71695_compressedIndexes[JS_71695_i] - 1;
        else
            // if it is, the next compressed index should be 0 based so we subtract one from the result
            JS_71695_nextCompressedIndex = JS_71695_compressedIndexes[JS_71695_i + 1] - 1;
        // the next dictionary entry should be the current dictionary entry + the first character of the next entry
        JS_71695_newDictionaryEntry = JS_71695_completeDictionary[JS_71695_compressedIndex] + JS_71695_completeDictionary[JS_71695_nextCompressedIndex][0];
        // add new dictionary entry to the dictionary
        JS_71695_completeDictionary.Add(JS_71695_newDictionaryEntry);
    }
}