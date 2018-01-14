using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Notepad.Models;

namespace Notepad.Migrations
{
    public class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext db)
        {
            db.Records.Add(new Record { Id = Guid.NewGuid(), Note = "Л. Толстой" });
            db.Records.Add(new Record { Id = Guid.NewGuid(), Note = "И. Тургенев" });
            db.Records.Add(new Record { Id = Guid.NewGuid(), Note = "А. Чехов" });

            db.SaveChanges();
            
        }
    }
}