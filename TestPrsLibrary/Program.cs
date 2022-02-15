using PrsLibrary.Controllers;
using PrsLibrary.Models;

using System;
using System.Linq;

namespace TestPrsLibrary {

    internal class Program {

        static void Print(Product product) {
            Console.WriteLine($"{product.Id,-5} {product.PartNbr,-12} {product.Name,-12} {product.Price,10:c} {product.Vendor.Name,-15}");
        }

        static void Main(string[] args) {

            var context = new PrsDbContext();

            var userCtrl = new UsersController(context);

            var user = userCtrl.Login("sa", "sax");

            if(user is null) {
                Console.WriteLine("User not found");
            } else {
                Console.WriteLine(user.Username);
            }












            //var username = "gdoud";
            //var password = "password";
            //context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            //var user = from u in context.Users
            //            where u.Username == username && u.Password == password
            //            select u;








            //var reqlCtrl = new RequestlinesController(context);

            //var requestlines = reqlCtrl.GetAll();

            //foreach(var rl in requestlines) {
            //    Console.WriteLine($"{ rl.Id} {rl.Request.Description} {rl.Product.Name}");
            //}

            //var prodCtrl = new ProductsController(context);

            //var products = prodCtrl.GetAll();

            //foreach(var p in products) {
            //    Print(p);
            //}

            //var product = prodCtrl.GetByPk(2);

            //if(product is not null) {
            //    Print(product);
            //}



            //var userCtrl = new UsersController(context);

            //var newUser = new User() {
            //    Id = 0, Username = "zz", Password = "xx",
            //    Firstname = "User", Lastname = "ZZ",
            //    Phone = "211", Email = "xx@user.com",
            //    IsReviewer = false, IsAdmin = false
            //};

            ////userCtrl.Create(newUser);

            //var user3 = userCtrl.GetByPk(3);

            //if(user3 is null) {
            //    Console.WriteLine("User not found!");
            //} else {
            //    Console.WriteLine($"User3: {user3.Firstname} {user3.Lastname}");
            //}

            //user3.Lastname = "User3";
            //userCtrl.Change(user3);

            //var user33 = userCtrl.GetByPk(33);

            //if (user33 is null) {
            //    Console.WriteLine("User not found!");
            //} else {
            //    Console.WriteLine($"User33: {user33.Firstname} {user33.Lastname}");
            //}

            //userCtrl.Remove(8);

            //var users = userCtrl.GetAll();

            //foreach(var user in users) {
            //    Console.WriteLine($"{user.Id} {user.Firstname} {user.Lastname}" );
            //}
        }
    }
}
