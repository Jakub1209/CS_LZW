﻿namespace _71695_2_4;

class Program
{
    static void Main(string[] args)
    {
        // string input = "LATA_OSA_KOŁO_NOSA_LATA_MUCHA_KOŁO_UCHA_LATA_BĄK_KOŁO_RĄK_LATA_OSA_KOŁO_NOSA_LATA_MUCHA_KOŁO_UCHA_LATA_BĄK_KOŁO_RĄK_LATA_OSA_KOŁO_NOSA_LATA_MUCHA_KOŁO_UCHA_LATA_BĄK_KOŁO_RĄK";
        string input = "DBCDDCBBBCDBADBADACBCABACBACDCBCACDACADDBAAADBDCBDDDABACBCCAAACBCDBCBDADDBBBBCCBDDDBBAADDCDCCDADBDCDCCACADCDCAADDCDBAAABBACCDBDABBDCDBCCBCADDDDACCCCCBCBADDCDDCDBBCDCCBDCDBDABDBBDAABBAACACABDACAAADACAABDBCAABADCCADDBCACACBAACA";
        var (dictionary, indexes) = Compressor.GetFullDictionaryAndIndexes(input);

        Console.WriteLine("dictionary:");
        foreach (string s in dictionary)
        {
            Console.WriteLine(s);
        }
        
        Console.WriteLine("indexes:");
        foreach (int i in indexes)
        {
            Console.WriteLine($"index {i}, dictionaryEntry: {dictionary[i-1]}");
        }
        
        List<string> predefinedDictionary = Compressor.CreatePredefinedDictionary(input);
        
        List<string> decompressedResult = Decompressor.Decompress(predefinedDictionary, indexes);
        string result = string.Join("", decompressedResult);
        Console.Write("decompressedResult: ");
        foreach (string s in decompressedResult)
        {
            Console.Write(s);
        }
        Console.WriteLine();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != result[i])
            {
                Console.Write($"There character on index {i} shoulbe be {input[i]}, not {result[i]}!");
            }
        }
    }
}