using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car() 
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 300,
                Description = "A3",
                ModelYear = "2015"
            };

            Console.WriteLine("Araba verisi eklendi.");
            carManager.Add(car);

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Model Yılı:" + item.ModelYear);
                Console.WriteLine("Markası:" + item.BrandId);
                Console.WriteLine("Modeli:" + item.Description);
                Console.WriteLine("Rengi:" + item.ColorId);
                Console.WriteLine("Günlük Kiralama Ücreti:" + item.DailyPrice);
                Console.WriteLine("--------------------");
            }

            carManager.Delete(car);
            Console.WriteLine("Araba verisi silindi");
        }
    }
}
