﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ScreenTransition.Controls
{
    public partial class MultiLineTitleView : ContentView
    {
        public MultiLineTitleView()
        {
            InitializeComponent();
        }

        #region Title1 BindableProperty
        public static readonly BindableProperty Title1Property =
            BindableProperty.Create("Title1", typeof(string), typeof(MultiLineTitleView)
                , null, BindingMode.TwoWay, propertyChanged: OnTitle1PropertyChanged);

        private static void OnTitle1PropertyChanged(BindableObject bindable
                                , object oldValue, object newValue)
        {
            if (!(bindable is MultiLineTitleView owner)) return;
            owner.Title1Label.Text = (string)newValue;
            owner.AjustSize();
        }

        public string Title1
        {
            get { return (string)GetValue(Title1Property); }
            set { SetValue(Title1Property, value); }
        }
        #endregion

        #region Title2 BindableProperty
        public static readonly BindableProperty Title2Property =
            BindableProperty.Create("Title2", typeof(string), typeof(MultiLineTitleView)
                , null, BindingMode.TwoWay, propertyChanged: OnTitle2PropertyChanged);

        private static void OnTitle2PropertyChanged(BindableObject bindable
                                , object oldValue, object newValue)
        {
            if (!(bindable is MultiLineTitleView owner)) return;
            owner.Title2Label.Text = (string)newValue;
            owner.AjustSize();
        }

        public string Title2
        {
            get { return (string)GetValue(Title2Property); }
            set { SetValue(Title2Property, value); }
        }
        #endregion

        #region Title3 BindableProperty
        public static readonly BindableProperty Title3Property =
            BindableProperty.Create("Title3", typeof(string), typeof(MultiLineTitleView)
                , null, BindingMode.TwoWay, propertyChanged: OnTitle3PropertyChanged);

        private static void OnTitle3PropertyChanged(BindableObject bindable
                                , object oldValue, object newValue)
        {
            if (!(bindable is MultiLineTitleView owner)) return;
            owner.Title3Label.Text = (string)newValue;
            owner.AjustSize();
        }

        public string Title3
        {
            get { return (string)GetValue(Title3Property); }
            set { SetValue(Title3Property, value); }
        }
        #endregion

        private void AjustSize()
        {
            int rows = 0;
            if (!string.IsNullOrEmpty(Title1)) rows++;
            if (!string.IsNullOrEmpty(Title2)) rows++;
            if (!string.IsNullOrEmpty(Title3)) rows++;

            double fontSize;
            FontSizeConverter fsc = new FontSizeConverter();
            switch (rows)
            {
                case 2:
                    fontSize = (double)fsc.ConvertFromInvariantString("Small");
                    break;
                case 3:
                    fontSize = (double)fsc.ConvertFromInvariantString("Micro");
                    break;
                default:
                    fontSize = (double)fsc.ConvertFromInvariantString("Title");
                    break;
            }
            Title1Label.FontSize = fontSize;
            Title2Label.FontSize = fontSize;
            Title3Label.FontSize = fontSize;
        }
    }
}