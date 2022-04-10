namespace GeradorDeContratos.services
{
    class PaypalService : IOnlinePaymentService
    {
        private const double FEE_PERCENTAGE = 0.02;
        private const double MONTHLY_INTEREST = 0.01;

        public double PaymentFee(double value)
        {
            return value + (value * FEE_PERCENTAGE);
        }

        public double Interest(double value, int months)
        {
            return value + value * MONTHLY_INTEREST * months;
        }
    }
}
