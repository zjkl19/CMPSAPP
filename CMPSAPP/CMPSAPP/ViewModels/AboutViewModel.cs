﻿using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace CMPSAPP.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("http://www.fjjky.com")));
        }

        public ICommand OpenWebCommand { get; }
    }
}