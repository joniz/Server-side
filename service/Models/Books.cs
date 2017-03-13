using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service.Mockups;
using repository.EntityModel;
using AutoMapper;
using repository;
namespace service.Models

{
    public class Books
    {
        public string _ISBN { get; set; }
        public string _title { get; set; }
        public int _signId { get; set; }
        public int _publicationYear { get; set; }
        public string _publicationInfo { get; set; }
        public int _pages { get; set; }
        public Classification CLASSIFICATION { get; set; }
        public List<Author> AUTHORS { get; set; }

        static private EBooks e_ISBN = new EBooks();

        static public Books getBook(string ISBN)
        {
            return Mapper.Map<Books>(e_ISBN.Read(ISBN));
        }
        static public List<Books> getBookList()
        {
            return Mapper.Map<List<BOOK>, List<Books>>(e_ISBN.List());
        }
        static public List<Author> getBookAuthor(string isbn)
        {
            return Mapper.Map<List<AUTHOR>, List<Author>>(e_ISBN.AuthorList(isbn));
        }
        static public List<Author> getAllA()
        {
            return Mapper.Map<List<AUTHOR>, List<Author>>(e_ISBN.getAllAuthors());




        }
    }
}
