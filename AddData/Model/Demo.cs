using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace AddData.Model
{
    [Table("TaskTable")]
   public class Demo
    {
        [Column("TaskName")]
        public string Name { get; set; }

        [AutoIncrement,PrimaryKey]
        public int ID { get; set; }
    }
}