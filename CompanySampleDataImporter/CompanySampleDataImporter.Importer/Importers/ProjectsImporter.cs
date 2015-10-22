namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.IO;
    using System.Linq;
    using Data;

    public class ProjectsImporter : IImporter
    {
        private const string ImportingMessageString = "Importing Projects";

        private const int NumberOfProjects = 100;//1000

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var allEmployees =
                            db
                            .Employees
                            .OrderBy(e => Guid.NewGuid())
                            .Select(e => e.Id)
                            .ToList();

                    var currentEmployeeIndex = 0;

                    for (int i = 0; i < NumberOfProjects; i++)
                    {
                        var currentProject = new Project
                        {
                            Name = RandomGenerator.GetRandomString(5, 50),
                        };

                        var numberOfEmployeesPerProject = RandomGenerator.GetRandomNumber(2, 8);

                        for (int j = 0; j < numberOfEmployeesPerProject; j++)
                        {
                            if (j + currentEmployeeIndex >= allEmployees.Count)
                            {
                                break;
                            }

                            var currentEmployeeId = allEmployees[currentEmployeeIndex];
                            var startDate = RandomGenerator.GetRandomDate(before: DateTime.Now.AddDays(-1));
                            var endDate = RandomGenerator.GetRandomDate(after: startDate);

                            currentProject.ProjectsEmployees.Add(new ProjectsEmployees
                            {
                                EmployeesId = currentEmployeeId,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                            currentEmployeeIndex++;
                        }

                        db.Project.Add(currentProject);

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
                return 4;
            }
        }
    }
}
