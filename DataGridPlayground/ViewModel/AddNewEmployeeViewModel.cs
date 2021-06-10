
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DataGridPlayground.Helper;
using System.ComponentModel.DataAnnotations;
using DataGridPlayground;

namespace DataGridPlayground.ViewModel
{
    public class AddNewEmployeeViewModel : ValidatableBindableBase
    {
        private string name;
        [Required]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string mail;
        [EmailAddress]
        public string Mail
        {
            get { return mail; }
            set { SetProperty(ref mail, value); }
        }

        private string project;
        public string Project
        {
            get { return project; }
            set { SetProperty(ref project, value); }
        }

        private string team;
        public string Team
        {
            get { return team; }
            set { SetProperty(ref team, value); }
        }

        public ParameterLessRelayCommand SaveCmd { get; }

        // Constructor
        public AddNewEmployeeViewModel()
        {
            SaveCmd = new ParameterLessRelayCommand(SaveDetails);
            Helper.Helper.employees.Add(new Model.Employee() { Name = "Rabi", Id = 652345, Mail = "malickr@abc.com", Project = "SCE", Team = "Planning", Sport = "Chess" });
            Helper.Helper.employees.Add(new Model.Employee() { Name = "Ayeshkant", Id = 326541, Mail = "mishraa@abc.com", Project = "SCE", Team = "Planning" });
            Helper.Helper.employees.Add(new Model.Employee() { Name = "Anindita", Id = 987569, Mail = "Dasha@abc.com", Project = "SCE", Team = "TnO" });
            Helper.Helper.employees.Add(new Model.Employee() { Name = "Shibashis", Id = 236489, Mail = "patros@abc.com", Project = "SCE", Team = "SRM" });
        }

        public void SaveDetails()
        {
            Helper.Helper.employees.Add(new Model.Employee() { Name = Name, Id = Id, Mail = Mail, Project = Project, Team = Team });
            Name = "";
            Id = 0;
            Mail = "";
            Project = "";
            Team = "";

        }

        public int AddNumbers(int a, int b)
        {
            return a + b;
        }


    }
}
