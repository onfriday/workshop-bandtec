using MvvmHelpers;
using Xamarin.Forms;

namespace WorkshopBandtecApp.ViewModels
{
    abstract class WorkshopBandtecBaseViewModel : BaseViewModel
    {
        protected readonly INavigation Navigation;

        public WorkshopBandtecBaseViewModel(INavigation pNavigation)
        {
            this.Navigation = pNavigation;
        }
    }
}
