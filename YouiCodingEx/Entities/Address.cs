using System;

namespace YouiCodingEx
{
    public class Address
    {


        public Address(int strNumber, string strName)
        {
            this.StreetNumber = strNumber;
            this.StreetName = strName;
        }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }

        public string OutPut
        {
            get
            {
                return string.Concat(Convert.ToString(this.StreetNumber), " ", this.StreetName);

            }
        }
    }
}
