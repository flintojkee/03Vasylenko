
using System;

namespace _02Vasylenko
{
    public class Person
    {
        
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsAdult
        {
            get
            {
                CalculateAge();
                return _age >= 18;
            }
        }
        public string SunSign
        {
            get {
                CalculateZodiacs();
                return _sunSign;
            }
        }
        public string ChineseSign
        {
            get
            {
                CalculateZodiacs();
                return _chineseSign;
            }
        }

        public bool IsBirthday
        {
            get
            {
                if (DateOfBirth.Day == DateTime.Today.Day) _isBirthday = true;
                return _isBirthday;
            }
        }

        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;
        public DateTime DateOfBirth { get; set; }

        private int _age;
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

    }
        
    }
