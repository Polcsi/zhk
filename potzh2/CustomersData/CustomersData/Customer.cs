namespace CustomersData
{
    public class Customer
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Country { get; set; }
        public double CreditLimit { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public int? SalesRepEmployeeNumber { get; set; }
        public string State { get; set; }
        public override string ToString()
        {
            return string.Format($"{CustomerName}:{CreditLimit}({CustomerNumber})");
        }
        public static Customer FromCsv(string csvLine)
        {
            string[] lineData = csvLine.Split(';');
            var salesEmployeeNumber = lineData[11] == "NULL" ? null : lineData[11];

            if(salesEmployeeNumber == null)
            {
                return new Customer { CustomerNumber = int.Parse(lineData[0]), CustomerName = lineData[1], ContactLastName = lineData[2], ContactFirstName = lineData[3], Phone = lineData[4], AddressLine1 = lineData[5], AddressLine2 = lineData[6], City = lineData[7], State = lineData[8], PostalCode = lineData[9], Country = lineData[10], SalesRepEmployeeNumber = null, CreditLimit = double.Parse(lineData[12]) };
            } else
            {
                return new Customer { CustomerNumber = int.Parse(lineData[0]), CustomerName = lineData[1], ContactLastName = lineData[2], ContactFirstName = lineData[3], Phone = lineData[4], AddressLine1 = lineData[5], AddressLine2 = lineData[6], City = lineData[7], State = lineData[8], PostalCode = lineData[9], Country = lineData[10], SalesRepEmployeeNumber = int.Parse(lineData[11]), CreditLimit = double.Parse(lineData[12]) };
            }
        }
    }
}
