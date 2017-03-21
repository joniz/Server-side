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
        public List<AUTHOR> getAllAuthors()
        {
            using (var db = new swagbaseEntities1())
            {
                return db.AUTHORs.OrderBy(x => x.LastName).ToList();
            }
        }
        public List<BOOK> List()
        {

            using (var db = new swagbaseEntities1())
            {

                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).OrderBy(x => x.Title).ToList();
            }
        }
        public CLASSIFICATION getClassification(string isbn)
        {
            using (var db = new swagbaseEntities1())
            {
                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).Where(x => x.ISBN == isbn).First().CLASSIFICATION;
            }


        }


        public List<AUTHOR> AuthorList(string isbn)
        {
            using (var db = new swagbaseEntities1())
            {
                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).Where(x => x.ISBN == isbn).First().AUTHORs.ToList();
            }


        }
        public BOOK Read(string isbn)
        {

            using (var db = new swagbaseEntities1())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).Where(x => x.ISBN == isbn).First();
            
            }

        }
        public void Add(BOOK bookObj)
        {
            using (var db = new swagbaseEntities1())
            {
                List<AUTHOR> auths = bookObj.AUTHORs.ToList();


                bookObj.AUTHORs = null;
                bookObj.CLASSIFICATION = null;

                db.BOOKs.Add(bookObj);


                foreach (AUTHOR a in auths)
                {
                    db.AUTHORs.Attach(a);
                    a.BOOKs.Add(bookObj);
                    db.Entry(a).State = EntityState.Modified;

                }

                db.SaveChanges();
        }
        }
        public void Update(BOOK bookObj)
        {
            using (var db = new swagbaseEntities1())
            {
                BOOK dummyBook = db.BOOKs.Include(x => x.AUTHORs).FirstOrDefault(a => a.ISBN == bookObj.ISBN);
                db.BOOKs.Attach(dummyBook);
                db.CLASSIFICATIONs.Attach(db.CLASSIFICATIONs.Find(bookObj.SignId));
                dummyBook.AUTHORs.Clear();
                List<int> authorsToDummy = bookObj.AUTHORs.Select(a => a.Aid).ToList();
                dummyBook.pages = bookObj.pages;
                dummyBook.Title = bookObj.Title;
                dummyBook.publicationinfo = bookObj.publicationinfo;
                dummyBook.PublicationYear = bookObj.publicationinfo;
                dummyBook.SignId = bookObj.SignId;
                dummyBook.CLASSIFICATION = bookObj.CLASSIFICATION;

                foreach (int auth in authorsToDummy)
                {
                    db.AUTHORs.Attach(db.AUTHORs.Find(auth));
                    dummyBook.AUTHORs.Add(db.AUTHORs.Find(auth));
                }
              

                db.SaveChanges();
            }

        }
        
        public void Delete(BOOK bookObj)
        {
            using (var db = new swagbaseEntities1())
            {

                BOOK bISBN = db.BOOKs.Find(bookObj.ISBN);
                db.BOOKs.Remove(bISBN);
                db.SaveChanges();
            }
        }
    }
}
