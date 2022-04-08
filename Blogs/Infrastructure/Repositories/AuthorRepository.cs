using System.Collections.Generic;
using System.Linq;
using Blogs.Application.Models;
using Blogs.Application.Repositories;

namespace Blogs.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BlogsDbContext _dbContext;

        public AuthorRepository( BlogsDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( Author author )
        {
            _dbContext.Set<Author>().Add( author );
        }

        public void DeleteById( int id )
        {
            Author author = GetById( id );
            if ( author == null )
            {
                return;
            }

            _dbContext.Set<Author>().Remove( author );
        }

        public List<Author> GetAll()
        {
            return _dbContext.Set<Author>().ToList();
        }

        public Author GetById( int id )
        {
            return _dbContext.Set<Author>().FirstOrDefault( x => x.Id == id );
        }
    }
}
