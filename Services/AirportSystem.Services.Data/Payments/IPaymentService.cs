namespace AirportSystem.Services.Data.Payments
{
    using System.Collections.Generic;

    using AirportSystem.Data.Models.Payments;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.ViewModels;

    public interface IPaymentService
    {
        void Create(PaymentInputModel paymentInputModel);

        Payment GetPaymentsByPassengerId(int passengerId);

        Payment GetPaymentsByTicketId(int ticketId);

        IEnumerable<PaymentsViewModel> GetAll();
    }
}
