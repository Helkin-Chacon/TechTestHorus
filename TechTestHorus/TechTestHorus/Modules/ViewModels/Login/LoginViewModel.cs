using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestHorus.Core.Router;
using TechTestHorus.Core.Services.Interfaces;
using TechTestHorus.Core.Ui;
using TechTestHorus.Modules.Repositories.Interfaces;
using Xamarin.Forms;

namespace TechTestHorus.Modules.ViewModels.Login
{ 
    public class LoginViewModel : ViewModelBase
    {
        private bool ShowPassword;
        
        private string _password;
        public string Password 
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
            }
        }
        private string email;
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
            }
        }
        protected ILoginRepository LoginRepository { get; set; }
        protected IValidationService ValidationService { get; set; }

        public LoginViewModel(INavigationService navigationService, ILoginRepository loginRepository, IValidationService validationService) : base(navigationService)
        {
            LoginRepository = loginRepository;
            ValidationService = validationService;
        }
        
        public Command<object> ShowPasswordCommand => new Command<object>(async (sender) =>
        {
            var entry = sender as CustomEntry;
            entry.InputType = ShowPassword ? XF.Material.Forms.UI.MaterialTextFieldInputType.Text : XF.Material.Forms.UI.MaterialTextFieldInputType.Password;
            ShowPassword = !ShowPassword;             
            
        });

        public Command<object> LoginCommand => new Command<object>(async (sender) =>
        {
            var loadingDialog = new LoadingDialog() { };

            await PopupNavigation.Instance.PushAsync(loadingDialog, true);

            if (!ValidationService.IsValidEmail(Email))
            {
                loadingDialog.IsTaskSuccess = false;
                await PopupNavigation.Instance.PopAsync();
                await Task.Delay(1000);
                var error = new ErrorDialog("Invalid Email", "This email is not a valid email.") { };
                await PopupNavigation.Instance.PushAsync(error, true);
                return;
            }
            if (!ValidationService.IsValidPassword(Password))
            {
                loadingDialog.IsTaskSuccess = false;
                await PopupNavigation.Instance.PopAsync();
                await Task.Delay(1000);
                var error = new ErrorDialog("Invalid Password", "Password must have at least 8 characters") { };
                await PopupNavigation.Instance.PushAsync(error, true);
                return;

            }

            if (await LoginRepository.Login(Email, Password))
            {
                loadingDialog.IsTaskSuccess = false;
                var b = await NavigationService.NavigateAsync(RouterNavigation.DashBoardPhonePage);



            }
            else 
            {
                await PopupNavigation.Instance.PopAsync();
                await Task.Delay(1000);
                var error = new ErrorDialog("Error", LoginRepository.GetErrors?.FirstOrDefault()?.Message) { };

                await PopupNavigation.Instance.PushAsync(error, true);
            }

            loadingDialog.TextResult = "User not registered";
            loadingDialog.IsTaskSuccess = false;
        });

    }

}
