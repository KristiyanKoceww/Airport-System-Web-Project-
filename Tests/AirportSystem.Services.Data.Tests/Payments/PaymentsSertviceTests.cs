namespace AirportSystem.Services.Data.Tests.Payments
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Data.Models.Payment;
    using AirportSystem.Data.Models.Payments;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Payments;
    using Xunit;

    public class PaymentsSertviceTests : BaseServiceTests
    {
        [Fact]
        public void EnsureCreatePaymentIsWorkingCorrect()
        {
            var service = new PaymentService(this.DbContext);

            var paymentModel = new PaymentInputModel()
            {
                PassengerId = 2,
                TicketId = 3,
                PaymentStatus = "PaymentRecieved",
                Amount = 200,
            };

            service.Create(paymentModel);

            var payments = this.DbContext.Payments.Count();
            var expected = 1;

            Assert.Equal(expected, payments);
        }

        [Fact]
        public async Task EnsureGetAllPaymentsIsWorkingCorrect()
        {
            var service = new PaymentService(this.DbContext);

            var payment = new Payment()
            {
                PassengerId = 2,
                TicketId = 3,
                PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), "PaymentRecieved"),
                Amount = 200,
            };

            var payment2 = new Payment()
            {
                PassengerId = 3,
                TicketId = 4,
                PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), "PaymentRecieved"),
                Amount = 222,
            };

            await this.DbContext.Payments.AddAsync(payment);
            await this.DbContext.Payments.AddAsync(payment2);
            await this.DbContext.SaveChangesAsync();

            var count = service.GetAll().Count();
            var expected = 2;

            Assert.Equal(expected, count);
        }

        [Fact]
        public async Task EnsureGetPaymentsByPassengerIdIsWorkingCorrect()
        {
            var service = new PaymentService(this.DbContext);

            var payment = new Payment()
            {
                PassengerId = 2,
                TicketId = 3,
                PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), "PaymentRecieved"),
                Amount = 200,
            };

            await this.DbContext.Payments.AddAsync(payment);
            await this.DbContext.SaveChangesAsync();

            var expectedPaymentTicketId = 3;
            var passengerId = 2;
            var paymentByPassenger = service.GetPaymentsByPassengerId(passengerId);

            Assert.Equal(expectedPaymentTicketId, paymentByPassenger.TicketId);
        }

        [Fact]
        public async Task EnsureGetPaymentsByPassengerIdReturnNullWhenNoMatch()
        {
            var service = new PaymentService(this.DbContext);

            var payment = new Payment()
            {
                PassengerId = 2,
                TicketId = 3,
                PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), "PaymentRecieved"),
                Amount = 200,
            };

            await this.DbContext.Payments.AddAsync(payment);
            await this.DbContext.SaveChangesAsync();

            var passengerId = 3;
            var paymentByPassenger = service.GetPaymentsByPassengerId(passengerId);

            Assert.Null(paymentByPassenger);
        }

        [Fact]
        public async Task EnsureGetPaymentsByticketIdReturnNullWhenNoMatch()
        {
            var service = new PaymentService(this.DbContext);

            var payment = new Payment()
            {
                PassengerId = 2,
                TicketId = 3,
                PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), "PaymentRecieved"),
                Amount = 200,
            };

            await this.DbContext.Payments.AddAsync(payment);
            await this.DbContext.SaveChangesAsync();

            var ticketId = 2;
            var paymentByPassenger = service.GetPaymentsByTicketId(ticketId);

            Assert.Null(paymentByPassenger);
        }

        [Fact]
        public async Task EnsureGetPaymentsByticketIdWorkProperly()
        {
            var service = new PaymentService(this.DbContext);

            var payment = new Payment()
            {
                PassengerId = 2,
                TicketId = 3,
                PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), "PaymentRecieved"),
                Amount = 200,
            };

            await this.DbContext.Payments.AddAsync(payment);
            await this.DbContext.SaveChangesAsync();

            var ticketId = 3;
            var paymentByPassenger = service.GetPaymentsByTicketId(ticketId);

            Assert.NotNull(paymentByPassenger);
        }
    }
}
