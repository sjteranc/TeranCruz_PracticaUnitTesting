using System.Collections.Generic;
using System.Threading.Tasks;
using BEPractice.Models;

namespace BEPractice.Services
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Person GetById(int id);
        Person Create(Person person);
        Person Update(int id, Person person);
        Person Delete(int id);

        Boolean IsAdult(int id);
    }
}