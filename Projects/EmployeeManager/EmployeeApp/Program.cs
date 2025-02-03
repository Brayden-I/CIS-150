namespace EmployeeApp
{
    //abstract is what is used to specify this is a base class that does not get created as it's own
    public abstract class Employee
    {
        //FIELDS
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal BaseSalary { get; set; }

        //CONSTRUCTOR
        public Employee(int id, string name, string department, decimal baseSalary)
        {
            this.Id=id;
            this.Name=name;
            this.Department=department;
            this.BaseSalary=baseSalary;
        }

        //METHODS
        public abstract decimal CalculatePay();
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Department: {Department}, Base Salary: {BaseSalary:C}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee fullTimeEmp = new FullTimeEmployee(1, "Alice Johnson", "HR", 50000, 5000);
            Employee partTimeEmp = new PartTimeEmployee(2, "Bob Smith", "IT", 0, 25, 120);
            Employee contractorEmp = new Contractor(3, "Charlie Brown", "Finance", 60000, new DateTime(2025, 12, 31));

            Console.WriteLine(fullTimeEmp);
            Console.WriteLine(partTimeEmp);
            Console.WriteLine(contractorEmp);
        }
    }
}
