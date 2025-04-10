namespace _71695_2_4;

public class Decompressor
{
    public static List<string> Decompress(List<string> predefinedDictionary, List<int> compressedIndexes)
    {
        // initialize a list of strings for the decompressed result
        List<string> decompressedResult = new List<string>();
        // initialize a list containing the complete dictionary. This list will be constantly updated during the decompression
        List<string> completeDictionary = predefinedDictionary;
        // for each index in the compressedIndexes list, add the corresponding entry in the dictionary to the output
        Console.WriteLine("Decompressing dictionary...");
        for (int i = 0; i < compressedIndexes.Count; i++)
        {
            // keep track of the current index for the dictionary entry
            int compressedIndex = compressedIndexes[i] - 1;
            // keep track of the next compressed index.
            int nextCompressedIndex = 0;
            // initialize a string which will hold the new entry for the dictionary
            string newDictionaryEntry = "";
            // If there aren't any indexes, just add the current index and end the decompression
            if (i + 1 < compressedIndexes.Count)
            {
                // if there isn't an entry in the dictionary with this current index
                if (compressedIndexes[i + 1] > completeDictionary.Count)
                    // the next compressed index should be the same as the current one
                    nextCompressedIndex = compressedIndexes[i] - 1;
                else
                    // if it is, the next compressed index should be 0 based so we subtract one from the result
                    nextCompressedIndex = compressedIndexes[i + 1] - 1;
                // the next dictionary entry should be the current dictionary entry + the first character of the next entry
                newDictionaryEntry = completeDictionary[compressedIndex] + completeDictionary[nextCompressedIndex][0];
                // add new dictionary entry to the dictionary
                completeDictionary.Add(newDictionaryEntry);
            }
            else
            {
                newDictionaryEntry = completeDictionary[compressedIndex];
            }
            
            Console.WriteLine($"compressedIndex: {compressedIndexes[i]}, completeDictionary[base0compressedIndex]: {completeDictionary[compressedIndex]}, completeDictionary[nextCompressedIndex][0]: {completeDictionary[nextCompressedIndex][0]}, Added entry: {newDictionaryEntry}");
            // add the dictionary entry to the result list
            decompressedResult.Add(completeDictionary[compressedIndex]);
            Console.WriteLine($"Decompressed entry: {completeDictionary[compressedIndex]}");
        }
        
        return decompressedResult;
    }
}