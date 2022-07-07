// this is the implemeneted billing system in the project

namespace AdapterPattern
{
    public class ThirdPartyBillingSystem
    {
        public void ProcessSalary(List<Employee> employees)
        {
            foreach (var item in employees)
            {
                Console.WriteLine($"process payment for {item.Name}");
            }
        }
    }
}
