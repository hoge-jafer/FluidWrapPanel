using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace FluidWrapPanel
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Random random = new Random();
        private Brush[] brushes;
        private int count;

        #region   依赖属性
        public bool UseRandomChildSize
        {
            get { return (bool)GetValue(UseRandomChildSizeProperty); }
            set { SetValue(UseRandomChildSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseRandomChildSizeProperty =
            DependencyProperty.Register("UseRandomchildSize", typeof(bool), typeof(MainPage), new PropertyMetadata(true, OnRandomChildSizeChanged));

        private static void OnRandomChildSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as MainPage;
            window?.RefreshFluidWrapPanel();
        }
        #endregion

        public MainPage()
        {
            this.InitializeComponent();
            brushes = new Brush[]
            {
              new SolidColorBrush(Color.FromArgb(255, 76, 217, 100)),
              new SolidColorBrush(Color.FromArgb(255, 0, 122, 255)),
              new SolidColorBrush(Color.FromArgb(255, 255, 150, 0)),
              new SolidColorBrush(Color.FromArgb(255, 255, 45, 85)),
              new SolidColorBrush(Color.FromArgb(255, 88, 86, 214)),
              new SolidColorBrush(Color.FromArgb(255, 255, 204, 0)),
              new SolidColorBrush(Color.FromArgb(255, 142, 142, 147)),
            };
            Loaded += MainWindow_Loaded;
            count = 0;
        }

        private void MainWindow_Loaded(object sender,RoutedEventArgs e)
        {
            OrientationCB.ItemsSource = new List<string> { "Horizontal","Vertical"};
            OrientationCB.SelectedIndex = 0;
            RefreshFluidWrapPanel();
        }

        private void OrientationCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (OrientationCB.SelectedValue as string)
            {
                case "Horizontal":
                    scrollviewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    scrollviewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    panel.Orientation = Orientation.Horizontal;
                    break;
                case "Vertical":
                    scrollviewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrollviewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    panel.Orientation = Orientation.Vertical;
                    break;
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshFluidWrapPanel();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var brush = brushes[random.Next(brushes.Length)];
            var factorwidth = UseRandomChildSize ? random.Next(1, 3) : 1;
            var factorheight = UseRandomChildSize ? random.Next(1, 3) : 1;

            var ctrl = new FluidItemControl
            {
                Width = factorwidth * panel.ItemWidth,
                Height = factorheight * panel.ItemHeight,
                FillProperty = brush,
                DataProperty = (++count).ToString()
            };
            await panel.AddChildAsync(ctrl);
        }

        private void RefreshFluidWrapPanel()
        {
            count = 0;
            var items = new ObservableCollection<UIElement>();
            var maxCount = random.Next(15, 20);
            for (int i = 0; i < maxCount; i++)
            {
                var brush = brushes[random.Next(brushes.Length)];
                var factorwidth = UseRandomChildSize ? random.Next(1, 3) : 1;
                var factorheight = UseRandomChildSize ? random.Next(1, 3) : 1;

                var ctrl = new FluidItemControl
                {
                    Width = factorwidth * panel.ItemWidth,
                    Height = factorheight * panel.ItemHeight,
                    FillProperty = brush,
                    DataProperty = (++count).ToString()
                };
                items.Add(ctrl);
            }
            panel.ItemsSource = items;
        }
              

        private void OnOrientationChanged(object sender,SelectionChangedEventArgs e)
        {
            switch (OrientationCB.SelectedValue as string)
            {
                case "Horizontal":
                    scrollviewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    scrollviewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    panel.Orientation = Orientation.Horizontal;
                    break;
                case "Vertical":
                    scrollviewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrollviewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    panel.Orientation = Orientation.Vertical;
                    break;
            }
        }

        private async void Onrefresh(object sender,RoutedEventArgs e)
        {
            var brush = brushes[random.Next(brushes.Length)];
            var factorwidth = UseRandomChildSize ? random.Next(1,3):1;
            var factorheight = UseRandomChildSize ? random.Next(1,3):1;

            var ctrl = new FluidItemControl
            {
                Width=factorwidth*panel.ItemWidth,
                Height=factorheight*panel.ItemHeight,
                FillProperty=brush,
                DataProperty=(++count).ToString()
            };
            await panel.AddChildAsync(ctrl);
        }

        

    }
}
