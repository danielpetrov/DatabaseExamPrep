namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.IO;
    using CompanySampleDataImporter.Data;

    public class DepartmentsImporter : IImporter
    {
        private const string ImportingMessageString = "Importing Departments";

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {

                };
            }
        }

        public string Message
        {
            get
            {
                return ImportingMessageString;
            }
        }

        public int Order
        {
            get
            {
                return 2;
            }
        }
    }
}
