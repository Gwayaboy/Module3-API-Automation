using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.API.Controllers
{

    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorsRepository;

        public AuthorsController(IAuthorRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return Ok(await _authorsRepository.GetAuthorsAsync());
        }

        [HttpGet("{authorId}")]
        public async Task<ActionResult<Author>> GetAuthor(Guid authorId)
        {
            var authorFromRepo =  await _authorsRepository.GetAuthorAsync(authorId);
            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(authorFromRepo);
        }

        [HttpPut("{authorId}")]
        public async Task<ActionResult<Author>> UpdateAuthor(
            Guid authorId,
            AuthorForUpdate authorForUpdate)
        {
            var author = await _authorsRepository.GetAuthorAsync(authorId);
            if (author == null)
            {
                return NotFound();
            }


            //// update & save
            await _authorsRepository.UpdateAuthor(author);
            await _authorsRepository.SaveChangesAsync();

            // return the author
            return Ok(author); 
        }

        [HttpPatch("{authorId}")]
        public async Task<ActionResult<Author>> UpdateAuthor(
            Guid authorId,
            JsonPatchDocument<AuthorForUpdate> patchDocument)
        {
            var author = await _authorsRepository.GetAuthorAsync(authorId);
            if (author == null)
            {
                return NotFound();
            }

            // update & save
            await _authorsRepository.UpdateAuthor(author);
            await _authorsRepository.SaveChangesAsync();

            // return the author
            return Ok(author);
        }
    }
}
