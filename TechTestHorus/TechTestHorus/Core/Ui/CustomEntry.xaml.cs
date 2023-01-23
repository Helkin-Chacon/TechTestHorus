using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TechTestHorus.Core.Resources.CustomMarckupExtension;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechTestHorus.Core.Ui
{
    public partial class CustomEntry : ContentView
    {
        public CustomEntry()
        {
            InitializeComponent();
            txt.PropertyChanged += EntryPropertyChanged;

        }
        public static readonly BindableProperty SourceRightIconProperty = BindableProperty.Create(nameof(SourceRightIcon), typeof(string), typeof(CustomEntry), default(string), BindingMode.TwoWay, propertyChanged: HandleSourceRightIconChanged);
        public string SourceRightIcon
        {
            get { return (string)base.GetValue(SourceRightIconProperty); }
            set { base.SetValue(SourceRightIconProperty, value); }
        }

        private static void HandleSourceRightIconChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var button = (CustomEntry)bindable;
            button.SourceRightIcon = ((string)newValue);
            button.FindByName<Image>("rightIcon").Source = ImageSource.FromResource(button.SourceRightIcon, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            button.FindByName<Grid>("rightIconGrid").IsVisible = !string.IsNullOrEmpty(button.SourceRightIcon);
        

            switch (button.SourceRightIcon)
            {
                case "TechTestHorus.Core.Resources.eye_b.png":
                case "TechTestHorus.Core.Resources.eye_none.png":
                    break;
              
            }

        }

        public static readonly BindableProperty RightButtonCommandProperty = BindableProperty.Create(nameof(RightButtonCommand), typeof(ICommand), typeof(CustomEntry), propertyChanged: new BindableProperty.BindingPropertyChangedDelegate(HandleRightButtonCommandChanged));
        public ICommand RightButtonCommand
        {
            get { return (ICommand)base.GetValue(RightButtonCommandProperty); }
            set { base.SetValue(RightButtonCommandProperty, value); }
        }
        private static void HandleRightButtonCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var entry = (CustomEntry)bindable;
            entry.RightButtonCommand = ((ICommand)newValue);

            if (entry.InputType == XF.Material.Forms.UI.MaterialTextFieldInputType.Password)
                entry.FindByName<Grid>("rightIconGrid").GestureRecognizers.Add(new TapGestureRecognizer() { Command = entry.RightButtonCommand, CommandParameter = entry });
        }

        public static readonly BindableProperty InputTypeProperty = BindableProperty.Create(nameof(InputType), typeof(XF.Material.Forms.UI.MaterialTextFieldInputType), typeof(CustomEntry), XF.Material.Forms.UI.MaterialTextFieldInputType.Default, BindingMode.OneWay, propertyChanged: HandleInputTypePropertyChanged);
        public XF.Material.Forms.UI.MaterialTextFieldInputType InputType
        {
            get { return (XF.Material.Forms.UI.MaterialTextFieldInputType)base.GetValue(InputTypeProperty); }
            set { base.SetValue(InputTypeProperty, value); }
        }

        public bool IsPassword;

        private static void HandleInputTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var button = (CustomEntry)bindable;
            button.FindByName<XF.Material.Forms.UI.MaterialTextField>("txt").InputType = ((XF.Material.Forms.UI.MaterialTextFieldInputType)newValue);
            button.IsPassword = (button.FindByName<XF.Material.Forms.UI.MaterialTextField>("txt").InputType == XF.Material.Forms.UI.MaterialTextFieldInputType.Password);

            if (button.FindByName<Grid>("rightIconGrid").IsVisible)
            {
                if (button.IsPassword)
                {
                    button.FindByName<Image>("rightIcon").Source = ImageSource.FromResource("TechTestHorus.Core.Resources.eye_b.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);
                }
                else
                {
                    button.FindByName<Image>("rightIcon").Source = ImageSource.FromResource("TechTestHorus.Core.Resources.eye_none_b.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);

                }
            }

        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomEntry), default(string), BindingMode.TwoWay, propertyChanged:
          new BindableProperty.BindingPropertyChangedDelegate(HandleTextPropertyChanged));

        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
            set { base.SetValue(TextProperty, value); }
        }
        private static void HandleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var button = (CustomEntry)bindable;          
            button.FindByName<XF.Material.Forms.UI.MaterialTextField>("txt").Text = ((string)newValue);           
        }
        async void EntryPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {


            if (e.PropertyName == Xamarin.Forms.Entry.TextProperty.PropertyName)
            {
               
                
                    if (sender is XF.Material.Forms.UI.MaterialTextField)
                    {
                        if (((XF.Material.Forms.UI.MaterialTextField)sender).ClassId == txt.ClassId)
                        {
                            var text = ((XF.Material.Forms.UI.MaterialTextField)sender).Text;

                            var hastext = !string.IsNullOrEmpty(text);

                            Text = text;

                           

                        }

                    }

                   



                

            }
        }

    }
}