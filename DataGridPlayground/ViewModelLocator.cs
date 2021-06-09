using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataGridPlayground.ViewModel;

namespace DataGridPlayground
{
    public static class ViewModelLocator
    {



        public static bool GetAutoWireViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoWireViewModelProperty, value);
        }

        // Using a DependencyProperty as the backing store for AutoWireViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoWireViewModelProperty =
            DependencyProperty.RegisterAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), 
                new PropertyMetadata(false, GetAutoWireViewModelChanged));

        private static void GetAutoWireViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;

            var ViewTypeName = d.GetType().FullName;
            var intermediateName = ViewTypeName + "Model";
            var fullNameArr = intermediateName.Split('.');
            fullNameArr[1] = "ViewModel";

            var ViewModelTypeName = String.Join('.', fullNameArr);
            var ViewModelType = Type.GetType(ViewModelTypeName);
            var ViewModel = Activator.CreateInstance(ViewModelType);
            ((FrameworkElement)d).DataContext = ViewModel;
        }
    }
}
