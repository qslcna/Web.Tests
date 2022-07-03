using Xunit;
using Pocket.Domain;
using Pocket.Context;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Web.Tests
{
    public class EFCoreTest
    {
        public DbContextOptions<PocketEFCoreContext> Option
        {
            get
            {
                var buidler = new DbContextOptionsBuilder<PocketEFCoreContext>();
                var connectString = "server=localhost;uid=root;pwd=toor;charset=utf8;persistsecurityinfo=True;database=pocket_efcore;DateTimeKind=Local";
                buidler.UseMySql(connectString, ServerVersion.AutoDetect(connectString));
                buidler.EnableSensitiveDataLogging();
                return buidler.Options;
        }
        }

        [Fact]
        public void Test1()
        {
            using (var ctx = new PocketEFCoreContext(this.Option))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }

        [Fact]
        public void Test2()
        {
            using (var ctx = new PocketEFCoreContext(this.Option))
            {
                var p = new Produce
                {
                    Date = DateTime.Now,
                    Items = new List<ProduceItem> {
                        new ProduceItem{
                            Count =1,
                        }
                    }
                };
                ctx.Produces.Add(p);
                ctx.SaveChanges();
            }
        }

        [Fact]
        public void Test3()
        {
            using (var ctx = new PocketEFCoreContext(this.Option))
            {
                var results = ctx.Produces.Include(x => x.Items).ToList();
            }
        }
    }
}

