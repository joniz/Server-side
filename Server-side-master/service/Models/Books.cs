﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service.Mockups;
using repository.EntityModel;
using AutoMapper;
using repository;
using System.ComponentModel.DataAnnotations;

namespace service.Models
{
    public class Books
    {

        [StringLength(14, MinimumLength = 6), Required(ErrorMessage = "You must enter a isbn, 6-14 digits.")]
        public string ISBN { get; set; }
        [StringLength(140, MinimumLength = 3), Required, RegularExpression("^[0-9]")]
        public string Title { get; set; }
        public int SignId { get; set; }
        [Required(ErrorMessage = "You must enter a publication year, 4 digits."), RegularExpression("^[0-9]"), StringLength(4, MinimumLength = 4), Range(400, 2017)]
        public string PublicationYear { get; set; }
        public string PublicationInfo { get; set; }
        public int pages { get; set; }

        public Classification CLASSIFICATION { get; set; }


        [Required(ErrorMessage = "You must enter atleast one author.")]
        public List<Author> AUTHORs { get; set; }

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
        static public void editBook(Books bookObj)
        {
            e_BookObject.Update(Mapper.Map<BOOK>(bookObj));

        }
       



    }
}
