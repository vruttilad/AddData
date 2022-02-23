using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using iText.Layout.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddData
{
    public class RecyclerAdapter : RecyclerView.Adapter
    {
        private List<string> _Name;
        public event EventHandler<int> itemClick;
        

        public RecyclerAdapter(List<string>Name)
        {
            _Name = Name;
        }

        public override int ItemCount => _Name.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            NameViewHolder nameViewHolder = holder as nameViewHolder;
            nameViewHolder.BindData(_Name[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Recycler, parent, false);
            return new NameViewHolder(view, OnClick);
        }
        public void OnClick(int position)
        {
            if(itemClick != null)
            {
                itemClick?.Invoke(this, position);
            }
            itemClick?.Invoke(this, position);
        }

        class NameViewHolder : RecyclerView.ViewHolder
        {
            //public Listview listView;
            _NameText = itemView.FindViewById<TextView>(Resource.Id._employeeText);
            _NameText.Click += (sender, e) => listner(base.LayoutPosition);
        }
        internal void Binddata(string employeeName)
        {
            _NameText.Text = employeeName;
        }
    }
}