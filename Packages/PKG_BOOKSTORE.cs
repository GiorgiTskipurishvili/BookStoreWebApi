using BookStoreWebApi.Models;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Numerics;

namespace BookStoreWebApi.Packages
{
    public class PKG_BOOKSTORE : PKG_BASE
    {

        public void add_book(BookStore bookStore)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_GIORGITSK_BOOKSTORE.add_book";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_title", OracleDbType.Varchar2).Value = bookStore.Title;
            cmd.Parameters.Add("p_author", OracleDbType.Varchar2).Value = bookStore.Author;
            cmd.Parameters.Add("p_price", OracleDbType.Int64).Value = bookStore.Price;
            cmd.Parameters.Add("p_quantity", OracleDbType.Int64).Value = bookStore.Quantity;


            cmd.ExecuteNonQuery();
            conn.Close();
        }


        //public List<BookStore> get_books()
        //{
        //    List<BookStore> bookStores = new List<BookStore>();

        //    OracleConnection conn = new OracleConnection();
        //    conn.ConnectionString = ConnStr;
        //    conn.Open();

        //    OracleCommand cmd = new OracleCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandText = "olerning.PKG_GIORGITSK_BOOKSTORE.get_books";
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //    OracleDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {

        //        while (reader.Read())
        //        {
        //            BookStore book = new BookStore()
        //            {
        //                Id = int.Parse(reader["id"].ToString()),
        //                Title = reader["title"].ToString(),
        //                Author = reader["author"].ToString(),
        //                Price = int.Parse(reader["price"].ToString()),
        //                Quantity = int.Parse(reader["quantity"].ToString()),
        //            };


        //            bookStores.Add(book);
        //        }

        //    }
        //    conn.Close();
        //    return bookStores;
        //}

        public List<BookStore> get_books()
        {
            List<BookStore> bookStores = new List<BookStore>();

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_GIORGITSK_BOOKSTORE.get_books";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                BookStore book = new BookStore()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Title = reader["title"].ToString(),
                    Author = reader["author"].ToString(),
                    Price = int.Parse(reader["price"].ToString()),
                    Quantity = int.Parse(reader["quantity"].ToString()),
                };

                bookStores.Add(book);
            }

            conn.Close();
            return bookStores;
        }



        public void delete_book(BookStore bookStore)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_GIORGITSK_BOOKSTORE.delete_book";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_id", OracleDbType.Int64).Value = bookStore.Id;

            cmd.ExecuteNonQuery();
            conn.Close();
        }



        public void update_book(BookStore bookStore)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_GIORGITSK_BOOKSTORE.update_book";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_id", OracleDbType.Int64).Value = bookStore.Id;
            cmd.Parameters.Add("p_title", OracleDbType.Varchar2).Value = bookStore.Title;
            cmd.Parameters.Add("p_authot", OracleDbType.Varchar2).Value = bookStore.Author;
            cmd.Parameters.Add("p_price", OracleDbType.Int64).Value = bookStore.Price;
            cmd.Parameters.Add("p_quantity", OracleDbType.Int64).Value = bookStore.Quantity;


            cmd.ExecuteNonQuery();
            conn.Close();
        }


        //public BookStore get_book_by_id(BookStore bookStore)
        //{
        //    OracleConnection conn = new OracleConnection();
        //    conn.ConnectionString = ConnStr;

        //    conn.Open();

        //    OracleCommand cmd = new OracleCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandText = "olerning.PKG_GIORGITSK_BOOKSTORE.get_book_by_id";
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.Add("p_id", OracleDbType.Int64).Value = bookStore.Id;
        //    cmd.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //    OracleDataReader reader = cmd.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        bookStore.Id = int.Parse(reader["id"].ToString());
        //        bookStore.Title = reader["title"].ToString();
        //        bookStore.Author = reader["author"].ToString();
        //        bookStore.Price = int.Parse(reader["price"].ToString());
        //        bookStore.Quantity = int.Parse(reader["price"].ToString());
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    conn.Close();
        //    return bookStore;
        //}



        public BookStore get_book_by_id(BookStore bookStore)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_GIORGITSK_BOOKSTORE.get_book_by_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_id", OracleDbType.Int64).Value = bookStore.Id;
            cmd.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                bookStore.Id = int.Parse(reader["id"].ToString());
                bookStore.Title = reader["title"].ToString();
                bookStore.Author = reader["author"].ToString();
                bookStore.Price = int.Parse(reader["price"].ToString());
                bookStore.Quantity = int.Parse(reader["quantity"].ToString()); 
            }
            else
            {
                return null; 
            }

            conn.Close();
            return bookStore;
        }




    }
}
