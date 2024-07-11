using System.Text;

namespace ProblemSolving.Utilities;

public static class Utils
{
    public static string ReverseString(string s)
    {
        var reversedString = new StringBuilder();

        for (int i = s.Length - 1; i >= 0; i--)
        {
            reversedString.Append(s[i]);
        }

        return reversedString.ToString();
    }
    public static bool IsPalindrome(string s)
    {
        var index = 0;

        while (index < s.Length / 2)
        {
            if (s[index] != s[s.Length - index - 1])
            {
                return false;
            }

            index++;
        }

        return true;
    }

    public static IEnumerable<int> MissingElements(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int diff = arr[i + 1] - arr[i];
            if (diff > 1)
            {
                for (int j = 1; j < diff; j++)
                {
                    yield return arr[i] + j;
                }
            }
        }
    }
}
