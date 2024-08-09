using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using PenalDamagesCalculation.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PenalDamagesCalculation.CalculatorLogic
{
    internal class ValueCalculator
    {
        private Dictionary<int, CellInfo> specialCalendarDays;
        //First - begining, second - end
        public DateTime[] borderDays { get; private set; }

        public ValueCalculator()
        {
            borderDays = new DateTime[2];
            specialCalendarDays = new Dictionary<int, CellInfo>();
        }

        //----------------------------

        private int DateToInt(DateTime date)
        {
            return int.Parse(date.ToShortDateString().Replace(".", string.Empty));
        }

        //---- Border Operations----------------

        public void AddBorder(DateTime newBorder, int typeOfBorder)
        {
            if (typeOfBorder > 1 && typeOfBorder < 0)
                throw new ArgumentOutOfRangeException("typeOfBorder", "parameter must be either 0 or 1");

            if (borderDays[typeOfBorder].Year == 1)
                borderDays[typeOfBorder] = newBorder;
            else if (borderDays[typeOfBorder].CompareTo(newBorder) == 0)
                return;
            else
                DeleteBorder(borderDays[typeOfBorder], typeOfBorder);

            if (typeOfBorder == 0)
                specialCalendarDays.TryAdd(DateToInt(newBorder), new CellInfo { dateBegining = true });
            else
                specialCalendarDays.TryAdd(DateToInt(newBorder), new CellInfo { dateEnd = true });

            borderDays[typeOfBorder] = newBorder;

        }

        public void DeleteBorder(DateTime borderToDelete, int typeOfBorder)
        {
            if (typeOfBorder > 1 && typeOfBorder < 0)
                throw new ArgumentOutOfRangeException("typeOfBorder", "parameter must be either 0 or 1");

            if (borderToDelete.CompareTo(borderDays[typeOfBorder]) == 0)
            {
                borderDays[typeOfBorder] = borderDays[typeOfBorder].AddYears(-borderDays[typeOfBorder].Year + 1).AddMonths(-borderDays[typeOfBorder].Month + 1).AddDays(-borderDays[typeOfBorder].Day + 1);

                try
                {
                    specialCalendarDays.Remove(DateToInt(borderToDelete));
                }
                catch (Exception err) { Console.WriteLine(err.Message); }
            }
        }

        //------ Payment period Operations-----------------

        public void AddPaymentPeriodMoney(DateTime dateId, double payment)
        {
            if (UpdatePaymentPeriodMoney(dateId, payment))
                return;
            else
            {
                CellInfo cellInfo;
                int id = DateToInt(dateId);

                cellInfo = new CellInfo();
                cellInfo.paymentPeriodMoney = payment;
                cellInfo.isNewPeriod = true;
                specialCalendarDays.Add(id, cellInfo);
            }
        }
        public bool UpdatePaymentPeriodMoney(DateTime dateId, double payment)
        {
            CellInfo cellInfo;
            int id = DateToInt(dateId);

            if (specialCalendarDays.TryGetValue(id, out cellInfo))
            {
                cellInfo.paymentPeriodMoney = payment;
                return true;
            }
            return false;
        }
        public void DeletePaymentPeriodMoney(DateTime dateId)
        {
            int id = DateToInt(dateId);

            if (specialCalendarDays.ContainsKey(id))
            {
                specialCalendarDays.Remove(id);
            }
        }

        //------- Money paid operations------------

        public void AddMoneyPaidOnDate(DateTime dateId, double moneyPaid)
        {
            if (UpdateMoneyPaidOnDate(dateId, moneyPaid))
                return;
            else
            {
                CellInfo cellInfo = new CellInfo();
                int id = DateToInt(dateId);

                cellInfo.moneyPaidOnDate = moneyPaid;
                cellInfo.isMoneyPaid = true;
                specialCalendarDays.Add(id, cellInfo);
            }
        }
        public bool UpdateMoneyPaidOnDate(DateTime dateId, double moneyPaid)
        {
            CellInfo cellInfo;
            int id = DateToInt(dateId);

            if (specialCalendarDays.TryGetValue(id, out cellInfo))
            {
                cellInfo.moneyPaidOnDate = moneyPaid;
                return true;
            }
            return false;
        }
        public void DeleteMoneyPaidOnDate(DateTime dateId)
        {
            int id = DateToInt(dateId);

            if (specialCalendarDays.ContainsKey(id))
            {
                specialCalendarDays.Remove(id);
            }
        }

        //----------Penal Operations----------------

        public void SetPenal(DateTime dateId, double newPenal)
        {
            CellInfo cellInfo;
            int id = DateToInt(dateId);
            if (specialCalendarDays.TryGetValue(id, out cellInfo))
                cellInfo.penalPercentage = newPenal;
        }

        //------ Functions that return data--------------

        public CellInfo GetDayInfo(DateTime date)
        {

            int id = DateToInt(date);
            CellInfo cellInfo = new CellInfo();
            if (specialCalendarDays.TryGetValue(id, out cellInfo))
                return cellInfo;

            return null;
        }

        public List<PenalTableData> CountPenalDamages()
        {
            if (borderDays[0].Year == 1 || borderDays[1].Year == 1)
                return null;


            List<PenalTableData> penalTableList = new List<PenalTableData>();
            CellInfo cellInfo;

            double totalPenal = 0;
            int daysOfPeriod = 1;

            DateTime dateOfCalc = borderDays[0];

            specialCalendarDays.TryGetValue(DateToInt(dateOfCalc), out cellInfo);

            double penalPercentage = cellInfo.penalPercentage;
            double debtMoney = cellInfo.paymentPeriodMoney - cellInfo.moneyPaidOnDate;
            double moneyRequired;

            while (dateOfCalc.CompareTo(borderDays[1]) <= 0)
            {
                dateOfCalc = dateOfCalc.AddDays(1);
                daysOfPeriod++;

                if (specialCalendarDays.TryGetValue(DateToInt(dateOfCalc), out cellInfo))
                {
                    totalPenal += daysOfPeriod * penalPercentage * debtMoney / 100;

                    moneyRequired = debtMoney;
                    debtMoney += -cellInfo.moneyPaidOnDate + cellInfo.paymentPeriodMoney;

                    penalTableList.Add(new PenalTableData(moneyRequired, cellInfo.moneyPaidOnDate, dateOfCalc, debtMoney, penalPercentage, new DateTime[2] { dateOfCalc.AddDays(-daysOfPeriod + 1), dateOfCalc }, daysOfPeriod, totalPenal));

                    penalPercentage = cellInfo.penalPercentage;
                    daysOfPeriod = 1;
                }
            }

            return penalTableList;
        }
    }
}
