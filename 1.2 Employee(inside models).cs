namespace EmployeeCRUDAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime JoiningDare { get; set; } //change to JoiningDate
    }
}
