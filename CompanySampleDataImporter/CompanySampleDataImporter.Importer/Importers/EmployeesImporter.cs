namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.IO;
    using Data;

    public class EmployeesImporter : IImporter
    {
        private const string ImportingMessageString = "Importing Employees";
        private const int NumberOfEmployees = 50; // 50000

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
               return 1;
            }
        }
    }
}
