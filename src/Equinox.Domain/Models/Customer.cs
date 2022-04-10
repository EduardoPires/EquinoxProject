using System;
using Equinox.Domain.Events;
using NetDevPack.Domain;

namespace Equinox.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        #region Ctors

        // Empty constructor for EF
        protected Customer() { }

        private Customer(string name, string email, DateTime birthDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            BirthDate = birthDate;

            AddDomainEvent(new CustomerRegisteredEvent(Id, Name, Email, BirthDate));
        }

        #endregion

        #region Props

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        #endregion

        #region Methods

        public static Customer RegisterNewCustomer(string name, string email, DateTime birthDate)
        {
            return new Customer(name, email, birthDate);
        }

        public void UpdateCustomer(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;

            AddDomainEvent(new CustomerUpdatedEvent(Id, Name, Email, BirthDate));
        }

        public void RemoveCustomer()
        {
            AddDomainEvent(new CustomerRemovedEvent(Id));
        }

        #endregion
    }
}