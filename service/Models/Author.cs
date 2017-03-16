using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service.Mockups;
using repository;
using AutoMapper;
using repository.EntityModel;
namespace service.Models
{
   public class Author
    {
        
       public int Aid { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public int BirthYear { get; set; }
       public Classification CLASSIFICATION { get; set; }
       public List<Books> BOOK { get; set; }

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
