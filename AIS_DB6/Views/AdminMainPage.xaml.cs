﻿using System;
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
using AIS_DB6.Views.Goods;
using AIS_DB6.Views.GoodsGroups;
using AIS_DB6.Views.Interface;
using AIS_DB6.Views.Producers;

namespace AIS_DB6.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void GoodsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Gr.Children.Clear();
            Gr.Children.Add(new GoodsTable());

        }

        private void GoodsGroupButton_OnClick(object sender, RoutedEventArgs e)
        {
            Gr.Children.Clear();
            Gr.Children.Add(new GoodsGroupTable());

        }

        private void Producers_OnClick(object sender, RoutedEventArgs e)
        {
            Gr.Children.Clear();
            Gr.Children.Add(new ProducersTable());
            //RightPart.Content = new ProducersTable();
        }

        private void PurchaseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Gr.Children.Clear();
            Gr.Children.Add(new PurchaseView());
        }
    }
}
