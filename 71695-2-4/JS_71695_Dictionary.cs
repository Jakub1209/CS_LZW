namespace _71695_2_4;

public class JS_71695_Dictionary
{
    // create a predefined dictionary which contains every unique character from the input string

    public static List<string> JS_71695_CreatePredefinedDictionary(string JS_71695_input)
    {
        // define a list of chars for each unique character
        List<string> JS_71695_predefinedDictionary = new List<string>();
        // add unique chars to the dictionary
        JS_71695_AddUniqueCharsToDictionary(ref JS_71695_predefinedDictionary, JS_71695_input);
        // return the list containing the list of unique characters from the input string
        return JS_71695_predefinedDictionary;
    }

    // add unique chars to the dictionary from the input string

    private static void JS_71695_AddUniqueCharsToDictionary(ref List<string> JS_71695_predefinedDictionary, string JS_71695_input)
    {
        // iterate over the whole input string and look for unique characters
        foreach (char JS_71695_c in JS_71695_input)
        {
            // change the type from char to string
            string JS_71695_s = JS_71695_c.ToString();
            // if a unique character is found, add it to the predefined dictionary list
            if (!JS_71695_predefinedDictionary.Contains(JS_71695_s)) JS_71695_predefinedDictionary.Add(JS_71695_s);
        }
    }
}