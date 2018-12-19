using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using MvvmLight1.View;
using MahApps.Metro.Controls.Dialogs;

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

        private string _t;
        public string T
        {
            get { return _t; }
            set
            {
                _t = value;
                RaisePropertyChanged(() => T);
            }
        }

        public RelayCommand send2
        {
            get;
            set;
        }


        public Page1ViewModel()
        {
            Messenger.Default.Register<string>(this, "aaa", Getmsg);
            send2 = new RelayCommand(send);
        }

        private void Getmsg(string msg)
        {
            this.Msg += msg;
            Messenger.Default.Unregister(this);
        }

        private void send()
        {
            
            Messenger.Default.Send<Object>("cong 1 dao 2", "test");
            Window1 window = new Window1();
            window.Show();
        }
    }
}
