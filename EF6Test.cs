using Xunit;
using Pocket.Domain;
using Pocket.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Web.Tests
{
    public class EF6Test
    {

        [Fact]
        public void Test1()
        {
            using (var ctx = new PocketEF6Context())
            {
                ctx.Database.Delete();
                ctx.Database.Create();
            }
        }

        [Fact]
        public void Test2()
        {
            using (var ctx = new PocketEF6Context())
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
            using (var ctx = new PocketEF6Context())
            {
                var results = ctx.Produces.Include(x => x.Items).ToList();
            }
        }
    }
}

