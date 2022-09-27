using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CustomersData
{
    public class Program
    {
        public List<Office> offices = new List<Office>();
        public List<Customer> customers = new List<Customer>();
        public List<Employee> employees = new List<Employee>();
        public List<Orders> orders = new List<Orders>();
        static void Main(string[] args)
        {
            Program prg = new Program();

            File.ReadAllLines("offices.csv").Skip(1).ToList().ForEach(delegate (string line)
            {
                prg.offices.Add(Office.FromCsv(line));
            });
            File.ReadAllLines("customers.csv").Skip(1).ToList().ForEach(delegate (string line)
            {
                prg.customers.Add(Customer.FromCsv(line));
            });
            File.ReadAllLines("employees.csv").Skip(1).ToList().ForEach(delegate (string line)
               {
                   prg.employees.Add(Employee.FromCsv(line));
               });
            File.ReadAllLines("orders.csv").Skip(1).ToList().ForEach(delegate (string line)
            {
                prg.orders.Add(Orders.FromCsv(line));
            });
            Console.WriteLine("Files Read!");


            // query 1
            var employeeEmails =
                from employee in prg.employees
                select new { employee.Email };

            Console.WriteLine("\nQuery#1");
            foreach (var email in employeeEmails)
            {
                Console.WriteLine(email.Email);
            }

            // query 2
            IEnumerable<Customer> creditLimit = 
                from customer in prg.customers
                where customer.CreditLimit >= 150000.0
                select customer;

            Console.WriteLine("\nQuery#2");
            foreach (Customer customer in creditLimit)
            {
                Console.WriteLine(customer);
            }

            // query 3
            var salesManagers =
                from employee in prg.employees
                join office in prg.offices on employee.OfficeCode equals office.OfficeCode
                where employee.JobTitle.Contains("Sales Manager")
                select office;

            Console.WriteLine("\nQuery#3");
            foreach (var office in salesManagers)
            {
                Console.WriteLine(office);
            }

            // query 4
            var creditLimitGroup =
                from customer in prg.customers
                group customer by customer.CreditLimit >= 100.0;

            Console.WriteLine("\nQuery#4");
            foreach (var customerGroup in creditLimitGroup)
            {
                Console.WriteLine(customerGroup.Key == true ? "Hight Credit Limit" : "Low Credit Limit");
                foreach (var customer in customerGroup)
                {
                    Console.WriteLine("\t" + customer);
                }
            }

            // query 5
            var signalGiftStors =
                from customer in prg.customers
                where customer.CustomerName.Contains("Signal Gift Stores")
                join employee in prg.employees on customer.SalesRepEmployeeNumber equals employee.EmployeeNumber into empGroup
                join order in prg.orders on customer.CustomerNumber equals order.CustomerNumber into orderGroup
                select new
                {
                    Employee = empGroup,
                    Order = orderGroup
                };

            Console.WriteLine("\nQuery#5");
            foreach (var group in signalGiftStors)
            {
                foreach (var employee in group.Employee)
                {
                    foreach (var order in group.Order)
                    {
                        Console.WriteLine($"{employee.LastName} {employee.FirstName} {employee.JobTitle} {employee.Email} {employee.GetOffice(prg).Phone} {order.OrderNumber} {order.OrderDate} {order.ShippedDate} {order.Status}");
                    }
                }
            }


            Console.ReadKey();
        }
    }
}
