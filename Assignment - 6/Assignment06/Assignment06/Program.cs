//using System;
//using System.Data.SqlClient;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignment06
//{
//    internal class Program
//    {

//        static SqlConnection con;
//        static SqlCommand cmd;
//        static SqlDataReader reader;
//        static string conStr = "server=DESKTOP-PE7BHIE;database=ProductInventoryDB; trusted_connection = true;";

//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conStr);
//                cmd = new SqlCommand("select * from Products", con);
//                con.Open();
//                reader = cmd.ExecuteReader();
//                Console.WriteLine("ProductId\t ProductName\t Price\t\t Quantity\t MfDate\t\t\t\t ExpDate");
//                while (reader.Read())
//                {
//                    Console.Write(reader["ProductId"] + "\t\t");
//                    Console.Write(reader["ProductName"] + "\t\t");
//                    Console.Write(reader["Price"] + "\t");
//                    Console.Write(reader["Quantity"] + "\t ");
//                    Console.Write(reader["MfDate"] + "\t\t\t");
//                    Console.Write(reader["ExpDate"] + "\t ");
//                    Console.WriteLine("\n");
//                }
//            }
//            catch (Exception ex) { Console.WriteLine(ex.Message); }
//            finally
//            {
//                con.Close();
//                Console.ReadKey();

//            }

//        }
//    }
//}


using System;
using System.Data.SqlClient;
using System.Data;

namespace Assignment06
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string conStr = "server=DESKTOP-PE7BHIE;database=ProductInventoryDB; trusted_connection = true;";

        static void View()
        {
            cmd = new SqlCommand("select * from Products", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Product ID: {reader["ProductId"]}\n Name: {reader["ProductName"]}\n Price: {reader["Price"]}\n Quantity: {reader["Quantity"]}\n MFDate: {reader["MFDate"]}\n ExpDate: {reader["ExpDate"]}\n");
            }

            reader.Close();
        }
        static void Add()
        {
            cmd = new SqlCommand("insert into Products (ProductId,ProductName, Price, Quantity, MfDate, ExpDate) values (@pid,@pn, @pp, @Qty, @mfd, @exp)", con);
            Console.WriteLine("\nEnter Product Id: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Manufacturing Date (yyyy-mm-dd): ");
            DateTime mfDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Expiry Date (yyyy-mm-dd): ");
            DateTime expDate = DateTime.Parse(Console.ReadLine());

            cmd.Parameters.AddWithValue("@pid", productId);
            cmd.Parameters.AddWithValue("@pn", productName);
            cmd.Parameters.AddWithValue("@pp", price);
            cmd.Parameters.AddWithValue("@Qty", quantity);
            cmd.Parameters.AddWithValue("@mfd", mfDate);
            cmd.Parameters.AddWithValue("@exp", expDate);

            int nor = cmd.ExecuteNonQuery();
            if (nor >= 1)
            {
                Console.WriteLine("**Product inserted successfully**");
            }
            
        }
        static void Update()
        {
            Console.Write("\nEnter Product ID to update quantity: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter New Quantity: ");
            int newQuantity = int.Parse(Console.ReadLine());

            cmd = new SqlCommand("update Products set Quantity = @NewQty where ProductId = @PId", con);
            cmd.Parameters.AddWithValue("@NewQty", newQuantity);
            cmd.Parameters.AddWithValue("@PId", productId);

            int nor = cmd.ExecuteNonQuery();
            if (nor > 0)
            {
                Console.WriteLine("**Product quantity updated successfully**");
            }
           
        }

        static void Remove()
        {
            Console.Write("\nEnter Product ID to remove: ");
            int productId = int.Parse(Console.ReadLine());

            cmd = new SqlCommand("delete from Products where ProductId = @PId", con);
            cmd.Parameters.AddWithValue("@PId", productId);
            int nor = cmd.ExecuteNonQuery();
            if (nor > 0)
            {
                Console.WriteLine("**Product Deleted successfully**");
            }
           
        }

        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conStr);
                con.Open();
                while (true)
                {
                    Console.WriteLine("\nSelect the operation you want to perform\n");
                    Console.WriteLine("1. View Products\n2. Add New Product\n3. Update Product Quantity\n4. Remove Product\n5. Exit");
                    int op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            View();
                            break;
                        case 2:
                            Add();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            Remove();
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid operation choice!!");
                            break;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Error..." + ex.Message); }
            finally
            {
                con.Close();
                Console.ReadKey();

            }
        }
    }
}