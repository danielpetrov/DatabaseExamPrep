namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.IO;
    using System.Linq;
    using Data;


    public class EmployeesImporter : IImporter
    {
        private const string ImportingMessageString = "Importing Employees";

        private const int NumberOfEmployees = 5000; // 5000

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    ////gets all departments ids
                    var deparmentsIds = db
                        .Department
                        .Select(d => d.Id)
                        .ToList();

                    for (int i = 0; i < NumberOfEmployees; i++)
                    {
                        ////gets random department id from the current department ids
                        var randomDepartmentId = deparmentsIds[RandomGenerator.GetRandomNumber(0, deparmentsIds.Count - 1)];

                        db.Employees.Add(new Employees
                        {
                            FirstName = RandomGenerator.GetRandomString(5, 20),
                            LastName = RandomGenerator.GetRandomString(5, 20),
                            YearSalary = RandomGenerator.GetRandomNumber(50000, 200000),
                            DepartmentId = randomDepartmentId
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
               return 2;
            }
        }
    }
}
