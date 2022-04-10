using System;
using GeradorDeContratos.entities;

namespace GeradorDeContratos.services
{
    class ProcessoContrato
    {
        private IOnlinePaymentService _paymentService;

        public ProcessoContrato(IOnlinePaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public bool GerarContrato(Contrato contrato, int months)
        {
            if (contrato == null)
                return false;

            double basicQuota = (double) contrato.TotalValue / months;
            contrato.NumParcela = months;

            for (int i = 1; i <= months; i++)
            {
                DateTime date = contrato.DateContract.AddMonths(i);
                double updatedQuota = _paymentService.Interest(basicQuota, i);
                double fullQuota = _paymentService.PaymentFee(updatedQuota);
                contrato.AddParcelas(new Parcela(date, fullQuota));
            }

            return true;
        }
    }
}
