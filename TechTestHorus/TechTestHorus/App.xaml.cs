using System;
using Prism;
using TechTestHorus.Modules.Ui.Login;
using Xamarin.Forms;
using Prism.Ioc;

using Xamarin.Forms.Xaml;
using TechTestHorus.Core.Router;
using Prism.Navigation;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using TechTestHorus.Core.Locator;
using TechTestHorus.Modules.ViewModels.Login;
using TechTestHorus.Core.Services.Interfaces;

namespace TechTestHorus
{
    public partial class App 
    {
        ISettingsService _settingsService;

        public App(IPlatformInitializer initializer)
           : base(initializer)
        {

        }

        protected override void OnInitialized()
        {
            InitializeComponent();
          
            XF.Material.Forms.Material.Init(this);


        }
        protected async override void OnStart()
        {
            base.OnStart();
            if (Container.IsRegistered<ISettingsService>())
            {
                _settingsService = Container.Resolve<ISettingsService>();
                var token = _settingsService.GetString<string>("oauthToken");
                if (!string.IsNullOrEmpty(token))
                {
                    var b = await NavigationService.NavigateAsync(RouterNavigation.DashBoardPhonePage);
                    return;

                }
                else
                {
                    var b = await NavigationService.NavigateAsync(RouterNavigation.LoghinPhonePage);

                }
            }

        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            Locator.RegisterTypes(containerRegistry);

        }
    }
}
