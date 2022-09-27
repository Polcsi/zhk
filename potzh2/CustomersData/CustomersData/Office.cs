namespace CustomersData
{
    public class Office
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int OfficeCode { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Territory { get; set; }
        public override string ToString()
        {
            return string.Format($"{OfficeCode}:{PostalCode}({Territory})");
        }
        public static Office FromCsv(string csvLine)
        {
            string[] dataFromLine = csvLine.Split(',');
            return new Office { OfficeCode = int.Parse(dataFromLine[0]),  City = dataFromLine[1], Phone = dataFromLine[2], AddressLine1 = dataFromLine[3], AddressLine2 = dataFromLine[4], State = dataFromLine[5], Country = dataFromLine[6], PostalCode = dataFromLine[7], Territory = dataFromLine[8] };
        }
    }
}
