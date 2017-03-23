using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace repository.EntityModel
{
    public class EAuthor
    {
        public List<AUTHOR> List() {

            using (var db = new swagbaseEntities())
            {

                return db.AUTHORs.Include(x => x.BOOKs).ToList();
            }
        }
      
        public List<BOOK> getBookList(int aId)
        {
            using(var db = new swagbaseEntities())
            {
                return db.AUTHORs.Include(x => x.BOOKs).Where(x => x.Aid == aId).First().BOOKs.ToList();
            }
    }
        public AUTHOR Read(int aID)
        {
            using (var db = new swagbaseEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.AUTHORs.Include(x => x.BOOKs).Where(x => x.Aid ==  aID).First();
            }

        }
        public void Add(AUTHOR authorObj)
        {
            using (var db = new swagbaseEntities())
            {
                
                    
                    db.AUTHORs.Add(authorObj);
                    db.SaveChanges();
            }
        } 
        public void Update(AUTHOR authorObj)
        {
            using (var db = new swagbaseEntities())
            {
                AUTHOR dummyAuthor = db.AUTHORs.Include("BOOKs").FirstOrDefault(a => a.Aid == authorObj.Aid);

                db.AUTHORs.Attach(dummyAuthor);
                dummyAuthor.BirthYear = authorObj.BirthYear;
                dummyAuthor.FirstName = authorObj.FirstName;
                dummyAuthor.LastName = authorObj.LastName;

                //dummyAuthor.BOOKs.Clear();
                //AUTHOR booksToDummy = authorObj.BOOKs.Select


                db.Entry(dummyAuthor).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(AUTHOR authorObj)
        {
            using (var db = new swagbaseEntities())
            {

                AUTHOR athID = db.AUTHORs.Find(authorObj.Aid);
                db.AUTHORs.Remove(athID);
                db.SaveChanges();
            }
        }
    }
}
