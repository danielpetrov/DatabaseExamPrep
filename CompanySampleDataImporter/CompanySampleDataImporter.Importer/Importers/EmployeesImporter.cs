namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.IO;
    using Data;

    public class EmployeesImporter : IImporter
    {
        private const string ImportingMessageString = "Importing Employees";
        private const int NumberOfEmployees = 500; // 5000

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {

                    for (int i = 0; i < NumberOfEmployees; i++)
                    {
                        db.Employees.Add(new Employees
                        {
                            FirstName = RandomGenerator.GetRandomString(5, 20),
                            LastName = RandomGenerator.GetRandomString(5, 20),
                            YearSalary = RandomGenerator.GetRandomNumber(50000, 200000),

                        });

                        if (i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }
                    }

                    db.SaveChanges();
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
