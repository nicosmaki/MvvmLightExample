﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MvvmLight1.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MvvmLight1.Model;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MessageViewModel>();
            SimpleIoc.Default.Register<Page1ViewModel>();
            SimpleIoc.Default.Register<Page2ViewModel>();
            SimpleIoc.Default.Register<Window1ViewModel>();
            SimpleIoc.Default.Register<Window2ViewModel>();

        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MessageViewModel messageView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MessageViewModel>();
            }
        }

        public Page1ViewModel P1
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Page1ViewModel>();
            }
        }

        public Page2ViewModel P2
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Page2ViewModel>();
            }
        }

        public Window1ViewModel W1
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Window1ViewModel>();
            }
        }

        public Window2ViewModel W2
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Window2ViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}