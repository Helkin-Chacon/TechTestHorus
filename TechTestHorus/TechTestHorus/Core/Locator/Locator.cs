using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using TechTestHorus.Core.Services;
using TechTestHorus.Core.Services.Interfaces;
using TechTestHorus.Modules.Repositories;
using TechTestHorus.Modules.Repositories.Interfaces;
using TechTestHorus.Modules.Ui.Login;
using TechTestHorus.Modules.ViewModels.Login;
using Xamarin.Forms;

namespace TechTestHorus.Core.Locator
{
    public static class Locator
    {

        public static void RegisterTypes(IContainerRegistry containerRegistry)
        {
            try
            {
                containerRegistry.RegisterSingleton<ISettingsService, SettingServices>();
                containerRegistry.RegisterSingleton<IValidationService, ValidationService>();

                //repository:
                containerRegistry.RegisterSingleton<ILoginRepository, LoginRepository>();
                containerRegistry.RegisterSingleton<IDashboardRepository, DashboardRepository>();
            }
            catch (Exception ex) {
            
            }
            //service:


            //ViewModel:

            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    //ViewModels
                    //
                    try
                    {
                        containerRegistry.RegisterForNavigation<LoghinPhonePage, LoginViewModel>();
                        containerRegistry.RegisterForNavigation<DashBoardPhonePage, DashboardViewModel>();
                    }
                    catch (Exception ex) { 
                    
                    }


                    break;


                case TargetIdiom.Tablet:
                    //ViewModels
                    break;
               
            }

            Application.Current.Resources.Add("IoC", containerRegistry);
        }

    }
}
