using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmployeeDomain
{
    class UnitOfWorkObjectContext
    {
        public void DoWork()
        {
            var context = new ObjectContext(_connectionString);

            var firstEmployee =
                context.CreateObjectSet<Employee>()
                    .OrderByDescending(e => e.HireDate)
                    .First();

            firstEmployee.HireDate = firstEmployee.HireDate.AddDays(1);

            var lastEmployee =
                context.CreateObjectSet<Employee>()
                    .OrderBy(e => e.HireDate)
                    .First();

            lastEmployee.Name = "Scott";


            context.SaveChanges();

        }


        #region Details


        private string _connectionString = ConfigurationManager
                    .ConnectionStrings[ConnectionStringName]
                    .ConnectionString;
        const string ConnectionStringName = "EmployeeDataModelContainer";

        #endregion
    }


    class UnitOfWorkDataSet
    {
        public void DoWork()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var adapter = new SqlDataAdapter("SELECT * FROM Employees", connection);
                var employeeTable = new DataTable("Employees");

                adapter.Fill(employeeTable);

                AddEmployee(employeeTable);
                ModifyEmployee(employeeTable);

                adapter.Update(employeeTable);

            }
        }

        private void ModifyEmployee(DataTable employeeTable)
        {
            var firstEmployee = employeeTable.Rows[0];
            firstEmployee["Name"] = "Scott";
        }

        private void AddEmployee(DataTable employeeTable)
        {
            var newEmployee = employeeTable.NewRow();
            newEmployee["Name"] = "Poonam";
            newEmployee["HireDate"] = DateTime.Now;
            employeeTable.Rows.Add(newEmployee);
        }

        #region Details

        private string _connectionString = "server=.;database=pocoEdm;integrated security=true";


        #endregion
    }
}
