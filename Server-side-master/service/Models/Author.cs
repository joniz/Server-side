﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service.Mockups;
using repository;
using AutoMapper;
using repository.EntityModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace service.Models
{
   public class Author
    {

       public int Aid { get; set; }
       [Required, StringLength(30, MinimumLength = 2)]
       public string FirstName { get; set; }
       [Required, StringLength(30, MinimumLength = 2)]
       public string LastName { get; set; }
       [Required, RegularExpression("^[0-9]{4}")]
       public int? BirthYear { get; set; }
       
       public List<Books> bookList { get; set; }

        static private EAuthor e_aID = new EAuthor();

       
        static public Author getAuthor(int AID)
        {
            return Mapper.Map<Author>(e_aID.Read(AID));
        }
        static public List<Author> getAuthorList()
        {
            return Mapper.Map<List<AUTHOR>, List<Author>>(e_aID.List());
        }
        static public List<Books> getBooksFromAuthor(int aId)
        {
            return Mapper.Map<List<BOOK>, List<Books>>(e_aID.getBookList(aId));
        }
        static public void editAuthor(Author authObj)
        {
            e_aID.Update(Mapper.Map<AUTHOR>(authObj));
        }
        static public void addAuthor(Author authObj)
        {
            e_aID.Add(Mapper.Map<AUTHOR>(authObj));
        }
        

    }
}
