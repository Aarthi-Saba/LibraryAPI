using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class EFCrud
    {
        private readonly EFContext _context;

        public EFCrud()
        {
            _context = new EFContext();
        }
        public void Add<T>(T poco)
        {
            _context.Add(poco);
            _context.SaveChanges();
        }
        public List<BookPoco> GetAllBooks(bool flag)
        {
            return _context.Books.Where(b => b.checkout == flag).ToList();
        }

        public void BookCheckout(Guid id, string bname)
        {
            var book = _context.Books.Where(b => b.Name == bname).FirstOrDefault();
            book.UserId = id;
            book.checkout = true;
            _context.SaveChanges();
        }

    }
}
