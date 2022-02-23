using AddData.Model;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Service.Autofill;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;

namespace AddData
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Toolbar toolbar;
        ImageView imgview;      
        private List<Demo> demoList;
        RecyclerView recyclerView;
        RecyclerView.LayoutManager myLayoutManager;
        private personDatabase myDataBase;
        private DataAdapter sadapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar1);
            imgview = FindViewById<ImageView>(Resource.Id.imgBtn);
            recyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerView);

            myDataBase = new personDatabase();
            myDataBase.dataTable();

            imgview.Click += imgClick;

            //imgview.Click += delegate {
            //    Intent i = new Intent(this, typeof(Add_Data));
            //    StartActivity(i);
            //};

            GetDetails();

            myLayoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(myLayoutManager);

            sadapter = new DataAdapter(demoList, this);
            recyclerView.SetAdapter(sadapter);

        }

       
        private List<Demo> GetDetails()
        {
            myDataBase = new personDatabase();
            var data = myDataBase.ReadTask();
            demoList = new List<Demo>();
            demoList.AddRange(data);

            return demoList;

        }
        private void imgClick(object sender, EventArgs e)
        {
            Intent p = new Intent(Application.Context, typeof(Add_Data));
            StartActivity(p);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}