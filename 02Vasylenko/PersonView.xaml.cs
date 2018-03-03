using System.Windows.Controls;
using FontAwesome.WPF;

namespace _02Vasylenko
{
    /// <summary>
    /// Логика взаимодействия для PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        private ImageAwesome _loader;
        public PersonView()
        {
            InitializeComponent();
            DataContext = new PersonViewModel(ShowLoader);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void ShowLoader(bool isShow)
                    {
                        LoaderHelper.OnRequestLoader(GridPersonView, ref _loader, isShow);
                   }
}
}
