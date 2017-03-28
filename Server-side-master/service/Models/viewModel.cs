using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace service.Models
{
    public class viewModel
    {
        public Books book { get; set; }
        public List<Books> bookList { get; set; }
        public List<Author> authorList { get; set; }
        public Author author { get; set; }
        public Classification classifications { get; set; }
        public Administrator administrator {get; set; }
        public List<Classification> classificationList { get; set; }
        public List<ValidationResult> valResultList { get; set; }
        


    }
}
