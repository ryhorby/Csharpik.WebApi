using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.Common;
using Csharpik.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly CsharpikContext _cotnext;

        public BookRepository(CsharpikContext cotnext)
        {
            _cotnext = cotnext;
        }

        public ObjectListDto GetAllBooks()
        {
            ObjectListDto dto = new ObjectListDto();

            try
            {
                dto.HttpCode = 200;
                dto.ObjList = _cotnext.Books.ToList();
            }
            catch (Exception ex)
            {
                dto.HttpCode = 404;
                dto.ErrorMessage = ex.Message;
            }
            
            return dto;
        }

        public ObjectDto GetBookById(int id)
        {
            ObjectDto dto = new ObjectDto();

            try
            {
                dto.HttpCode = 200;
                dto.Obj = _cotnext.Books.Where(b => b.Id == id).Single();
            }
            catch (Exception ex)
            {
                dto.HttpCode = 404;
                dto.ErrorMessage = ex.Message;
            }

            return dto;
        }
    }
}
