﻿namespace ConfigurationComparator
{
    public interface IConsole
    {
        public void PrintToConsole(string value);
        public string ReadInput();
        public void PrintToConsole();
    }
}