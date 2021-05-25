using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ViewFeatures;

using RazorWebApp.Entities;
using RazorWebApp.Interfaces;
using RazorWebApp.Services;

namespace RazorWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IRegistradosRepositoryAsync _registrado;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;

        public IndexModel(ILogger<IndexModel> logger, IRegistradosRepositoryAsync registrado,
            IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _logger = logger;

            _registrado = registrado;
             _unitOfWork = unitOfWork;
            _renderService = renderService;
        }

        public IEnumerable<Registrados> Registrados { get; set; }

        public void OnGet()
        {

        }

        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            Registrados = await _registrado.GetAllAsync();

            return new PartialViewResult
            {
                ViewName = "_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<Registrados>>(ViewData, Registrados)

            };

        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new Registrados()) });
            else
            {
                var thisCustomer = await _registrado.GetByIdAsync(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisCustomer) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Registrados customer)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _registrado.AddAsync(customer);
                    await _unitOfWork.Commit();
                }
                else
                {
                    await _registrado.UpdateAsync(customer);
                    await _unitOfWork.Commit();
                }

                Registrados = await _registrado.GetAllAsync();
                var html = await _renderService.ToStringAsync("_ViewAll", Registrados);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEdit", customer);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var customer = await _registrado.GetByIdAsync(id);
            await _registrado.DeleteAsync(customer);
            await _unitOfWork.Commit();
            
            Registrados = await _registrado.GetAllAsync();
            
            var html = await _renderService.ToStringAsync("_ViewAll", Registrados);
            
            return new JsonResult(new { isValid = true, html = html });
        }

    }
}
