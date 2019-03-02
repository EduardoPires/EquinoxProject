using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Equinox.UI.Web.Controllers
{
    [Authorize]
    [Route("customer-management")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _customerAppService = customerAppService;
        }

        [AllowAnonymous]
        [HttpGet("list-all")]
        public IActionResult Index()
        {
            return View(_customerAppService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("customer-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpGet("register-new")]
        [Authorize(Policy = "CanWriteCustomerData")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("register-new")]
        [Authorize(Policy = "CanWriteCustomerData")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);
            _customerAppService.Register(customerViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Registered!";

            return View(customerViewModel);
        }

        [HttpGet("edit-customer/{id:guid}")]
        [Authorize(Policy = "CanWriteCustomerData")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpPost("edit-customer/{id:guid}")]
        [Authorize(Policy = "CanWriteCustomerData")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);

            _customerAppService.Update(customerViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Updated!";

            return View(customerViewModel);
        }

        [HttpGet("remove-customer/{id:guid}")]
        [Authorize(Policy = "CanRemoveCustomerData")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpPost("remove-customer/{id:guid}"), ActionName("Delete")]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _customerAppService.Remove(id);

            if (!IsValidOperation()) return View(_customerAppService.GetById(id));

            ViewBag.Sucesso = "Customer Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("customer-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var customerHistoryData = _customerAppService.GetAllHistory(id);
            return Json(customerHistoryData);
        }
    }
}