using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Cart.Models;
using System.Configuration;
using Cart.API.RequestModels;
using Newtonsoft.Json;

namespace Cart.Client
{
    class Program
    {
       
        static void Main(string[] args)
        {
            CallGetCart().Wait();
            CallPutCart().Wait();
            CallDeleteCart().Wait();
        }

        static async Task CallGetCart()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
                client.DefaultRequestHeaders.Accept.Clear();
                
                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                 
                HttpResponseMessage response = await client.GetAsync("api/Cart/1" ); 

                
                if (response.IsSuccessStatusCode)
                {
                    var order = await response.Content.ReadAsAsync<Order>();                 
                    Console.WriteLine($" Order ID : { order.ID} , Order Status : {order.Status} , Customer ID : {order.CustomerID}");

                    foreach (var item in order.Products)
                    {
                        Console.WriteLine($" Product ID : { item.ProductID} , Total Price : {item.TotalPrice} , Quantity  : {item.Quantity}");
                    }
                    Console.ReadLine();
                } else
                {
                    Console.WriteLine("internal server error");
                    Console.ReadKey();
                }

            }
        }


        static async Task CallPutCart()
        {
            using (var client = new HttpClient())
            {
                PutModel putModel = new PutModel { ProductID = 2, Quantity = 10 };

                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
                client.DefaultRequestHeaders.Accept.Clear();
                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method

                //JsonAsync("api/Cart/1", putModel);
                var items = new Dictionary<string, string>();
                items.Add("ProductId", "2");
                items.Add("Quantity", "10");
                FormUrlEncodedContent content = new FormUrlEncodedContent(items);
                HttpResponseMessage response = await client.PutAsync("api/Cart/1", content);

                if (response.IsSuccessStatusCode)
                {
                    var order = await response.Content.ReadAsAsync<Order>();
                    Console.WriteLine($" Order ID : { order.ID} , Order Name : {order.Status} , Customer ID : {order.CustomerID}");

                    foreach (var item in order.Products)
                    {
                        Console.WriteLine($" Product ID : { item.ProductID} , Total Price : {item.TotalPrice} , Quantity  : {item.Quantity}");
                    }
                    Console.ReadLine();
                } else
                {
                    Console.WriteLine("internal server error");
                    Console.ReadKey();
                }

            }
        }


        static async Task CallDeleteCart()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
                client.DefaultRequestHeaders.Accept.Clear();               
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.DeleteAsync("api/Cart/1?productId=1");
                if (response.IsSuccessStatusCode)
                {
                    var order = await response.Content.ReadAsAsync<Order>();
                    Console.WriteLine($" Order ID : { order.ID} , Order Name : {order.Status} , Customer ID : {order.CustomerID}");

                    foreach (var item in order.Products)
                    {
                        Console.WriteLine($" Product ID : { item.ProductID} , Total Price : {item.TotalPrice} , Quantity : {item.Quantity}");
                    }
                    Console.ReadLine();
                } else
                {
                    Console.WriteLine("internal server error");
                    Console.ReadKey();
                }

            }
        }

    }//class
}//namespace
