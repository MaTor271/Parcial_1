using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_1.Entities
{
    public class Loan
    {
        public int Id { get; set; }

        // Clave foránea para Book
        [Required(ErrorMessage = "The {0} field is required")]
        public int BookId { get; set; }

        // Clave foránea para User
        [Required(ErrorMessage = "The {0} field is required")]
        public int UserId { get; set; }

        // Fecha en la que se realiza la reserva
        [Required(ErrorMessage = "The {0} field is required")]
        [DataType(DataType.DateTime, ErrorMessage = "The {0} field must be a valid date")]
        public DateTime BookingDate { get; set; }

        // Fecha en la que el libro está disponible
        [Required(ErrorMessage = "The {0} field is required")]
        [DataType(DataType.DateTime, ErrorMessage = "The {0} field must be a valid date")]
        public DateTime AvailableDate { get; set; }

        // Fecha en la que el préstamo fue efectuado
        [Required(ErrorMessage = "The {0} field is required")]
        [DataType(DataType.DateTime, ErrorMessage = "The {0} field must be a valid date")]
        public DateTime LoanDate { get; set; }

        // Fecha en la que el libro es devuelto (puede ser null si aún no ha sido devuelto)
        [DataType(DataType.DateTime, ErrorMessage = "The {0} field must be a valid date")]
        public DateTime? ReturnDate { get; set; }

        // Fecha límite de devolución
        [Required(ErrorMessage = "The {0} field is required")]
        [DataType(DataType.DateTime, ErrorMessage = "The {0} field must be a valid date")]
        public DateTime DueDate { get; set; }

        // Tarifa por día de retraso
        [Required(ErrorMessage = "The {0} field is required")]
        [Range(0, double.MaxValue, ErrorMessage = "The {0} must be a positive value")]
        public decimal FinePerDay { get; set; } = 1.00m; // Ejemplo: 1.00 es la tarifa diaria

        // Relación con el libro (opcional)
        public Book? Book { get; set; }

        // Relación con el usuario
        [Required(ErrorMessage = "A User must be associated with the loan")]
        public User? User { get; set; }

        // Propiedad calculada para la multa total
        public decimal TotalFine
        {
            get
            {
                if (ReturnDate.HasValue && ReturnDate > DueDate)
                {
                    // Calcula la diferencia en días entre la fecha de devolución y la fecha límite
                    int daysLate = (ReturnDate.Value - DueDate).Days;
                    return daysLate * FinePerDay;
                }
                return 0;
            }
        }

        // Propiedad calculada para asegurar que la fecha de devolución no es anterior a la de préstamo
        public bool IsReturnDateValid()
        {
            return ReturnDate == null || ReturnDate >= LoanDate;
        }
    }
}

