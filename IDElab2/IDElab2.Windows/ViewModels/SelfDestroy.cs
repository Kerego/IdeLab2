using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace IDElab2.ViewModels
{
    public class SelfDestroy : CommonBase
    {
        public SelfDestroy()
        {
            selfDestroyTimer = string.Empty;
            visibility = Visibility.Collapsed;
            destroyButtonEnabled = true;
        }

        private string _selfDestroyTimer;
        public string selfDestroyTimer
        {
            get { return _selfDestroyTimer; }
            set
            {
                _selfDestroyTimer = value;
                OnPropertyChanged("selfDestroyTimer");
            }
        }


        private Visibility _visibility;
        public Visibility visibility
        {
            get { return _visibility; }
            set { _visibility = value;
            OnPropertyChanged("visibility");
            }
        }


        private bool _destroyButtonEnabled;
        public bool destroyButtonEnabled
        {
            get { return _destroyButtonEnabled; }
            set
            {
                _destroyButtonEnabled = value;
                OnPropertyChanged("destroyButtonEnabled");
            }
        }
        

    }
}
