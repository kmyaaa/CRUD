using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Task.DataAccess.IRepository
{
    public interface IRepository<tbl_Entity> where tbl_Entity:class
    {
        IEnumerable<tbl_Entity> GetAll();      //Get All
        tbl_Entity Get(int id);                //Get By ID
        void Add(tbl_Entity item);          //Insert Record
        void Update(tbl_Entity item);          //Update Record
        void Delete(tbl_Entity item);                //Delete Recird
    }
}
