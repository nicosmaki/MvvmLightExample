using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;


namespace MvvmLight1.ViewModel
{
    public class Page1ViewModel : ViewModelBase
    {
        private string _msg;
        public string Msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
                RaisePropertyChanged(() => Msg);
            }
        }

        public Page1ViewModel()
        {
            Messenger.Default.Register<string>(this, "aaa", Getmsg);
            
            
        }

        private void Getmsg(string msg)
        {
            this.Msg += msg;
            Messenger.Default.Unregister(this);
        }
    }
}
