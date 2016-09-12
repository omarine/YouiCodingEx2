namespace YouiCodingEx
{
   public class People
    {
        public People()
        {

        }

        public People(string fName, string lName)
        {
            this.FirstName = fName;
            this.LastName = lName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FirstNameFrequency { get; set; }
        public int LastNameFrequency { get; set; }

        public string Output
        {

            get
            {
                
               return string.Concat(this.FirstName, ",", this.FirstNameFrequency, ",", this.LastName, ",",
                    this.LastNameFrequency);
            }
        }

    }
}
