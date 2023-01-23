using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace TechTestHorus.Core.Ui
{
   

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorDialog : PopupPage
    {
        public ErrorDialog()
        {
            InitializeComponent();
            icon_close.GestureRecognizers.Add(new TapGestureRecognizer() { Command = CloseButtonCommand });
        }

        public ErrorDialog(string title = null, string msj = null, Command<object> command = null)
        {
            InitializeComponent();
            lbltitle.Text = title;
            lblsubtitle.Text = msj;
            icon_close.GestureRecognizers.Add(new TapGestureRecognizer() { Command = CloseButtonCommand });
            if (command != null)
            {
                var nCommand = new Command<object>(async (obj) => {
                    command.Execute(null);
                    CloseButtonCommand.Execute(null);
                });
                button.GestureRecognizers.Add(new TapGestureRecognizer() { Command = nCommand });
            }
            else
            {
                button.GestureRecognizers.Add(new TapGestureRecognizer() { Command = CloseButtonCommand });
            }

        }

        private bool CanCloseButtonExecute = true;
        public Command<object> CloseButtonCommand => new Command<object>(async (sender) =>
        {
            if (CanCloseButtonExecute)
            {
                CanCloseButtonExecute = false;
                try
                {
                    await PopupNavigation.Instance.RemovePageAsync(this, true);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                CanCloseButtonExecute = true;
            }
        });
    }
}