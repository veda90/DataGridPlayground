using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using DataGridPlayground.Helper;
using DataGridPlayground.Model;
using DataGridPlayground;
using System.Windows;

namespace DataGridPlayground.ViewModel
{
    internal class EmployeeListVM : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees { get; set; }

        public RelayCommand<object> RefreshCommand { get; set; }

        public RelayCommand<Employee> DeleteEmployeeCommand { get; set; }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set 
            { 
                selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
                DeleteEmployeeCommand.RaiseCanExecuteChanged();
            }
        }

            

        public EmployeeListVM()
        {
            
            RefreshCommand = new RelayCommand<object>(RefreshTable);
            DeleteEmployeeCommand = new RelayCommand<Employee>(DeleteSelectedEmployee,CanDeleteEmployee);

            Employees = new ObservableCollection<Employee>();
            
        }

        // Delete
        public bool CanDeleteEmployee(Employee emp)
        {
            return SelectedEmployee != null;
        }

        private void DeleteSelectedEmployee(Employee emp)
        {
            Helper.Helper.employees.Remove(emp);
            RefreshTable(emp);
        }

        // Refresh
        public void RefreshTable(object obj)
        {
            Employees.Clear();
            foreach (var item in Helper.Helper.employees)
            {
                Employees.Add(item);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public void ShowDialogue()
        {
            MessageBox.Show("MVVM behavior used ..!!");
        }

    }
}
