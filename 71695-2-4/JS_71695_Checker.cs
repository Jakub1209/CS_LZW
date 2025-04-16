namespace _71695_2_4;

public class JS_71695_Checker
{
    // check is the inputted string is valid for compression
    public static bool JS_71695_IsValidForCompression(string JS_71695_input)
    {
        // the string cannot be null, or be all made from white spaces
        if (!JS_71695_NoNullOrWhiteSpace(JS_71695_input)) return false;
        // the string cannot be too short or too long
        if (!JS_71695_LengthIsValid(JS_71695_input)) return false;
        // the string cannot contain control characters
        if (!JS_71695_NoControlCharacters(JS_71695_input)) return false;
        // if everything seems fine, accept the string for compression
        return true;
    }

    static bool JS_71695_NoControlCharacters(string JS_71695_input)
    {
        // if any of the chars entered into the string are a control character, but it isn't a white space,
        // reject that string
        if (JS_71695_input.Any(JS_71695_c => char.IsControl(JS_71695_c) && !char.IsWhiteSpace(JS_71695_c)))
        {
            Console.WriteLine("The string shouldn't contain control characters like these:\n" +
                              "- Null (0x00)\n" +
                              "- Start of Heading (0x01)\n" +
                              "- Start of Text (0x02)\n" +
                              "- End of Text (0x03)\n" +
                              "- Backspace (0x08)\n" +
                              "- Horizontal Tab (0x09)\n" +
                              "- Line Feed (0x0A)\n" +
                              "- Vertical Tab (0x0B)\n" +
                              "- Form Feed (0x0C)\n" +
                              "- Carriage Return (0x0D)\n" +
                              "- Escape (0x1B)\n" +
                              "- Delete (0x7F)\n" +
                              "- Please, try again!");
            return false;
        }
        return true;
    }

    static bool JS_71695_LengthIsValid(string JS_71695_input)
    {
        // hard-code the min and max length a string should be
        int JS_71695_minLength = 10;  // Too short to benefit from compression
        int JS_71695_maxLength = 1_000_000;  // Prevent denial-of-service
        // check if the length requirements are met
        if (JS_71695_input.Length < JS_71695_minLength || JS_71695_input.Length > JS_71695_maxLength)
        {
            Console.WriteLine($"The minimum string length should be: {JS_71695_minLength} and the max length: " +
                              $"{JS_71695_maxLength}.\n Your is: {JS_71695_input.Length}. Please, try again!");
            return false;
        }
        return true;
    }

    static bool JS_71695_NoNullOrWhiteSpace(string JS_71695_input)
    {
        if (string.IsNullOrWhiteSpace(JS_71695_input))
        {
            Console.WriteLine("The string cannot be null or empty. Please, try again!");
            // reject that string
            return false;
        }
        return true;
    }
    
    // check if the string has been decompressed correctly, by analyzing each of the characters in the input and output strings
    public static void JS_71695_CheckIfDecompressedCorrectly(string JS_71695_input, string JS_71695_output)
    {
        // for every character in the input string,
        for (int JS_71695_i = 0; JS_71695_i < JS_71695_input.Length; JS_71695_i++)
        {
            // check if the character at a specified index is the same as the character on the same index in the output string
            // if not, write where the problem is
            if (JS_71695_input[JS_71695_i] != JS_71695_output[JS_71695_i])
            {
                Console.WriteLine($"The character on index {JS_71695_i}: '{JS_71695_input[JS_71695_i]}' " +
                                  $"is not the same as the character on the output '{JS_71695_output[JS_71695_i]}'");
            }
        }

        // if the input string is equal to the output string, note that the string has been correctly compressed
        if (JS_71695_input == JS_71695_output)
        {
            Console.WriteLine("Compressed Correctly!");
        }
        else
        {
            Console.WriteLine("Decompressed Incorrectly!");
        }
    }
}