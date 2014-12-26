using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemanticTypes.SemanticTypeQualifiedByTypeExamples;

namespace SemanticTypes.Test
{
    [TestClass]
    public class IdTests
    {
        private class Book
        {
            public Id<Book> BookId { get; set; }
            public string Title { get; set; }
            public Id<Author> AuthorId { get; set; }
        }

        private class Author
        {
            public Id<Author> AuthorId { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
        }

        private void f(Id<Book> bookId)
        {
        }

        [TestMethod]
        public void IdGreaterThan0_Succeeds()
        {
            var author = new Author
            {
                AuthorId = new Id<Author>(1),
                Name = "Leo Tolstoy"
            };

            var book = new Book
            {
                AuthorId = author.AuthorId,
                BookId = new Id<Book>(2),
                Title = "War And Peace"
            };

            Assert.AreEqual(2, book.BookId.Value);

            // Doesn't compile
            // book.BookId = 5;

            // Doesn't compile
            // f(author.AuthorId);

            // Doesn't compile
            // f(5);

            // Compiles
            f(book.BookId);
        }
    }
}
