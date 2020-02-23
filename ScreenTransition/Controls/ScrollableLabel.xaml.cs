using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace ScreenTransition.Controls
{
    public partial class ScrollableLabel : ContentView
    {
        public ScrollableLabel()
        {
            InitializeComponent();
        }

        #region Text BindableProperty
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(ScrollableLabel), null, BindingMode.TwoWay, propertyChanged: OnTextPropertyChanged);

        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ScrollableLabel scrollableLabel = bindable as ScrollableLabel;
            if (scrollableLabel == null) return;
            scrollableLabel.TextDispLabel.Text = newValue as string;
            //throw new NotImplementedException();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        void HeadTruncation_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }
        #endregion

        private void OnTruncationPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "IsVisible") return;
            if (!(sender is VisualElement element)) return;
            if (element.IsVisible == false) return;

            Color background = Color.Transparent;
            VisualElement search = element;
            while (search != null)
            {
                if (search is NavigationPage)
                {
                    background = ((NavigationPage)search).BarBackgroundColor;
                }
                else
                {
                    background = search.BackgroundColor;
                }

                if (background.A > 0)
                {
                    break;
                }
                search = search.Parent as VisualElement;
            }
            element.BackgroundColor = background;
        }

        private void OnSizeChanged(object sender, EventArgs args)
        {
            //Debug.WriteLine($"OnSizeChanged {TextDispLabel.Width}/{scrV.Width} ");
            //TailTruncation.IsVisible = (TextDispLabel.Width - scrV.Width > 0);
        }
    }
}
