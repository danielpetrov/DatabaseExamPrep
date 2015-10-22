namespace CompanySampleDataImporter.Importer
{
    using System.IO;
    using System.Reflection;
    using System.Linq;
    using Importers;
    using System;
    using Data;

    public class SampleDataImporter
    {
        /// <summary>
        /// Used instead of Console.Write...
        /// </summary>
        private TextWriter textWriter;

        private SampleDataImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public static SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

        /// <summary>
        /// GetExecutingAssembly - gets the current assembly
        /// GetTypes - gets the type of an object
        /// Where - from linq libraly, used to filter only classes that implement IImporter
        /// Select, Activator.CreateInstance and ofType used to make an instance of the selected class, not just object
        /// i.Get - uses action method for each of the instances
        /// </summary>
        public void Import()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IImporter).IsAssignableFrom(t)
                && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .OfType<IImporter>()
                .OrderBy(i => i.Order)
                .ToList()
                .ForEach(i =>
                {
                    this.textWriter.Write(i.Message);

                    var db = new CompanyEntities();
                    i.Get(db, this.textWriter);

                    textWriter.WriteLine();
                });
        }
     }
}
