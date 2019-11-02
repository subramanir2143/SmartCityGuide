using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace AIeSCT.Mobile.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private string searchText;

        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {

                searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        private RelayCommand searchClick;

        public RelayCommand SearchClick
        {
            get
            {
                return searchClick ?? (searchClick = new RelayCommand(() =>
                {
                    // if (this.FirstName == "kannan")
                    MessagingCenter.Send<MainViewModel, string>(this, "Search", this.SearchText);

                })
                    );
            }
        }
    }
}