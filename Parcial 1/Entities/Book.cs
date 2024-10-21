using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parcial_1.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [Display(Name = "Title")]
        [MaxLength(200, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required")]
        [Display(Name = "Author")]
        [MaxLength(100, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        public string Author { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        public string PublicationDate { get; set; } = null!;

        [MaxLength(20, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        public string ISBN { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        public string Language { get; set; } = null!;

        public int Pages { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        // Relación con Publisher (uno a muchos)
        [Required]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; } = null!;

        // Relación con Category (uno a muchos)
        
        public Category? Category { get; set; }

        // Relación con Loan (uno a muchos)
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();

        // Relación con Reservation (uno a muchos)
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
