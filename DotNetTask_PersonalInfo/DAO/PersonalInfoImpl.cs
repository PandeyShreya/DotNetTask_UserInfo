using DotNetTask_PersonalInfo.Models;
using Npgsql;
using System.Data;

namespace DotNetTask_PersonalInfo.DAO
{
    public class PersonalInfoImpl : IPersonalinfo
    {
        NpgsqlConnection _conn;

        public PersonalInfoImpl(NpgsqlConnection conn)
        {
            _conn = conn;
        }
        public async Task<int> DeleteInfo(int id)
        {
            int rowaffected = 0;
            string deleteQuery = $"delete from personalinfo.personalinfo where id={id}";
            try
            {
                using (_conn)
                {
                    await _conn.OpenAsync();
                    NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, _conn);
                    deleteCommand.CommandType = CommandType.Text;
                    rowaffected = await deleteCommand.ExecuteNonQueryAsync();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);

            }
            return rowaffected;
     }

        public async Task<PersonalInformation> GetInsertInfo(int id)
        {
            PersonalInformation info = new PersonalInformation();
            string errorMsg = string.Empty;
            string query = $@"select * from personalinfo.personalinfo where id={id}";

            try
            {
                using (_conn)
                {
                    await _conn.OpenAsync();
                    NpgsqlCommand selectCommand = new NpgsqlCommand(query, _conn);
                    selectCommand.CommandType = System.Data.CommandType.Text;
                    selectCommand.Parameters.AddWithValue("id");
                    NpgsqlDataReader reader = await selectCommand.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            info.Id = reader.GetInt32(0);
                            info.Name = reader.GetString(1);
                            info.DateOfBirth = reader.GetDateTime(2);
                            info.ResidentialAddress = reader.GetString(3);
                            info.PermanentAddress = reader.GetString(4);
                            info.PhoneNumber = reader.GetString(5);
                            info.EmailAddress = reader.GetString(6);
                            info.MaritalStatus = reader.GetString(7);
                            info.Gender = reader.GetString(8);
                            info.Occupation = reader.GetString(9);
                            info.AadharCardNumber = reader.GetString(10);
                            info.PanNumber = reader.GetString(11);

                        }
                    }
                    reader?.Close();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return info;
        }

        public async Task<List<PersonalInformation>> GetPersonalInfo()
        {
            List<PersonalInformation> infoList = new List<PersonalInformation>();
            string errorMsg = string.Empty;
            string query = @"select * from personalinfo.personalinfo";

            try
            {
                using (_conn)
                {
                    await _conn.OpenAsync();
                    NpgsqlCommand selectCommand = new NpgsqlCommand(query, _conn);
                    selectCommand.CommandType = System.Data.CommandType.Text;
                    NpgsqlDataReader reader = await selectCommand.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PersonalInformation info = new PersonalInformation();
                            info.Id = reader.GetInt32(0);
                            info.Name = reader.GetString(1);
                            info.DateOfBirth = reader.GetDateTime(2);
                            info.ResidentialAddress = reader.GetString(3);
                            info.PermanentAddress = reader.GetString(4);
                            info.PhoneNumber = reader.GetString(5);
                            info.EmailAddress = reader.GetString(6);
                            info.MaritalStatus = reader.GetString(7);
                            info.Gender = reader.GetString(8);
                            info.Occupation = reader.GetString(9);
                            info.AadharCardNumber = reader.GetString(10);
                            info.PanNumber = reader.GetString(11);
                            infoList.Add(info);
                        }
                    }
                    reader?.Close();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return infoList;
        }

        public async Task<int> InsertInfo(PersonalInformation info)
        {
            int rowInserted = 0;
            string insertQuery = @"
        INSERT INTO personalinfo.personalinfo (
           name, dob, raddress, paddress, phone_number, email, marital_status, gender, occupation, aadhar_number, pan_number
        ) VALUES (
            @Name, @Dob, @RAddress, @PAddress, @PhoneNumber, @Email, @MaritalStatus, @Gender, @Occupation, @AadharNumber, @PanNumber
        );";

            try
            {
                using (_conn)
                {
                    await _conn.OpenAsync();
                    NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, _conn);
                    insertCommand.CommandType = CommandType.Text;
                    insertCommand.Parameters.AddWithValue("@Name", info.Name);
                    insertCommand.Parameters.AddWithValue("@Dob", info.DateOfBirth);
                    insertCommand.Parameters.AddWithValue("@RAddress", info.ResidentialAddress);
                    insertCommand.Parameters.AddWithValue("@PAddress", info.PermanentAddress);
                    insertCommand.Parameters.AddWithValue("@PhoneNumber", info.PhoneNumber);
                    insertCommand.Parameters.AddWithValue("@Email", info.EmailAddress);
                    insertCommand.Parameters.AddWithValue("@MaritalStatus", info.MaritalStatus);
                    insertCommand.Parameters.AddWithValue("@Gender", info.Gender);
                    insertCommand.Parameters.AddWithValue("@Occupation", info.Occupation);
                    insertCommand.Parameters.AddWithValue("@AadharNumber", info.AadharCardNumber);
                    insertCommand.Parameters.AddWithValue("@PanNumber", info.PanNumber);
                    rowInserted = await insertCommand.ExecuteNonQueryAsync();

                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return rowInserted;
        }


        public async Task<int> UpdateInfo(int id, string name)
        {
            int rowUpdated = 0;
            string updateQuery = $@"update personalinfo.personalinfo set name='{name}' where id={id}";
            try
            {
                using (_conn)
                {
                    await _conn.OpenAsync();
                    NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, _conn);
                    updateCommand.CommandType = CommandType.Text;
                    rowUpdated = await updateCommand.ExecuteNonQueryAsync();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return rowUpdated;
        }
    }
}
