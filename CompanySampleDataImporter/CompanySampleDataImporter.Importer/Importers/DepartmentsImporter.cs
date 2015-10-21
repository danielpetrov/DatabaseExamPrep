namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.IO;
    using Data;

    public class DepartmentsImporter : IImporter
    {
        private const string ImportingMessageString = "Importing Departments";
        private const int NumberOfDepartments = 100;

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    for (int i = 0; i < NumberOfDepartments; i++)
                    {
                        db.Department.Add(new Department
                        {
                            Name = RandomGenerator.GetRandomString(10, 50)
                        });

                        if(i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if(i % 100 == 0)
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
