using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.dtos
{
    public class PhoneDTO
    {
        int ID, quantity, TypeID, CategoryID, StatusID, ManuFactureYear;
        string PhoneName;
        DateTime AccquiredDate;
        double Price;

        public PhoneDTO()
        {

        }

        public PhoneDTO(int iD, int quantity, int typeID, int categoryID, int statusID, int manuFactureYear, string phoneName, DateTime accquiredDate, double price)
        {
            ID1 = iD;
            this.Quantity = quantity;
            TypeID1 = typeID;
            CategoryID1 = categoryID;
            StatusID1 = statusID;
            ManuFactureYear1 = manuFactureYear;
            PhoneName1 = phoneName;
            AccquiredDate1 = accquiredDate;
            Price1 = price;
        }

        public int ID1 { get => ID; set => ID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int TypeID1 { get => TypeID; set => TypeID = value; }
        public int CategoryID1 { get => CategoryID; set => CategoryID = value; }
        public int StatusID1 { get => StatusID; set => StatusID = value; }
        public int ManuFactureYear1 { get => ManuFactureYear; set => ManuFactureYear = value; }
        public string PhoneName1 { get => PhoneName; set => PhoneName = value; }
        public DateTime AccquiredDate1 { get => AccquiredDate; set => AccquiredDate = value; }
        public double Price1 { get => Price; set => Price = value; }
    }
}
