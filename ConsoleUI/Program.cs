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
            //CarTest();

            //ColorTest();

            //BrandTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color()
            {
                ColorName = "Yellow",
            };

            colorManager.Add(color);

            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine(item.ColorName);
            }

            colorManager.Delete(color);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand()
            {
                BrandName = "Nissan",
            };

            brandManager.Add(brand);

            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.BrandName);
            }

            brandManager.Delete(brand);
        }

        private static void CarTest()
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

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Model Yılı:" + item.ModelYear);
                Console.WriteLine("Markası:" + item.BrandName);
                Console.WriteLine("Modeli:" + item.Description);
                Console.WriteLine("Rengi:" + item.ColorName);
                Console.WriteLine("Günlük Kiralama Ücreti:" + item.DailyPrice);
                Console.WriteLine("--------------------");
            }

            carManager.Delete(car);
            Console.WriteLine("Araba verisi silindi");
        }
    }
}
