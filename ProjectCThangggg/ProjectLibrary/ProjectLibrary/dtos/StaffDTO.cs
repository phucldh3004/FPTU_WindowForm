using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Staff
{
    public class StaffDTO
    {
        string staffID;
        string staffName;
        string password;
        string address;
        string phoneNumber;

        public StaffDTO()
        {
        }

        public StaffDTO(string staffID, string staffName, string password, string address, string phoneNumber)
        {
            this.StaffID = staffID;
            this.StaffName = staffName;
            this.Password = password;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public string StaffID { get => staffID; set => staffID = value; }
        public string StaffName { get => staffName; set => staffName = value; }
        public string Password { get => password; set => password = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
       
}
