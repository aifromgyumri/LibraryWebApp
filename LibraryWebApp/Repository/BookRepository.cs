using LibraryWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Repository
{
    public class BookRepository : AbstractRepository<Book>
    {
        public BookRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Book> GetAll()
        {
            return _dbContext.Books.AsNoTracking().ToArray();
        }

        public override Book GetById(long id)
        {
            return _dbContext.Books.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}