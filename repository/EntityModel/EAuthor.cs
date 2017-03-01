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

            using (var db = new swagbaseEntities1())
            {

                return db.AUTHORs.ToList();
            }
        }
        public AUTHOR Read(int aID)
        {
            using (var db = new swagbaseEntities1())
            {
                return db.AUTHORs.Find(aID);
            }

        }
        public void Add(AUTHOR authorObj)
        {
            using (var db = new swagbaseEntities1())
            {
                db.AUTHORs.Add(authorObj);
                db.SaveChanges();
            }
        } 
        public void Update(AUTHOR authorObj)
        {
            using (var db = new swagbaseEntities1())
            {

                db.AUTHORs.Attach(authorObj);
                db.Entry(authorObj).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(AUTHOR authorObj)
        {
            using (var db = new swagbaseEntities1())
            {

                AUTHOR athID = db.AUTHORs.Find(authorObj.Aid);
                db.AUTHORs.Remove(athID);
                db.SaveChanges();
            }
        }
    }
}
