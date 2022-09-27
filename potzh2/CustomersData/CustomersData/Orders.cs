using System;

namespace CustomersData
{
    public class Orders
    {
        public string Comments { get; set; }
        public int CustomerNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string Status { get; set; }
        public static Orders FromCsv(string csvLine)
        {
            string[] lineData = csvLine.Split(';');
            var shipDate = lineData[3] == "NULL" ? null : lineData[3];

            if(shipDate == null)
            {
                return new Orders { OrderNumber = int.Parse(lineData[0]), OrderDate = DateTime.Parse(lineData[1]), RequiredDate = DateTime.Parse(lineData[2]), ShippedDate = null, Status = lineData[4], Comments = lineData[5], CustomerNumber = int.Parse(lineData[6]) };
            } else
            {
                return new Orders { OrderNumber = int.Parse(lineData[0]), OrderDate = DateTime.Parse(lineData[1]), RequiredDate = DateTime.Parse(lineData[2]), ShippedDate = DateTime.Parse(lineData[3]), Status = lineData[4], Comments = lineData[5], CustomerNumber = int.Parse(lineData[6]) };
            }
            
        }
    }
}
