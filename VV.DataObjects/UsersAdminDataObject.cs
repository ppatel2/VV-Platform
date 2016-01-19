using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace VV.DataObjects
{
    public class UsersAdminDataObject
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string Guid { get; set; }
        public string CookieId { get; set; }
        public ObservableCollection<string> Claims { get; set; }

    }
}
