namespace PenalDamagesCalculation
{
    partial class CalculatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Calendar = new MonthCalendar();
            groupBox_settings = new GroupBox();
            input_penalPercentage = new TextBox();
            label_Penal = new Label();
            checkBox_endDate = new CheckBox();
            checkBox_paidMoneyOnDate = new CheckBox();
            input_paidMoneyOnDate = new TextBox();
            checkBox_BeginningDate = new CheckBox();
            input_newPeriod = new TextBox();
            checkBox_newPeriod = new CheckBox();
            penalDataTable = new DataGridView();
            requiredPayment = new DataGridViewTextBoxColumn();
            moneyPaid = new DataGridViewTextBoxColumn();
            dateOfPayment = new DataGridViewTextBoxColumn();
            arrears = new DataGridViewTextBoxColumn();
            penalPercentage = new DataGridViewTextBoxColumn();
            periodBegin = new DataGridViewTextBoxColumn();
            PeriodEnd = new DataGridViewTextBoxColumn();
            numOfOverdueDays = new DataGridViewTextBoxColumn();
            penalAmount = new DataGridViewTextBoxColumn();
            groupBox_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)penalDataTable).BeginInit();
            SuspendLayout();
            // 
            // Calendar
            // 
            Calendar.Location = new Point(5, 18);
            Calendar.MaxSelectionCount = 1;
            Calendar.Name = "Calendar";
            Calendar.TabIndex = 0;
            Calendar.DateSelected += monthCalendar1_DateSelected;
            // 
            // groupBox_settings
            // 
            groupBox_settings.Controls.Add(input_penalPercentage);
            groupBox_settings.Controls.Add(label_Penal);
            groupBox_settings.Controls.Add(checkBox_endDate);
            groupBox_settings.Controls.Add(checkBox_paidMoneyOnDate);
            groupBox_settings.Controls.Add(input_paidMoneyOnDate);
            groupBox_settings.Controls.Add(checkBox_BeginningDate);
            groupBox_settings.Controls.Add(input_newPeriod);
            groupBox_settings.Controls.Add(checkBox_newPeriod);
            groupBox_settings.Location = new Point(223, 12);
            groupBox_settings.Name = "groupBox_settings";
            groupBox_settings.Size = new Size(368, 213);
            groupBox_settings.TabIndex = 2;
            groupBox_settings.TabStop = false;
            // 
            // input_penalPercentage
            // 
            input_penalPercentage.Enabled = false;
            input_penalPercentage.Location = new Point(184, 172);
            input_penalPercentage.Name = "input_penalPercentage";
            input_penalPercentage.Size = new Size(125, 27);
            input_penalPercentage.TabIndex = 9;
            input_penalPercentage.Text = "0";
            input_penalPercentage.Visible = false;
            input_penalPercentage.KeyPress += input_KeyPress;
            input_penalPercentage.Leave += input_penalPercentage_Leave;
            // 
            // label_Penal
            // 
            label_Penal.AutoSize = true;
            label_Penal.BackColor = Color.Transparent;
            label_Penal.Location = new Point(184, 143);
            label_Penal.Name = "label_Penal";
            label_Penal.Size = new Size(89, 20);
            label_Penal.TabIndex = 10;
            label_Penal.Text = "Ставка пені";
            label_Penal.Visible = false;
            // 
            // checkBox_endDate
            // 
            checkBox_endDate.AutoSize = true;
            checkBox_endDate.Location = new Point(185, 26);
            checkBox_endDate.Name = "checkBox_endDate";
            checkBox_endDate.Size = new Size(120, 24);
            checkBox_endDate.TabIndex = 9;
            checkBox_endDate.Text = "Кінцева дата";
            checkBox_endDate.UseVisualStyleBackColor = true;
            checkBox_endDate.Click += checkBox_endDate_Click;
            // 
            // checkBox_paidMoneyOnDate
            // 
            checkBox_paidMoneyOnDate.AutoSize = true;
            checkBox_paidMoneyOnDate.Location = new Point(5, 142);
            checkBox_paidMoneyOnDate.Name = "checkBox_paidMoneyOnDate";
            checkBox_paidMoneyOnDate.Size = new Size(173, 24);
            checkBox_paidMoneyOnDate.TabIndex = 4;
            checkBox_paidMoneyOnDate.Text = "Борг було оплачено";
            checkBox_paidMoneyOnDate.UseVisualStyleBackColor = true;
            checkBox_paidMoneyOnDate.Click += checkBox_paidMoneyOnDate_Click;
            // 
            // input_paidMoneyOnDate
            // 
            input_paidMoneyOnDate.Enabled = false;
            input_paidMoneyOnDate.Location = new Point(29, 172);
            input_paidMoneyOnDate.Name = "input_paidMoneyOnDate";
            input_paidMoneyOnDate.Size = new Size(125, 27);
            input_paidMoneyOnDate.TabIndex = 5;
            input_paidMoneyOnDate.Text = "0";
            input_paidMoneyOnDate.KeyPress += input_KeyPress;
            input_paidMoneyOnDate.Leave += input_paidMoneyOnDate_Leave;
            // 
            // checkBox_BeginningDate
            // 
            checkBox_BeginningDate.AutoSize = true;
            checkBox_BeginningDate.Location = new Point(6, 26);
            checkBox_BeginningDate.Name = "checkBox_BeginningDate";
            checkBox_BeginningDate.Size = new Size(139, 24);
            checkBox_BeginningDate.TabIndex = 2;
            checkBox_BeginningDate.Text = "Початкова дата";
            checkBox_BeginningDate.UseVisualStyleBackColor = true;
            checkBox_BeginningDate.Click += checkBox_BeginningDate_Click;
            // 
            // input_newPeriod
            // 
            input_newPeriod.Enabled = false;
            input_newPeriod.Location = new Point(29, 108);
            input_newPeriod.Name = "input_newPeriod";
            input_newPeriod.Size = new Size(125, 27);
            input_newPeriod.TabIndex = 8;
            input_newPeriod.Text = "0";
            input_newPeriod.KeyPress += input_KeyPress;
            input_newPeriod.Leave += input_newPeriod_Leave;
            // 
            // checkBox_newPeriod
            // 
            checkBox_newPeriod.AutoSize = true;
            checkBox_newPeriod.Location = new Point(5, 78);
            checkBox_newPeriod.Name = "checkBox_newPeriod";
            checkBox_newPeriod.Size = new Size(128, 24);
            checkBox_newPeriod.TabIndex = 7;
            checkBox_newPeriod.Text = "Новий період";
            checkBox_newPeriod.UseVisualStyleBackColor = true;
            checkBox_newPeriod.Click += checkBox_newPeriod_Click;
            // 
            // penalDataTable
            // 
            penalDataTable.AllowUserToAddRows = false;
            penalDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            penalDataTable.Columns.AddRange(new DataGridViewColumn[] { requiredPayment, moneyPaid, dateOfPayment, arrears, penalPercentage, periodBegin, PeriodEnd, numOfOverdueDays, penalAmount });
            penalDataTable.Location = new Point(5, 251);
            penalDataTable.Name = "penalDataTable";
            penalDataTable.ReadOnly = true;
            penalDataTable.RowHeadersWidth = 51;
            penalDataTable.Size = new Size(1176, 355);
            penalDataTable.TabIndex = 3;
            penalDataTable.Click += penalDataTable_Click;
            // 
            // requiredPayment
            // 
            requiredPayment.HeaderText = "Необхідний платіж";
            requiredPayment.MinimumWidth = 6;
            requiredPayment.Name = "requiredPayment";
            requiredPayment.ReadOnly = true;
            requiredPayment.Width = 125;
            // 
            // moneyPaid
            // 
            moneyPaid.HeaderText = "Сплачено";
            moneyPaid.MinimumWidth = 6;
            moneyPaid.Name = "moneyPaid";
            moneyPaid.ReadOnly = true;
            moneyPaid.Width = 125;
            // 
            // dateOfPayment
            // 
            dateOfPayment.HeaderText = "Дата оплати";
            dateOfPayment.MinimumWidth = 6;
            dateOfPayment.Name = "dateOfPayment";
            dateOfPayment.ReadOnly = true;
            dateOfPayment.Width = 125;
            // 
            // arrears
            // 
            arrears.HeaderText = "Залишок заборгованості";
            arrears.MinimumWidth = 6;
            arrears.Name = "arrears";
            arrears.ReadOnly = true;
            arrears.Width = 125;
            // 
            // penalPercentage
            // 
            penalPercentage.HeaderText = "Відсоток пені";
            penalPercentage.MinimumWidth = 6;
            penalPercentage.Name = "penalPercentage";
            penalPercentage.ReadOnly = true;
            penalPercentage.Width = 125;
            // 
            // periodBegin
            // 
            periodBegin.HeaderText = "Нарахування з";
            periodBegin.MinimumWidth = 6;
            periodBegin.Name = "periodBegin";
            periodBegin.ReadOnly = true;
            periodBegin.Width = 125;
            // 
            // PeriodEnd
            // 
            PeriodEnd.HeaderText = "Нарахування до";
            PeriodEnd.MinimumWidth = 6;
            PeriodEnd.Name = "PeriodEnd";
            PeriodEnd.ReadOnly = true;
            PeriodEnd.Width = 125;
            // 
            // numOfOverdueDays
            // 
            numOfOverdueDays.HeaderText = "Дні прострочення";
            numOfOverdueDays.MinimumWidth = 6;
            numOfOverdueDays.Name = "numOfOverdueDays";
            numOfOverdueDays.ReadOnly = true;
            numOfOverdueDays.Width = 125;
            // 
            // penalAmount
            // 
            penalAmount.HeaderText = "Пеня ";
            penalAmount.MinimumWidth = 6;
            penalAmount.Name = "penalAmount";
            penalAmount.ReadOnly = true;
            penalAmount.Width = 125;
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 618);
            Controls.Add(penalDataTable);
            Controls.Add(groupBox_settings);
            Controls.Add(Calendar);
            Name = "CalculatorForm";
            Text = "Калькулятор пені";
            groupBox_settings.ResumeLayout(false);
            groupBox_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)penalDataTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar Calendar;
        private GroupBox groupBox_settings;
        private CheckBox checkBox_paidMoneyOnDate;
        private CheckBox checkBox_BeginningDate;
        private TextBox input_newPeriod;
        private CheckBox checkBox_newPeriod;
        private TextBox input_paidMoneyOnDate;
        private CheckBox checkBox_endDate;
        private Label label_Penal;
        private TextBox input_penalPercentage;
        private DataGridView penalDataTable;
        private DataGridViewTextBoxColumn requiredPayment;
        private DataGridViewTextBoxColumn moneyPaid;
        private DataGridViewTextBoxColumn dateOfPayment;
        private DataGridViewTextBoxColumn arrears;
        private DataGridViewTextBoxColumn penalPercentage;
        private DataGridViewTextBoxColumn periodBegin;
        private DataGridViewTextBoxColumn PeriodEnd;
        private DataGridViewTextBoxColumn numOfOverdueDays;
        private DataGridViewTextBoxColumn penalAmount;
    }
}
