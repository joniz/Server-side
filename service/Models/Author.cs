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
        
       public int _aId { get; set; }
       public string _firstName { get; set; }
       public string _lastName { get; set; }
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
        
    }
}
