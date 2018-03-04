
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace _02Vasylenko
{
    public class Person
    {
        
        public string Name {
            get { return _firstName; }
            set
            {
                if (value == string.Empty)
                {
                    throw new IlligalInputException("First name");
                }
                else
                {
                    _firstName = value;
                }
                
            }
        }

        public string LastName {
            get { return _lastName; }
            set
            {
                if (value == string.Empty)
                {
                    throw new IlligalInputException("Last name");
                }
                else
                {
                    _lastName = value;
                }

            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (value==string.Empty)
                {
                    throw new IlligalInputException("Email");
                    
                }
                else
                {
                    if (new EmailAddressAttribute().IsValid(value))
                    {
                        _email = value;
                    }
                     else
                        throw new IlligalEmailException(value);
                }

            }
        }

        internal bool IsAdult
        {
            get
            {
                CalculateAge();
                return _age >= 18;
            }
        }
        internal string SunSign
        {
            get {
                CalculateZodiacs();
                return _sunSign;
            }
        }
       internal string ChineseSign
        {
            get
            {
                CalculateZodiacs();
                return _chineseSign;
            }
        }

        internal bool IsBirthday
        {
            get
            {
                isBirthday();
                return _isBirthday;
            }
        }

        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;
        private DateTime _birthDate;
        private string _email;
        private string _firstName;
        private string _lastName;
        public DateTime DateOfBirth {
            get { return _birthDate; }
            set
            {
                int check = DateTime.Today.Year - value.Year;
                if (DateTime.Today.Date < value.Date || check > 135)
                {
                    throw new IlligalDateException(value.ToString(CultureInfo.InvariantCulture)+" ");
                }
                else
                {
                    _birthDate = value;
                }
               
            }
        }
        private int _age;
        private bool _isReal;
        public Person(string name, string lastName, string email, DateTime dateOfBirth)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
        public Person(string name, string lastName, string email)
        {
            Name = name;
            LastName = lastName;
            Email = email;
        }
        public Person(string name, string lastName, DateTime dateOfBirth)
        {
            Name = name;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            DateOfBirth = dateOfBirth;
        }

        public Person(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        public bool IsReal
        {
            get
            {
                isReal();
                return _isReal;
            }
        }

        public Person()
        {
        }
           
            private void CalculateAge()
            {
                DateTime today = DateTime.Today;
                _age = today.DayOfYear <= DateOfBirth.DayOfYear
                    ? today.Year - DateOfBirth.Year - 1
                    : today.Year - DateOfBirth.Year;
            }

            private void CalculateZodiacs()
            {
                switch (DateOfBirth.Month)
                {
                    case 1:
                        _sunSign = DateOfBirth.Day < 20 ? "Capricorn" : "Aquarius";
                        break;
                    case 2:
                        _sunSign = DateOfBirth.Day < 18 ? "Aquarius" : "Pisces";
                        break;
                    case 3:
                        _sunSign = DateOfBirth.Day < 20 ? "Pisces" : "Aries";
                        break;
                    case 4:
                        _sunSign = DateOfBirth.Day < 20 ? "Aries" : "Taurus";
                        break;
                    case 5:
                        _sunSign = DateOfBirth.Day < 21 ? "Taurus" : "Gemini";
                        break;
                    case 6:
                        _sunSign = DateOfBirth.Day < 21 ? "Gemini" : "Cancer";
                        break;
                    case 7:
                        _sunSign = DateOfBirth.Day < 23 ? "Cancer" : "Leo";
                        break;
                    case 8:
                        _sunSign = DateOfBirth.Day < 23 ? "Leo" : "Virgo";
                        break;
                    case 9:
                        _sunSign = DateOfBirth.Day < 23 ? "Virgo" : "Libra";
                        break;
                    case 10:
                        _sunSign = DateOfBirth.Day < 23 ? "Libra" : "Scorpio";
                        break;
                    case 11:
                        _sunSign = DateOfBirth.Day < 22 ? "Scorpio" : "Sagittarius";
                        break;
                    case 12:
                        _sunSign = DateOfBirth.Day < 22 ? "Sagittarius" : "Capricorn";
                        break;
                }

                switch (DateOfBirth.Year % 12)
                {
                    case 0:
                    _chineseSign = "Monkey";
                        break;
                    case 1:
                    _chineseSign = "Rooster";
                        break;
                    case 2:
                    _chineseSign = "Dog";
                        break;
                    case 3:
                    _chineseSign = "Pig";
                        break;
                    case 4:
                    _chineseSign = "Rat";
                        break;
                    case 5:
                    _chineseSign = "Ox";
                        break;
                    case 6:
                    _chineseSign = "Tiger";
                        break;
                    case 7:
                    _chineseSign = "Rabbit";
                        break;
                    case 8:
                    _chineseSign = "Dragon";
                        break;
                    case 9:
                    _chineseSign = "Snake";
                        break;
                    case 10:
                    _chineseSign = "Horse";
                        break;
                    case 11:
                    _chineseSign = "Sheep";
                        break;
                }
            }

        private void isBirthday()
        {
            if(DateOfBirth.Day == DateTime.Today.Day)_isBirthday = true;
        }
        private void isReal()
        {
            int check = DateTime.Today.Year - DateOfBirth.Year;
            if (DateTime.Today.Date < DateOfBirth.Date || check > 135) _isReal = false;
            else
            {
                _isReal = true;
            }
        }
        internal class IlligalDateException : Exception
        {
            public IlligalDateException(string error )
                : base("Error: illigal format of date: "+ error+"You can`t be older than 135 years or have not born yet")
            { }
        }
        internal class IlligalEmailException : Exception
        {
            public IlligalEmailException(string error)
                : base("Error: illigal format of email: " + error)
            { }
        }
        internal class IlligalInputException : Exception
        {
            public IlligalInputException(string error)
                : base("Error: this field" + error+"is required")
            { }
        }
    }
        
    }
