using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_1.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        public string? LoanDate { get; set; }

        public string? ActualReturnDate { get; set; } 

        [Required(ErrorMessage = "The {0} field is required")]
        public string EstimatedReturnDate { get; set; } = null!;


        public Book? Book { get; set; }
        public User? User { get; set; }
    }
}

