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

namespace service.Models
{
   public class Author
    {
       [Required, RegularExpression("^[0-9]"), StringLength(15, MinimumLength = 1)]
       public int _aId { get; set; }
       [Required, StringLength(30, MinimumLength = 2)]
       public string _firstName { get; set; }
       [Required, StringLength(30, MinimumLength = 2)]
       public string _lastName { get; set; }
       [Required, RegularExpression("^[0-9]{4}")]
       public int _birthYear { get; set; }

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
        
    }
}
