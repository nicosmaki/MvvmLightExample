using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;


namespace MvvmLight1.Model
{
    public class Person:ObservableObject
    {
        private string _name;
        private Sex _sex;
        private int _age;
        private string _loginname;
        private string _loginpwd;

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public Sex Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                RaisePropertyChanged(() => Sex);
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                RaisePropertyChanged(() => Age);
            }
        }

        /*public string Loginname
        {
            get { return _loginname; }
            set
            {
                _loginname = value;
                RaisePropertyChanged(() => Loginname);
            }
        }
        
        public string Loginpwd
        {
            get { return _loginpwd; }
            set
            {
                _loginpwd = value;
                RaisePropertyChanged(() => Loginpwd);
            }
        }*/

        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                RaisePropertyChanged(() => Content);
            }
        }
    }
}
