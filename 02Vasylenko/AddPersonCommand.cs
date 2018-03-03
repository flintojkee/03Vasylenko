using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _02Vasylenko
{
    public class AddPersonCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            var personManager = new PersonManager();

            if (parameter is Person person && personManager.Add(new Person
            {
                LastName = person.LastName,
                Name = person.Name, 
                Email = person.Email,
                DateOfBirth = person.DateOfBirth
            }))
                MessageBox.Show("Person Add Successful !"); 
        }
    }
}
