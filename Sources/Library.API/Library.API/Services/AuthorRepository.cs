using Library.API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Services
{
    public class InMemoryAuthorRepository : IAuthorRepository
    {
        private List<Author> Authors = new List<Author>
        {
            new Author()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "George",
                    LastName = "RR Martin"
                },
                new Author()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Stephen",
                    LastName = "Fry"
                },
                new Author()
                {
                    Id = Guid.Parse("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"),
                    FirstName = "James",
                    LastName = "Elroy"
                },
                new Author()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    FirstName = "Douglas",
                    LastName = "Adams"
                }
        };


        public Task UpdateAuthor(Author author)
        {
            return Task.FromResult(Authors[Authors.FindIndex(a => a.Id == author.Id)] = author);
        }
       
        public Task<bool> AuthorExistsAsync(Guid authorId)
        {
            return Task.FromResult(Authors.Exists(a => a.Id == authorId));
        }

        public Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return Task.FromResult(Authors.AsEnumerable());
        }

        public Task<Author> GetAuthorAsync(Guid authorId)
        {
            return Task.FromResult(Authors.Find(a => a.Id == authorId));
        }

        public Task<bool> SaveChangesAsync()
        {
            return Task.FromResult(true);
        }
    }
}
