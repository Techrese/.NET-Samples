namespace AdapterPattern
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public Decimal Salary { get; set; }
    }
}