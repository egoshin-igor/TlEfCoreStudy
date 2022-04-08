using System.Collections.Generic;
using System.Linq;
using Blogs.Api.Dtos;
using Blogs.Application;
using Blogs.Application.Models;
using Blogs.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Controllers
{
    [ApiController]
    [Route( "authors" )]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(
            IAuthorRepository authorRepository,
            IUnitOfWork unitOfWork )
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public List<AuthorDto> GetAll()
        {
            List<Author> authors = _authorRepository.GetAll();

            return authors.Select( x => new AuthorDto
            {
                Id = x.Id,
                Name = x.Name,
            } ).ToList();
        }

        [HttpGet( "{id}" )]
        public AuthorDto GetById( [FromRoute] int id )
        {
            Author author = _authorRepository.GetById( id );
            if ( author == null )
                return null;

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        [HttpDelete( "{id}" )]
        public void DeleteById( [FromRoute] int id )
        {
            _authorRepository.DeleteById( id );

            _unitOfWork.Commit();
        }

        [HttpPost]
        public void Add( [FromBody] AddAuthorCommandDto command )
        {
            _authorRepository.Add( new Author( command.Name ) );

            _unitOfWork.Commit();
        }

        [HttpPut( "{id}" )]
        public IActionResult Update( [FromRoute] int id, [FromBody] AddAuthorCommandDto command )
        {
            Author author = _authorRepository.GetById( id );
            if ( author == null )
            {
                return BadRequest();
            }
            author.Update( command.Name );

            _unitOfWork.Commit();

            return Ok();
        }
    }
}
