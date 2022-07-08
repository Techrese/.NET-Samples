using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class Adapter : ITarget
    {
        private readonly ThirdPartyBillingSystem _billingSystem = new();

        public void processCompanySalary(string[,] employeesArray)
        {
            List<Employee> employees = new List<Employee>();

            string id = string.Empty;
            string name = string.Empty;
            string salary = string.Empty;


            for (int i = 0; i < employeesArray.GetLength(0); i++)
            {
                Employee employee = new();

                for (int j = 0; j < employeesArray.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        employee.Id = Guid.Parse(employeesArray[i, j]);
                    }
                    else if (j == 1)
                    {
                        employee.Name = employeesArray[i, j];
                    }
                    else if (j == 2)
                    {
                        employee.Salary = Convert.ToDecimal(employeesArray[i, j]);
                    }                   
                }

                employees.Add(employee);
            }

            _billingSystem.ProcessSalary(employees);
        }
    }
}
