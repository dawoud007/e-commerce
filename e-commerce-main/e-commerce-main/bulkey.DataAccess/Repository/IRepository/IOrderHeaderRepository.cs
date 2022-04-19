
using bulkey.DataAccess.Repository.IRepository;
using bulkey.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulkey.DataAccess.Repository.IRepository
{
 public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {

        void Update(OrderHeader obj);
        void UpdateStatus(int id, string orderstatus,string? paymentStatus=null);
        void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId);
    }
}
