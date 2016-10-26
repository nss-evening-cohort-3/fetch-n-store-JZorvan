using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FetchAndStore.Models;

namespace FetchAndStore.DAL
{
    public class StoreContext : DbContext
    {
        public virtual DbSet<Response> Responses { get; set; }
    }
}