using Repository.Models;

namespace Repository.Site.ViewModels
{
    public class PersonViewModel
    {
        public Person Person { get; set; } = new Person();

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
