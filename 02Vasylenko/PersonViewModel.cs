using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _02Vasylenko
{
    public class PersonViewModel : INotifyPropertyChanged 
    {
    
        private readonly Person domObject;
        private readonly PersonManager PersonManager;
        private readonly ObservableCollection<Person> _Persons;
        private Action<bool> _showLoaderAction;
        public PersonViewModel(Action<bool> showLoader)
        {
            domObject = new Person();
            PersonManager = new PersonManager();
            _Persons = new ObservableCollection<Person>();
            AddPersonCmd = new RelayCommand(Add, CanAdd);
            _showLoaderAction = showLoader;
        }
        public PersonViewModel()
        {
            domObject = new Person();
            PersonManager = new PersonManager();
            _Persons = new ObservableCollection<Person>();
            AddPersonCmd = new RelayCommand(Add, CanAdd);
        }
        public string LastName
        {
            get { return domObject.LastName; }
            set
            {
                domObject.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Name
        {
            get { return domObject.Name; }
            set
            {
                domObject.Name = value;
                OnPropertyChanged("Name");
            }
        }
       public string Email
        {
            get { return domObject.Email; }
            set
            {
                domObject.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime DateOfBirth
        {
            get { return domObject.DateOfBirth; }
            set
            {
                if (value > DateTime.Today)
                {
                    throw new IlligalDateException(value.ToString(CultureInfo.CurrentCulture));
                }
                else
                {
                    domObject.DateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }      
            }
        }
        public bool IsAdult
        {
            get { return domObject.IsAdult; }
        }
        public string SunSign
        {
            get { return domObject.SunSign; }
        }
        public string ChineseSign
        {
            get { return domObject.ChineseSign; }
        }
        public bool IsBirthday
        {
            get { return domObject.IsBirthday; }
        }

        public ObservableCollection<Person> Persons { get { return _Persons; } }
        public ICommand AddPersonCmd { get; }

        public bool CanAdd(object obj)
        {
            if(LastName != String.Empty&& Name !=String.Empty && Email != String.Empty&& DateOfBirth!= DateTime.MinValue)
            {
                return true;
            }
            return false;
        }
        public async void Add(object obj)
        {
            _showLoaderAction.Invoke(true);
            await Task.Run((() =>
                            {
                                Thread.Sleep(2000);
                            }));
            var person = new Person { LastName = LastName, Name = Name, Email = Email, DateOfBirth = DateOfBirth };
            if (person.IsReal)
            {
                Persons.Add(person);
                ResetPerson();
                if (person.DateOfBirth.DayOfYear.Equals(DateTime.Today.DayOfYear)) MessageBox.Show("HappyBirthday");
            }
            else
            {
                MessageBox.Show("You can`t exist in real world. Check daybirth field, please.");
            }

            _showLoaderAction.Invoke(false);
        }

   
        private void ResetPerson()
        {
            LastName = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        class IlligalDateException : Exception
        {
            public IlligalDateException(string message)
                : base(message)
            { }
        }
    }
}

