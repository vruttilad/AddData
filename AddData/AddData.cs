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
    public class AddData : Activity
    {
        Toolbar toolbar;
        EditText edtTxt;
        Button btn;
        personDatabase pDB;
        Demo demo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Add_Data);
            // Create your application here
            pDB = new personDatabase();
            pDB.CreateData();
            UIReferences();
            UIClick();
        }

        private void UIReferences()
        {
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar2);
            edtTxt = FindViewById<EditText>(Resource.Id.edt1);
            btn = FindViewById<Button>(Resource.Id.addBtn);
        }

        private void UIClick()
        {
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //Intent i = new Intent(this, typeof(MainActivity));
            //StartActivity(i);
            demo = new Demo();
            demo.Name = edtTxt.Text;

            var inserted = pDB.InstertStudents(demo);

            

            
        }
    }
}