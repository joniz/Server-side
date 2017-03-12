﻿using System;
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
        public List<BOOK> List()
        {

            using (var db = new dbtestEntities())
            {

                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).OrderBy(x => x.Title).ToList();
            }
        }
        public CLASSIFICATION getClassification(string isbn)
        {
            using (var db = new dbtestEntities())
            {
                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).Where(x => x.ISBN == isbn).First().CLASSIFICATION;
            }


        }


        public List<AUTHOR> AuthorList(string isbn)
        {
            using (var db = new dbtestEntities())
            {
                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).Where(x => x.ISBN == isbn).First().AUTHORs.ToList();
            }


        }
        public BOOK Read(string isbn)
        {
            using (var db = new dbtestEntities())
            {
                return db.BOOKs.Include(x => x.AUTHORs).Include(x => x.CLASSIFICATION).Where(x => x.ISBN == isbn).First();
            }

        }
        public void Add(BOOK bookObj)
        {
            using (var db = new dbtestEntities())
            {
                db.BOOKs.Add(bookObj);
                db.SaveChanges();
            }
        }
        public void Update(BOOK bookObj)
        {
            using (var db = new dbtestEntities())
            {

                db.BOOKs.Attach(bookObj);
                db.Entry(bookObj).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(BOOK bookObj)
        {
            using (var db = new dbtestEntities())
            {

                BOOK bISBN = db.BOOKs.Find(bookObj.ISBN);
                db.BOOKs.Remove(bISBN);
                db.SaveChanges();
            }
        }
    }
}
