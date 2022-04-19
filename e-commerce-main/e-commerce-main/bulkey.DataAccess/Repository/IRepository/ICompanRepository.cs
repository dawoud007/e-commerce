
using bulkey.DataAccess.Repository.IRepository;
using bulkey.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulkey.DataAccess.Repositories
{
    public interface ICompanRepository : IRepository<Compan>
    {
        void Update(Compan obj);
        
    }
}
