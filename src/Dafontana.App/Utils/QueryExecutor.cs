using Dafontana.Domain.Entities;
using Dafontana.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dafontana.App.Utils
{
    public class QueryExecutor
    {
        private readonly IUnitOfWork unitOfWork;

        public QueryExecutor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async void Run()
        {
            Console.WriteLine("Loading data...");

            var sales = await unitOfWork.SaleDetailsRepository.List(
                filter: x => x.Sale.Date >= DateTime.Today.AddDays(-30) && x.Sale.Date < DateTime.Today,
                include: x => x.Include(s => s.Sale).ThenInclude(v => v.Store).Include(x => x.Product).ThenInclude(x => x.Trademark));

            Console.Clear();

            Console.WriteLine($"1: Total ventas últimos 30 días: {Environment.NewLine}" +
                $"- Monto: {string.Format("{0:0.00}", sales.Sum(x => x.Total))} {Environment.NewLine}" +
                $"- Cantidad: {sales.Count()}");

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine($"2: Día y hora en que se realizó la venta con el monto más alto: {Environment.NewLine}" +
                $"- Fecha: {sales.OrderByDescending(x => x.Sale.Total).First().Sale.Date} {Environment.NewLine}" +
                $"- Monto: {string.Format("{0:0.00}", sales.OrderByDescending(x => x.Sale.Total).First().Sale.Total)}");

            Console.WriteLine(Environment.NewLine);

            var TopProduct = sales.GroupBy(x => x.Product)
                            .OrderByDescending(g => g.Sum(x => x.Total))
                            .Select(g => new
                            {
                                Product = g.Key,
                                TotalAmount = g.Sum(x => x.Total)
                            })
                            .First();

            Console.WriteLine($"3: Producto con mayor monto total de ventas: {Environment.NewLine}" +
                $"- Nombre del producto: {TopProduct.Product.Name} {Environment.NewLine}" +
                $"- Montol total de ventas: {string.Format("{0:0.00}", TopProduct.TotalAmount)}");

            Console.WriteLine(Environment.NewLine);

            var TopStore = sales.GroupBy(x => x.Sale.Store.Name)
                            .OrderByDescending(g => g.Sum(x => x.Total))
                            .Select(g => new
                            {
                                Nombre = g.Key,
                                TotalAmount = g.Sum(x => x.Total)
                            })
                            .First();

            Console.WriteLine($"4: Local con mayor monto de ventas: {Environment.NewLine}" +
                $"- Nombre del local: {TopStore.Nombre} {Environment.NewLine}" +
                $"- Montol total de ventas: {string.Format("{0:0.00}", TopStore.TotalAmount)}");

            Console.WriteLine(Environment.NewLine);

            var TopTrademark = sales.GroupBy(x => x.Product.Trademark)
                                    .Select(g => new
                                    {
                                        Trademark = g.Key.Name,
                                        Margin = (g.Sum(x => x.Total) - g.Sum(x => x.Product.UnitCost * x.Amount)) / Convert.ToDecimal(g.Sum(x => x.Total) / 100)
                                    })
                                    .OrderByDescending(x => x.Margin)
                                    .First();

            Console.WriteLine($"5: La marca con mayor margen de ganancias: {Environment.NewLine}" +
                $"- Nombre de la marca: {TopTrademark.Trademark} {Environment.NewLine}" +
                $"- Margen de ganancia: {string.Format("{0:0.00}", TopTrademark.Margin)}%");          

            Console.WriteLine(Environment.NewLine);

            var ProductsByLocal = sales.GroupBy(x => new { StoreName = x.Sale.Store.Name, ProductName = x.Product.Name })
                .Select(g => new
               {
                   g.Key.StoreName,
                   g.Key.ProductName,
                   Amount = g.Sum(x => x.Amount),
                   RowNum = g.OrderByDescending(x => x.Amount).Select((x, i) => new { x.Sale.Store.Name, i }).FirstOrDefault().i + 1
               })
               .Where(x => x.RowNum == 1)
               .OrderByDescending(x => x.Amount)
               .GroupBy(x => new { x.StoreName })
               .Select(x => x.First());

            Console.WriteLine($"6: El producto que más se vende en cada local: {Environment.NewLine}");

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(String.Format("|{0,15}|{1,20}|{2,15}|", "LOCAL", "PRODUCTO", "CANTIDAD"));
            Console.WriteLine("------------------------------------------------------");
            foreach (var item in ProductsByLocal)
            {                
                Console.WriteLine(String.Format("|{0,15}|{1,20}|{2,15}|", item.StoreName, item.ProductName, item.Amount));
                Console.WriteLine("------------------------------------------------------");
            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}
