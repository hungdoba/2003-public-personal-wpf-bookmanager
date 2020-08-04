using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace booksManager
{
    class allBooksBorrowInformation
    {
        public string nameBorrower { get; set; }
        public string addressBorrower { get; set; }
        public string phoneBorrowerer { get; set; }
        public string nameBook { get; set; }
        public DateTime timeBorrow { get; set; }
        public DateTime timeReturn { get; set; } 
        public string note { get; set; }
    }
}
