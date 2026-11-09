namespace TemperatureBlazorApp.Models
{
	public enum TemperatureScale { Celsius, Fahrenheit, Kelvin }

	public class TemperatureResult
	{
		public double Celsius { get; set; }
		public double Fahrenheit { get; set; }
		public double Kelvin { get; set; }
	}

	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int Age { get; set; }
	}

	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
	}

	public class CreateProductRequest
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
	}

	public class CreateProductResponse
	{
		public int StatusCode { get; set; }
		public Product Product { get; set; } = new();
	}
}
