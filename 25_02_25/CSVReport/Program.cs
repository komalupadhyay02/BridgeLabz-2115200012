using System;
using System.Data.SqlClient;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Define your connection string (update the database name and credentials)
        string connectionString = "Server=myServerAddress;Database=myDatabase;User Id=myUsername;Password=myPassword;";

        // Define the SQL query to fetch employee records
        string query = "SELECT EmployeeID, Name, Department, Salary FROM Employees";

        // Create a connection to the database
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                // Execute the query and get the data
                SqlDataReader reader = command.ExecuteReader();

                // Create and open the CSV file
                using (StreamWriter writer = new StreamWriter("employee_report.csv"))
                {
                    // Write the CSV header
                    writer.WriteLine("Employee ID, Name, Department, Salary");

                    // Write data rows
                    while (reader.Read())
                    {
                        string employeeId = reader["EmployeeID"].ToString();
                        string name = reader["Name"].ToString();
                        string department = reader["Department"].ToString();
                        string salary = reader["Salary"].ToString();

                        // Write the employee record as a CSV row
                        writer.WriteLine($"{employeeId}, {name}, {department}, {salary}");
                    }
                }

                Console.WriteLine("CSV report generated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
