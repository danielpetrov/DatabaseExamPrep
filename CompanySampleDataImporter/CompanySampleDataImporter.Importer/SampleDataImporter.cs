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
        private TextWriter textWriter;

        private SampleDataImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public static SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

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
                    this.textWriter.WriteLine(i.Message);

                    var db = new CompanyEntities();
                    i.Get(db, this.textWriter);
                });
        }
     }
}
