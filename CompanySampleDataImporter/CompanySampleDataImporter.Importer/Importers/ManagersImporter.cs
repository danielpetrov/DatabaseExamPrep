namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data;

    public class ManagersImporter : IImporter
    {
        private const string ImportingMessageString = "Importing Managers";

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    ////tree ierarchy levels of employees in percent
                    var levels = new[] { 5, 5, 10, 10, 10, 15, 15, 15, 15 };

                    ////Returns each employees ids in random order
                    var allEmployeesIds = db.Employees
                        .OrderBy(e => Guid.NewGuid())
                        .Select(e => e.Id)
                        .ToList();

                    var currentPercentage = 0;
                    List<int> previousManager = null;

                    for (int i = 0; i < levels.Length; i++)
                    {
                        var level = levels[i];
                        var skip = (int)((currentPercentage * allEmployeesIds.Count) / 100.0);
                        var take = (int)((level * allEmployeesIds.Count) / 100.0);

                        ////gets a percent of employees depending on 
                        ////level and it makes sure we dont get the same employee twice
                        var currentEmployeesIds =
                            allEmployeesIds
                            .Skip(skip)
                            .Take(take)
                            .ToList();

                        ////Взима всички служители по ид от базата
                        var employees =
                            db
                            .Employees
                            .Where(e => currentEmployeesIds.Contains(e.Id))
                            .ToList();

                        ////foreach employee we got by logic we must update its manager
                        foreach (var emp in employees)
                        {
                            emp.ManagerId =
                            previousManager == null
                            ? null
                            : (int?)previousManager[(RandomGenerator.GetRandomNumber(0, previousManager.Count - 1))];
                        }

                        
                            tr.Write(".");
                        
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        

                        previousManager = currentEmployeesIds;
                        currentPercentage += level;
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
                return 3;
            }
        }
    }
}
