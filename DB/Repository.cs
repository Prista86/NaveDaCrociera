namespace NaveDaCrociera.DB
{
    public class Repository
    {
        private DBContext DBContext;
        public Repository(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        //public List<Person> GetPersons()
        //{
        //    //select * from persons
        //    List<Person> result = this.DBContext.Persons.ToList();
        //    return result;
        //}
        //public void InsertPerson(Person person)
        //{
        //    this.DBContext.Persons.Add(person);
        //    this.DBContext.SaveChanges();
        //}
        //public void UpdatePerson(Person person)
        //{
        //    this.DBContext.Persons.Update(person);
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
