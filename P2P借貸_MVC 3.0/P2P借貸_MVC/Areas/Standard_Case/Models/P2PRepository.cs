using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace P2P借貸_MVC.Areas.Standard_Case.Models
{
    public class P2PRepository<T> : IP2PRepository<T> where T : class
    {
        private P2P借貸平台_2Entities1 db = null;
        private DbSet<T> Dbset = null;

        public P2PRepository()
        {
            db = new P2P借貸平台_2Entities1();
            Dbset = db.Set<T>();
        }
        public void Creat(T _Entity)
        {
            Dbset.Add(_Entity);
            db.SaveChanges();
        }

        public void Delete(T _Entity)
        {
            Dbset.Remove(_Entity);
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Dbset;
        }

        public T GetById(int id)
        {
            return Dbset.Find(id);
        }

        public void Update(T _Entity)
        {
            db.Entry(_Entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}