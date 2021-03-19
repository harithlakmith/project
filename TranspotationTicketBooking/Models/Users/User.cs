using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace TranspotationTicketBooking.Models.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
        public string BusNo { get; set; }
        public long PId { get; set; }

        public ICollection<Passenger> Passengers { get; set; }
        public ICollection<BusInfo> BusInfos { get; set; }


    }
}
