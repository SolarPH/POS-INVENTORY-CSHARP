using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DesktopApp.Functions;

namespace DesktopApp.DatabaseManager
{
    
    class MainDatabase
    {
        SqlConnection con = new SqlConnection();
        public void InitDatabase()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            hasUserData(con);
            clearCurrentSalesPerson(con);
            con.Close();
            con.Dispose();
        }

        public void InteractDB_hasUserData()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            hasUserData(con);
            con.Close();
            con.Dispose();
        }

        public int InteractDB_getUserLevel(string username, string password)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            int res = getUserLevel(con,username,password);
            con.Close();
            con.Dispose();
            return res;
        }

        public string InteractDB_getCurrentSalesPerson()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            string res = getCurrentSalesPerson(con);
            con.Close();
            con.Dispose();
            return res;
        }

        public void InteractDB_addAccount(string username, string password, int userLevel, string fullname)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            addAccount(con,username,password,userLevel,fullname);
            con.Close();
            con.Dispose();
        }

        public void InteractDB_setCurrentSalesPerson(string username, string password)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            setCurrentSalesPerson(con, username, password);
            con.Close();
            con.Dispose();
        }

        public void InteractDB_clearCurrentSalesPerson()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            clearCurrentSalesPerson(con);
            con.Close();
            con.Dispose();
        }

        public Boolean InteractDB_doesCredentialsExist(string username)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            Boolean res = doesCredentialsExist(con, username);
            con.Close();
            con.Dispose();
            return res;
        }

        public Boolean InteractDB_isCredentialsMatch(string username, string password)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            Boolean res = isCredentialsMatch(con,username,password);
            con.Close();
            con.Dispose();
            return res;
        }

        public string[] InteractDB_DisplayUpdate(int ID)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            string[] res = DisplayUpdate(con,ID);
            con.Close();
            con.Dispose();
            return res;
        }

        public void InteractDB_InsertEntry(int ID, string Name, double Price, int quantity)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            InsertEntry(con,ID,Name,Price,quantity);
            con.Close();
            con.Dispose();
        }

        public void InteractDB_ManageStocks(int ID, string Name, double price, int quantity, string command)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            UpdateStocks(con,ID,Name,price,quantity,command);
            con.Close();
            con.Dispose();
        }

        public string[][] InteractDB_SearchProduct(string searchText, string searchMode)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            string[][] res = SearchProduct(con, searchText,searchMode);
            con.Close();
            con.Dispose();
            return res;
        }

        public Boolean InteractDB_CheckMatch(int ID)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            Boolean result = CheckMatch(con, ID);
            con.Close();
            con.Dispose();
            return result;
        }

        public void InteractDB_logSales(int ID, string Name, int quantity, double priceTotal, string ORNO)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            logSales(con, ID, Name, quantity, priceTotal, ORNO);
            con.Close();
            con.Dispose();
        }

        public void InteractDB_InsertDiscVat(string Name, double percentage, int active, int alwaysActive, string type)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            int ID = generateDiscVatID(con);
            InsertDiscVat(con, ID, Name, percentage, active, alwaysActive, type);
            con.Close();
            con.Dispose();
        }

        public string[][] InteractDB_AllDiscVat()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            string[][] res = AllDiscVat(con);
            con.Close();
            con.Dispose();
            return res;
        }

        public Boolean InteractDB_DiscVatMatchedName(string name)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            Boolean res = DiscVatMatchedName(con,name);
            con.Close();
            con.Dispose();
            return res;
        }

        public void InteractDB_UpdateDiscVat(int ID, string Name, double percentage, int active, int alwaysActive, string type)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            UpdateDiscVat(con, ID,Name,percentage,active,alwaysActive,type);
            con.Close();
            con.Dispose();
        }

        public Boolean InteractDB_VatExist()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            Boolean res = VatExist(con);
            con.Close();
            con.Dispose();
            return res;
        }

        public void InteractDB_setStatusDiscVat(string Name, int status)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            setStatusDiscVat(con, Name, status);
            con.Close();
            con.Dispose();
        }

        public string[][] InteractDB_InactiveDisc()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            string[][] res = InactiveDisc(con);
            con.Close();
            con.Dispose();
            return res;
        }

        public string[][] InteractDB_ActiveDisc()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            string[][] res = ActiveDisc(con);
            con.Close();
            con.Dispose();
            return res;
        }

        public void InteractDB_resetDiscStat()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            resetDiscStat(con);
            con.Close();
            con.Dispose();
        }

        public string[] InteractDB_GetVat()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            string[] res = GetVat(con);
            con.Close();
            con.Dispose();
            return res;
        }

        // PRIVATE
        private string[] DisplayUpdate(SqlConnection con, int ID)
        {
            SqlCommand com = new SqlCommand("SELECT ID,Name,Price FROM TABLE_PRODUCTS WHERE ID = " + Convert.ToString(ID), con);
            SqlDataReader reader = com.ExecuteReader();
            string ID_S = "", Name_S = "", Quan_S = "";
            while (reader.Read())
            {
                ID_S = Convert.ToString(reader[0]);
                Name_S = Convert.ToString(reader[1]);
                Quan_S = Convert.ToString(reader[2]);
            }
            reader.Close();
            SqlCommand com2 = new SqlCommand("SELECT ID,Available,Returned,Rejected,Sold FROM TABLE_STOCKS WHERE ID = " + Convert.ToString(ID), con);
            SqlDataReader reader2 = com2.ExecuteReader();
            string S_A = "", S_B = "", S_C = "", S_D = "";
            while (reader2.Read())
            {
                S_A = Convert.ToString(reader2[1]);
                S_B = Convert.ToString(reader2[2]);
                S_C = Convert.ToString(reader2[3]);
                S_D = Convert.ToString(reader2[4]);
            }
            reader2.Close();
            return new string[] {ID_S,Name_S,Quan_S,S_A,S_B,S_C,S_D};
        }

        private string[][] SearchProduct(SqlConnection con, string searchText, string searchMode)
        {
            int ID = 0;
            string Name = "";
            int searchModeIndex = 0;

            if (searchMode == "ID")
            {
                if (searchText != "")
                {
                    ID = Convert.ToInt32(searchText);
                    searchModeIndex = 1;
                }
            }
            else if (searchMode == "NAME")
            {
                if (searchText != "")
                {
                    Name = searchText;
                    searchModeIndex = 2;
                }
            }
            string CommandString = "";
            switch (searchModeIndex)
            {
                case 0:
                    CommandString = "SELECT * FROM TABLE_PRODUCTS";
                    break;
                case 1:
                    CommandString = "SELECT * FROM TABLE_PRODUCTS WHERE CAST(ID as VARCHAR) LIKE '%" + Convert.ToString(ID) + "%'";
                    break;
                case 2:
                    CommandString = "SELECT * FROM TABLE_PRODUCTS WHERE NAME LIKE '%" + Name + "%'";
                    break;
            }
            SqlCommand com = new SqlCommand(CommandString, con);
            SqlDataReader reader = com.ExecuteReader();
            int rows = 0;
            while (reader.Read())
            {
                rows++;
            }
            reader.Close();
            string[][] allres = new string[rows][];
            SqlDataReader reader2 = com.ExecuteReader();
            int readerIndex = 0;
            while (reader2.Read())
            {
                string[] subres = new string[4];
                subres[0] = Convert.ToString(reader2[0]);
                subres[1] = Convert.ToString(reader2[1]);
                subres[2] = Convert.ToString(reader2[2]);
                subres[3] = Convert.ToString(reader2[3]);
                allres[readerIndex] = subres;
                readerIndex++;
            }
            reader2.Close();
            return allres;
        }
        
        private Boolean CheckMatch(SqlConnection con, int ID)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_PRODUCTS WHERE ID = " + Convert.ToString(ID), con);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        private void UpdateStocks(SqlConnection con, int ID, string Name, double Price, int quantity, string command)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_PRODUCTS WHERE ID = " + Convert.ToString(ID), con);
            SqlCommand com2 = new SqlCommand("SELECT * FROM TABLE_STOCKS WHERE ID = " + Convert.ToString(ID), con);
            SqlDataReader reader = com.ExecuteReader();
            /*
             * Indexes:
             * 0 - ID - int
             * 1 - Name - string
             * 2 - Price - double
             * 3 - Quantity - int
             */
            string A1 = "";
            double A2 = 0.00;
            int A3 = 0;
            if (reader.Read())
            {
                A1 = Convert.ToString(reader[1]);
                A2 = Convert.ToDouble(reader[2]);
                A3 = Convert.ToInt32(reader[3]);
            }
            reader.Close();

            SqlDataReader reader2 = com2.ExecuteReader();
            /*
             * Indexes:
             * 0 - ID - int
             * 1 - Available - int
             * 2 - Sold - int
             * 3 - Returned - int
             * 4 - Rejected - int
             */
            int B1 = 0, B2 = 0, B3 = 0, B4 = 0;
            if (reader2.Read())
            {
                B1 = Convert.ToInt32(reader2[1]);
                B2 = Convert.ToInt32(reader2[2]);
                B3 = Convert.ToInt32(reader2[3]);
                B4 = Convert.ToInt32(reader2[4]);
            }
            reader2.Close();

            string newA1 = "";
            double newA2 = 0.00;
            int newA3 = 0;

            int newB1 = 0, newB2 = 0, newB3 = 0, newB4 = 0;

            switch (command)
            {
                case "UPDATE":
                    newA1 = Name;
                    newA2 = Price;
                    newA3 = A3;
                    newB1 = B1;
                    newB2 = B2;
                    newB3 = B3;
                    newB4 = B4;
                    break;
                case "ADD":
                    newA1 = A1;
                    newA2 = A2;
                    newA3 = A3 + quantity;
                    newB1 = B1 + quantity;
                    newB2 = B2;
                    newB3 = B3;
                    newB4 = B4;
                    break;
                case "RETURN":
                    newA1 = A1;
                    newA2 = A2;
                    newA3 = A3 - quantity;
                    newB1 = B1 - quantity;
                    newB2 = B2;
                    newB3 = B3 + quantity;
                    newB4 = B4;
                    break;
                case "REJECT":
                    newA1 = A1;
                    newA2 = A2;
                    newA3 = A3 - quantity;
                    newB1 = B1 - quantity;
                    newB2 = B2;
                    newB3 = B3;
                    newB4 = B4 + quantity;
                    break;
                case "SOLD":
                    newA1 = A1;
                    newA2 = A2;
                    newA3 = A3 - quantity;
                    newB1 = B1 - quantity;
                    newB2 = B2 + quantity;
                    newB3 = B3;
                    newB4 = B4;
                    break;
                default:
                    break;
            }

            SqlCommand update = new SqlCommand("UPDATE TABLE_PRODUCTS SET " +
                "Name = '" + newA1 + "', " +
                "Price = " + String.Format("{0:0.00}",newA2) + ", " +
                "Quantity = " + Convert.ToString(newA3) +
                " WHERE ID = " + Convert.ToString(ID), con);
            update.ExecuteNonQuery();
            SqlCommand update2 = new SqlCommand("UPDATE TABLE_STOCKS SET " +
                "Available = " + Convert.ToString(newB1) + ", " +
                "Sold = " + Convert.ToString(newB2) + ", " +
                "Returned = " + Convert.ToString(newB3) + ", " +
                "Rejected = " + Convert.ToString(newB4) +
                " WHERE ID = " + Convert.ToString(ID), con);
            update2.ExecuteNonQuery();
        }

        private void InsertEntry(SqlConnection con, int ID,string Name,double Price,int quantity)
        {
            SqlCommand com = new SqlCommand("INSERT INTO TABLE_PRODUCTS(ID,Name,Price,Quantity) VALUES (@ID,@Name,@Price,@Quan)", con);
            com.Parameters.Add(new SqlParameter("ID", ID));
            com.Parameters.Add(new SqlParameter("Name", Name));
            com.Parameters.Add(new SqlParameter("Price", Price));
            com.Parameters.Add(new SqlParameter("Quan", quantity));
            com.ExecuteNonQuery();
            SqlCommand com2 = new SqlCommand("INSERT INTO TABLE_STOCKS(ID,Available,Sold,Returned,Rejected) VALUES (@ID,@Available,0,0,0)", con);
            com2.Parameters.Add(new SqlParameter("ID", ID));
            com2.Parameters.Add(new SqlParameter("Available", quantity));
            com2.ExecuteNonQuery();
        }

        private void hasUserData(SqlConnection con)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_USERDATA", con);
            SqlDataReader reader = com.ExecuteReader();
            Boolean rows = reader.HasRows;
            reader.Close();
            if (rows == false)
            {
                int defaultStat = 0;
                int adminUL = 4;
                string passEncoded = new PassHash().PassHashResult("admin");
                SqlCommand adminAdd = new SqlCommand("INSERT INTO TABLE_USERDATA(USERNAME,PASSWORD,FULLNAME,USERLEVEL,ACTIVE) VALUES (@UN,@PASS,@FN,@UL,@STAT)", con);
                adminAdd.Parameters.Add("UN", "admin");
                adminAdd.Parameters.Add("PASS", passEncoded);
                adminAdd.Parameters.Add("FN","Administrator");
                adminAdd.Parameters.Add("UL", adminUL);
                adminAdd.Parameters.Add("STAT", defaultStat);
                adminAdd.ExecuteNonQuery();
            }
        }

        private string getCurrentSalesPerson(SqlConnection con)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_USERDATA WHERE ACTIVE = 1", con);
            SqlDataReader reader = com.ExecuteReader();
            string FullName = "";
            while (reader.Read())
            {
                FullName = reader[2].ToString();
            }
            reader.Close();
            
            return FullName;
        }

        private Boolean isCredentialsMatch(SqlConnection con, string username, string password)
        {
            Boolean res = false;
            string passHashed = new PassHash().PassHashResult(password);
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_USERDATA WHERE USERNAME = @UN AND PASSWORD = @PWH",con);
            com.Parameters.Add("UN",username);
            com.Parameters.Add("PWH", passHashed);
            SqlDataReader reader = com.ExecuteReader();
            res = reader.HasRows;
            reader.Close();
            return res;

        }

        private int getUserLevel(SqlConnection con, string username, string password)
        {
            int UL = 0;
            string passHashed = new PassHash().PassHashResult(password);
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_USERDATA WHERE USERNAME = @UN AND PASSWORD = @PWH", con);
            com.Parameters.Add("UN", username);
            com.Parameters.Add("PWH", passHashed);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                UL = Convert.ToInt32(reader[3]);
            }
            reader.Close();
            return UL;
        }

        private void addAccount(SqlConnection con, string username, string password, int userLevel, string fullname)
        {
            string passEncoded = new PassHash().PassHashResult(password);
            int defaultStat = 0;
            SqlCommand adminAdd = new SqlCommand("INSERT INTO TABLE_USERDATA(USERNAME,PASSWORD,FULLNAME,USERLEVEL,ACTIVE) VALUES (@UN,@PASS,@FN,@UL,@STAT)", con);
            adminAdd.Parameters.Add("UN", username);
            adminAdd.Parameters.Add("PASS", passEncoded);
            adminAdd.Parameters.Add("FN", fullname);
            adminAdd.Parameters.Add("UL", userLevel);
            adminAdd.Parameters.Add("STAT", defaultStat);
            adminAdd.ExecuteNonQuery();
        }

        private Boolean doesCredentialsExist(SqlConnection con, string username)
        {
            Boolean res = false;
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_USERDATA WHERE USERNAME = @UN", con);
            com.Parameters.Add("UN", username);
            SqlDataReader reader = com.ExecuteReader();
            res = reader.HasRows;
            reader.Close();
            return res;
        }

        private void setCurrentSalesPerson(SqlConnection con, string username, string password)
        {
            string passHashed = new PassHash().PassHashResult(password);
            SqlCommand com = new SqlCommand("UPDATE TABLE_USERDATA SET ACTIVE = 1 WHERE USERNAME = @UN AND PASSWORD = @PWH", con);
            com.Parameters.Add("UN", username);
            com.Parameters.Add("PWH", passHashed);
            com.ExecuteNonQuery();
        }

        private void clearCurrentSalesPerson(SqlConnection con)
        {
            SqlCommand com = new SqlCommand("UPDATE TABLE_USERDATA SET ACTIVE = 0 WHERE ACTIVE = 1", con);
            com.ExecuteNonQuery();
        }

        private void logSales(SqlConnection con, int ID, string Name, int quantity, double priceTotal, string ORNO)
        {
            DateTime saletimeParsed = new ORNOGEN().ORNOstringToDT(ORNO);
            string Salesperson = getCurrentSalesPerson(con);

            SqlCommand com = new SqlCommand("INSERT INTO TABLE_SALES(ORnumber,ID,Name,Sold,TotalSales,Salesperson,SaleTime) VALUES (@ORN,@ID,@Name,@Sold,@TotalSales,@SalesPerson,@SaleTime)", con);
            com.Parameters.Add(new SqlParameter("ORN", ORNO));
            com.Parameters.Add(new SqlParameter("ID", ID));
            com.Parameters.Add(new SqlParameter("Name", Name));
            com.Parameters.Add(new SqlParameter("Sold", quantity));
            com.Parameters.Add(new SqlParameter("TotalSales", priceTotal));
            com.Parameters.Add(new SqlParameter("Salesperson", Salesperson));
            com.Parameters.Add(new SqlParameter("SaleTime", saletimeParsed));
            com.ExecuteNonQuery();
        }
        
        private void InsertDiscVat(SqlConnection con, int ID, string Name, double percentage, int active, int alwaysActive, string type)
        {
            SqlCommand com = new SqlCommand("INSERT INTO TABLE_DISCVAT(ID,Name,Percentage,Active,AlwaysActive,Type) VALUES (@ID,@Name,@Percentage,@Active,@AlwaysActive,@Type)", con);
            com.Parameters.Add(new SqlParameter("ID", ID));
            com.Parameters.Add(new SqlParameter("Name", Name));
            com.Parameters.Add(new SqlParameter("Percentage", percentage));
            com.Parameters.Add(new SqlParameter("Active", active));
            com.Parameters.Add(new SqlParameter("AlwaysActive", alwaysActive));
            com.Parameters.Add(new SqlParameter("Type",type));
            com.ExecuteNonQuery();
        }

        private string[][] InactiveDisc(SqlConnection con)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_DISCVAT WHERE Active = 0 AND Type = @Type", con);
            com.Parameters.Add(new SqlParameter("Type", "DISC"));
            SqlDataReader reader = com.ExecuteReader();
            int rows = 0;
            while (reader.Read())
            {
                rows++;
            }
            reader.Close();
            string[][] allres = new string[rows][];
            SqlDataReader reader2 = com.ExecuteReader();
            int readerIndex = 0;
            while (reader2.Read())
            {
                string[] subres = new string[6];
                subres[0] = Convert.ToString(reader2[0]);
                subres[1] = Convert.ToString(reader2[1]);
                subres[2] = Convert.ToString(reader2[2]);
                subres[3] = Convert.ToString(reader2[3]);
                subres[4] = Convert.ToString(reader2[4]);
                subres[5] = Convert.ToString(reader2[5]);
                allres[readerIndex] = subres;
                readerIndex++;
            }
            reader2.Close();
            return allres;
        }

        private string[][] ActiveDisc(SqlConnection con)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_DISCVAT WHERE Active = 1 AND Type = @Type", con);
            com.Parameters.Add(new SqlParameter("Type", "DISC"));
            SqlDataReader reader = com.ExecuteReader();
            int rows = 0;
            while (reader.Read())
            {
                rows++;
            }
            reader.Close();
            string[][] allres = new string[rows][];
            SqlDataReader reader2 = com.ExecuteReader();
            int readerIndex = 0;
            while (reader2.Read())
            {
                string[] subres = new string[6];
                subres[0] = Convert.ToString(reader2[0]);
                subres[1] = Convert.ToString(reader2[1]);
                subres[2] = Convert.ToString(reader2[2]);
                subres[3] = Convert.ToString(reader2[3]);
                subres[4] = Convert.ToString(reader2[4]);
                subres[5] = Convert.ToString(reader2[5]);
                allres[readerIndex] = subres;
                readerIndex++;
            }
            reader2.Close();
            return allres;
        }

        private void resetDiscStat(SqlConnection con)
        {
            SqlCommand com = new SqlCommand("UPDATE TABLE_DISCVAT SET Active = 0 WHERE AlwaysActive = 0", con);
            com.ExecuteNonQuery();
        }

        private string[][] AllDiscVat(SqlConnection con)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_DISCVAT", con);
            SqlDataReader reader = com.ExecuteReader();
            int rows = 0;
            while (reader.Read())
            {
                rows++;
            }
            reader.Close();
            string[][] allres = new string[rows][];
            SqlDataReader reader2 = com.ExecuteReader();
            int readerIndex = 0;
            while (reader2.Read())
            {
                string[] subres = new string[6];
                subres[0] = Convert.ToString(reader2[0]);
                subres[1] = Convert.ToString(reader2[1]);
                subres[2] = Convert.ToString(reader2[2]);
                subres[3] = Convert.ToString(reader2[3]);
                subres[4] = Convert.ToString(reader2[4]);
                subres[5] = Convert.ToString(reader2[5]);
                allres[readerIndex] = subres;
                readerIndex++;
            }
            reader2.Close();
            return allres;
        }

        private Boolean DiscVatMatchedName(SqlConnection con, string name)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_DISCVAT WHERE Name = @Name", con);
            com.Parameters.Add(new SqlParameter("Name",name));
            SqlDataReader reader = com.ExecuteReader();
            Boolean hasRows = reader.HasRows;
            reader.Close();
            return hasRows;
        }

        private Boolean VatExist(SqlConnection con)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM TABLE_DISCVAT WHERE Type = @Type", con);
            com.Parameters.Add(new SqlParameter("Type","VAT"));
            SqlDataReader reader = com.ExecuteReader();
            Boolean hasRows = reader.HasRows;
            reader.Close();
            return hasRows;
        }

        private string[] GetVat(SqlConnection con)
        {
            SqlCommand com = new SqlCommand("SELECT ID,Name,Percentage FROM TABLE_DISCVAT WHERE Type = @Type", con);
            com.Parameters.Add(new SqlParameter("Type", "VAT"));
            SqlDataReader reader = com.ExecuteReader();
            string ID = "";
            string name = "";
            string percentage = "0";
            while (reader.Read())
            {
                ID = Convert.ToString(reader[0]);
                name = Convert.ToString(reader[1]) + " (LESS) ";
                percentage = Convert.ToString(reader[2]);
            }
            string[] res = {ID,name,percentage};
            reader.Close();
            return res;
        }

        private void setStatusDiscVat(SqlConnection con, string Name, int status)
        {
            SqlCommand com = new SqlCommand("UPDATE TABLE_DISCVAT SET Active = @Status WHERE Name = @Name", con);
            com.Parameters.Add(new SqlParameter("Name",Name));
            com.Parameters.Add(new SqlParameter("Status",status));
            com.ExecuteNonQuery();
        }

        private void UpdateDiscVat(SqlConnection con, int ID, string Name, double percentage, int active, int alwaysActive, string type)
        {
            SqlCommand com = new SqlCommand("UPDATE TABLE_DISCVAT SET Name = @Name, Percentage = @Percentage, Active = @Active, AlwaysActive = @AlwaysActive, Type = @Type WHERE ID = @ID", con);
            com.Parameters.Add(new SqlParameter("ID", ID));
            com.Parameters.Add(new SqlParameter("Name", Name));
            com.Parameters.Add(new SqlParameter("Percentage", percentage));
            com.Parameters.Add(new SqlParameter("Active", active));
            com.Parameters.Add(new SqlParameter("AlwaysActive", alwaysActive));
            com.Parameters.Add(new SqlParameter("Type", type));
            com.ExecuteNonQuery();
        }
        
        private int generateDiscVatID(SqlConnection con)
        {
            int lastID = 1000 - 1;
            SqlCommand com = new SqlCommand("SELECT ID FROM TABLE_DISCVAT ORDER BY ID", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                lastID = Convert.ToInt32(reader[0]);
            }
            reader.Close();
            return lastID+1;
        }
    }
}
