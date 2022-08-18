using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}