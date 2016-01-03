using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{

    public class UsersStubDataObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CardsCount { get; set; }
        public int FingersCount { get; set; }
        public int FacesCount { get; set; }
    }
 
}
