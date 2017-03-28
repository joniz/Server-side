using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service.Mockups;
namespace service.Models
{
   public class Author
    {
       public int _aId { get; set; }
       public string _firstName { get; set; }
       public string _lastName { get; set; }
       public int _birthYear { get; set; }


        public static List<Author> getAuthorList()
        {
            return Mockups.authorMockup.authorList;
        }

    }
}
