﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenTransition.ViewModels;
using Xamarin.Forms;

namespace ScreenTransition.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, ITrasitionPage
    {
        private MainPageViewModel _viewModel => this.BindingContext as MainPageViewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        public Task<bool> BeforeTransitionTask()
        {
            return null;
        }

        public async void OnPushAsync(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ChildPage());
        }

        public async void OnPushModalAsync(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new Modal01Page());
        }
    }
}
