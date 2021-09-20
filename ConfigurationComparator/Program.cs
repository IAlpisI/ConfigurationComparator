namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var englishViz = new EnglishVisualization();
            var main = new Main(englishViz);
            main.Run();
        }
    }
}
