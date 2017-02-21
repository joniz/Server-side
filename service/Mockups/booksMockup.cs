using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service.Models;

namespace service.Mockups
{
    class booksMockup
    {
        static public List<Books> booksList = new List<Books>
        {
            new Books {_ISBN = 111, _title = "Harry potter", _signId = 1337, _publicationYear = 1337, _publicationInfo = "Bös", _pages = 100 },
            new Books {_ISBN = 122, _title = "Head", _signId = 1338, _publicationYear = 1996, _publicationInfo = "Bös", _pages = 100 },
            new Books {_ISBN = 123, _title = "Headawd", _signId = 1339, _publicationYear = 1996, _publicationInfo = "Bös", _pages = 100 },
            new Books {_ISBN = 124, _title = "Hadawj", _signId = 1340, _publicationYear = 1996, _publicationInfo = "Bös", _pages = 100 }
        };


    }
}
