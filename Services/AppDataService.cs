using System.Collections.Generic;
using TemperatureBlazorApp.Models;
using System.Linq;


namespace TemperatureBlazorApp.Services
{
    public class AppDataService
    {
        private readonly List<Student> _students = new()
        {
            new Student { Id = 1, Name = "Анна Иванова", Age = 20 },
            new Student { Id = 2, Name = "Иван Петров", Age = 21 }
        };

        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Яблоко", Price = 1.20m },
            new Product { Id = 2, Name = "Банан", Price = 0.80m }
        };

        public List<Student> GetStudents() => _students.ToList();

        public void AddStudent(Student student)
        {
            student.Id = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;
            _students.Add(student);
        }

        public void DeleteStudent(int id) => _students.RemoveAll(s => s.Id == id);

        public List<Product> GetProducts() => _products.ToList();

        public CreateProductResponse CreateProduct(CreateProductRequest request)
        {
            var newProduct = new Product
            {
                Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1,
                Name = request.Name,
                Price = request.Price
            };
            _products.Add(newProduct);
            return new CreateProductResponse { StatusCode = 0, Product = newProduct };
        }
    }
}
