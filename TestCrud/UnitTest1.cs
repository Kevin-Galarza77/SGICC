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
        readonly TipoTransferenciaServicio tipoTransferenciaServicio = new TipoTransferenciaServicio();
        readonly MovimientosServicio movimientoServicio = new MovimientosServicio();
        readonly TransferenciaServicio transferenciaServicio = new TransferenciaServicio();

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

        [TestMethod]
        public void TestTipoTransferencias()
        {
            transfer_types tipoTransferencia = InsertarTipoTransferencia();
        }

        [TestMethod]
        public void TestTipoTransferenciasPorEstado()
        {
            // Crear un tipo de transferencia
            transfer_types tipoTransferencia = InsertarTipoTransferencia();

            // Listar los tipos de transferencias por estado
            IEnumerable<transfer_types> tipoTransferencias = tipoTransferenciaServicio.listarTipoTransferenciasPorEstado(true);

            var dictionario = new Dictionary<bool, string>();
            dictionario.Add(true, "ACTIVO");
            dictionario.Add(false, "INACTIVO");

            // Mostrar los tipos de transferencias
            Console.WriteLine("Tipos de Transferencias encontradas con estado: "+ dictionario[true]);
            foreach (var item in tipoTransferencias)
            {
                Console.WriteLine(UtilityTest<transfer_types>.ToStringObject(item));
                Console.WriteLine("--------------------------------------------------");
            }

            // Eliminar el tipo de transferencia
            tipoTransferenciaServicio.EliminarTipoTransferencia(tipoTransferencia.transfer_type_id);
        }

        [TestMethod]
        public void TestTransferencias()
        {
            transfers transferencia = InsertarTransferencia();
        }

        [TestMethod]
        public void TestTransferenciaPorFecha()
        {
            // Crear una transferencia
            transfers transferencia = InsertarTransferencia();

            // Listar las transferencias por fecha de hace un mes hasta hoy
            IEnumerable<transfers> transferencias = transferenciaServicio.transferenciasPorFecha(DateTime.Now.AddMonths(-1), DateTime.Now);

            // Mostrar las transferencias
            Console.WriteLine("Transferencias encontradas en el rango de fechas");
            foreach (var item in transferencias)
            {
                Console.WriteLine(UtilityTest<transfers>.ToStringObject(item));
                Console.WriteLine("--------------------------------------------------");
            }

            // Eliminar la transferencia creada
            new TransferenciaServicio().EliminarTransferencia(transferencia.transfer_id);
        }

        [TestMethod]
        public void TestMovimientos()
        { 
            transfers transferencia = InsertarTransferencia();

            products product = InsertarProducto();

            stock_moves movimiento = new stock_moves();
            movimiento.product_id = product.product_id;
            movimiento.transfer_id = transferencia.transfer_id;
            movimiento.stock_move_quantity = 50;
            movimiento.stock_move_price_unit = 10.50m;
            movimientoServicio.InsertarMovimiento(movimiento);
        }

        [TestMethod]
        public void TestMovimientoPorTransferencia()
        {
            // Crear una transferencia
            transfers transferencia = InsertarTransferencia();

            // Crear un producto
            products product = InsertarProducto();

            // Crear un movimiento
            stock_moves movimiento = new stock_moves();
            movimiento.product_id = product.product_id;
            movimiento.transfer_id = transferencia.transfer_id;
            movimiento.stock_move_quantity = 50;
            movimiento.stock_move_price_unit = 10.50m;
            movimientoServicio.InsertarMovimiento(movimiento);

            // Crear otro movimiento

            products producto2 = InsertarProducto("PILSENER 600", 100, 5.50m, 10.50m);
            stock_moves movimiento2 = new stock_moves();
            movimiento2.product_id = producto2.product_id;
            movimiento2.transfer_id = transferencia.transfer_id;
            movimiento2.stock_move_quantity = 100;
            movimiento2.stock_move_price_unit = 5.50m;
            movimientoServicio.InsertarMovimiento(movimiento2);

            // Listar los movimientos por transferencia
            IEnumerable<stock_moves> movimientos = movimientoServicio.movimientosPorTransferencia(transferencia.transfer_id);

            // Mostrar los movimientos
            Console.WriteLine("Movimientos encontrados por transferencia");
            foreach (var item in movimientos)
            {
                Console.WriteLine(UtilityTest<stock_moves>.ToStringObject(item));
                Console.WriteLine("--------------------------------------------------");
            }

            // Eliminar movimientos
            movimientoServicio.EliminarMovimiento(movimiento.stock_move_id);
            movimientoServicio.EliminarMovimiento(movimiento2.stock_move_id);

            // Eliminar la transferencia
            transferenciaServicio.EliminarTransferencia(transferencia.transfer_id);
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

        public products InsertarProducto(String nombreProducto="PILSENER 600", int stockQuantity=50, decimal purchasePrice=10.50m, decimal salePrice=15.50m)
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
            product.product_name = nombreProducto;
            product.product_purchase_price = purchasePrice;
            product.product_sale_price = salePrice;
            product.product_img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSWXiegcar_nm58gMO6SI66n6bGAeH_t_x1Rw&s";
            product.product_stock_quantity = stockQuantity;
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
