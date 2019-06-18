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
using AIS_DB6.ViewModels.Suppliers;

namespace AIS_DB6.Views.Suppliers
{
    /// <summary>
    /// Логика взаимодействия для SuppliersTable.xaml
    /// </summary>
    public partial class SuppliersTable : UserControl
    {
        public SuppliersTable()
        {
            InitializeComponent();

            DataContext = new SupplierViewModel();
        }
    }
}
