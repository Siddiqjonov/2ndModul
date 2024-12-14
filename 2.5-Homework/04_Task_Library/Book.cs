using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Task_Library
{
    public class Book
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
    }
}
