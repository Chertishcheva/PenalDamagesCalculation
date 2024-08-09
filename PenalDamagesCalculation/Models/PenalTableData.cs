using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenalDamagesCalculation.Models
{
    internal class PenalTableData
    {
        public double requiredPayment { get; set; }
        public double moneyPaid { get; set; }
        public DateTime dateOfPayment { get; set; }
        public double arrears { get; set; }
        public double penalPercentage { get; set; }
        public DateTime[] paymentTerm { get; set; }
        public int numOfOverdueDays { get; set; }
        public double penalAmount { get; set; }

        public PenalTableData()
        {
            paymentTerm = new DateTime[2];
        }

        public PenalTableData(double requiredPayment, double moneyPaid, DateTime dateOfPayment, double arrears, double penalPercentage, DateTime[] paymentTerm, int numOfOverdueDays, double penalAmount)
        {
            this.requiredPayment = requiredPayment;
            this.moneyPaid = moneyPaid;
            this.dateOfPayment = dateOfPayment;
            this.arrears = arrears;
            this.penalPercentage = penalPercentage;
            this.paymentTerm = paymentTerm;
            this.numOfOverdueDays = numOfOverdueDays;
            this.penalAmount = penalAmount;
        }

    }
}
