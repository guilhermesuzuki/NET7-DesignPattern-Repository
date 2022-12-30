using Repository.Models;

namespace Repository.Site.ViewModels
{
    public class PeopleViewModel
    {
        public List<PersonViewModel> People { get; set; } = new List<PersonViewModel>();
    }
}
