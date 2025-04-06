namespace _71695_2_4;

class Program
{
    static void Main(string[] args)
    {
        string input = "LATA_OSA_KOŁO_NOSA_LATA_MUCHA_KOŁO_UCHA";
        
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
    }
}