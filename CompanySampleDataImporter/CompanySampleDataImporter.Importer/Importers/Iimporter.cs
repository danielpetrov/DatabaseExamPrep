namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.IO;
    using Data;

    public interface IImporter
    {
        /// <summary>
        /// Message on the console, so we know which Importer is curently activated
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Order in which the Importers will be executed
        /// </summary>
        int Order { get; }

        /// <summary>
        /// Action Method for generating data to the database
        /// </summary>
        Action<CompanyEntities, TextWriter> Get { get; }
    }
}
