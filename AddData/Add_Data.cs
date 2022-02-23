using AddData.Model;
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

namespace AddData
{
    [Activity(Label = "Add_Data")]
    public class Add_Data : Activity
    {
        public Toolbar toolbar;
        public EditText editText;
        public Button button;
        personDatabase Pdb;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Add_Data);
            // Create your application here
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar2);
            editText = FindViewById<EditText>(Resource.Id.edt1);
            button = FindViewById<Button>(Resource.Id.addBtn);

            button.Click += add_Click;
            Pdb = new personDatabase();
            Pdb.dataTable();

        }

        private void add_Click(object sender, EventArgs e)
        {
            if(editText.Text != string.Empty)
            {
                Demo datatable = new Demo();
                datatable.Name = editText.Text;


                bool checkinsert = Pdb.InstertData(datatable);
                if (checkinsert == true )
                {

                    Intent p = new Intent(Application.Context, typeof(MainActivity));
                    StartActivity(p);
                    Toast.MakeText(this, "data inserted succesfully", ToastLength.Short).Show();

                }
                else
                {

                    Toast.MakeText(this, "no insert", ToastLength.Short).Show();



                }
            }
            else
            {

                Toast.MakeText(this, "Data Not Inserted ", ToastLength.Short).Show();

            }

       
        }
    }
}