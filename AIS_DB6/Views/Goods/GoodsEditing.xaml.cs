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
using System.Windows.Shapes;
using AIS_DB6.Models;
using AIS_DB6.ViewModels.Goods;

namespace AIS_DB6.Views.Tables
{
    /// <summary>
    /// Логика взаимодействия для GoodsEditing.xaml
    /// </summary>
    public partial class GoodsEditing : Window
    {
        public GoodsEditing(Good good)
        {
            InitializeComponent();

            DataContext = new GoodsEditingViewModel(this, good);
        }
    }
}
