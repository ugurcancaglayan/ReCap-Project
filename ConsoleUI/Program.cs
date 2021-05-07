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

            //UserTest();

            //CustomerTest();

            //RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Rental Id : {0}", item.Id);
                Console.WriteLine("Car Id : {0}", item.CarId);
                Console.WriteLine("Customer Id : {0} ", item.CustomerId);
                Console.WriteLine("Car's Rental Date : {0} ", item.RentDate);
                Console.WriteLine("Car's Return Date : {0} ", item.ReturnDate);
                Console.WriteLine("---------------------------------------------");
            }
            Console.WriteLine();
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Customer Id : {0}", item.Id);
                Console.WriteLine("User Id : {0}", item.UserId);
                Console.WriteLine("Customer's Company Name : {0} ", item.CompanyName);
                Console.WriteLine("---------------------------------------------");
            }
            Console.WriteLine();
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User()
            {
                FirstName = "Ali",
                LastName = "Can",
                Email = "alican@gmail.com",
                Password = "12345"
            };
            Console.WriteLine(userManager.Add(user).Message);

            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Id : " + item.Id);
                Console.WriteLine("Firstname : " + item.FirstName);
                Console.WriteLine("Lastname : " + item.LastName);
                Console.WriteLine("Email : " + item.Email);
                Console.WriteLine("Password : " + item.LastName);
                Console.WriteLine("--------------------");
            }

            Console.WriteLine(userManager.Delete(user).Message);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color()
            {
                ColorName = "Yellow",
            };

            Console.WriteLine(colorManager.Add(color).Message);

            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.ColorName);
            }

            Console.WriteLine(colorManager.Delete(color).Message);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand()
            {
                BrandName = "Nissan",
            };

            Console.WriteLine(brandManager.Add(brand).Message);

            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.BrandName);
            }

            Console.WriteLine(brandManager.Delete(brand).Message);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car()
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 300,
                Description = "BMW",
                ModelYear = "2009"
            };

            Console.WriteLine(carManager.Add(car).Message);
            Console.WriteLine(carManager.GetCarDetails().Message);

            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Model Yılı:" + item.ModelYear);
                Console.WriteLine("Markası:" + item.BrandName);
                Console.WriteLine("Modeli:" + item.Description);
                Console.WriteLine("Rengi:" + item.ColorName);
                Console.WriteLine("Günlük Kiralama Ücreti:" + item.DailyPrice);
                Console.WriteLine("--------------------");
            }


            Console.WriteLine(carManager.Delete(car).Message);
        }
    }
}
