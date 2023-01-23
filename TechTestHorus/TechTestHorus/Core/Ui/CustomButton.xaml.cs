using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TechTestHorus.Core.Resources.CustomMarckupExtension;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.Xaml;
using Image = Xamarin.Forms.Image;
using Label = Xamarin.Forms.Label;

namespace TechTestHorus.Core.Ui
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomButton : ContentView
    {

        public enum ButtonTypeEnum
        {
            Normal,
            FacebookButton,
            InstagramButton
        }
        public static readonly BindableProperty ButtonTypeProperty = BindableProperty.Create(nameof(ButtonType), typeof(ButtonTypeEnum), typeof(CustomButton), ButtonTypeEnum.Normal, BindingMode.TwoWay, propertyChanged: HandleButtonTypeTypeChanged);
        public ButtonTypeEnum ButtonType
        {
            get { return (ButtonTypeEnum)base.GetValue(ButtonTypeProperty); }
            set { base.SetValue(ButtonTypeProperty, value); }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomButton), default(string), BindingMode.TwoWay, propertyChanged:
            new BindableProperty.BindingPropertyChangedDelegate(HandleTextPropertyChanged));

        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
            set { base.SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create(nameof(ClickCommand), typeof(ICommand), typeof(CustomButton), propertyChanged: new BindableProperty.BindingPropertyChangedDelegate(HandleClickCommandChanged));
        public ICommand ClickCommand
        {
            get { return (ICommand)base.GetValue(ClickCommandProperty); }
            set { base.SetValue(ClickCommandProperty, value); }
        }


        public static readonly BindableProperty ClickCommandParameterProperty = BindableProperty.Create(nameof(ClickCommandParameter), typeof(object), typeof(CustomButton), propertyChanged: new BindableProperty.BindingPropertyChangedDelegate(HandleClickCommandParameterChanged));
        public object ClickCommandParameter
        {
            get { return (object)base.GetValue(ClickCommandParameterProperty); }
            set { base.SetValue(ClickCommandParameterProperty, value); }
        }

        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColorButton), typeof(Color), typeof(CustomButton), propertyChanged: new BindableProperty.BindingPropertyChangedDelegate(HandleBackgroundColorButtonChanged));
        public Color BackgroundColorButton
        {
            get { return (Color)base.GetValue(BackgroundColorProperty); }
            set { base.SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColorButton), typeof(Color), typeof(CustomButton), propertyChanged: new BindableProperty.BindingPropertyChangedDelegate(HandleTextColorButtonChanged));
        public Color TextColorButton
        {
            get { return (Color)base.GetValue(TextColorProperty); }
            set { base.SetValue(TextColorProperty, value); }
        }
        public CustomButton()
        {
            InitializeComponent();
        }
        private static void HandleTextColorButtonChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var button = (CustomButton)bindable;
            button.NameLbl.TextColor = ((Color)newValue);
        }
        private static void HandleBackgroundColorButtonChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var button = (CustomButton)bindable;
            button.NormalType.BackgroundColor = ((Color)newValue);
        }
        private static void HandleClickCommandParameterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var button = (CustomButton)bindable;
            button.ClickCommandParameter = ((object)newValue);
        }
        private static void HandleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var button = (CustomButton)bindable;
                button.FindByName<Label>("NameLbl").Text = (string)newValue;

        }
        private static void HandleClickCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var button = (CustomButton)bindable;
            button.ClickCommand = ((ICommand)newValue);

            button.NormalType.GestureRecognizers.Add(new TapGestureRecognizer() { Command = ((ICommand)newValue), CommandParameter = button.ClickCommandParameter });
            button.SocialNetwork.GestureRecognizers.Add(new TapGestureRecognizer() { Command = ((ICommand)newValue), CommandParameter = button.ClickCommandParameter });
        }
        private static void HandleButtonTypeTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try { 
                var button = (CustomButton)bindable;
                button.ButtonType = ((ButtonTypeEnum)newValue);
                switch (button.ButtonType) 
                    {
                    case ButtonTypeEnum.Normal:
                        button.FindByName<PancakeView>("SocialNetwork").IsVisible = false;
                        button.FindByName<PancakeView>("NormalType").IsVisible = true;


                        break;
                    case ButtonTypeEnum.FacebookButton:
                        button.FindByName<PancakeView>("SocialNetwork").IsVisible = true;
                        button.FindByName<PancakeView>("NormalType").IsVisible = false;
                        button.FindByName<Image>("IconSocialNetwork").Source = ImageSource.FromResource("TechTestHorus.Core.Resources.facebook_g.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);

                        break;
                    case ButtonTypeEnum.InstagramButton:
                        button.FindByName<PancakeView>("SocialNetwork").IsVisible = true;
                        button.FindByName<PancakeView>("NormalType").IsVisible = false;
                        button.FindByName<Image>("IconSocialNetwork").Source = ImageSource.FromResource("TechTestHorus.Core.Resources.instagram_g.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);
                        break;
                }
            }
            catch(Exception ex) 
            {
            }
        }
    }
}