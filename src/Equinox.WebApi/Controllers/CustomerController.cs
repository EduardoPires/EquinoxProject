using System;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.WebApi.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService, IDomainNotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/list-all")]
        public IActionResult Index()
        {
            return Ok(_customerAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/customer-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return Ok(customerViewModel);
        }     

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(customerViewModel);
            _customerAppService.Register(customerViewModel);

            if (IsValidOperation())
                Ok();

            return BadRequest(Notifications);
        }
        
        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/edit-customer/{id:guid}")]
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

            return Ok(customerViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/edit-customer/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(customerViewModel);

            _customerAppService.Update(customerViewModel);

            if (IsValidOperation())
                Ok();

            return BadRequest(Notifications);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("customer-management/remove-customer/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return Ok(customerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("customer-management/remove-customer/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _customerAppService.Remove(id);

            if (!IsValidOperation()) return BadRequest(Notifications);

            return DeleteConfirmed(id);
        }

        [AllowAnonymous]
        [Route("customer-management/customer-history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var customerHistoryData = _customerAppService.GetAllHistory(id);
            return Ok(customerHistoryData);
        }
    }
}
