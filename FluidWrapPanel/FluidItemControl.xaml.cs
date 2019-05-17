using System;
using System.Collections.Generic;
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

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace FluidWrapPanel
{
    
    public sealed partial class FluidItemControl : UserControl
    {
        #region Fill 依赖属性


        public Brush FillProperty
        {
            get { return (Brush)GetValue(FillPropertyProperty); }
            set { SetValue(FillPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FillProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillPropertyProperty =
            DependencyProperty.Register("FillProperty", typeof(Brush), typeof(FluidItemControl), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));


        #endregion

        #region Data依赖属性


        public string DataProperty
        {
            get { return (string)GetValue(DataPropertyProperty); }
            set { SetValue(DataPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataPropertyProperty =
            DependencyProperty.Register("DataProperty", typeof(string), typeof(FluidItemControl), new PropertyMetadata(string.Empty));


        #endregion
        public FluidItemControl()
        {
            this.InitializeComponent();
        }
    }
}
