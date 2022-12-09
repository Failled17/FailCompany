using FailCompany.Resourses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FailCompany
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PractikaEntities db = new PractikaEntities();

        public static User user { get; set; }
        public static Product product { get; set; }
        public App()
        {
            db.User.Load();
            db.Product.Load();
        }
    }
}
