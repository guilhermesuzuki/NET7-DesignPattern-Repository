using Repository.Models;

namespace Repository.Site.ViewModels
{
    public class PeopleViewModel
    {
        public List<PersonCars> People { get; set; } = new List<PersonCars>();
    }

    public class PersonCars
    {
        public Person Person { get; set; } = new Person();
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
