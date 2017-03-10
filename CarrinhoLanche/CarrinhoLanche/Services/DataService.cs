using CarrinhoLanche.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using CarrinhoLanche.Services;
using System.Diagnostics;

[assembly: Dependency(typeof(DataService))]

namespace CarrinhoLanche.Services
{
    public class DataService : IDataService
    {
        #region Products
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return new List<Product> {
                new Product {
                    Name ="teste 1",
                    Description ="descr 1",
                    ImageUrl="http://www.yoki.com.br/wp-content/uploads/2015/05/batata-palha-extrafina-cebola-e-salsa-card.jpg"
                },

                new Product {
                    Name ="teste 2",
                    Description ="descr 2",
                    ImageUrl ="http://vult.com.br/wp-content/uploads/2016/04/SOBRANCELHAS.jpg"
                }
            };
        }
        #endregion


        #region some nifty helpers

        static async Task Execute(Func<Task> execute)
        {
            try
            {
                await execute();
            }
            // catch all other errors
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        static async Task<T> Execute<T>(Func<Task<T>> execute, T defaultReturnObject)
        {
            try
            {
                return await execute();
            }
            catch (Exception ex) // catch all other errors
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            return defaultReturnObject;
        }
        #endregion
    }
}
