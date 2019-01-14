using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App2;
using App2.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NativeListView), typeof(NativeiOSListViewRenderer))]
namespace App2.iOS
{
    public class NativeiOSListViewRenderer : ListViewRenderer
    {
        private IDisposable _offsetObserver;
        private double _prevYOffset;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement is NativeListView)
                _offsetObserver = Control.AddObserver("contentOffset",
                             Foundation.NSKeyValueObservingOptions.New, HandleAction);
        }

        private void HandleAction(Foundation.NSObservedChange obj)
        {
            var effectiveY = Math.Max(Control.ContentOffset.Y, 0);
            if (!CloseTo(effectiveY, _prevYOffset) && Element is NativeListView)
            {
                var myList = Element as NativeListView;

                myList.IsScrolling = true;
                _prevYOffset = effectiveY;
            }
        }
        private static bool CloseTo(double x, double y)
        {
            return Math.Abs(x - y) < 0.1;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && _offsetObserver != null)
            {
                _offsetObserver.Dispose();
                _offsetObserver = null;
            }
        }
    }
}