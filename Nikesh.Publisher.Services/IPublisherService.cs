using System.Threading.Tasks;
using Nikesh.Publisher.ViewModels;

namespace Nikesh.Publisher.Services
{
    public interface IPublisherService
    {
        Task Send(InformationViewModel viewModel);
    }
}
