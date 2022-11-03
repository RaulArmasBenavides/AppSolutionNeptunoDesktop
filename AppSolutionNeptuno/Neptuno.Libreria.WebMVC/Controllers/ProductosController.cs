using Neptuno.Libreria.Business;
using Neptuno.Libreria.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neptuno.Libreria.WebMVC.Controllers
{
    public class ProductosController : Controller
    {
        //instancia objeto de la clase ProductoBll
        ProductoBLL obj = new ProductoBLL();
        ProveedorBLL opro = new ProveedorBLL();
        CategoriaBLL ocat = new CategoriaBLL();

        ProductoTO pro;


        // GET: Productos
        public ActionResult Index()
        {
            return View(obj.productoListar().ToList());
        }


        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            ProductoTO pro = new ProductoTO();
            pro.IdProducto = id;
            return View(obj.productoBuscar(pro));
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(ProductoTO pro)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    obj.productoProcesar(pro, 1);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            ProductoTO pro = new ProductoTO();
            pro.IdProducto = id;
            return View(obj.productoBuscar(pro));
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductoTO pro)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    obj.productoProcesar(pro, 2);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            ProductoTO pro = new ProductoTO();
            pro.IdProducto = id;
            return View(obj.productoBuscar(pro));
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ProductoTO pro = new ProductoTO();
                pro.IdProducto = id;
                if (ModelState.IsValid)
                {
                    obj.productoProcesar(pro, 3);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
