using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_1.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string? Name{ get; set; }
        public string? Country { get; set; }

        // Relación con Book (uno a muchos)
        public ICollection<Book>? Books { get; set; }
    }

}
