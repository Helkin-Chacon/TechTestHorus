using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechTestHorus.Modules.Models.Dashboard
{
    public class ChallengeItems : BindableBase
    {

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CurrentPoints { get; set; }

        public int TotalPoints { get; set; }
        public int Percentaje { get; set; }

        private bool selected;
        public bool IsSelected { get => selected; set { SetProperty(ref selected, value); RaisePropertyChanged(nameof(IsSelected)); } }


    }
}
