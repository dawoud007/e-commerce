
using bulkey.DataAccess;
using bulkey.DataAccess.Repository;
using bulkey.DataAccess.Repository.IRepository;
using bulkey.Models;
using bulkey.Models.ViewModels;
using bulkey.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bulkey.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_User_Admin)]

    public class    CompanController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        
        }

        public IActionResult Index()
        {
            return View();
        }



        //ubsert  
        public IActionResult Upsert(int? id)
        {
           Compan compan =new Compan();


            if (id == null || id == 0)
            {
                //create product
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                return View(compan);
            }
            else
            {
                compan = _unitOfWork.Compan.GetFirstOrDefault(u => u.Id == id);
                return View(compan);

                //update product
            }


        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Compan obj)
        {

            if (ModelState.IsValid)
            {
               

                
                if (obj.Id == 0)
                {
                    _unitOfWork.Compan.Add(obj);
                    TempData["success"] = "company created successfully";
                }
                else
                {
                    _unitOfWork.Compan.Update(obj);
                    TempData["success"] = "comany updated successfully";
                }
                _unitOfWork.Save();
             
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //delete




        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var productList=_unitOfWork.Compan.GetAll();
            return Json(new {data=productList});
        }

        [HttpDelete]
       
        public IActionResult Delete(int? id)
        {


            var obj = _unitOfWork.Compan.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new {success=false,message="error while deleting"});
            }
            
            _unitOfWork.Compan.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "producted deledted successfully" });
           

        }
        #endregion
    }
}
