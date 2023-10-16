namespace WebcreteAPIExplorer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.textBoxRequest = new System.Windows.Forms.TextBox();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxRequest = new System.Windows.Forms.ComboBox();
            this.textBoxAPIKEY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAPPID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSlug = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "API URL";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(103, 18);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(351, 20);
            this.textBoxURL.TabIndex = 1;
            this.textBoxURL.Text = "http://demo.api.concretego.com/webcreteapi.asmx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "UserName";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(524, 18);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(134, 20);
            this.textBoxUserName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(663, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(720, 18);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(111, 20);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(332, 45);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(124, 25);
            this.buttonProcess.TabIndex = 6;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // textBoxRequest
            // 
            this.textBoxRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRequest.Location = new System.Drawing.Point(3, 23);
            this.textBoxRequest.MaxLength = 524272;
            this.textBoxRequest.Multiline = true;
            this.textBoxRequest.Name = "textBoxRequest";
            this.textBoxRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRequest.Size = new System.Drawing.Size(480, 560);
            this.textBoxRequest.TabIndex = 7;
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResponse.Location = new System.Drawing.Point(3, 23);
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResponse.Size = new System.Drawing.Size(481, 560);
            this.textBoxResponse.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 79);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxRequest);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxResponse);
            this.splitContainer1.Size = new System.Drawing.Size(977, 586);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Request";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Response";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Request Type";
            // 
            // comboBoxRequest
            // 
            this.comboBoxRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRequest.FormattingEnabled = true;
            this.comboBoxRequest.Items.AddRange(new object[] {
            "AccountingCategoryQuery",
            "CompanyQuery",
            "CreditCodeQuery",
            "CustomerQuery",
            "CustomerQuery(IncludeSundryCharges)",
            "CustomerQuery(IncludeUserDefinedFields)",
            "CustomerQuery(ListOnly)",
            "CustomerUpdate",
            "DivisionQuery",
            "EmployeeQuery",
            "EmployeeUpdate",
            "InventoryTransactionQuery(QuantityAdjustments)",
            "InventoryTransactionQuery(RawMaterialReceipt)",
            "InventoryTransactionQuery(Usages)",
            "InvoiceQueryByCustomerCode",
            "InvoiceQueryByCustomerCodeListOnly",
            "InvoiceQueryByInvoiceDate",
            "ItemCategoryQuery",
            "ItemDelete",
            "ItemQuery",
            "ItemQuery(ByItemCateogry)",
            "ItemQuery(ConstituentOnly)",
            "ItemQuery(IncludeBatching)",
            "ItemQuery(IncludeCost)",
            "ItemQuery(IncludeLocation)",
            "ItemQuery(IncludeMixDesign)",
            "ItemQuery(IncludePricing)",
            "ItemQuery(IncludeTaxOverride)",
            "ItemQuery(ListConstituentOnly)",
            "ItemQuery(ListMixOnly)",
            "ItemQuery(ListOnly)",
            "ItemQuery(MixOnly)",
            "ItemQuery(SpecificLocation(s))",
            "ItemTypeQuery",
            "ItemUpdate",
            "ItemUpdate(Remove Location)",
            "JobQuery",
            "LocationQuery",
            "LocationUpdate",
            "OrderQuery",
            "OrderQuery(FailOnOrderLock)",
            "OrderQuery(OrderUpdate)",
            "OrderUpdate",
            "PlantQuery",
            "PriceCategoryQuery",
            "ProjectQuery",
            "ProjectQuery(IncludeCustomer)",
            "ProjectQuery(IncludeProduct)",
            "ProjectQuery(IncludeSundryCharges)",
            "ProjectQuery(ListOnly)",
            "ProjectUpdate",
            "QuoteQuery",
            "TaxAuthorityQuery",
            "TaxAuthorityUpdate",
            "TaxCodeQuery",
            "TaxCodeUpdate",
            "TaxLocationQuery",
            "TaxLocationUpdate",
            "TicketBatchResultMessageQuery",
            "TicketMessageQuery",
            "TicketQuery",
            "TicketQuery(FailOnOrderLock)",
            "TicketQuery(IncludeRemovedTickets)",
            "TicketQuery(ListOnly)",
            "TicketQuery(LoadTime)",
            "TicketQuery(MixCode)",
            "TicketQuery(OrderID)",
            "TicketQuery(Reviewed)",
            "TicketQuery(SortDesc)",
            "TicketQuery(TicketTime)",
            "TicketQuery(UpdateTime)",
            "TicketQuery(WithBatchWeightsOnly)",
            "TicketQuery(WithCustomerUserDefinedFields)",
            "TicketQuery(WithOrderUserDefinedFields)",
            "TicketQuery(WithUserDefinedFields)",
            "TicketUpdate",
            "TruckGpsUpdate",
            "TruckQuery",
            "TruckQuery(LocationUpdateTime)",
            "TruckQuery(StatusUpdateTime)",
            "TruckStatusMessageQuery",
            "TruckStatusMessageQuery(StatusBeginTime)",
            "TruckStatusMessageQuery(UpdateTime)",
            "TruckStatusQuery",
            "TruckStatusQuery(LocationUpdateTime)",
            "TruckStatusQuery(StatusUpdateTime)",
            "TruckStatusUpdate",
            "TruckUpdate",
            "UOMQuery",
            "VersionQuery"});
            this.comboBoxRequest.Location = new System.Drawing.Point(103, 48);
            this.comboBoxRequest.Name = "comboBoxRequest";
            this.comboBoxRequest.Size = new System.Drawing.Size(222, 21);
            this.comboBoxRequest.Sorted = true;
            this.comboBoxRequest.TabIndex = 11;
            this.comboBoxRequest.SelectedIndexChanged += new System.EventHandler(this.comboBoxRequest_SelectedIndexChanged);
            // 
            // textBoxAPIKEY
            // 
            this.textBoxAPIKEY.Location = new System.Drawing.Point(727, 48);
            this.textBoxAPIKEY.Name = "textBoxAPIKEY";
            this.textBoxAPIKEY.Size = new System.Drawing.Size(212, 20);
            this.textBoxAPIKEY.TabIndex = 15;
            this.textBoxAPIKEY.Text = "F52D2965BF8318F";
            this.textBoxAPIKEY.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(664, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "API KEY";
            // 
            // textBoxAPPID
            // 
            this.textBoxAPPID.Location = new System.Drawing.Point(522, 48);
            this.textBoxAPPID.Name = "textBoxAPPID";
            this.textBoxAPPID.Size = new System.Drawing.Size(134, 20);
            this.textBoxAPPID.TabIndex = 13;
            this.textBoxAPPID.Text = "Test";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(464, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "APP ID";
            // 
            // textBoxSlug
            // 
            this.textBoxSlug.Location = new System.Drawing.Point(874, 18);
            this.textBoxSlug.Name = "textBoxSlug";
            this.textBoxSlug.Size = new System.Drawing.Size(111, 20);
            this.textBoxSlug.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(840, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Slug";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 677);
            this.Controls.Add(this.textBoxSlug);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxAPIKEY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAPPID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxRequest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "WebcreteAPI Explorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.TextBox textBoxRequest;
        private System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxRequest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAPIKEY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAPPID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSlug;
        private System.Windows.Forms.Label label9;
    }
}

