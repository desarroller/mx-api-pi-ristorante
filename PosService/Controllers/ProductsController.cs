// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PosService.Services;
using System.Collections.Generic;
using StorageDB;
namespace PosService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StorageDBService _storageDbService;

        public ProductsController(StorageDBService storageDbService) =>
               _storageDbService = storageDbService;

        //[HttpGet(Name = "GetProducts")]
        [HttpGet]
        public async Task<IEnumerable<Products>> Get() =>
            await _storageDbService.GetAsync();


        // [HttpGet]
        // public async Task<List<Book>> Get() =>
        //await _booksService.GetAsync();
    }
}
