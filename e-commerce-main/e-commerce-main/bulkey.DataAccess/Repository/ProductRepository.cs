using bulkey.DataAccess.Repository.IRepository;
using bulkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulkey.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }

   

        public void Update(Product obj)
        {
            var objFromDb=_db.products.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb == null)
            {
               
                objFromDb.Description=obj.Description;
                objFromDb.ISBN=obj.ISBN;
                objFromDb.CoverTypeId=obj.CoverTypeId;
                objFromDb.ListPrice=obj.ListPrice;
                objFromDb.Author=obj.Author;
                objFromDb.Price100=obj.Price100;
                objFromDb.Price50=obj.Price50;
                objFromDb.Category=obj.Category;
                objFromDb.ListPrice= obj.ListPrice;
               
                objFromDb.Title=obj.Title;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl=obj.ImageUrl;
                }
            }
        }
    }
}
