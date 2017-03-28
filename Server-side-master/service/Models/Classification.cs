using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using repository;
using repository.EntityModel;

namespace service.Models
{
    public class Classification
    {
        public int SignId { get; set; }
        public string Description { get; set; }
        public string Signum { get; set; }


        static private EClassification e_classification = new EClassification();


        public static Classification getClassification(int signID)
        {
            return Mapper.Map<Classification>(e_classification.Read(signID));
        }
        public static List<Classification> getClassificationList()
        {

            return Mapper.Map<List<CLASSIFICATION>, List<Classification>>(e_classification.List());
        }
        //public Classification Read(int SignId)
        //{

        //    using (var db = new swagbaseEntities())
        //    {
        //        return db..Classification.Find(id);

        //    }
        //}
    }
}
