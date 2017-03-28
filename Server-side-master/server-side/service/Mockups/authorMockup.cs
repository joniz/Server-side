using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service.Models;
namespace service.Mockups
{
    class authorMockup
    {
        public static List<Author> authorList = new List<Author>
        {
            new Author {_aId = 1, _firstName = "Jonathan", _lastName = "Johansson", _birthYear = 1996 },
            new Author {_aId = 2, _firstName = "Linus", _lastName = "Warrén", _birthYear = 1997 },
            new Author {_aId = 3, _firstName = "kalle", _lastName = "kuöa", _birthYear = 1998 },
            new Author {_aId = 4, _firstName = "Jonathaadn", _lastName = "Jadwdohansson", _birthYear = 1999 }
        };  

    }
}
