namespace ConfigurationComparatorAPI.Extensions
{
    public static class GetFileWithoutTypeExtension
    {
        public static string GetFileWithoutExtention(this string fileName, string extension) =>
                fileName[0..^extension.Length];
    }
}
