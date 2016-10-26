using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FetchAndStore.Models;

namespace FetchAndStore.DAL
{
    public class StoreRepository
    {
        public StoreContext Context { get; set; }

        public StoreRepository()
        {
            Context = new StoreContext();
        }

        public StoreRepository(StoreContext _context)
        {
            Context = _context;
        }

        public List<Response> GetResponses()
        {
            return Context.Responses.ToList();
        }

        public void AddResponse(Response userResponse)
        {
            Context.Responses.Add(userResponse);
            Context.SaveChanges();
        }
    }
}