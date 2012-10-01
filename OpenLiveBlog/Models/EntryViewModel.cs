using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenLiveBlog.Models
{
    public class EntryViewModel
    {
        public string content { get; set; }
        public string username { get; set; }
        public string id { get; protected set; }
        public DateTime dateTime { get; protected set; }
        public string date
        {
            get
            {
                return dateTime.ToString("H:mm");
            }
        }

        public EntryViewModel()
        {
            dateTime = DateTime.Now;
            id = Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}