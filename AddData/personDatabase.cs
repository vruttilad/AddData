using AddData.Model;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;

namespace AddData
{
    class personDatabase
    {
        public static string DBname = "SQLite.db3";
        public static string DBPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBname);
        SQLiteConnection sqliteconnection;

        public personDatabase()
        {
            try {


                Console.WriteLine(DBPath);
                sqliteconnection = new SQLiteConnection(DBPath);
                Console.WriteLine("Succefully Database Created!....");



            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }

        }

        internal void dataTable()
        {
            try
            {
                var created = sqliteconnection.CreateTable<Demo>();
                Console.WriteLine("Succefully Table Created!....");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }
        }

        public bool InstertData(Demo demo)
        {
            long result = sqliteconnection.Insert(demo);
            if (result == -1)
            {

                return false;
            }

            else
            {
                Console.WriteLine("Succefully Inserted Data ");
                return true;
            }
        }
        public Demo GetByUserId(int studentId)
        {
            var userId = sqliteconnection.Table<Demo>().Where(u => u.ID == studentId).FirstOrDefault();

            return userId;

        }
        public List<Demo> ReadTask()
        {
            try
            {
                var taskdata = sqliteconnection.Table<Demo>().ToList();
                return taskdata;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                return null;
            }


        }
        public bool DeleteStudents(Demo data)
        {


            long result = sqliteconnection.Delete(data);
            if (result == -1)
            {

                return false;
            }

            else
            {
                Console.WriteLine("Succefully Deleted Data ");
                return true;
            }


        }

        
    }
}