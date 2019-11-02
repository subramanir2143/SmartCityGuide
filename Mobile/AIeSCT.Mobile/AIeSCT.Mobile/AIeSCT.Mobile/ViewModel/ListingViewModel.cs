using AIeSCT.Mobile.Data;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIeSCT.Mobile.ViewModel
{
    public class ListingViewModel: ViewModelBase
    {
        public string intent;

        public string Intent
        {
            get
            {
                return intent;
            }
            set
            {

                intent = value;
                RaisePropertyChanged("Intent");
            }
        }

        private IEnumerable<ResultClass> coll;

        public IEnumerable<ResultClass> Coll
        {
            get
            {
                return coll;
            }
            set
            {

                coll = value;
                RaisePropertyChanged("Coll");
            }
        }
    }
}
