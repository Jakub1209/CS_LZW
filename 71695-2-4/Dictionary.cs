namespace _71695_2_4;

public class Dictionary
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

    private static void AddUniqueCharsToDictionary(ref List<string> predefinedDictionary, string input)
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
}