﻿namespace PresentationApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window
            {
                Page = new AppShell()
            };

#if WINDOWS
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            window.Width = 1000;
            window.Height = 1000;
        }
#endif

            return window;
        }
    }
}