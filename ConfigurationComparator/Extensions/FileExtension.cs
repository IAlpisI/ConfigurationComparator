namespace ConfigurationComparator.Extensions
{
    public static class FileExtension
    {
        /// <summary>
        /// Check if file extension match
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="extension">Extensino</param>
        /// <returns></returns>
        public static bool FileExtentionMatch(this string fileName, string extension) =>
            fileName.Length >= extension.Length && fileName[^extension.Length..].Equals(extension);
    }
}
