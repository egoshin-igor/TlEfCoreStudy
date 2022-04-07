using System.Collections.Generic;
using Blogs.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Controllers
{
    [ApiController]
    [Route( "authors" )]
    public class AuthorsController : ControllerBase
    {
        public AuthorsController()
        {
        }

        [HttpGet]
        public List<AuthorDto> GetAll()
        {
            return new List<AuthorDto>
            {
                new AuthorDto{ Id = 1, Name = "Ivan" }
            };
        }

        [HttpGet( "{id}" )]
        public AuthorDto GetById( [FromRoute] int id )
        {
            return new AuthorDto { Id = id, Name = "Ivan" };
        }

        [HttpDelete( "{id}" )]
        public void DeleteById( [FromRoute] int id )
        {

        }

        [HttpPost]
        public void Add( [FromBody] AddAuthorCommandDto command )
        {

        }

        [HttpPut( "{id}" )]
        public void Update( [FromBody] AddAuthorCommandDto command )
        {

        }
    }
}
