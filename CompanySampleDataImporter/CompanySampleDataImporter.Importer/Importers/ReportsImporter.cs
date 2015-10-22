namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.IO;
    using System.Linq;
    using Data;

    public class ReportsImporter : IImporter
    {
        private const string ImportingMessageString = "Importing Reports";

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var allEmployees =
                            db
                            .Employees
                            .Select(e => e.Id)
                            .ToList();

                    var numberOfReportsPerEmployee = 0;

                    for(int i = 0; i < allEmployees.Count; i++)
                    {
                        numberOfReportsPerEmployee = RandomGenerator.GetRandomNumber(25,75);

                        for (int j = 0; j < numberOfReportsPerEmployee; j++)
                        {
                            db.Reports.Add(new Reports
                            {
                                EmployeeId = allEmployees[i],
                                Time = RandomGenerator.GetRandomDate(before: DateTime.Now)
                            });
                        }

                        tr.Write(".");

                        db.SaveChanges();
                        db.Dispose();
                        db = new CompanyEntities();
                    }
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
                return 5;
            }
        }
    }
}
