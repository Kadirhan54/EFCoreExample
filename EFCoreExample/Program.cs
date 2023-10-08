// See https://aka.ms/new-console-template for more information
using EFCoreExample.Entities;
using EFCoreExample.Persistence;


bool DeletePerson(int id)
{
    using (var context = new ExampleDbContext())
    {
        // Find the person with the specified Id
        var personToDelete = context.Persons.Find(id);

        if (personToDelete != null)
        {
            // Delete the person
            context.Persons.Remove(personToDelete);
            context.SaveChanges();
            return true;
        }
        return false;
    }
}

void BulkInsertion()
{
    using (var context = new ExampleDbContext())
    {

        var newProducts = new List<Product>
        {
            new Product { Name = "Product1", Price = 10.99m, StockQuantity = 100 },
            new Product { Name = "Product2", Price = 15.99m, StockQuantity = 50 },
            new Product { Name = "Product3", Price = 5.99m, StockQuantity = 200 }
        };

        var newPersons = new List<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1985, 5, 15)
            },
            new Person
            {
                Id = 2,
                FirstName = "Alice",
                LastName = "Smith",
                DateOfBirth = new DateTime(1990, 8, 22)
            },
            new Person
            {
                Id = 3,
                FirstName = "Bob",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1978, 12, 10)
            }
        };

        // Add the new products to the database
        context.Products.AddRange(newProducts);
        context.Persons.AddRange(newPersons);
        context.SaveChanges();
    }

}

bool UpdateProduct(int id) 
{
    using (var context = new ExampleDbContext())
    {
        // Find the product with the specified Id
        var productToUpdate = context.Products.Find(id);

        if (productToUpdate != null)
        {
            // Update the product properties
            productToUpdate.Name = "UpdatedProduct";
            productToUpdate.Price = 19.99m;
            productToUpdate.StockQuantity = 75;

            // Save the changes to the database
            context.SaveChanges();
            return true;
        }
        return false;
    }

}


BulkInsertion();

Console.WriteLine("Hello, World!");