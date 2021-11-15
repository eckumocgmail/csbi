using csbi_test_clients_dictionary.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csbi_test_clients_dictionary.Data
{
    public class CrmDbContext: DbContext
    {
        public CrmDbContext(   ) : base( )
        {
        }

        public CrmDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerInfo> Customers { get; set; }

        //
        // Сводка:
        //     Override this method to configure the database (and other options) to be used
        //     for this context. This method is called for each instance of the context that
        //     is created. The base implementation does nothing.
        //     In situations where an instance of Microsoft.EntityFrameworkCore.DbContextOptions
        //     may or may not have been passed to the constructor, you can use Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured
        //     to determine if the options have already been set, and skip some or all of the
        //     logic in Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder).
        //
        // Параметры:
        //   optionsBuilder:
        //     A builder used to create or modify options for this context. Databases (and other
        //     extensions) typically define extension methods on this object that allow you
        //     to configure the context.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured==false)
            {
                optionsBuilder.UseInMemoryDatabase(nameof(CrmDbContext));
            }
        }


    }
}
