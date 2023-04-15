using Cars.Models;

namespace Cars.database
{
    public class dbContext
    {
        public dbContext() { }

        public static List<Car> cars = new List<Car>()
        {
            new Car() { id = 1, name = "hundai", price = 500000, ProductionDate = DateTime.Today.AddYears(-3) , type ="Gas"},
            new Car() { id = 2, name = "honda", price = 600000, ProductionDate = DateTime.Today.AddYears(-2) , type ="Gas"},
            new Car() { id = 3, name = "Daio", price = 200000, ProductionDate = DateTime.Today.AddYears(-1) , type ="Gas" },
        };
    }
}
