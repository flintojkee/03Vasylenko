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
            get { return _domObject.LastName; }
            set
            {
                _domObject.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Name
        {
            get { return _domObject.Name; }
            set
            {
                _domObject.Name = value;
                OnPropertyChanged("Name");
            }
        }
       public string Email
        {
            get { return _domObject.Email; }
            set
            {
                _domObject.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime DateOfBirth
        {
            get { return _domObject.DateOfBirth; }
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
            try
            {
                await Task.Run((() =>
                {
                    Thread.Sleep(2000);
                }));
                var person = new Person { LastName = LastName, Name = Name, Email = Email, DateOfBirth = DateOfBirth };
                        Persons.Add(person);
                        ResetPerson();
                        if (person.DateOfBirth.DayOfYear.Equals(DateTime.Today.DayOfYear)) MessageBox.Show("HappyBirthday");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

