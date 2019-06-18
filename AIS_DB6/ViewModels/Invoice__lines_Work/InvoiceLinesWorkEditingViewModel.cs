﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AIS_DB6.Models;
using AIS_DB6.Tools;

namespace AIS_DB6.ViewModels.Invoice__lines_Work
{
    class InvoiceLinesWorkEditingViewModel:CrudVMBase
    {
        private RelayCommand _saveCommand;



        public RelayCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand(SaveImplementation, CanExecute));

        private bool CanExecute(object arg)
        {
            return SelectedInvoiceId != 0 && SelectedWorkerId != 0 && TypeOfWork != null && WorkCost != 0.0;
        }

        private void SaveImplementation(object obj)
        {
            InvoiceLinesWork ilw = db.InvoiceLinesWork.SingleOrDefault(i =>
                i.InvoiceId == InvoiceId && i.WorkerId == WorkerId);
            if (ilw != null)
            {
                //ilw.ContractId = SelectedInvoiceId;
                //ilw.ContractId = SelectedInvoiceId;
                //ilw.WorkerId = SelectedWorkerId;
                ilw.StartDate = SelectedDate;
                ilw.WorkCost = WorkCost;
                ilw.TypeOfWork = TypeOfWork;
                //ilw.Invoice = db.Invoices.Find(SelectedInvoiceId);
                //ilw.Worker = db.Workers.Find(SelectedWorkerId);
                db.SaveChanges();
            }


        

            Thiswindow.Close();
        }

       

        private Window _thiswindow;

        public Window Thiswindow
        {
            get => _thiswindow;
            set => _thiswindow = value;
        }
        private int _selectedWorkerId;

        public int SelectedWorkerId
        {
            get => _selectedWorkerId;
            set
            {
                _selectedWorkerId = value;
                OnPropertyChanged();
            }
        }

        private int _selectedInvoiceId;

        public int SelectedInvoiceId
        {
            get => _selectedInvoiceId;
            set
            {
                _selectedInvoiceId = value;
                OnPropertyChanged();
            }
        }

        private int _workerId;

        public int WorkerId
        {
            get => _workerId;
            set => _workerId = value;
        }

        private int _invoiceId;

        public int InvoiceId
        {
            get => _invoiceId;
            set => _invoiceId = value;
        }

        private List<int> _workerIds;

        public List<int> WorkerIds
        {
            get => _workerIds;
            set => _workerIds = value;
        }



        private List<int> _invoiceIds;

        public List<int> InvoiceIds
        {
            get => _invoiceIds;
            set => _invoiceIds = value;
        }


        private double _workCost;

        public double WorkCost
        {
            get => _workCost;
            set => _workCost = value;
        }

        private string _typeOfWork;

        public string TypeOfWork
        {
            get => _typeOfWork;
            set => _typeOfWork = value;
        }

        private DateTime _selectedDate = DateTime.Today;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        protected async override void GetData()
        {
            await Task.Run(() =>
            {
                foreach (Worker gg in db.Workers)
                {
                    WorkerIds.Add(gg.WorkerId);
                }
            
                foreach (Invoice pp in db.Invoices)
                {
                    InvoiceIds.Add(pp.InvoiceId);
                }



            });

        }

        public InvoiceLinesWorkEditingViewModel(Window w, InvoiceLinesWork ilw) : base()
        {
            InvoiceIds = new List<int>();
            WorkerIds = new List<int>();
           
            Thiswindow = w;

             
            WorkerId = SelectedWorkerId = ilw.WorkerId;
            InvoiceId = SelectedInvoiceId = ilw.InvoiceId;
            SelectedDate = ilw.StartDate;
            WorkCost = ilw.WorkCost;
            TypeOfWork = ilw.TypeOfWork;


        }

    }
}
