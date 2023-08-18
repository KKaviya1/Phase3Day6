//using System;
//using System.Data.SqlClient;


//namespace DisconnectedArc
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static SqlDataReader reader;
//        static string conStr = "server=DESKTOP-PE7BHIE;database=EmpsDb; trusted_connection = true;";

//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conStr);
//                cmd = new SqlCommand("select * from Emps", con);
//                con.Open();
//                reader = cmd.ExecuteReader();
//                Console.WriteLine("ID \t FirstName\t LastName\t Salary\t Designation");
//                while (reader.Read())
//                {
//                    Console.Write(reader["ID"]+"\t");
//                    Console.Write(reader["Fname"]+"\t \t");
//                    Console.Write(reader["Lname"] + "\t \t");
//                    Console.Write(reader["Salary"] + "\t \t");
//                    Console.Write(reader["Designation"] + "\t");
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

//insert**

//using System;
//using System.Data.SqlClient;
//using System.Data;

//namespace conAppDisconnectedArc
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static SqlDataReader reader;
//        static string conStr = "server=DESKTOP-PE7BHIE;database=EmpsDb; trusted_connection = true;";
//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conStr);
//                cmd = new SqlCommand()
//                {
//                    CommandText = "insert into Emps(Id,Fname,Lname,Salary,Designation)values(@id,@fn,@ln,@sal,@desg)",
//                    Connection = con
//                };
//                Console.WriteLine("Enter Employee Id");
//                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
//                Console.WriteLine("Enter FirstName ");
//                cmd.Parameters.AddWithValue("@fn", Console.ReadLine());
//                Console.WriteLine("Enter LastName ");
//                cmd.Parameters.AddWithValue("@ln", Console.ReadLine());
//                Console.WriteLine("Enter Salary ");
//                cmd.Parameters.AddWithValue("@sal", double.Parse(Console.ReadLine()));
//                Console.WriteLine("Enter Designation ");
//                cmd.Parameters.AddWithValue("@desg", Console.ReadLine());

//                con.Open();
//                int nor = cmd.ExecuteNonQuery();
//                if (nor >= 1)
//                {
//                    Console.WriteLine("Record Inserted!!!");
//                }
//            }
//            catch (Exception ex) { Console.WriteLine(ex.Message); }
//            finally
//            {
//                Console.ReadKey();

//            }

//        }
//    }
//}

//delete**

//using System;
//using System.Data.SqlClient;
//using System.Data;

//namespace conAppDisconnectedArc
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static SqlDataReader reader;
//        static string conStr = "server=DESKTOP-PE7BHIE;database=EmpsDb; trusted_connection = true;";
//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conStr);
//                cmd = new SqlCommand()
//                {
//                    CommandText = "delete from Emps where Id= @id",
//                    Connection = con
//                };
//                Console.WriteLine("Enter Employee Id to Delete: ");
//                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

//                con.Open();
//                int nor = cmd.ExecuteNonQuery();
//                if (nor >= 1)
//                {
//                    Console.WriteLine("Record Deleted!!!");
//                }
//            }
//            catch (Exception ex) { Console.WriteLine("Error!!!" + ex.Message); }
//            finally
//            {
//                Console.ReadKey();

//            }

//        }
//    }
//}

//find**

//using System;
//using System.Data.SqlClient;
//using System.Data;

//namespace conAppDisconnectedArc
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static string conStr = "server=DESKTOP-PE7BHIE;database=EmpsDb; trusted_connection = true;";
//        static SqlDataReader reader;
//        static void Main(string[] args)
//        {
//            try
//            {
//                int id;
//                Console.WriteLine("Enter Employee Id to find out Details ");
//                id = int.Parse(Console.ReadLine());
//                con = new SqlConnection(conStr);
//                cmd = new SqlCommand()
//                {
//                    CommandText = "select * from Emps where Id= @id",
//                    Connection = con
//                };

//                cmd.Parameters.AddWithValue("@id", id);
//                con.Open();
//                reader = cmd.ExecuteReader();

//                if (reader.HasRows)
//                {
//                    Console.WriteLine($"Record found for ID {id} and details as follows");
//                    while (reader.Read())
//                    {
//                        Console.WriteLine("ID:\t" + reader["ID"]);
//                        Console.WriteLine("FirstName:\t" + reader["Fname"]);
//                        Console.WriteLine("LastName:\t" + reader["Lname"]);
//                        Console.WriteLine("Salary:\t" + reader["Salary"]);
//                        Console.WriteLine("Designation:\t" + reader["Designation"]);
//                    }

//                }
//                else
//                {
//                    Console.WriteLine($"No such Id {id} exist in our database");
//                }

//            }
//            catch (Exception ex) { Console.WriteLine(ex.Message); }
//            finally
//            {
//                Console.ReadKey();

//            }

//        }
//    }
//}


//Update**

//using System;
//using System.Data.SqlClient;
//using System.Data;

//namespace conAppDisconnectedArc
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static string conStr = "server=DESKTOP-PE7BHIE;database=EmpsDb; trusted_connection = true;";
//        static SqlDataReader reader;
//        static void Main(string[] args)
//        {
//            try
//            {
//                int id;
//                Console.WriteLine("Enter Employee Id to update Details ");
//                id = int.Parse(Console.ReadLine());
//                con = new SqlConnection(conStr);
//                cmd = new SqlCommand()
//                {
//                    CommandText = "select * from Emps where Id= @id",
//                    Connection = con
//                };

//                cmd.Parameters.AddWithValue("@id", id);
//                con.Open();
//                reader = cmd.ExecuteReader();

//                if (reader.HasRows)
//                {
//                    con.Close();
//                    con.Open();
//                    cmd.CommandText = "update Emps set Fname=@fn, Lname=@ln,Salary=@sal, Designation=@desg where Id=@eid";
//                    Console.WriteLine("Enter New FirstName ");
//                    cmd.Parameters.AddWithValue("@fn", Console.ReadLine());
//                    Console.WriteLine("Enter New LastName ");
//                    cmd.Parameters.AddWithValue("@ln", Console.ReadLine());
//                    Console.WriteLine("Enter New Salary ");
//                    cmd.Parameters.AddWithValue("@sal", double.Parse(Console.ReadLine()));
//                    Console.WriteLine("Enter New Designation ");
//                    cmd.Parameters.AddWithValue("@desg", Console.ReadLine());
//                    cmd.Parameters.AddWithValue("@eid", id);
//                    cmd.ExecuteNonQuery();
//                    Console.WriteLine("Record Updated");

//                }
//                else
//                {
//                    Console.WriteLine($"No such Id {id} exist in our database");
//                }

//            }
//            catch (Exception ex) { Console.WriteLine(ex.Message); }
//            finally
//            {
//                Console.ReadKey();

//            }

//        }
//    }
//}


//Scalar**

//using System;
//using System.Data.SqlClient;
//using System.Data;

//namespace conAppDisconnectedArc
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static string conStr = "server=DESKTOP-PE7BHIE;database=EmpsDb; trusted_connection = true;";
//        static SqlDataReader reader;
//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conStr);
//                cmd = new SqlCommand("Select count(Id) from Emps", con);
//                con.Open();
//                Console.WriteLine("Number of Employees are: " + cmd.ExecuteScalar());
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

namespace conAppDisconnectedArc
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static string conStr = "server=DESKTOP-PE7BHIE;database=EmpsDb; trusted_connection = true;";
        static SqlDataReader reader;
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand();
                Console.WriteLine("Find out:\n 1.Avg\n 2.Max\n 3.Min\n 4.Sum of Salary.\n Enter your choice 1,2,3 or 4");
                int op = int.Parse(Console.ReadLine());

                switch(op)
                {
                    case 1:
                        {
                            cmd.CommandText = "select avg(Salary) from Emps";
                            break;
                        }

                    case 2:
                        {
                            cmd.CommandText = "select max(Salary) from Emps";
                            break;
                        }

                    case 3:
                        {
                            cmd.CommandText = "select min(Salary) from Emps";
                            break;
                        }

                    case 4:
                        {
                            cmd.CommandText = "select sum(Salary) from Emps";
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid Operation Choice");
                            return;
                        }
                
                }

             }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                con.Close();
                Console.ReadKey();

            }

        }
    }
}
