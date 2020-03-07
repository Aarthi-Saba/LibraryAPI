using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pocos;

namespace LibraryAPI.Controllers
{
    [Route("api/library/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly EFCrud _ef;
        public StaffController()
        {
            _ef = new EFCrud();
        }
        [HttpGet]
        [Route("book/{checkoutflag}")]
        public ActionResult GetCheckedOutBooks(bool checkoutflag)
        {
            var result = _ef.GetAllBooks(checkoutflag);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("addbook")]
        public ActionResult PostBook(BookPoco book)
        {
            _ef.Add(book);
            return Ok();

        }
    }
}