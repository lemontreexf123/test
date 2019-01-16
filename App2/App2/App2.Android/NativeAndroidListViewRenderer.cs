using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2;
using App2.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NativeListView), typeof(NativeAndroidListViewRenderer))]
namespace App2.Droid
{
    public class NativeAndroidListViewRenderer : ListViewRenderer
    {
        public NativeAndroidListViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement is NativeListView)
                Control.Scroll += Control_Scroll;
        }
        private void Control_Scroll(object sender, AbsListView.ScrollEventArgs e)
        {
            var myList = Element as NativeListView;
            myList.IsScrolling = true;

        }
        
    }
}