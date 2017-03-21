﻿using System;
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

            using (var db = new dbtestEntities())
            {

                return db.AUTHORs.Include(x => x.BOOKs).ToList();
            }
        }
      
        public List<BOOK> getBookList(int aId)
        {
            using(var db = new dbtestEntities())
            {
                return db.AUTHORs.Include(x => x.BOOKs).Where(x => x.Aid == aId).First().BOOKs.ToList();
            }
    }
        public AUTHOR Read(int aID)
        {
            using (var db = new dbtestEntities())
            {
                return db.AUTHORs.Find(aID);
            }

        }
        public void Add(AUTHOR authorObj)
        {
            using (var db = new dbtestEntities())
            {
                using(var transaction = db.Database.BeginTransaction())
                {
                    authorObj.Aid = (db.AUTHORs.ToList().Max(x => x.Aid) + 1);
                    db.AUTHORs.Add(authorObj);
                    db.SaveChanges();
                    transaction.Commit();
                }



                
            }
        } 
        public void Update(AUTHOR authorObj)
        {
            using (var db = new dbtestEntities())
            {

                db.AUTHORs.Attach(authorObj);
                db.Entry(authorObj).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(AUTHOR authorObj)
        {
            using (var db = new dbtestEntities())
            {

                AUTHOR athID = db.AUTHORs.Find(authorObj.Aid);
                db.AUTHORs.Remove(athID);
                db.SaveChanges();
            }
        }
    }
}
