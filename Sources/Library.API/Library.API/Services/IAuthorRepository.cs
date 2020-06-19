using Library.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.API.Services
{
    public interface IAuthorRepository 
    {
        Task<bool> AuthorExistsAsync(Guid authorId);

        Task<IEnumerable<Author>> GetAuthorsAsync();

        Task<Author> GetAuthorAsync(Guid authorId);

        Task UpdateAuthor(Author author);

        Task<bool> SaveChangesAsync();
    }
}
