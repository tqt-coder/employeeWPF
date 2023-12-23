using Microsoft.Data.SqlClient;
using ManageEmployee.DTO;
using ManageEmployee.BUS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace ManageEmployee.DAO
{
    internal class EmployeeDAO
    {
        DatabaseUtilitites db = DatabaseUtilitites.getInstance();
        public ObservableCollection<EmployeeDTO> getAll()
        {
            ObservableCollection<EmployeeDTO> list = new ObservableCollection<EmployeeDTO>();
            string sql = "SELECT EmployeeID, FullName ,Email ,Address ,TelephoneNumber ,AvatarImage FROM Employee limit 10";
            var command = new SqlCommand(sql, db.connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                EmployeeDTO em = new EmployeeDTO();
                em.FullName = (string?)reader["FullName"];
                em.Email = (string?)reader["Email"];
                em.Address = (string?)reader["Address"];
                em.TelephoneNumber = (string?)reader["TelephoneNumber"];
                em.AvatarImage = (string?)reader["AvatarImage"];
                em.EmployeeID = (int)reader["EmployeeID"];
                list.Add(em);
            }

            reader.Close();

            return list;
        }

        public void deleteEmployeeById(int EmployeeID)
        {
            string sql = $"""
                DELETE FROM Employee
                WHERE EmployeeID = {EmployeeID};
                """;

            var command = new SqlCommand(sql, db.connection);

            command.ExecuteNonQuery();
        }

        // insert và trả ra id
        public int insertEmployee(EmployeeDTO employeeDTO)
        {
            // insert SQL
            string sql = "insert into Employee(FullName ,Email ,Address ,TelephoneNumber ,AvatarImage)" +
            "values(@FullName, @Email, @Address, @TelephoneNumber, @AvatarImage)";
            var command = new SqlCommand(sql, db.connection);

            command.Parameters.Add("@FullName", SqlDbType.VarChar).Value = employeeDTO.FullName;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = employeeDTO.Email;
            command.Parameters.Add("@Address", SqlDbType.VarChar).Value = employeeDTO.Address;
            command.Parameters.Add("@TelephoneNumber", SqlDbType.VarChar).Value = employeeDTO.TelephoneNumber;
            command.Parameters.Add("@AvatarImage", SqlDbType.VarChar).Value = employeeDTO.AvatarImage;

            command.ExecuteNonQuery();

            // select SQL
            int id = -1;
            string sql1 = "SELECT TOP 1 EmployeeID FROM Employee ORDER BY EmployeeID DESC ";

            var command1 = new SqlCommand(sql1, db.connection);

            var reader = command1.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["EmployeeID"];
            }

            reader.Close();

            return id;
        }

        public void updateEmployee(EmployeeDTO employeeDTO)
        {
            string sql = "update Employee " +
                "set FullName =  @FullName, Email = @Email, Address = @Address, TelephoneNumber = @TelephoneNumber, AvatarImage = @AvatarImage" +
                "where EmployeeID = @EmployeeID";
            var command = new SqlCommand(sql, db.connection);

            command.Parameters.Add("@FullName", SqlDbType.VarChar).Value = employeeDTO.FullName;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = employeeDTO.Email;
            command.Parameters.Add("@Address", SqlDbType.VarChar).Value = employeeDTO.Address;
            command.Parameters.Add("@TelephoneNumber", SqlDbType.VarChar).Value = employeeDTO.TelephoneNumber;
            command.Parameters.Add("@AvatarImage", SqlDbType.VarChar).Value = employeeDTO.AvatarImage;
            command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employeeDTO.EmployeeID;

            command.ExecuteNonQuery();
        }
        

        public EmployeeDTO getEmployeeById(int id) 
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            EmployeeDTO result = new EmployeeDTO();

            string sql = "EmployeeID, FullName, Email, Address, TelephoneNumber, AvatarImage FROM Employee" +
                "where EmployeeID = @id";

            var command = new SqlCommand(sql, db.connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                EmployeeDTO em = new EmployeeDTO();
                em.FullName = (string?)reader["FullName"];
                em.Email = (string?)reader["Email"];
                em.Address = (string?)reader["Address"];
                em.TelephoneNumber = (string?)reader["TelephoneNumber"];
                em.AvatarImage = (string?)reader["AvatarImage"];
                em.EmployeeID = (int)reader["EmployeeID"];

                list.Add(em);
            }

            reader.Close();
            result = list[0];

            return result;
        }
    }
}
