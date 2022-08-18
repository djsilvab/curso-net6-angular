namespace LinqSnippets
{
    public class Snippets
    {
        public static void Main()
        {
            var listTexts = new List<string> { "a", "b", "ab", "ca", "aa", "b" };
            //var uniqueTexts = listNumbers.Single();
            var uniqueOrDefaultTexts = listTexts.SingleOrDefault(x => x.Equals("a"));
            var respuesta = uniqueOrDefaultTexts;

            var evenNumbers = new List<int> { 0, 2, 4, 6, 8 };
            var othersEvenNumbers = new List<int> { 0, 2, 6 };
            var myEvenNumbers = evenNumbers.Except(othersEvenNumbers);

            var myOpinions = new List<string> {
                "Opinión 1, text 1",
                "Opinión 2, text 2",
                "Opinión 3, text 3",
                "Opinión 4, text 4"
            };

            var myOpinionSelection = myOpinions.SelectMany(x => x.Split(","));

           var enterprises = new List<Enterprise>
           {
                new Enterprise{
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new List<Employee>{
                        new Employee{ Id = 1, Name = "Martin", Email = "martin@gmail.com", Salary = 3000 },
                        new Employee{ Id = 2, Name = "Pepe", Email = "pepe@gmail.com", Salary = 1000 },
                        new Employee{ Id = 3, Name = "Juan", Email = "juan@gmail.com", Salary = 2000 },
                        new Employee{ Id = 4, Name = "Carlos", Email = "carlos@gmail.com", Salary = 4000 }
                    }
                },
                new Enterprise{
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new List<Employee>{
                        new Employee{ Id = 5, Name = "Ana", Email = "ana@gmail.com", Salary = 3500 },
                        new Employee{ Id = 6, Name = "Maria", Email = "maria@gmail.com", Salary = 1500 },
                        new Employee{ Id = 7, Name = "Pamela", Email = "pamela@gmail.com", Salary = 2500 },
                        new Employee{ Id = 8, Name = "Lourdes", Email = "lourdes@gmail.com", Salary = 4500 }
                    }
                }
           };

           //Obtain all employees of all enterprises
           var employeeList = enterprises.SelectMany(e => e.Employees);

           //Know if a list is empty
           bool hasEnterprises = enterprises.Any();

           bool hasEmployees = enterprises.Any(e => e.Employees.Any());

           //All enterprises at least has an employee with more than 1000$ of salary
           bool hasEmployeeWithSalaryMoreThanOrEqual1000 = enterprises.Any(e => e.Employees.Any(x => x.Salary > 1000));

            //linq collections
            var firstList = new List<string> { "a", "b", "c" };
            var secondList = new List<string> { "a", "c", "d" };

            //INNER JOIN -->clasico
            var commonResult = from element1 in firstList
                               join element2 in secondList
                               on element1 equals element2
                               select new { element1, element2 };

            //INNER JOIN -->moderno
            var commonResult1 = firstList.Join(secondList, e1 => e1, e2 => e2, (e1, e2) => new { e1, e2 });

            //OUTER JOIN -- LEFT
            var leftOuterJoin = from e1 in firstList
                                join e2 in secondList
                                on e1 equals e2 into tempList
                                from e3 in tempList.DefaultIfEmpty()
                                where e1 != e3
                                select new { Element = e1 };

            //OUTER JOIN -- MODERNO(*)
            var leftOuterJoin2 = from e1 in firstList
                                 from e2 in secondList.Where(x => x.Equals(e1)).DefaultIfEmpty()
                                 where !e1.Equals(e2)
                                 select new { Element = e1 };


            //OUTER JOIN -- RIGHT
            var rightOuterJoin = from e2 in secondList
                                 join e1 in firstList
                                 on e2 equals e1 into tempList
                                 from e3 in tempList.DefaultIfEmpty()
                                 where e2 != e3
                                 select new { Element = e2 };
            // UNION
            var unionList = leftOuterJoin2.Union(rightOuterJoin);

            //SKIP TAKE LINQ
            var myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var skipTwoFirstValues = myList.Skip(2);
            var skipTwoLastValues = myList.SkipLast(2);
            var skipWhileSmallerThan4 = myList.SkipWhile(n => n < 4);//va exceptuando los items que cumplen las condiciones //{4,5,...,10}

            //TAKE
            var takeFirstTwoValues = myList.Take(2);    
            var takeLastTwoValues = myList.TakeLast(2);
            var takeWhileSmallerThan4 = myList.TakeWhile(n => n < 4);//va tomando los items que cumplen las condiciones //{1,2,3}
        }
    }
}