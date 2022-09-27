namespace CustomersData
{
    public class Employee
    {
        public string Email { get; set; }
        public int EmployeeNumber { get; set; }
        public string Extension { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public int OfficeCode { get; set; }
        public string ReportsTo { get; set; }
        public Office GetOffice(Program program)
        {
            return program.offices.Find(x => x.OfficeCode == OfficeCode);
        }
        public static Employee FromCsv(string csvLine)
        {
            string[] lineData = csvLine.Split(',');
            return new Employee {EmployeeNumber = int.Parse(lineData[0]), LastName = lineData[1], FirstName = lineData[2], Extension = lineData[3], Email = lineData[4], OfficeCode = int.Parse(lineData[5]), ReportsTo = lineData[6], JobTitle = lineData[7] };
        }
    }
}
