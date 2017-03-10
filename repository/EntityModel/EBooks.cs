using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
namespace repository.EntityModel
{
    public class EBooks
    {
        public List<BOOK> List(string search)
        {

            using (var db = new swagbaseEntities())
            {

                return db.BOOKs.Where(x => x.Title.StartsWith(search) || search == null).OrderBy(x => x.Title).ToList();
            }
        }
        public List<AUTHOR> AuthorList(string isbn)
        {
            using (var db = new swagbaseEntities())
            {
                return db.BOOKs.Find(isbn).AUTHORs.ToList();
            }


        }
        public BOOK Read(string isbn)
        {
            using (var db = new swagbaseEntities())
            {
                return db.BOOKs.Find(isbn);
            }

        }
        public void Add(BOOK bookObj)
        {
            using (var db = new swagbaseEntities())
            {
                db.BOOKs.Add(bookObj);
                db.SaveChanges();
            }
        }
        public void Update(BOOK bookObj)
        {
            using (var db = new swagbaseEntities())
            {

                db.BOOKs.Attach(bookObj);
                db.Entry(bookObj).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(BOOK bookObj)
        {
            using (var db = new swagbaseEntities())
            {

                BOOK bISBN = db.BOOKs.Find(bookObj.ISBN);
                db.BOOKs.Remove(bISBN);
                db.SaveChanges();
            }
        }
    }
}
