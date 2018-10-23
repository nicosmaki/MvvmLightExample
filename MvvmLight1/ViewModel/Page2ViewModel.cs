using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace MvvmLight1.ViewModel
{
    public class Page2ViewModel:ViewModelBase
    {
        private string mess;
        public string Mess
        {
            get { return mess; }
            set
            {
                mess = value;
                RaisePropertyChanged(() => Mess);
            }
        }
        public Page2ViewModel()
        {
            Messenger.Default.Register<string>(this, "test",me);
        }
        private void me(string m)
        {
            Mess = m;
        }
    }
}
