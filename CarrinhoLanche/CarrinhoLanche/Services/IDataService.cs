using CarrinhoLanche.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarrinhoLanche.Services
{
    public interface IDataService
    {        
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
