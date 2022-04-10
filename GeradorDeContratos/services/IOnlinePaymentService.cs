namespace GeradorDeContratos.services
{
    public interface IOnlinePaymentService
    {
        public double PaymentFee(double value);

        public double Interest(double value, int months);
    }
}
