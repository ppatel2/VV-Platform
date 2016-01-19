using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using VV.DataObjects;
using System.Data;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.IO;

namespace VV.Web.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private string connectionStr;

        public DataAccess()
        {
            connectionStr = Database.ConnectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionStr);
        }

        public List<UsersDataObject> GetUserList(string filter)
        {

            long number1 = 0;
            bool canConvert = long.TryParse(filter.Trim(), out number1);

            string storProgName = canConvert ? "GetUserListByCard" : "GetUserListByName";
            var users = new List<UsersDataObject>();
            using (SqlConnection connection = this.GetConnection())
            {

                connection.Open();
                using (var command = new SqlCommand(storProgName, connection))
                {
                    //command.CommandText = storProgName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Filter", filter);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int recCount = 0;
                            while (reader.Read() && !reader.IsClosed)
                            {
                                //if (recCount > 1000) break;
                                recCount++;
                                //var user =  GetUserByID(userID);
                                var user = new UsersDataObject();
                                user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                                user.Name = reader.GetString(reader.GetOrdinal("Name"));
                                user.ExternalID = reader.IsDBNull(reader.GetOrdinal("ExternalID")) ? "" : reader.GetString(reader.GetOrdinal("ExternalID"));
                                user.IsActive = reader.IsDBNull(reader.GetOrdinal("IsActive")) ? false : reader.GetBoolean(reader.GetOrdinal("IsActive"));
                                user.FingersCount = reader.IsDBNull(reader.GetOrdinal("Fingers")) ? 0 : reader.GetInt32(reader.GetOrdinal("Fingers"));
                                user.FacesCount = reader.IsDBNull(reader.GetOrdinal("Faces")) ? 0 : reader.GetInt32(reader.GetOrdinal("Faces"));
                                user.CardsCount = reader.IsDBNull(reader.GetOrdinal("Cards")) ? 0 : reader.GetInt32(reader.GetOrdinal("Cards"));
                                users.Add(user);

                            }
                        }
                    }
                }
            }
            return users;
        }

        public UsersDataObject GetUserByID(int userID)
        {
            UsersDataObject user = null;
            using (SqlConnection connection = this.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "GetUserDataByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);
                    user = fillUserDataObj(command);
                }
            }
            return user;
        }

        public UsersDataObject GetUserByExternalID(string externalID)
        {
            UsersDataObject user = null;
            using (SqlConnection connection = this.GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "GetUserByExternalID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ExternalID", externalID);
                    user = fillUserDataObj(command);
                }
            }
            return user;
        }

        private UsersDataObject fillUserDataObj(SqlCommand command)
        {
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0) return null;

            var user = new UsersDataObject();

            DataRow userRow = ds.Tables[0].Rows[0];
            user.Id = Int32.Parse(userRow["Id"].ToString());
            user.ExternalID = userRow["ExternalID"].ToString();
            user.Name = userRow["Name"].ToString();
            user.DevicePassword = userRow["DevicePassword"].ToString();
            user.Password = userRow["Password"].ToString();
            user.ImageData = (byte[])(userRow["UserImage"] == DBNull.Value ? null : userRow["UserImage"]);
            user.IsAdministrator = userRow["IsAdministrator"] == DBNull.Value ? false : Convert.ToBoolean(userRow["IsAdministrator"].ToString());
            user.IsDeviceAdministrator = userRow["IsDeviceAdministrator"] == DBNull.Value ? false : Convert.ToBoolean(userRow["IsDeviceAdministrator"].ToString());
            user.UpdatedAt = userRow["UpdatedAt"] == DBNull.Value ? new DateTime(1970, 1, 1) : Convert.ToDateTime(userRow["UpdatedAt"]);
            user.IsActive = userRow["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(userRow["IsActive"].ToString());
            user.Fingers = new ObservableCollection<FingerDataObject>();

            if (ds.Tables.Count > 1)
            {
                foreach (DataRow fingerRow in ds.Tables[1].Rows)
                {
                    var finger = new FingerDataObject();
                    int fingerInd = Int32.Parse(fingerRow["FingerIndex"].ToString());
                    finger.FingerIndex = FingerDataObject.FingerCodeDescriptions[(FingerDataObject.FingerCode)fingerInd];  // fingerRow["FingerIndex"].ToString();
                    finger.Templates = new ObservableCollection<TemplateObject>();
                    foreach (DataRow templateRow in ds.Tables[2].Rows)
                    {
                        int templateFingerInd = Int32.Parse(templateRow["FingerIndex"].ToString());

                        if (templateFingerInd == fingerInd)
                        {
                            var template = new TemplateObject();
                            template.Id = templateRow["Id"] == DBNull.Value ? 0 : Int32.Parse(templateRow["Id"].ToString());
                            template.QualityScore = Int32.Parse(templateRow["QualityScore"].ToString());
                            template.Checksum = Int64.Parse(templateRow["Checksum"].ToString());
                            template.FingerIndex = templateFingerInd;
                            template.UserID = Int32.Parse(templateRow["UserId"].ToString());
                            template.Data = (byte[])(templateRow["Data"] == DBNull.Value ? null : templateRow["Data"]);
                            template.UpdatedAt = templateRow["UpdatedAt"] == DBNull.Value ? new DateTime(1970, 1, 1) : Convert.ToDateTime(userRow["UpdatedAt"]);

                            finger.Templates.Add(template);
                        }
                    }
                    user.Fingers.Add(finger);
                }
                user.FingersCount = user.Fingers.Count;
            }

            user.Cards = new ObservableCollection<CardDataObject>();
            if (ds.Tables.Count > 3)
            {
                foreach (DataRow cardRow in ds.Tables[3].Rows)
                {
                    var card = new CardDataObject();
                    card.Id = cardRow["Id"].ToString();
                    card.ExternalId = cardRow["ExternalId1"].ToString();
                    card.IsActive = cardRow["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(cardRow["IsActive"].ToString());
                    card.IsBypass = cardRow["IsBypass"] == DBNull.Value ? false : Convert.ToBoolean(cardRow["IsBypass"].ToString());
                    card.BadgeNumber = cardRow["BadgeNumber"].ToString();
                    card.Priority = cardRow["Priority"] == DBNull.Value ? 0 : Int32.Parse(cardRow["Priority"].ToString());
                    card.FacilityCode = cardRow["FacilityCode"] == DBNull.Value ? 0 : Int64.Parse(cardRow["FacilityCode"].ToString());
                    card.PIN = cardRow["PIN"].ToString();
                    user.Cards.Add(card);
                }
                user.CardsCount = user.Cards.Count;
            }

            user.Locations = new ObservableCollection<LocationDataObject>();
            if (ds.Tables.Count > 4)
                foreach (DataRow locationRow in ds.Tables[4].Rows)
                {
                    var location = new LocationDataObject();
                    location.Id = locationRow["Id"].ToString();
                    location.Location = locationRow["Location"].ToString();
                    user.Locations.Add(location);
                }
 

            user.Properties = new ObservableCollection<PropertyDataObject>();
            if (ds.Tables.Count > 5)
                foreach (DataRow propertyRow in ds.Tables[5].Rows)
                {
                    var Property = new PropertyDataObject();
                    Property.ID = propertyRow["User_id"].ToString();
                    Property.Property = new KeyValuePair<string, string>(propertyRow["propertyName"].ToString(), propertyRow["propertyValue"].ToString());
                    user.Properties.Add(Property);
                }

            return user;
        }

        public List<ReadersStubDataObject> GetReadersStubs(string filterStr)
        {
            string strSQL = "Select Id, ReaderName, Location, DefaultReader,Online,DeviceID,IPAddress  from [dbo].BiometricReader";
            if (!string.IsNullOrEmpty(filterStr))
            {
                strSQL += string.Format(@" WHERE ReaderName LIKE '%{0}%' OR Location LIKE '%{0}%'", filterStr.Trim());
            }
            var list = new List<ReadersStubDataObject>();
            using (SqlConnection connection = this.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(strSQL, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int recCount = 0;
                            while (reader.Read() && !reader.IsClosed)
                            {
                                //if (recCount > 1000) break;
                                recCount++;
                                var stub = new ReadersStubDataObject();

                                stub.ID = reader.GetInt32(reader.GetOrdinal("Id"));
                                stub.Name = reader["ReaderName"] == DBNull.Value ? "" : reader["ReaderName"].ToString();
                                stub.Location = reader["Location"] == DBNull.Value ? "" : reader["Location"].ToString();
                                stub.DefaultReader = reader["DefaultReader"] == DBNull.Value ? false : Convert.ToBoolean(reader["DefaultReader"].ToString());
                                //stub.Profile = reader["ProfileCode"] == DBNull.Value ? -1 : Int32.Parse(reader["ProfileCode"].ToString());
                                stub.Online = reader["Online"] == DBNull.Value ? false : Convert.ToBoolean(reader["Online"].ToString());
                                stub.DeviceID = reader["DeviceID"] == DBNull.Value ? 0 : Int64.Parse(reader["DeviceID"].ToString());
                                stub.IPAddress = reader["IPAddress"] == DBNull.Value ? "" : reader["IPAddress"].ToString();


                                list.Add(stub);
                            }
                        }
                    }
                }
            }
            return list;
        }

        public ReadersDataObject GetReaderByID(int readerID)
        {
            ReadersDataObject reader = null;
            int rdrID = readerID;
            using (SqlConnection connection = this.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "GetReaderDetailsByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReaderID", rdrID);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow userRow = ds.Tables[0].Rows[0];
                        reader = getReaderFromRow(userRow);
                    }
                }
            }
            return reader;
        }

        public ReadersDataObject GetReaderDetailsByDeviceID(long readerID)
        {
            ReadersDataObject reader = null;
            long rdrID = readerID;
            using (SqlConnection connection = this.GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "GetReaderDetailsByDeviceID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReaderID", rdrID);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow userRow = ds.Tables[0].Rows[0];
                        reader = getReaderFromRow(userRow);
                    }
                }
            }
            return reader;
        }

        private ReadersDataObject getReaderFromRow(DataRow userRow)
        {
            var reader = new ReadersDataObject();
            reader.ID = userRow["Id"] == DBNull.Value ? 0 : Int32.Parse(userRow["Id"].ToString());
            System.Diagnostics.Trace.WriteLine(System.String.Format("GetReaderFromRow  {0}", reader.ID));

            reader.CardFormatCode = userRow["CardFormatCode"] == DBNull.Value ? 0 : Int32.Parse(userRow["CardFormatCode"].ToString());
            reader.CardOffset = userRow["CardOffset"] == DBNull.Value ? 0 : Int32.Parse(userRow["CardOffset"].ToString());
            reader.CardReadModeCode = userRow["CardReadModeCode"] == DBNull.Value ? 0 : Int32.Parse(userRow["CardReadModeCode"].ToString());
            reader.OperationModeCode = userRow["OperationModeCode"] == DBNull.Value ? 0 : Int32.Parse(userRow["OperationModeCode"].ToString());
            reader.DefaultReader = userRow["DefaultReader"] == DBNull.Value ? false : Convert.ToBoolean(userRow["DefaultReader"].ToString());
            reader.DeviceHandle = userRow["DeviceHandle"] == DBNull.Value ? 0 : Int32.Parse(userRow["DeviceHandle"].ToString());
            reader.DeviceID = userRow["DeviceID"] == DBNull.Value ? 0 : Int64.Parse(userRow["DeviceID"].ToString());
            reader.DHCP = userRow["DHCP"] == DBNull.Value ? false : Convert.ToBoolean(userRow["DHCP"].ToString());
            reader.FacilityCode = userRow["FacilityCode"] == DBNull.Value ? 0 : Int32.Parse(userRow["FacilityCode"].ToString());
            reader.FailCode = userRow["FailCode"] == DBNull.Value ? "" : userRow["FailCode"].ToString();
            reader.FirmwareVersion = userRow["FirmwareVersion"] == DBNull.Value ? "" : userRow["FirmwareVersion"].ToString();
            reader.Gateway = userRow["Gateway"] == DBNull.Value ? "" : userRow["Gateway"].ToString();
            reader.IPAddress = userRow["IPAddress"] == DBNull.Value ? "" : userRow["IPAddress"].ToString();
            reader.KernelVersion = userRow["KernelVersion"] == DBNull.Value ? "" : userRow["KernelVersion"].ToString();
            reader.ProductName = userRow["ProductName"] == DBNull.Value ? "" : userRow["ProductName"].ToString();
            reader.Location = userRow["Location"] == DBNull.Value ? "" : userRow["Location"].ToString();
            reader.Name = userRow["ReaderName"] == DBNull.Value ? "" : userRow["ReaderName"].ToString();
            reader.Online = userRow["Online"] == DBNull.Value ? false : Convert.ToBoolean(userRow["Online"].ToString());
            reader.ProfileCode = userRow["ProfileCode"] == DBNull.Value ? -1 : Int32.Parse(userRow["ProfileCode"].ToString());
            reader.ServerIPAddress = userRow["ServerIPAddress"] == DBNull.Value ? "" : userRow["ServerIPAddress"].ToString();
            reader.ServerPort = userRow["Port"] == DBNull.Value ? 0 : Int32.Parse(userRow["Port"].ToString());
            reader.Subnet = userRow["Subnet"] == DBNull.Value ? "" : userRow["Subnet"].ToString();
            reader.TemplateTypeCode = userRow["TemplateTypeCode"] == DBNull.Value ? 0 : Int32.Parse(userRow["TemplateTypeCode"].ToString());
            reader.TimeSync = userRow["TimeSync"] == DBNull.Value ? false : Convert.ToBoolean(userRow["TimeSync"].ToString());

            reader.LastSync = userRow["LastSync"] == DBNull.Value ? new DateTime(1970, 1, 1) : Convert.ToDateTime(userRow["LastSync"].ToString());
            reader.UpdatedAt = userRow["UpdatedAt"] == DBNull.Value ? new DateTime(1970, 1, 1) : Convert.ToDateTime(userRow["UpdatedAt"].ToString());

            reader.TypeCode = userRow["DeviceType"] == DBNull.Value ? 0 : Int32.Parse(userRow["DeviceType"].ToString());
            reader.UseServerMatching = userRow["UseServerMatching"] == DBNull.Value ? false : Convert.ToBoolean(userRow["UseServerMatching"].ToString());
            reader.UseServerMode = userRow["UseServerMode"] == DBNull.Value ? false : Convert.ToBoolean(userRow["UseServerMode"].ToString());
            reader.WiegandOutputCode = userRow["WiegandOutputCode"] == DBNull.Value ? 0 : Int32.Parse(userRow["WiegandOutputCode"].ToString());
            reader.WiegandPassthrough = userRow["WiegandPassthrough"] == DBNull.Value ? false : Convert.ToBoolean(userRow["WiegandPassthrough"].ToString());
            return reader;
        }

        public int InsertUser(string externalID, string name, bool bDeviceAdministrator)
        {

            using (SqlConnection connection = this.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    int id = -1;
                    command.CommandText = "InsertNewUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ExternalID", externalID);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@CreatedBy", Environment.UserName);
                    command.Parameters.AddWithValue("@IsDeviceAdministrator", bDeviceAdministrator);

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnValue);

                    command.ExecuteNonQuery();

                    id = (int)returnValue.Value;
                    return id;
                }
            }
        }

        public void InsertUserCard(string cardExternalId, string badgeNumber, bool isActive, string PIN,  int userId)
        {
            using (SqlConnection connection = this.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "InsertNewUserCard";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CardExternalId", cardExternalId);
                    command.Parameters.AddWithValue("@BadgeNumber", badgeNumber);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@PIN", PIN);

                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@CreatedBy", Environment.UserName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUserByExternalID(string externalID)
        {
            using (SqlConnection connection = this.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandText = "DeleteUserByExternalID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserExternalID", externalID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(UsersDataObject userDO)
        {
            using (SqlConnection conn = this.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [dbo].[User] SET Name = @Name WHERE ExternalID = @ExternalID";
                    cmd.Parameters.AddWithValue("@Name", userDO.Name);
                    cmd.Parameters.AddWithValue("@ExternalID", userDO.ExternalID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCard(CardDataObject cardDO)
        {
            using (SqlConnection conn = this.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [dbo].[Card] SET BadgeNumber = @BadgeNumber, Priority = @Priority, IsBypass = @IsBypass, IsActive = @IsActive, PIN = @PIN, FacilityCode = @FacilityCode WHERE ExternalID1 = @ExternalID1";
                    cmd.Parameters.AddWithValue("@BadgeNumber", cardDO.BadgeNumber);
                    cmd.Parameters.AddWithValue("@Priority", cardDO.Priority);
                    cmd.Parameters.AddWithValue("@IsBypass", cardDO.IsBypass);
                    cmd.Parameters.AddWithValue("@IsActive", cardDO.IsActive);
                    cmd.Parameters.AddWithValue("@PIN", cardDO.PIN);
                    cmd.Parameters.AddWithValue("@FacilityCode", cardDO.FacilityCode);
                    cmd.Parameters.AddWithValue("@ExternalID1", cardDO.ExternalId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCardByExternalID(string externalID)
        {
            using (SqlConnection connection = this.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandText = "DeleteCardByExternalID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CardExternalID", externalID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Messages> GetMessages(string userName, int limitOfMessages)
        {
            var listOfMessages = new List<Messages>();
            using (SqlConnection connection = this.GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT TOP {0} From, RecievedAt, ";
                    command.Parameters.AddWithValue("@ExternalID", externalID);
                    user = fillUserDataObj(command);
                }
            }
            return user;
        }

        public static string EncryptString(string plainText)
        {
            try
            {
                string initVector;
                string passPhrase;
                string saltValue;
                string hashAlgorithm;
                int keySize;
                int pIter;

                initVector = "1NVY#$ads77epo29";
                passPhrase = "pH7s8a6#&!";
                saltValue = "s*#sfas@1";
                hashAlgorithm = "SHA1";
                keySize = Convert.ToInt32("256");
                pIter = Convert.ToInt32("6");

                if (!string.IsNullOrEmpty(plainText))
                {
                    // Convert strings into byte arrays.
                    // Let us assume that strings only contain ASCII codes.
                    // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
                    // encoding.
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                    // Convert our plaintext into a byte array.
                    // Let us assume that plaintext contains UTF8-encoded characters.
                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                    // First, we must create a password, from which the key will be derived.
                    // This password will be generated from the specified passphrase and 
                    // salt value. The password will be created using the specified hash 
                    // algorithm. Password creation can be done in several iterations.
                    PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                    passPhrase,
                                                                    saltValueBytes,
                                                                    hashAlgorithm,
                                                                    pIter);

                    // Use the password to generate pseudo-random bytes for the encryption
                    // key. Specify the size of the key in bytes (instead of bits).
                    byte[] keyBytes = password.GetBytes(keySize / 8);

                    // Create uninitialized Rijndael encryption object.
                    RijndaelManaged symmetricKey = new RijndaelManaged();

                    // It is reasonable to set encryption mode to Cipher Block Chaining
                    // (CBC). Use default options for other symmetric key parameters.
                    symmetricKey.Mode = CipherMode.CBC;

                    // Generate encryptor from the existing key bytes and initialization 
                    // vector. Key size will be defined based on the number of the key 
                    // bytes.
                    ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                                     keyBytes,
                                                                     initVectorBytes);

                    // Define memory stream which will be used to hold encrypted data.
                    MemoryStream memoryStream = new MemoryStream();

                    // Define cryptographic stream (always use Write mode for encryption).
                    CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                                 encryptor,
                                                                 CryptoStreamMode.Write);
                    // Start encrypting.
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                    // Finish encrypting.
                    cryptoStream.FlushFinalBlock();

                    // Convert our encrypted data from a memory stream into a byte array.
                    byte[] cipherTextBytes = memoryStream.ToArray();

                    // Close both streams.
                    memoryStream.Close();
                    cryptoStream.Close();

                    // Convert encrypted data into a base64-encoded string.
                    string cipherText = Convert.ToBase64String(cipherTextBytes);

                    // Return encrypted string.
                    return cipherText;
                }

            }//return plainText + "THIS";
#pragma warning disable 0168 // variable declared but not used
            catch (Exception e)
#pragma warning restore 0168 // variable declared but not used
            {
                return plainText;
            }
            return plainText;
        }
    }
}
