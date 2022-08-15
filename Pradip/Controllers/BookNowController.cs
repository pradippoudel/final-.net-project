using Pradip.Areas.Identity.Data;
using Pradip.Data;
using Pradip.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Pradip.Controllers
{
    public class BookNowController : Controller
    {
        public PradipContext _context;
        public BookNowController(PradipContext context)
        {
            _context = context;
        }
        public IActionResult MobilesDetails()
        {
            var mobileDetails = _context.Books.ToList();
            return View(mobileDetails);

        }

        public IActionResult BookNow()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> bookNowAsync(clientRecord cr)
        {
            if (ModelState.IsValid)
            {
                var e = new clientRecord()
                {
                    productName = cr.productName,
                    BuyerName = cr.BuyerName,
                    Address=cr.Address,
                    Contact=cr.Contact,
                };
                _context.Books.Add(e);
                await _context.SaveChangesAsync();
                TempData["msg"] = "Saved";
                return View();

            }
            else
            {
                TempData["error"] = "Some error occur";
                return View();
            }

        }
        public IActionResult Remove(int Id)
        {
            var PR = _context.Books.SingleOrDefault(p => p.Id == Id);
            _context.Books.Remove(PR);
            _context.SaveChanges();
            TempData["msg"] = "Successfully Deleted";
            return RedirectToAction("MobilesDetails");

        }


        public IActionResult Edit(int Id)
        {
            var edit = _context.Books.SingleOrDefault(p => p.Id == Id);
            return View(edit);
        }


        [HttpPost]
        public IActionResult Edit(clientRecord Pr)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(Pr);
                _context.SaveChanges();
                TempData["msg"] = "Update successfully";
                return RedirectToAction("MobilesDetails");
            }
            else
            {
                TempData["erreo"] = "Error occured";
                return View();
            }
        }
    }
}
