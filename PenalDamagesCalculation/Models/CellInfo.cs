using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenalDamagesCalculation.Models
{
    internal class CellInfo
    {
        public bool dateBegining { get; set; }
        public bool dateEnd { get; set; }
        public bool isNewPeriod { get; set; }
        public double paymentPeriodMoney { get; set; }
        public double penalPercentage { get; set; }
        public bool isMoneyPaid { get; set; }
        public double moneyPaidOnDate { get; set; }
    }

}
