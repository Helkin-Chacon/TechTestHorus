﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechTestHorus.Modules.Ui.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoghinPhonePage : ContentPage
    {
        public LoghinPhonePage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex) { 
            }
        }
    }
}