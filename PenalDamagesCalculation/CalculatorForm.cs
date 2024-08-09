using System.Runtime.CompilerServices;
using PenalDamagesCalculation.CalculatorLogic;
using PenalDamagesCalculation.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PenalDamagesCalculation
{
    public partial class CalculatorForm : Form
    {
        private ValueCalculator valueCalculator = new ValueCalculator();
        private DateTime selectedDate { get => Calendar.SelectionRange.Start; }
        private double newPeriodMoney { get => double.Parse(input_newPeriod.Text); }
        private double moneyPaidOnDate { get => double.Parse(input_paidMoneyOnDate.Text); }
        private double penalPercentageInput { get => double.Parse(input_penalPercentage.Text); }

        public CalculatorForm()
        {
            InitializeComponent();
            groupBox_settings.Text = selectedDate.ToShortDateString();

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            toStandardDesign();

            CellInfo cellInfo = valueCalculator.GetDayInfo(selectedDate);
            if (cellInfo != null)
            {
                if (cellInfo.dateBegining)
                {
                    toggleBeginningDateDesignItems(true);

                }
                else if (cellInfo.dateEnd)
                {
                    checkBox_endDate.Checked = true;
                    checkBox_BeginningDate.Checked = false;
                    checkBox_BeginningDate.Enabled = false;
                }

                if (cellInfo.isNewPeriod)
                {
                    toggleNewPeriodDesignItems(true);

                    input_newPeriod.Text = cellInfo.paymentPeriodMoney.ToString();

                    togglePenalDesignItems(true);
                    input_penalPercentage.Text = cellInfo.penalPercentage.ToString();

                }

                if (cellInfo.isMoneyPaid)
                {
                    toggleMoneyPaid(true);
                    input_paidMoneyOnDate.Text = cellInfo.moneyPaidOnDate.ToString();

                    togglePenalDesignItems(true);
                    input_penalPercentage.Text = cellInfo.penalPercentage.ToString();

                }

            }
        }

        //----- design toggles --------

        private void toStandardDesign()
        {
            checkBox_BeginningDate.Checked = false;
            checkBox_endDate.Checked = false;

            checkBox_BeginningDate.Enabled = true;
            checkBox_endDate.Enabled = true;

            checkBox_paidMoneyOnDate.Checked = false;
            checkBox_paidMoneyOnDate.Enabled = true;
            input_paidMoneyOnDate.Enabled = false;

            checkBox_newPeriod.Checked = false;
            checkBox_newPeriod.Enabled = true;
            input_newPeriod.Enabled = false;

            togglePenalDesignItems(false);

            groupBox_settings.Text = selectedDate.ToShortDateString();
        }
        private void togglePenalDesignItems(bool option)
        {
            label_Penal.Visible = option;
            input_penalPercentage.Visible = option;
            input_penalPercentage.Enabled = option;
        }

        private void toggleNewPeriodDesignItems(bool option)
        {
            checkBox_newPeriod.Checked = option;
            input_newPeriod.Enabled = option;
        }

        private void toggleMoneyPaid(bool option)
        {
            checkBox_paidMoneyOnDate.Checked = option;
            input_paidMoneyOnDate.Enabled = option;
        }

        private void toggleBeginningDateDesignItems(bool option)
        {
            checkBox_BeginningDate.Checked = option;
            checkBox_endDate.Enabled = !option;

            toggleNewPeriodDesignItems(option);
            checkBox_newPeriod.Enabled = !option;

            togglePenalDesignItems(option);
        }


        //-------- checkBox actions ---------

        private void checkBox_BeginningDate_Click(object sender, EventArgs e)
        {
            if (checkBox_BeginningDate.CheckState == CheckState.Checked)
            {
                try
                {
                    valueCalculator.AddBorder(selectedDate, 0);
                    valueCalculator.AddPaymentPeriodMoney(selectedDate, newPeriodMoney);
                    valueCalculator.AddMoneyPaidOnDate(selectedDate, moneyPaidOnDate);
                    valueCalculator.SetPenal(selectedDate, penalPercentageInput);
                }
                catch (Exception err) { Console.WriteLine(err.Message); }

                toggleBeginningDateDesignItems(true);
            }
            else if (checkBox_BeginningDate.CheckState == CheckState.Unchecked)
            {
                valueCalculator.DeleteBorder(selectedDate, 0);

                toStandardDesign();
            }
            DrawTableInfo();
        }

        private void checkBox_endDate_Click(object sender, EventArgs e)
        {
            if (checkBox_endDate.CheckState == CheckState.Checked)
            {
                try
                {
                    valueCalculator.AddBorder(selectedDate, 1);
                    checkBox_BeginningDate.Enabled = false;
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                DrawTableInfo();
            }
            else if (checkBox_endDate.CheckState == CheckState.Unchecked)
            {
                valueCalculator.DeleteBorder(selectedDate, 1);
                checkBox_BeginningDate.Enabled = true;
            }
        }
        private void checkBox_newPeriod_Click(object sender, EventArgs e)
        {
            if (checkBox_newPeriod.CheckState == CheckState.Checked)
            {
                valueCalculator.AddPaymentPeriodMoney(selectedDate, newPeriodMoney);
                valueCalculator.SetPenal(selectedDate, penalPercentageInput);

                togglePenalDesignItems(true);
                toggleNewPeriodDesignItems(true);
            }
            else if (checkBox_newPeriod.CheckState == CheckState.Unchecked)
            {
                valueCalculator.DeletePaymentPeriodMoney(selectedDate);

                togglePenalDesignItems(false);
                toggleNewPeriodDesignItems(false);
            }
            DrawTableInfo();
        }
        private void checkBox_paidMoneyOnDate_Click(object sender, EventArgs e)
        {
            if (checkBox_paidMoneyOnDate.CheckState == CheckState.Checked)
            {
                valueCalculator.AddMoneyPaidOnDate(selectedDate, moneyPaidOnDate);
                valueCalculator.SetPenal(selectedDate, penalPercentageInput);

                togglePenalDesignItems(true);
                toggleMoneyPaid(true);
            }
            else if (checkBox_paidMoneyOnDate.CheckState == CheckState.Unchecked)
            {
                valueCalculator.DeleteMoneyPaidOnDate(selectedDate);

                togglePenalDesignItems(false);
                toggleMoneyPaid(false);
            }
            DrawTableInfo();
        }

        //---- input reader ---------

        private void input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.ActiveControl = null;
            }
            else if (e.KeyChar != 8)
            {
                e.Handled = CheckStringFormat((e.KeyChar), (sender as TextBox).Text);
            }
        }

        private void input_paidMoneyOnDate_Leave(object sender, EventArgs e)
        {
            try
            {
                valueCalculator.UpdateMoneyPaidOnDate(selectedDate, moneyPaidOnDate);
                valueCalculator.SetPenal(selectedDate, penalPercentageInput);

                DrawTableInfo();
            }
            catch
            {
                input_paidMoneyOnDate.Text = "";
            }
        }

        private void input_newPeriod_Leave(object sender, EventArgs e)
        {
            try
            {
                valueCalculator.UpdatePaymentPeriodMoney(selectedDate, newPeriodMoney);
                valueCalculator.SetPenal(selectedDate, penalPercentageInput);

                DrawTableInfo();
            }
            catch
            {
                input_newPeriod.Text = "";
            }
        }

        private void input_penalPercentage_Leave(object sender, EventArgs e)
        {
            try
            {
                valueCalculator.SetPenal(selectedDate, penalPercentageInput);
                DrawTableInfo();
            }
            catch
            {
                input_penalPercentage.Text = "";
            }
        }

        //------ table render -------

        private void penalDataTable_Click(object sender, EventArgs e)
        {
            DrawTableInfo();
        }
        private void DrawTableInfo()
        {
            List<PenalTableData> tableInfo = valueCalculator.CountPenalDamages();
            if (tableInfo == null)
                return;
            while (penalDataTable.Rows.Count > 0)
            {

                penalDataTable.Rows.RemoveAt(penalDataTable.Rows.Count - 1);
            }

            foreach (var item in tableInfo)
            {
                penalDataTable.Rows.Add(
                    item.requiredPayment,
                    item.moneyPaid,
                    item.dateOfPayment,
                    item.arrears,
                    item.penalPercentage,
                    item.paymentTerm[0].ToShortDateString(),
                    item.paymentTerm[1].ToShortDateString(),
                    item.numOfOverdueDays,
                    item.penalAmount);
            }
        }

        //----------------------------------
        private static bool CheckStringFormat(char newSymbol, string existingInputString)
        {
            return (char.IsNumber(newSymbol) || newSymbol.Equals(',') && !(existingInputString.IndexOf(",") > -1)) ? false : true;
        }

        
    }
}
