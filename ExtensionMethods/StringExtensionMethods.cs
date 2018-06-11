namespace ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static int NumberOfWords(this string str)
        {
            return System.Text.RegularExpressions.Regex.Matches(str, @"((\w+(\s?)))").Count;
        }
    }
}
