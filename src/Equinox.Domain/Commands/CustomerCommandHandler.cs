using System;
using System.Threading;
using System.Threading.Tasks;
using Equinox.Domain.Events;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace Equinox.Domain.Commands
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, ValidationResult>,
        IRequestHandler<UpdateCustomerCommand, ValidationResult>,
        IRequestHandler<RemoveCustomerCommand, ValidationResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = Customer.RegisterNewCustomer(message.Name, message.Email, message.BirthDate);

            if (await _customerRepository.GetByEmail(customer.Email) != null)
            {
                AddError("The customer e-mail has already been taken.");
                return ValidationResult;
            }

            _customerRepository.Add(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _customerRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("This customer does not exist.");
                return ValidationResult;
            }

            var existingCustomer = await _customerRepository.GetByEmail(message.Email);

            if (existingCustomer != null && existingCustomer.Id != message.Id)
            {
                if (!existingCustomer.Equals(message))
                {
                    AddError("The customer e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            customer.UpdateCustomer(message.Name, message.Email, message.BirthDate);

            _customerRepository.Update(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _customerRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            customer.RemoveCustomer();

            _customerRepository.Remove(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}