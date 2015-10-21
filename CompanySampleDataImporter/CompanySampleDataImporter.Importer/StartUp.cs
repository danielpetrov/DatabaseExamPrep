namespace CompanySampleDataImporter.Importer
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            RandomGenerator.GetRandomDate();
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
