using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToB.Common.GenericRepository;

namespace ConsoleApplication1.Dal
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class TestDbContext : BaseDbContext
    {
        //TODO : Find the reason, why we need this line.
        DbSet<Pocos.Table1> Movies { get; set; }

        public TestDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
    }
}
