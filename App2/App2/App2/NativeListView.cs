﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2
{
    public class NativeListView : ListView
    {
        public static readonly BindableProperty
            IsScrollingProperty =
                BindableProperty.Create(nameof(IsScrolling),
                typeof(bool), typeof(NativeListView), false);

        public bool IsScrolling
        {
            get { return (bool)GetValue(IsScrollingProperty); }
            set { SetValue(IsScrollingProperty, value); }
        }
    }
}
