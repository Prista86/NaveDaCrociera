using NaveDaCrociera.DB.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NaveDaCrociera.DB
{
    public class Repository
    {
        private DBContext DBContext;
        public Repository(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        public List<Spettacoli> GetSpettacoli()
        {
            //select * from persons
            List<Spettacoli> result = this.DBContext.Spettacoli.ToList();
            return result;
        }
        public List<PrenotazioniSpettacoli> GetPrenotazioniSpettacoli()
        {
            //select * from persons
            List<PrenotazioniSpettacoli> result = this.DBContext.PrenotazioniSpettacoli.ToList();
            return result;
        }
        public void UpdateSpettacoli(Spettacoli spettacoli)
        {
            this.DBContext.Spettacoli.Update(spettacoli);
            this.DBContext.SaveChanges();
        }
        public void InsertPrenotazioniSpettacoli(PrenotazioniSpettacoli prenotazioniSpettacoli)
        {
            this.DBContext.PrenotazioniSpettacoli.Add(prenotazioniSpettacoli);
            this.DBContext.SaveChanges();
        }

        //public void InsertPerson(Person person)
        //{
        //    this.DBContext.Persons.Add(person);
        //    this.DBContext.SaveChanges();
        //}

        //public void DeletePerson(string ID)
        //{
        //    Person toDelete = this.DBContext.Persons
        //            //.Where(p => p.ID != null && p.ID.Value.ToString() == ID) nel caso fosse nullable
        //            .Where(p => p.Id.ToString() == ID)
        //            .FirstOrDefault();
        //    this.DBContext.Persons.Remove(toDelete);
        //    this.DBContext.SaveChanges();
        //}
    }
}
