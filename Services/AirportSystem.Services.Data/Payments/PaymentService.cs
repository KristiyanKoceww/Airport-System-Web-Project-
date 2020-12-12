namespace AirportSystem.Services.Data.Payments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AirportSystem.Data;
    using AirportSystem.Data.Models.Payment;
    using AirportSystem.Data.Models.Payments;
    using AirportSystem.Services.Data.InputModels;

    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext db;

        public PaymentService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(PaymentInputModel paymentInputModel)
        {
            var payment = new Payment()
            {
                PassengerId = paymentInputModel.PassengerId,
                TicketId = paymentInputModel.TicketId,
                PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), paymentInputModel.PaymentStatus),
                Amount = paymentInputModel.Amount,
            };

            this.db.Payments.Add(payment);
            this.db.SaveChanges();
        }

        public IEnumerable<Payment> GetAll()
        {
            var payments = this.db.Payments.Select(x => new Payment()
            {
                PassengerId = x.PassengerId,
                TicketId = x.TicketId,
                PaymentStatus = x.PaymentStatus,
            }).ToList();

            return payments;
        }

        public Payment GetPaymentsByPassengerId(int passengerId)
        {
            var peymant = this.db.Payments.Where(x => x.PassengerId == passengerId).FirstOrDefault();

            return peymant;
        }

        public Payment GetPaymentsByTicketId(int ticketId)
        {
            var peymant = this.db.Payments.Where(x => x.TicketId == ticketId).FirstOrDefault();

            return peymant;
        }
    }
}
