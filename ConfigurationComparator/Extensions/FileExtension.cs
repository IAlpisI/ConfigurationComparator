namespace ConfigurationComparator.Extensions
{
    public static class FileExtension
    {
        public static bool CheckFileExtention(this string fileName, string extension) =>
            fileName.Length >= extension.Length && fileName[^extension.Length..].Equals(extension);
    }
}
