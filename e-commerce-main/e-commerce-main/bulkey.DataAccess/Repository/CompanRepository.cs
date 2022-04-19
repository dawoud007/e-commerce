
using bulkey.DataAccess;
using bulkey.DataAccess.Repository;
using bulkey.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulkey.DataAccess.Repositories


{
    public class CompanRepository : Repository<Compan>,ICompanRepository
    {
        private ApplicationDbContext _db;
        public CompanRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

      
        public void Update(Compan obj)
        {
            _db.newComp.Update(obj);
        }
    }
}

