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
using AIS_DB6.ViewModels.Interface;

namespace AIS_DB6.Views.Interface
{
    /// <summary>
    /// Логика взаимодействия для ConclusionContractViewModel.xaml
    /// </summary>
    public partial class ConclusionContract : UserControl
    {
        public ConclusionContract()
        {
            InitializeComponent();
            DataContext = new ConclusionContractViewModel();
        }
    }
}
