using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace repository.EntityModel
{
    public class EClassification
    {
        public List<CLASSIFICATION> List()
        {

            using (var db = new swagbaseEntities1())
            {

                return db.CLASSIFICATIONs.ToList();
            }
        }
        public CLASSIFICATION Read(int signId)
        {

            using (var db = new swagbaseEntities1())
            {
                return db.CLASSIFICATIONs.Find(signId);
            }

        }
        public void Add(CLASSIFICATION classiObj)
        {
            using (var db = new swagbaseEntities1())
            {
                db.CLASSIFICATIONs.Add(classiObj);
                db.SaveChanges();
            }
        }
        public void Update(CLASSIFICATION classiObj)
        {

            using (var db = new swagbaseEntities1())
            {

                db.CLASSIFICATIONs.Attach(classiObj);
                db.Entry(classiObj).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(CLASSIFICATION classiObj)
        {
            using (var db = new swagbaseEntities1())
            {

                CLASSIFICATION csignID = db.CLASSIFICATIONs.Find(classiObj.SignId);
                db.CLASSIFICATIONs.Remove(csignID);
                db.SaveChanges();
            }
        }
    }
}
