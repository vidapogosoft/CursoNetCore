using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using BlazorWA1.Shared.Models;

namespace BlazorWA1.Server.DataAccess
{
    public class RegistradoDataAccessLayer
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public IEnumerable<Registrados> GetAllRegistrados()
        {
            return db.Registrados.ToList();

        }

        public void AddRegister(Registrados NewItem)
        {
            db.Registrados.Add(NewItem);
            db.SaveChanges();
        }

        public void EditRegister(Registrados Item)
        {
            db.Entry(Item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Registrados GetRegData(int id)
        {
           
                Registrados reg = db.Registrados.Find(id);
                return reg;
            
        }

        public void DeleteRegister(int id)
        {
           
                Registrados reg = db.Registrados.Find(id);
                db.Registrados.Remove(reg);
                db.SaveChanges();
           
        }

    }
}
