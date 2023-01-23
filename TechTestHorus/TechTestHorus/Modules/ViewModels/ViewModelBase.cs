using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TechTestHorus.Modules.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, IInitializeAsync, INavigationAware, IDestructible
    {
        public INavigationService NavigationService { get; private set; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public virtual void Clear()
        {

        }

        public virtual async Task InitializeAsync(INavigationParameters parameters)
        {

        }
    }
}
