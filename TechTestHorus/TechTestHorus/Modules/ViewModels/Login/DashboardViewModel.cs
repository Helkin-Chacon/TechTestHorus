using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestHorus.Core.Models.WebApi.Dashboard;
using TechTestHorus.Core.Router;
using TechTestHorus.Core.Services.Interfaces;
using TechTestHorus.Core.Ui;
using TechTestHorus.Modules.Models.Dashboard;
using TechTestHorus.Modules.Repositories;
using TechTestHorus.Modules.Repositories.Interfaces;
using Xamarin.Forms;

namespace TechTestHorus.Modules.ViewModels.Login
{
    public class DashboardViewModel : ViewModelBase
    {

        private ObservableCollection<ChallengeItems> challengesList;
        public ObservableCollection<ChallengeItems> ChallengesList
        {
            get => challengesList;
            set
            {
                SetProperty(ref challengesList, value);
            }
        }

        private string _completedChallenge;
        public string CompletedChallenge
        {
            get => _completedChallenge;
            set
            {
                SetProperty(ref _completedChallenge, value);
            }
        }

        private string _totalChallenge;
        public string TotalChallenge
        {
            get => _totalChallenge;
            set
            {
                SetProperty(ref _totalChallenge, value);
            }
        }
        protected ISettingsService _settingsService { get; set; }

        public IDashboardRepository DashboardRepository { get; set; }
        public DashboardViewModel(INavigationService navigationService, IDashboardRepository dashboardRepository, ISettingsService settingsService) : base(navigationService)
        {
            DashboardRepository = dashboardRepository;
            _settingsService = settingsService;
        }

        public async Task getChallenges()
        {
            var loadingDialog = new LoadingDialog() { };

            await PopupNavigation.Instance.PushAsync(loadingDialog, true);

            var challenges = await DashboardRepository.GetChallenges();
            if (challenges != null)
            {
               
                ChallengesList = new ObservableCollection<ChallengeItems>();
                foreach (var chal in challenges)
                {
                    ChallengeItems item = new ChallengeItems();
                    item.Title = chal.Title;
                    item.CurrentPoints = chal.CurrentPoints;
                    item.TotalPoints = chal.TotalPoints;
                    item.Id = chal.Id;
                    item.Description = chal.Description;
                    item.IsSelected = false;
                    item.Percentaje = CalculatePercentaje(item.CurrentPoints, item.TotalPoints);
                  
                    ChallengesList.Add(item);
                    var complete = ChallengesList.Where(x => x.Percentaje == 100).ToList();
                    CompletedChallenge = complete.Count.ToString();
                    TotalChallenge = challenges.Count.ToString();
                    RaisePropertyChanged(nameof(ChallengesList));
                }
            }
            loadingDialog.IsTaskSuccess = false;

        }
        public Command<object> BackCommand => new Command<object>(async (sender) =>
        {
            _settingsService.DeleteItem("oauthToken");
            var a = await NavigationService.NavigateAsync($"{RouterNavigation.Absolute}{RouterNavigation.LoghinPhonePage}", animated: false);


        });
        public Command<object> SelectChallengeCommand => new Command<object>(async (sender) =>
        {
            var item = sender as ChallengeItems;
            item.IsSelected = true;
            foreach (var items in ChallengesList) 
            {
                if (items.Id == item.Id)
                {
                    items.IsSelected = true;
                }
                else
                {
                    items.IsSelected = false;
                }
            }

            var alert = new ErrorDialog(item.Title, item.Description) { };

            await PopupNavigation.Instance.PushAsync(alert, true);

        });

        private int CalculatePercentaje(int currentPoints, int totalPoints)
        {
            var multi = currentPoints * 100;
            return (int)(multi / totalPoints);
        }

        public override async void Initialize(INavigationParameters parameters)
        {

            await getChallenges();

        }
    }
}
