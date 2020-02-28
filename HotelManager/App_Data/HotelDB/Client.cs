using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class Client
    {
        public Client()
        {
            Reservations = new List<Reservation>();
        }
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public bool IsAdult { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}