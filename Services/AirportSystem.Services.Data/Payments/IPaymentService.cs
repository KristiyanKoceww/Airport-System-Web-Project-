namespace AirportSystem.Services.Data.Payments
{
    using System.Collections.Generic;

    using AirportSystem.Data.Models.Payments;
    using AirportSystem.Services.Data.InputModels;

    public interface IPaymentService
    {
        void Create(PaymentInputModel paymentInputModel);

        Payment GetPaymentsByPassengerId(string passengerId);

        Payment GetPaymentsByTicketId(string ticketId);

        IEnumerable<Payment> GetAll();
    }
}
