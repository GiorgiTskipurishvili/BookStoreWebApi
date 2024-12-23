using BookStoreWebApi.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace BookStoreWebApi.Packages
{
    public class PKG_ORDER :PKG_BASE
    {
        public void add_order(Order order)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_GIORGITSK_ORDERS.add_order";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_fullname", OracleDbType.Varchar2).Value = order.FullName;
            cmd.Parameters.Add("p_orderquantity", OracleDbType.Int64).Value = order.OrderQuantity;
            cmd.Parameters.Add("p_book_id", OracleDbType.Int64).Value = order.BookId;

            cmd.ExecuteNonQuery();
            conn.Close();
        }



        public List<Order> get_order_by_fulname(string fullName)
        {
            List<Order> orders = new List<Order>();
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_GIORGITSK_ORDERS.get_order_by_fulname";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_fullname", OracleDbType.Varchar2).Value = fullName;
            cmd.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        FullName = reader["fullname"].ToString(),
                        OrderQuantity = Convert.ToInt32(reader["orderquantity"]),
                        BookId = Convert.ToInt32(reader["book_id"])
                    });
                }
            }

            conn.Close();
            return orders;
        }



        public void delete_order(Order order)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_GIORGITSK_ORDERS.delete_order";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_id", OracleDbType.Int64).Value = order.Id;

            cmd.ExecuteNonQuery();
            conn.Close();
        }



    }
}
