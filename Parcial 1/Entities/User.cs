using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_1.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Primer Nombre")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Segundo Nombre")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string SurName { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Apellidos")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required")]
        [Display(Name = "Email")]
        [MaxLength(200, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        [EmailAddress(ErrorMessage = "The {0} field must be a valid email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required")]
        [MaxLength(200, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required")]
        [MaxLength(20, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        [Phone(ErrorMessage = "The {0} field must be a valid phone number")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required")]
        [MaxLength(50, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        public string DateOfBirth { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required")]
        [MaxLength(50, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        public string MembershipType { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required")]
        [MaxLength(50, ErrorMessage = "The {0} field cannot have more than {1} characters")]
        public DateTime? RegistrationDate { get; set; } 
        public bool IsActive { get; set; }

        public ICollection<Loan>? Loans { get; set; }
        public ICollection<Reservation>? Reservations { get; set; } 
    
    }
}
    