﻿using System;
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
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int SignId { get; set; }
        public string PublicationYear { get; set; }
        public string PublicationInfo { get; set; }
        public int pages { get; set; }
        public Classification CLASSIFICATION { get; set; }
        public List<Author> AUTHORS { get; set; }

        static private EBooks e_BookObject = new EBooks();

        static public Books getBook(string ISBN)
        {
            return Mapper.Map<Books>(e_BookObject.Read(ISBN));
        }
        static public List<Books> getBookList()
        {
            return Mapper.Map<List<BOOK>, List<Books>>(e_BookObject.List());
        }
        static public List<Author> getBookAuthor(string isbn)
        {
            return Mapper.Map<List<AUTHOR>, List<Author>>(e_BookObject.AuthorList(isbn));
        }
        static public void updateBook(Books bookObject)
        {
            //e_BookObject.Update(Mapper.Map<BOOK>(bookObject));

        }
        static public List<Author> getAllA()
        {
            return Mapper.Map<List<AUTHOR>, List<Author>>(e_BookObject.getAllAuthors());
        }
        static public void addBook(Books bookObj)
        {
            e_BookObject.Add(Mapper.Map<BOOK>(bookObj));

        }
    }
}
