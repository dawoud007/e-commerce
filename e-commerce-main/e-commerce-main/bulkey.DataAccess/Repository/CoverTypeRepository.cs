using bulkey.DataAccess.Repository.IRepository;
using bulkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulkey.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }

   

        public void Update(CoverType obj)
        {
            _db.coverTypes.Update(obj);
        }
    }
}
