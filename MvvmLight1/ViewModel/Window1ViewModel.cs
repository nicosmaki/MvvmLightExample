using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using MvvmLight1.View;

namespace MvvmLight1.ViewModel
{
    public class Window1ViewModel:ViewModelBase
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
        public Window1ViewModel()
        {
            Messenger.Default.Register<string>(this, "W1", me);
            GotoW2 = new RelayCommand(goW2);
        }
        private void me(string m)
        {
            Mess = m;
            Console.WriteLine(Mess);
        }

        public RelayCommand GotoW2
        {
            get;
            set;
        }

        private void goW2()
        {
            Window2 w2 = new Window2();
            w2.Show();
            Messenger.Default.Send<string>("W1 to W2", "W2");
        }
    }
}
