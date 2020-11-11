using System;
using System.Collections.Generic;
using System.Text;

namespace Making_New_Class
{
    class Nameofclass
    {
        private string name;
        private string writer;
        private int pages; // REMEMBER to use the same class (string, int) everywhere!!!

        public Nameofclass()
        {
            name = "";
            writer = "";
            pages = 0;
        }

        public Nameofclass(string newname, string newwriter, int newpages)
            {
                name = newname;
                writer = newwriter;
                pages = newpages;
            }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Writer
        {
            get
            {
                return writer;
            }
            set
            {
                writer = value;
            }
        }
        public int Pages // HERE is used INT!!! just as from beginning
        {
            get
            {
                return pages;
            }
            set
            {
                pages = value;
            }
        }
    }
}
