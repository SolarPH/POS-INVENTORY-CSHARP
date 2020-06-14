using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DesktopApp.DatabaseManager
{
    
    class MainDatabase
    {
        SqlConnection con = new SqlConnection();
        public void InitDatabase()
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            con.Close();
            con.Dispose();
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

        public Boolean InteractDB_CheckMatch(int ID)
        {
            con.ConnectionString = @"Server=LAPTOP-U2J56FAS\SQLEXPRESS;Database=POS_InventoryDB;Trusted_Connection=True";
            con.Open();
            Boolean result = CheckMatch(con, ID);
            con.Close();
            con.Dispose();
            return result;
        }

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
    }
}
