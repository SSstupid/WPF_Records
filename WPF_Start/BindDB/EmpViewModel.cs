using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindDB
{
    public class EmpViewModel
    {
        int no = 0;
        string name;
        string address;

        public int No
        {
            get { return no; }
            set { this.No = value; }
        }
        public string Name
        {
            get { return name; }
            set { this.Name = value; }
        } 
        public string Address
        {
            get { return address; }
            set { this.Address = value; }
        }
    }
}
