using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _02Vasylenko
{
    public class PersonViewModel : INotifyPropertyChanged 
    {
    
        private readonly Person _domObject;
        private readonly ObservableCollection<Person> _persons;
        private readonly Action<bool> _showLoaderAction;
        public PersonViewModel(Action<bool> showLoader)
        {
            _domObject = new Person();
            new PersonManager();
            _persons = new ObservableCollection<Person>();
            AddPersonCmd = new RelayCommand(Add);
            _showLoaderAction = showLoader;
        }
        public PersonViewModel()
        {
            _domObject = new Person();
            new PersonManager();
            _persons = new ObservableCollection<Person>();
            AddPersonCmd = new RelayCommand(Add);
        }
        public string LastName
        {
            get => _domObject.LastName;
            set
            {
                _domObject.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Name
        {
            get => _domObject.Name;
            set
            {
                _domObject.Name = value;
                OnPropertyChanged("Name");
            }
        }
       public string Email
        {
            get => _domObject.Email;
           set
            {
                _domObject.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime DateOfBirth
        {
            get => _domObject.DateOfBirth;
            set
            {
                _domObject.DateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        public bool IsAdult => _domObject.IsAdult;
        public string SunSign => _domObject.SunSign;
        public string ChineseSign => _domObject.ChineseSign;
        public bool IsBirthday => _domObject.IsBirthday;

        public ObservableCollection<Person> Persons { get { return _persons; } }
        public ICommand AddPersonCmd { get; }

        public async void Add(object obj)
        {
            _showLoaderAction.Invoke(true);
            
                await Task.Run((() =>
                { 
                    Thread.Sleep(2000);
                }));
            try
            {
                if (LastName == string.Empty)
                {
                    throw new IlligalInputException("Last Name");
                }
                if (Name == string.Empty)
                {
                    throw new IlligalInputException("Last Name");
                }
                if (!new EmailAddressAttribute().IsValid(Email))
                {
                    throw new IlligalEmailException(Email);
                }
                int check = DateTime.Today.Year - DateOfBirth.Year;
                if (DateTime.Today.Date < DateOfBirth.Date || check > 135)
                {
                    throw new IlligalDateException(DateOfBirth.ToString(CultureInfo.InvariantCulture) + " ");
                }
                var person = new Person { LastName = LastName, Name = Name, Email = Email, DateOfBirth = DateOfBirth };
                Persons.Add(person);
                if (person.DateOfBirth.DayOfYear.Equals(DateTime.Today.DayOfYear)) MessageBox.Show("HappyBirthday");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ResetPerson();
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
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        internal class IlligalInputException : Exception
        {
            public IlligalInputException(string error)
                : base("Error: this field" + error + " is required")
            { }
        }
        internal class IlligalDateException : Exception
        {
            public IlligalDateException(string error)
                : base("Error: illigal format of date: " + error + "You can`t be older than 135 years or have not born yet")
            { }
        }
        internal class IlligalEmailException : Exception
        {
            public IlligalEmailException(string error)
                : base("Error: illigal format of email: " + error)
            { }
        }
    }
}

