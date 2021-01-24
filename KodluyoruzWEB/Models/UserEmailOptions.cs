using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Models
{
    public class UserEmailOptions
    {
        public List<string> toEmails { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public List<KeyValuePair<string,string>> PlaceHolders { get; set; }
    }
}
