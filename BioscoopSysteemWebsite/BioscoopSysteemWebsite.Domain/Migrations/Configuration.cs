using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;
namespace BioscoopSysteemWebsite.Domain.Migrations {


    [ExcludeFromCodeCoverage]
    internal sealed class Configuration : DbMigrationsConfiguration<BioscoopSysteemWebsite.Domain.Concrete.ApplicationDbContext>
    {
        //Geschreven door Gregor Hoogstad
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BioscoopSysteemWebsite.Domain.Concrete.ApplicationDbContext context)
        {
        }
    }
}
