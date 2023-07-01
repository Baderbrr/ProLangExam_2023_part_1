namespace Utilities;

public class StringUtilities
{
	public static int ToWords(string input)
	{
		return input.Split(' ').Length;
	}

	public static string ToSentence(string input)
	{
		string fLetter = input[0].ToString().ToUpper();
		string rLetters = input.Substring(1, input.Length - 1).ToLower();
		string result = fLetter + rLetters;
		return result;
	}


}