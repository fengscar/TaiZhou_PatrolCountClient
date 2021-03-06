﻿using GuardTourSystem.Utils;
using GuardTourSystem.ViewModel;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuardTourSystem.View
{
    /// <summary>
    /// EventView.xaml 的交互逻辑
    /// </summary>
    public partial class EventView : ShowContentView
    {
        public EventView()
        {
            InitializeComponent();
            this.DataContext = new EventViewModel();
        }


        private void Export_Button_Click(object sender, RoutedEventArgs e)
        {
            ExcelExporter.TelerikControlExport(this.GridView, LanLoader.Load(LanKey.Export_Event));
        }

        //private void usercontrol_Loaded(object sender, RoutedEventArgs e)
        //{
        //    MainWindow mw = Window.GetWindow(this) as MainWindow;
        //    vm.ShowMessageDialog = new Action<string, string>(mw.ShowMessageMetroDialog);
        //    vm.ShowConfirmDialogAction = new Func<string, string, Task<MessageDialogResult>>(mw.ShowMetroConfirmDialog);
        //}
    }
}
