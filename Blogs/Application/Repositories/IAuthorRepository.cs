using Blogs.Application.Models;
using System.Collections.Generic;

namespace Blogs.Application.Repositories
{
    public interface IAuthorRepository
    {
        void Add( Author author );
        void DeleteById( int id );
        Author GetById( int id );
        List<Author> GetAll();
    }
}
