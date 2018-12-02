using Microsoft.Data.Sqlite;
using System;

namespace SqliteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Data Source=dapperTest.db";
            string sql =
                            @"drop table if exists userInfo;
                            create table userInfo(
                                userInfo int primary key,
                                userName nvarchar(50)
                            );
                            insert into userInfo values(1,'小明');
                            insert into userInfo values(2,'小红');
                            ";
            string sql2 = "select * from userInfo";

            try
            {
                using (SqliteConnection conn = new SqliteConnection(connString))
                {
                    conn.Open();
                    SqliteCommand cmd = new SqliteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = sql2;
                    SqliteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine("UserId:{0}\tUserName:{1}", dr[0], dr[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("End.");
            Console.Read();
        }
    }
}
