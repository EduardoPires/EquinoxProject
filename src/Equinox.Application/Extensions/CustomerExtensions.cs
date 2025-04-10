using Equinox.Application.ViewModels;
using Equinox.Domain.Commands;
using Equinox.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Equinox.Application.Extensions
{
    public static class CustomerExtensions
    {
        public static CustomerViewModel ToViewModel(this Customer customer)
        {
            if (customer == null) return null;

            return new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                BirthDate = customer.BirthDate
            };
        }

        public static IEnumerable<CustomerViewModel> ToViewModel(this IEnumerable<Customer> customers)
        {
            return customers?.Select(c => c.ToViewModel());
        }

        public static Customer ToEntity(this CustomerViewModel customer)
        {
            if (customer == null) return null;

            return new Customer(customer.Id, customer.Name, customer.Email, customer.BirthDate);
        }

        public static RegisterNewCustomerCommand ToRegisterCommand(this CustomerViewModel customer)
        {
            if (customer == null) return null;

            return new RegisterNewCustomerCommand(customer.Name, customer.Email, customer.BirthDate);
        }

        public static UpdateCustomerCommand ToUpdateCommand(this CustomerViewModel customer)
        {
            if (customer == null) return null;

            return new UpdateCustomerCommand(customer.Id, customer.Name, customer.Email, customer.BirthDate);
        }
    }
}
