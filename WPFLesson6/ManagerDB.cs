using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WPFLesson6
{
    public class ManagerDB : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ManagerDB() : this("name=ManagerDB") { }
        public ManagerDB(string ConnectionString) : base(ConnectionString) { }
    }
}
