﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CookBook
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KniggaShopEntities1 : DbContext
    {

        private static KniggaShopEntities1 _context;

        public KniggaShopEntities1()
            : base("name=KniggaShopEntities1")
        {
        }

        public static KniggaShopEntities1 GetContext()
        {
            if (_context == null)
            {
                _context = new KniggaShopEntities1();
            }

            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderBook> OrderBook { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}