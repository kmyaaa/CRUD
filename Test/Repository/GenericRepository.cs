using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.Repository
{
    public class GenericRepository<tbl_Entity> : IRepository<tbl_Entity> where tbl_Entity:class
    {
        private ShopContext _dbEntity;

        DbSet<tbl_Entity> _dbset; 

        public GenericRepository(ShopContext dbEntity)
        {
            this._dbEntity = dbEntity;
            _dbset = _dbEntity.Set<tbl_Entity>();
        }

        public IEnumerable<tbl_Entity> GetAll()
        {
           return _dbset.ToList();
        }


        public tbl_Entity Get(int id)
        {
           return _dbset.Find(id);
        }

        public void Add(tbl_Entity entity)
        {
            _dbset.Add(entity);
            _dbEntity.SaveChanges();
        }

        public void Delete(tbl_Entity entity)
        {           
            _dbset.Remove(entity);
            _dbEntity.SaveChanges();
        }


        public void Update(tbl_Entity entity)
        {
            _dbset.Attach(entity);
            _dbEntity.Entry(entity).State = EntityState.Modified;
            _dbEntity.SaveChanges();
        }
    }
}