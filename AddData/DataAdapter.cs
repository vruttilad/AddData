using AddData.Model;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AddData
{
    class DataAdapter : RecyclerView.Adapter
    {
        private List<Demo> demolist;
        public Context context;
        personDatabase pDB;
        Demo studentU;

        public DataAdapter(List<Demo> demolist, Context context)
        {
            this.demolist = demolist;
            this.context = context;
        }

        public override int ItemCount => demolist.Count;

        

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            DataViewholder Dataholder = holder as DataViewholder;
            Dataholder.BindData(demolist[position]);
            Dataholder.deletebutton.Click += (s, e) =>
            {

                pDB = new personDatabase();
                studentU = pDB.GetByUserId(demolist[position].ID);
                if (studentU != null)
                {
                    var isDeleted = pDB.DeleteStudents(studentU);
                    if (isDeleted == true)
                    {
                        Toast.MakeText(context, "Data Deleted Succesfully", ToastLength.Short).Show();
                    }

                    else
                    {

                        Toast.MakeText(context, "No action performed", ToastLength.Short).Show();

                    }
                }
                Intent i = new Intent(Application.Context, typeof(MainActivity));
                context.StartActivity(i);
            };

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Delete, parent, false);
            return new DataViewholder(view);
        }
    }

    internal class DataViewholder : RecyclerView.ViewHolder
    {
        public ImageView deletebutton;
        public TextView dataview;



        public DataViewholder(View itemView) : base(itemView)
        {
            deletebutton = itemView.FindViewById<ImageView>(Resource.Id.imgViewBtn);
            dataview = itemView.FindViewById<TextView>(Resource.Id.deleteview);

        }



        internal void BindData(Demo data_table)
        {
            dataview.Text = data_table.Name;
        }
    }
}





