using Microsoft.VisualStudio.TestTools.UnitTesting;
using SG.App.Aplicacion.Servicios;
using SG.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCrud
{
    [TestClass]
    public class UnitTest1
    {
        readonly ProductoServicio productoServicio= new ProductoServicio();
        readonly CategoriaServicio categoriaServicio= new CategoriaServicio();
        readonly AjusteStockServicio ajusteStockServicio= new AjusteStockServicio();

        [TestMethod]
        public void TestMethod1()
        {

            var productList = productoServicio.productosPorCategoria(1);


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("PRODUCTOS POR CATEGORIA");
            Console.WriteLine("--------------------------------------------------");

            foreach (var item in productList)
            {
                Console.WriteLine(item.product_id + " .- " + item.product_name);
            }

            var categoriaList = categoriaServicio.categoriasPorEstado(true); 

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("CATEGORIAS POR ESTADO");
            Console.WriteLine("--------------------------------------------------");

            foreach (var item in categoriaList)
            {
                Console.WriteLine(item.category_id + " .- " + item.category_name);
            }

            var ajusteList = ajusteStockServicio.ajustesPorProducto(1);

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("AJUSTE POR PRODUCTO");
            Console.WriteLine("--------------------------------------------------");

            foreach (var item in ajusteList)
            {
                Console.WriteLine(item.stock_adjust_id+ " .- " + item.stock_adjust_date);
            }


        }

        public void TestTipoTransferencias()
        {
            transfer_types tipoTransferencia = InsertarTipoTransferencia();
        }

        public void TestTransferencias()
        {
            transfers transferencia = InsertarTransferencia();
        }

        public void TestMovimientos()
        {
            MovimientosServicio movimientoServicio = new MovimientosServicio();

            transfers transferencia = InsertarTransferencia();

            products product = InsertarProducto();

            stock_moves movimiento = new stock_moves();
            movimiento.product_id = product.product_id;
            movimiento.transfer_id = transferencia.transfer_id;
            movimiento.stock_move_quantity = 50;
            movimiento.stock_move_price_unit = 10.50m;
            movimientoServicio.InsertarMovimiento(movimiento);
        }

        // HELPPERS
        public transfer_types InsertarTipoTransferencia()
        {
            TipoTransferenciaServicio tipoTransferenciaServicio = new TipoTransferenciaServicio();
            IEnumerable<transfer_types> tipoTransferencias;
            transfer_types tipoTransferencia = new transfer_types();
            tipoTransferencia.TRANSFER_TYPE_NAME = "INGRESO";
            tipoTransferencia.TRANSFER_TYPE_DESCRIPTION = "INGRESO DE PRODUCTOS";

            tipoTransferenciaServicio.InsertarTipoTransferencia(tipoTransferencia);

            tipoTransferencias = tipoTransferenciaServicio.listarTipoTransferencias();

            return tipoTransferencias.Last();
        }

        public transfers InsertarTransferencia()
        {
            TransferenciaServicio transferenciaServicio = new TransferenciaServicio();
            transfers transferencia = new transfers();
            transfer_types tipoTransferencia = InsertarTipoTransferencia();
            transferencia.transfer_type_id = tipoTransferencia.transfer_type_id;
            transferencia.transfer_number = "0001";
            transferencia.transfer_date = DateTime.Now;
            transferencia.transfer_created = DateTime.Now;
            transferencia.transfer_invoice_number = "0001";
            transferenciaServicio.InsertarTransferencia(transferencia);

            IEnumerable<transfers> transferencias = transferenciaServicio.listarTransferencias();

            return transferencias.Last();
        }

        public products InsertarProducto()
        {
            // Consultamos la útlima categoría
            CategoriaServicio categoriaServicio = new CategoriaServicio();
            IEnumerable<categories> categorias = categoriaServicio.listarTodo();
            categories categoria = new categories();

            if (categorias.Count() == 0)
            {
                categoria = InsertarCategoría();
            }

            ProductoServicio productoServicio = new ProductoServicio();
            products product = new products();
            product.product_name = "PILSENER 600";
            product.product_purchase_price = 10.50m;
            product.product_sale_price = 15.50m;
            product.product_img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSWXiegcar_nm58gMO6SI66n6bGAeH_t_x1Rw&s";
            product.product_stock_quantity = 50;
            product.product_state = true;
            product.category_id = 1;
            productoServicio.InsertarProducto(product);

            IEnumerable<products> productos = productoServicio.listarProductos();

            return productos.Last();
        }

        public categories InsertarCategoría()
        {
            CategoriaServicio categoriaServicio = new CategoriaServicio();
            categories categoria = new categories();
            categoria.category_name = "PILSENER";
            categoria.category_state = true;
            categoriaServicio.InsertarCategoria(categoria);

            IEnumerable<categories> categorias = categoriaServicio.listarTodo();

            return categorias.Last();
        }

        //TABLA USUARIOS

        //INSERT

        public users InsertarUsuario()
        {
            UsuarioServicio usuarioServicio = new UsuarioServicio();
            users users = new users();

            users.rol_id = 1;
            users.user_name = "Grupo 5";
            users.user_email = "email@gmail.com";
            users.user_state = true;
            users.user_password = "123789654";

            return users;
        }
    }
}
