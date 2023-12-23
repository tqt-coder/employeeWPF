using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEmployee.DTO
{
     public class EmployeeDTO : INotifyPropertyChanged, ICloneable
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string AvatarImage { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
