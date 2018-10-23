using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace MvvmLight1.ViewModel
{
    public class Window2ViewModel:ViewModelBase
    {
        public Window2ViewModel()
        {
            Messenger.Default.Register<string>(this, "W2", mes);
        }

        private string me;
        public string Me
        {
            get { return me; }
            set
            {
                me = value;
                RaisePropertyChanged(() => Me);
            }
        }

        private void mes(string m)
        {
            Me = m;
            Console.WriteLine(Me);
        }
    }
}
