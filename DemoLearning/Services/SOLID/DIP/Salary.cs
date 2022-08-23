using DemoLearning.Interface.SOLID;

namespace DemoLearning.Services.SOLID.DIP
{
    public class SalaryCalculatorModified : ISalaryCalculator
    {
        public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;

        public string CalculateSalary()
        {
            return "dd";
        }
    }
}
