using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DataGridPlayground
{
    public static class MvvmBehaviors
    {


        public static string GetClickedMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(ClickedMethodNameProperty);
        }

        public static void SetClickedMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(ClickedMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for ClickedMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClickedMethodNameProperty =
            DependencyProperty.RegisterAttached("ClickedMethodName", typeof(string), typeof(MvvmBehaviors), new PropertyMetadata(null, OnClickedMethodNameChanged));

        private static void OnClickedMethodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button element = d as Button;
            if (element != null)
            {
                element.Click += (s, e2) =>
                {
                    var viewModel = element.DataContext;
                    if (viewModel == null) return;
                    var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                    if (methodInfo != null) methodInfo.Invoke(viewModel, null);
                };
            }
        }
    }
}
