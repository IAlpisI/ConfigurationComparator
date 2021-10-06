namespace ConfigurationComparator.Extensions
{
    public static class FileExtension
    {
        public static bool CheckFileExtention(this string fileName, string extension) =>
            fileName.Length >= extension.Length && fileName[^extension.Length..].Equals(extension);

        public static string GetFileWithoutExtention(this string fileName, string extension) =>
            fileName[0..^extension.Length];

    }
}
