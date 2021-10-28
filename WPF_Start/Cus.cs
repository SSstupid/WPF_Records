using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Start
{
    public class Cus : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string name;
        private int age;

        public string Name 
        { 
            get 
            { 
                return name; 
            } 
            set 
            {
                if (name == value) { return; }
                name = value;
                Notify("name");
            } 
        } 
        public int Age 
        { 
            get 
            { 
                return age; 
            } 
            set 
            {
                if (age == value) { return; }
                age = value;
                Notify("age");
            } 
        }
        public Cus() { }
        public Cus(string Name , int Age)
        {
            this.name = Name;
            this.age = Age;
        }
    }
}
