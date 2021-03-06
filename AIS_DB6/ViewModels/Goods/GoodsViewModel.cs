﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using AIS_DB6.Annotations;
using AIS_DB6.Models;
using AIS_DB6.Tools;
using AIS_DB6.Views.Tables;

namespace AIS_DB6.ViewModels
{
    //TODO updated row doesnt update in datagridd FIX!
    class GoodsViewModel:CrudVMBase
    {
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
        private RelayCommand _printCommand;
        //private RelayCommand _backCommand;

        //public RelayCommand BackCommand =>
        //    _backCommand ?? (_backCommand = new RelayCommand(BackImplementation, (o => true)));

        //private void BackImplementation(object obj)
        //{
        //    Direc
        //    NavigationService.Navigate(new Uri("mypage.xaml", UriKind.Relative));
        //}

        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddImplementation, (o => true )));

        private void AddImplementation(object obj)
        {
            GoodsAdding ga = new GoodsAdding();
            //ga.ShowDialog();
            ga.ShowDialog();
            RefreshData();
        }

        public RelayCommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand(EditImplementation, CanExecuteCommand));

        private void EditImplementation(object obj)
        {
            
            GoodsEditing ge = new GoodsEditing(SelectedGood.TheGood);
            ge.ShowDialog();

            Good temp = db.Goods.Find(SelectedGood.TheGood.GoodsId);
            SelectedGood.TheGood.Characteristics = temp.Characteristics;
            SelectedGood.TheGood.Name = temp.Name;
            SelectedGood.TheGood.GoodsGroupId = temp.GoodsGroupId;
            
            
            RefreshData();
        }

        public RelayCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteImplementation, CanExecuteCommand));

        private void DeleteImplementation(object obj)
        {
            try
            {
                DeleteCurrent();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            base.RefreshData();
        }

        private GoodVM _selectedGood;

        public GoodVM SelectedGood
        {
            get => _selectedGood;
            set
            {
                _selectedGood = value;
                base.OnPropertyChanged();
            }
        }

        private ObservableCollection<GoodVM> _goods ;

        public ObservableCollection<GoodVM> Goods
        {
            get => _goods;
            set
            {
                _goods = value;
                base.OnPropertyChanged();
              
            }
        }

        protected  override void RefreshData()
        {
            Goods.Clear();
            
           GetData();
            

        }

        protected async override void GetData()
        {
            db = new AisContext();
          
              
          
            ObservableCollection<GoodVM> goodsTemp = new ObservableCollection<GoodVM>();
            var _goods = await
                (from g in db.Goods
                 
                 select g).ToListAsync();

           
            foreach (Good good in _goods)
            {
                goodsTemp.Add(new GoodVM(){TheGood = good});
            }

            Goods = goodsTemp;
          
        }

        protected override void DeleteCurrent()
        {
            //TODO do something with number lines
            if (SelectedGood != null)
            {
                db.Goods.Remove(SelectedGood.TheGood);
                db.SaveChanges();
                base.RefreshData();
            }
        }

        private bool CanExecuteCommand(object obj)
        {
            return SelectedGood != null;
        }

        public GoodsViewModel(): base()
        {
           

        }


      
    }
}
