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
            using (var db = new dbtestEntitiesEntities())
            {
                return db.AUTHORs.OrderBy(x => x.LastName).ToList();
            }
        }
        public List<BOOK> List()
        {

            using (var db = new dbtestEntitiesEntities())
            {

                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).OrderBy(x => x.Title).ToList();
            }
        }
        public CLASSIFICATION getClassification(string isbn)
        {
            using (var db = new dbtestEntitiesEntities())
            {
                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).Where(x => x.ISBN == isbn).First().CLASSIFICATION;
            }


        }


        public List<AUTHOR> AuthorList(string isbn)
        {
            using (var db = new dbtestEntitiesEntities())
            {
                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).Where(x => x.ISBN == isbn).First().AUTHORs.ToList();
            }


        }
        public BOOK Read(string isbn)
        {

            using (var db = new dbtestEntitiesEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).Where(x => x.ISBN == isbn).First();
            
            }

        }
        public void Add(BOOK bookObj)
        {
            using (var db = new dbtestEntitiesEntities())
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
        public void Update(string isbn, int authId)
        {
            using (var db = new dbtestEntitiesEntities())
            {
                AUTHOR a = new AUTHOR { Aid = authId };  //Skapa dummy objekt av författaren
                db.AUTHORs.Attach(a);

                BOOK b = new BOOK { ISBN = isbn }; //Skapa dummy objekt av boken
                db.BOOKs.Attach(b);

                b.AUTHORs.Add(a); //Be EF uppdatera mellankopplingstabellen i contexten db

                db.SaveChanges(); //Spara ned till databasen

            }

        }
        public void Delete(BOOK bookObj)
        {
            using (var db = new dbtestEntitiesEntities())
            {

                BOOK bISBN = db.BOOKs.Find(bookObj.ISBN);
                db.BOOKs.Remove(bISBN);
                db.SaveChanges();
            }
        }
    }
}
