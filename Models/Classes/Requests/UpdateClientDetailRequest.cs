using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes.Requests
{
    public class UpdateClientDetailRequest
    {
        public int ClientDetailID { get; set; }      
        public string ClientFirstName { get; set; }       
        public string ClientLastName { get; set; }     
        public string Phone { get; set; }       
        public string CivilIDNumber { get; set; }
    }
}
