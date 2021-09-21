namespace ConfigurationComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var ev = new EnglishVisualization();
            var main = new Main(ev);
            main.Run();
        }
    }
}
