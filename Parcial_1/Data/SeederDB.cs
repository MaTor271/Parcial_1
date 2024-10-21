using Microsoft.EntityFrameworkCore;
using Parcial_1.API.Data;
using Parcial_1.Entities;

namespace Parcial_1.API.Data
{
    public class SeederDB
    {
        private readonly DataContext _dataContext;

        public SeederDB(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckPublishersAsync();
            await CheckCategoriesAsync();
            await CheckUsersAsync();
            await CheckBooksAsync();
            await CheckLoansAsync();
            await CheckReservationsAsync();
        }

        private async Task CheckPublishersAsync()
        {
            if (!_dataContext.Publishers.Any())
            {
                _dataContext.Publishers.Add(new Publisher { Name = "Penguin Random House", Country = "USA" });
                _dataContext.Publishers.Add(new Publisher { Name = "HarperCollins", Country = "UK" });
                _dataContext.Publishers.Add(new Publisher { Name = "Planeta", Country = "Spain" });
                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckCategoriesAsync()
        {
            if (!_dataContext.Categories.Any())
            {
                _dataContext.Categories.Add(new Category { Name = "Fiction" });
                _dataContext.Categories.Add(new Category { Name = "Non-fiction" });
                _dataContext.Categories.Add(new Category { Name = "Science Fiction" });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckUsersAsync()
        {
            if (!_dataContext.Users.Any())
            {
                _dataContext.Users.Add(new User
                {
                    FirstName = "Juan",
                    SurName = "Pérez",
                    LastName = "López",
                    Email = "juanperez@gmail.com",
                    Address = "Calle Falsa 123",
                    Phone = "555-1234",  
                    DateOfBirth = "1990-01-01",
                    MembershipType = "Premium",
                    RegistrationDate = DateTime.Now,
                    IsActive = true
                });
                _dataContext.Users.Add(new User
                {
                    FirstName = "María",
                    SurName = "García",
                    LastName = "Rodríguez",
                    Email = "mariagarcia@gmail.com",
                    Address = "Avenida Siempreviva 742",
                    Phone = "555-9876",
                    DateOfBirth = "1985-03-15",
                    MembershipType = "Standard",
                    RegistrationDate = DateTime.Now,
                    IsActive = true
                });

                _dataContext.Users.Add(new User
                {
                    FirstName = "Carlos",
                    SurName = "Méndez",
                    LastName = "González",
                    Email = "carlosmendez@gmail.com",
                    Address = "Calle Primavera 456",
                    Phone = "555-6789",
                    DateOfBirth = "1992-07-22",
                    MembershipType = "Basic",
                    RegistrationDate = DateTime.Now,
                    IsActive = true
                });

                await _dataContext.SaveChangesAsync();
            }
        }


        
        private async Task CheckBooksAsync()
        {
            if (!_dataContext.Books.Any())
            {
                var publisher = await _dataContext.Publishers.FirstOrDefaultAsync();
                var category = await _dataContext.Categories.FirstOrDefaultAsync();

                if (publisher != null && category != null)
                {
                    _dataContext.Books.Add(new Book
                    {
                        Title = "El Quijote",
                        Author = "Miguel de Cervantes",
                        ISBN = "978-3-16-148410-0",
                        Publisher = publisher,
                        Category = category,
                        Language = "Español",
                        PublicationDate = "2024"
                    });
                    _dataContext.Books.Add(new Book
                    {
                        Title = "Cien años de soledad",
                        Author = "Gabriel García Márquez",
                        ISBN = "978-84-376-0494-7",
                        Publisher = publisher,
                        Category = category,
                        Language = "Español",
                        PublicationDate = "2024"
                    });
                    _dataContext.Books.Add(new Book
                    {
                        Title = "1984",
                        Author = "George Orwell",
                        ISBN = "978-0-452-28423-4",
                        Publisher = publisher,
                        Category = category,
                        Language = "Español",
                        PublicationDate = "2024"

                    });
                    await _dataContext.SaveChangesAsync();
                }
            }
        }

        
        private async Task CheckLoansAsync()
        {
            if (!_dataContext.Loans.Any())
            {
                var user = await _dataContext.Users.FirstOrDefaultAsync();
                var book = await _dataContext.Books.FirstOrDefaultAsync();

                if (user != null && book != null)
                {
                    _dataContext.Loans.Add(new Loan
                    {
                        User = user,
                        Book = book,
                        LoanDate = DateTime.Now,
                        ReturnDate = DateTime.Now.AddDays(14)
                    });
                    await _dataContext.SaveChangesAsync();
                }
            }
        }

        
        private async Task CheckReservationsAsync()
        {
            if (!_dataContext.Reservations.Any())
            {
                var user = await _dataContext.Users.FirstOrDefaultAsync();
                var book = await _dataContext.Books.FirstOrDefaultAsync();

                if (user != null && book != null)
                {
                    _dataContext.Reservations.Add(new Reservation
                    {
                        User = user,
                        Book = book,
                        LoanDate = "2024-04-24",
                        EstimatedReturnDate = "2024-04-24"
                    });
                    await _dataContext.SaveChangesAsync();
                }
            }
        }
    }
}
