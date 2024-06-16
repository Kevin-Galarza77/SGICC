using Microsoft.VisualStudio.TestTools.UnitTesting;
using SG.App.Aplicacion.Servicios;
using SG.Dominio.Modelo.Entidades;
using System;

namespace TestCrud
{
    [TestClass]
    public class UnitTest1
    {
        //readonly CategoriaServicio categoriaServicio = new CategoriaServicio();
        //readonly ProductoServicio productoServicio = new ProductoServicio();
        readonly AjusteStockServicio ajusteStockServicio = new AjusteStockServicio();

        [TestMethod]
        public void TestMethod1()
        {
            //categories categoria = new categories();
            //categoria.category_name = "PILSENER";
            //categoria.category_state = true;
            //categoriaServicio.InsertarCategoria(categoria);

            //products product = new products();
            //product.product_name = "PILSENER 600";
            //product.product_purchase_price = 10.50m;
            //product.product_sale_price = 15.50m;
            //product.product_img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSWXiegcar_nm58gMO6SI66n6bGAeH_t_x1Rw&s";
            //product.product_stock_quantity = 50;
            //product.product_state = true;
            //product.category_id = 1;
            //productoServicio.InsertarProducto(product);

            stock_adjusts ajusteStock = new stock_adjusts();
            ajusteStock.product_id = 1;
            ajusteStock.stock_adjust_date = DateTime.Now;
            ajusteStock.stock_adjust_quantity = 50;
            ajusteStock.stock_adjust_reason = "SE INGRESO MAL LA CANTIDAD DE COMPRA EL DIA JUEVES";
            ajusteStockServicio.InsertarAjusteStock(ajusteStock);

        }
    }
}
