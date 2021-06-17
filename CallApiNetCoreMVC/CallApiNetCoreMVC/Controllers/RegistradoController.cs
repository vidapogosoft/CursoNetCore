using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoreModel;
using CoreApiClient;
using CallApiNetCoreMVC.Models;
using CallApiNetCoreMVC.Factory;

using Microsoft.Extensions.Options;

namespace CallApiNetCoreMVC.Controllers
{
    public class RegistradoController : Controller
    {

        private readonly IOptions<MySettingsModel> appSettings;
        public string url;

        public RegistradoController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
           
        }

        // GET: RegistradoController
        public async Task<IActionResult> Index()
        {

            var data = await ApiClientFactory
                .Instance.GetRegistrados();

            return View(data);
        }

        // GET: RegistradoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistradoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistradoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistrado,Identificacion,Nombres,Apellidos,NombresCompletos")] RegistradoModel registrado)
        {
            try
            {

                var response = await ApiClientFactory.Instance.SaveRegistrado(registrado);

                if (response)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Json("Error en registro de datos");
                }

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        // GET: RegistradoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistradoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistradoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistradoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
