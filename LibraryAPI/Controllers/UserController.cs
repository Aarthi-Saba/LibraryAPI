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
    [Route("api/library/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EFCrud _ef;
        public UserController()
        {
            _ef = new EFCrud();
        }
        [HttpGet]
        [Route("browsebooks")]
        public ActionResult GetBookList(bool checkoutflag)
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
        [HttpPut]
        [Route("checkoutbook/{userid}/{bookname}")]
        public ActionResult GetBook(Guid userid, string bookname)
        {
            _ef.BookCheckout(userid, bookname);
            return Ok();
        }
        [HttpPost]
        [Route("adduserinfo")]
        public ActionResult PostUserInfo(UserPoco user)
        {
            _ef.Add(user);
            return Ok();
        }
    }
}