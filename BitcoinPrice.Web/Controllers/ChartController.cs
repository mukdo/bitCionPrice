using BitcoinPrice.Library;
using BitcoinPrice.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinPrice.Web.Controllers
{
    public class ChartController : Controller
    {
        private IBitCoinUnitOfWork _bitCoinUnitOfWork;
        private BitCoinContext _dbContext;
        public ChartController( IBitCoinUnitOfWork bitCoinUnitOfWork, BitCoinContext bitCoinContext)
        {
            _bitCoinUnitOfWork = bitCoinUnitOfWork;
            _dbContext = bitCoinContext;
        }
        public IActionResult Index()
        {
            //var model = new ViewModel(_bitCoinUnitOfWork);
           var model=  _dbContext.BitCoinPrice.OrderByDescending(x => x.time.updatedISO).ToList();
            
            return View(model);
        }
    }
}
