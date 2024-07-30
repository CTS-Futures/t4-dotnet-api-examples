using System;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;


// Import the T4 definitions namespace.
using T4;

// Import the API namespace.
using T4.API;

// Import XML for saving and retriving markets.
using System.Xml;
using System.Collections.Generic;

// Generic collections.

namespace T4Example2CSharp
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {

        #region Windows Form Designer generated code

        internal System.Windows.Forms.Label lblMarket;
        internal System.Windows.Forms.ComboBox cboMarkets;
        internal System.Windows.Forms.Label lblContract;
        internal System.Windows.Forms.Label lblExchange;
        internal System.Windows.Forms.ComboBox cboContracts;
        internal System.Windows.Forms.ComboBox cboExchanges;
        internal System.Windows.Forms.GroupBox grpAccountPicker;
        internal System.Windows.Forms.ComboBox cboAccounts;
        internal System.Windows.Forms.Label lblCash;
        internal System.Windows.Forms.Label lblAccount;
        internal System.Windows.Forms.TextBox txtCash;
        internal System.Windows.Forms.GroupBox grpMarkets;
        internal System.Windows.Forms.Label lblMisc1;
        internal System.Windows.Forms.Button cmdRunMisc1;
        internal System.Windows.Forms.ComboBox cboMisc1;
        internal System.Windows.Forms.Label lblMisc2;
        internal System.Windows.Forms.Button cmdRunMisc2;
        internal System.Windows.Forms.ComboBox cboMisc2;
        internal System.Windows.Forms.Label lblLastPrice;
        internal System.Windows.Forms.Label lblOfferPrice;
        internal System.Windows.Forms.Label lblBidPrice;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtOfferVol1;
        internal System.Windows.Forms.TextBox txtLastVolTotal1;
        internal System.Windows.Forms.TextBox txtLast2;
        internal System.Windows.Forms.TextBox txtLast1;
        internal System.Windows.Forms.TextBox txtOfferVol2;
        internal System.Windows.Forms.TextBox txtBidVol2;
        internal System.Windows.Forms.TextBox txtOffer2;
        internal System.Windows.Forms.TextBox txtBid2;
        internal System.Windows.Forms.TextBox txtMarketDescription2;
        internal System.Windows.Forms.Button cmdGet2;
        internal System.Windows.Forms.TextBox txtNet1;
        internal System.Windows.Forms.TextBox txtNet2;
        internal System.Windows.Forms.Label lblNet;
        internal System.Windows.Forms.TextBox txtLastVol1;
        internal System.Windows.Forms.Label lblSells;
        internal System.Windows.Forms.TextBox txtBuys1;
        internal System.Windows.Forms.TextBox txtBuys2;
        internal System.Windows.Forms.TextBox txtSells1;
        internal System.Windows.Forms.Button cmdGet1;
        internal System.Windows.Forms.TextBox txtMarketDescription1;
        internal System.Windows.Forms.TextBox txtBid1;
        internal System.Windows.Forms.Button cmdBuy2;
        internal System.Windows.Forms.Button cmdSell1;
        internal System.Windows.Forms.Button cmdSell2;
        internal System.Windows.Forms.Label lblBuys;
        internal System.Windows.Forms.TextBox txtSells2;
        internal System.Windows.Forms.TextBox txtOffer1;
        internal System.Windows.Forms.Button cmdBuy1;
        internal System.Windows.Forms.TextBox txtBidVol1;
        internal System.Windows.Forms.TextBox txtLastVol2;
        internal System.Windows.Forms.TextBox txtLastVolTotal2;
        internal System.Windows.Forms.Label lblTotalVol;
        internal System.Windows.Forms.Label lblLastVol;
        internal System.Windows.Forms.Label lblOfferVol;
        internal System.Windows.Forms.Label lblBidVol;
        internal System.Windows.Forms.Button cmdSave;
        internal System.Windows.Forms.Label lblSaveInfo;
        internal System.Windows.Forms.GroupBox grpOrders;
        internal System.Windows.Forms.ListBox lstOrders;
        internal System.Windows.Forms.Label lblOrderInfo;
        private GroupBox grpMarket2;
        internal TextBox txtMode;
        internal Label lblMode;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //


            // Finnally register Form events.
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Closed += new System.EventHandler(this.frmMain_Closed);

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMarket = new System.Windows.Forms.Label();
            this.cboMarkets = new System.Windows.Forms.ComboBox();
            this.lblContract = new System.Windows.Forms.Label();
            this.lblExchange = new System.Windows.Forms.Label();
            this.cboContracts = new System.Windows.Forms.ComboBox();
            this.cboExchanges = new System.Windows.Forms.ComboBox();
            this.grpAccountPicker = new System.Windows.Forms.GroupBox();
            this.cboAccounts = new System.Windows.Forms.ComboBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.grpMarkets = new System.Windows.Forms.GroupBox();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblMisc1 = new System.Windows.Forms.Label();
            this.cmdRunMisc1 = new System.Windows.Forms.Button();
            this.cboMisc1 = new System.Windows.Forms.ComboBox();
            this.lblLastPrice = new System.Windows.Forms.Label();
            this.lblOfferPrice = new System.Windows.Forms.Label();
            this.lblBidPrice = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtOfferVol1 = new System.Windows.Forms.TextBox();
            this.txtLastVolTotal1 = new System.Windows.Forms.TextBox();
            this.txtLast1 = new System.Windows.Forms.TextBox();
            this.txtNet1 = new System.Windows.Forms.TextBox();
            this.lblNet = new System.Windows.Forms.Label();
            this.txtLastVol1 = new System.Windows.Forms.TextBox();
            this.lblSells = new System.Windows.Forms.Label();
            this.txtBuys1 = new System.Windows.Forms.TextBox();
            this.txtSells1 = new System.Windows.Forms.TextBox();
            this.cmdGet1 = new System.Windows.Forms.Button();
            this.txtMarketDescription1 = new System.Windows.Forms.TextBox();
            this.txtBid1 = new System.Windows.Forms.TextBox();
            this.cmdSell1 = new System.Windows.Forms.Button();
            this.lblBuys = new System.Windows.Forms.Label();
            this.txtOffer1 = new System.Windows.Forms.TextBox();
            this.cmdBuy1 = new System.Windows.Forms.Button();
            this.txtBidVol1 = new System.Windows.Forms.TextBox();
            this.lblTotalVol = new System.Windows.Forms.Label();
            this.lblLastVol = new System.Windows.Forms.Label();
            this.lblOfferVol = new System.Windows.Forms.Label();
            this.lblBidVol = new System.Windows.Forms.Label();
            this.lblMisc2 = new System.Windows.Forms.Label();
            this.cmdRunMisc2 = new System.Windows.Forms.Button();
            this.cboMisc2 = new System.Windows.Forms.ComboBox();
            this.txtLast2 = new System.Windows.Forms.TextBox();
            this.txtOfferVol2 = new System.Windows.Forms.TextBox();
            this.txtBidVol2 = new System.Windows.Forms.TextBox();
            this.txtOffer2 = new System.Windows.Forms.TextBox();
            this.txtBid2 = new System.Windows.Forms.TextBox();
            this.txtMarketDescription2 = new System.Windows.Forms.TextBox();
            this.cmdGet2 = new System.Windows.Forms.Button();
            this.txtNet2 = new System.Windows.Forms.TextBox();
            this.txtBuys2 = new System.Windows.Forms.TextBox();
            this.cmdBuy2 = new System.Windows.Forms.Button();
            this.cmdSell2 = new System.Windows.Forms.Button();
            this.txtSells2 = new System.Windows.Forms.TextBox();
            this.txtLastVol2 = new System.Windows.Forms.TextBox();
            this.txtLastVolTotal2 = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblSaveInfo = new System.Windows.Forms.Label();
            this.grpOrders = new System.Windows.Forms.GroupBox();
            this.lstOrders = new System.Windows.Forms.ListBox();
            this.lblOrderInfo = new System.Windows.Forms.Label();
            this.grpMarket2 = new System.Windows.Forms.GroupBox();
            this.grpAccountPicker.SuspendLayout();
            this.grpMarkets.SuspendLayout();
            this.grpOrders.SuspendLayout();
            this.grpMarket2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMarket
            // 
            this.lblMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarket.Location = new System.Drawing.Point(68, 157);
            this.lblMarket.Name = "lblMarket";
            this.lblMarket.Size = new System.Drawing.Size(161, 50);
            this.lblMarket.TabIndex = 11;
            this.lblMarket.Text = "Market:";
            this.lblMarket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboMarkets
            // 
            this.cboMarkets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarkets.Location = new System.Drawing.Point(234, 160);
            this.cboMarkets.Name = "cboMarkets";
            this.cboMarkets.Size = new System.Drawing.Size(510, 39);
            this.cboMarkets.TabIndex = 6;
            this.cboMarkets.TabStop = false;
            this.cboMarkets.SelectedIndexChanged += new System.EventHandler(this.cboMarkets_SelectedIndexChanged);
            // 
            // lblContract
            // 
            this.lblContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContract.Location = new System.Drawing.Point(68, 100);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(161, 50);
            this.lblContract.TabIndex = 10;
            this.lblContract.Text = "Contract:";
            this.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExchange
            // 
            this.lblExchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExchange.Location = new System.Drawing.Point(21, 43);
            this.lblExchange.Name = "lblExchange";
            this.lblExchange.Size = new System.Drawing.Size(197, 50);
            this.lblExchange.TabIndex = 9;
            this.lblExchange.Text = "Exchange:";
            this.lblExchange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboContracts
            // 
            this.cboContracts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContracts.Location = new System.Drawing.Point(234, 103);
            this.cboContracts.Name = "cboContracts";
            this.cboContracts.Size = new System.Drawing.Size(510, 39);
            this.cboContracts.Sorted = true;
            this.cboContracts.TabIndex = 8;
            this.cboContracts.TabStop = false;
            this.cboContracts.SelectedIndexChanged += new System.EventHandler(this.cboContracts_SelectedIndexChanged);
            // 
            // cboExchanges
            // 
            this.cboExchanges.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExchanges.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cboExchanges.Location = new System.Drawing.Point(234, 45);
            this.cboExchanges.Name = "cboExchanges";
            this.cboExchanges.Size = new System.Drawing.Size(510, 39);
            this.cboExchanges.Sorted = true;
            this.cboExchanges.TabIndex = 7;
            this.cboExchanges.TabStop = false;
            this.cboExchanges.SelectedIndexChanged += new System.EventHandler(this.cboExchanges_SelectedIndexChanged);
            // 
            // grpAccountPicker
            // 
            this.grpAccountPicker.Controls.Add(this.cboAccounts);
            this.grpAccountPicker.Controls.Add(this.lblCash);
            this.grpAccountPicker.Controls.Add(this.lblAccount);
            this.grpAccountPicker.Controls.Add(this.txtCash);
            this.grpAccountPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAccountPicker.Location = new System.Drawing.Point(21, 19);
            this.grpAccountPicker.Name = "grpAccountPicker";
            this.grpAccountPicker.Size = new System.Drawing.Size(1861, 124);
            this.grpAccountPicker.TabIndex = 64;
            this.grpAccountPicker.TabStop = false;
            this.grpAccountPicker.Text = "Account";
            // 
            // cboAccounts
            // 
            this.cboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccounts.Location = new System.Drawing.Point(333, 52);
            this.cboAccounts.Name = "cboAccounts";
            this.cboAccounts.Size = new System.Drawing.Size(541, 39);
            this.cboAccounts.Sorted = true;
            this.cboAccounts.TabIndex = 42;
            this.cboAccounts.TabStop = false;
            this.cboAccounts.SelectedIndexChanged += new System.EventHandler(this.cboAccounts_SelectedIndexChanged);
            // 
            // lblCash
            // 
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(905, 52);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(106, 51);
            this.lblCash.TabIndex = 44;
            this.lblCash.Text = "Cash:";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccount
            // 
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(57, 52);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(307, 51);
            this.lblAccount.TabIndex = 41;
            this.lblAccount.Text = "Current Account:";
            this.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCash
            // 
            this.txtCash.BackColor = System.Drawing.Color.White;
            this.txtCash.Location = new System.Drawing.Point(1017, 52);
            this.txtCash.Name = "txtCash";
            this.txtCash.ReadOnly = true;
            this.txtCash.Size = new System.Drawing.Size(280, 39);
            this.txtCash.TabIndex = 43;
            this.txtCash.TabStop = false;
            this.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpMarkets
            // 
            this.grpMarkets.Controls.Add(this.txtMode);
            this.grpMarkets.Controls.Add(this.lblMode);
            this.grpMarkets.Controls.Add(this.lblMarket);
            this.grpMarkets.Controls.Add(this.lblMisc1);
            this.grpMarkets.Controls.Add(this.cboMarkets);
            this.grpMarkets.Controls.Add(this.cmdRunMisc1);
            this.grpMarkets.Controls.Add(this.lblContract);
            this.grpMarkets.Controls.Add(this.cboMisc1);
            this.grpMarkets.Controls.Add(this.lblExchange);
            this.grpMarkets.Controls.Add(this.lblLastPrice);
            this.grpMarkets.Controls.Add(this.cboContracts);
            this.grpMarkets.Controls.Add(this.lblOfferPrice);
            this.grpMarkets.Controls.Add(this.cboExchanges);
            this.grpMarkets.Controls.Add(this.lblBidPrice);
            this.grpMarkets.Controls.Add(this.Label1);
            this.grpMarkets.Controls.Add(this.txtOfferVol1);
            this.grpMarkets.Controls.Add(this.txtLastVolTotal1);
            this.grpMarkets.Controls.Add(this.txtLast1);
            this.grpMarkets.Controls.Add(this.txtNet1);
            this.grpMarkets.Controls.Add(this.lblNet);
            this.grpMarkets.Controls.Add(this.txtLastVol1);
            this.grpMarkets.Controls.Add(this.lblSells);
            this.grpMarkets.Controls.Add(this.txtBuys1);
            this.grpMarkets.Controls.Add(this.txtSells1);
            this.grpMarkets.Controls.Add(this.cmdGet1);
            this.grpMarkets.Controls.Add(this.txtMarketDescription1);
            this.grpMarkets.Controls.Add(this.txtBid1);
            this.grpMarkets.Controls.Add(this.cmdSell1);
            this.grpMarkets.Controls.Add(this.lblBuys);
            this.grpMarkets.Controls.Add(this.txtOffer1);
            this.grpMarkets.Controls.Add(this.cmdBuy1);
            this.grpMarkets.Controls.Add(this.txtBidVol1);
            this.grpMarkets.Controls.Add(this.lblTotalVol);
            this.grpMarkets.Controls.Add(this.lblLastVol);
            this.grpMarkets.Controls.Add(this.lblOfferVol);
            this.grpMarkets.Controls.Add(this.lblBidVol);
            this.grpMarkets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMarkets.Location = new System.Drawing.Point(21, 176);
            this.grpMarkets.Name = "grpMarkets";
            this.grpMarkets.Size = new System.Drawing.Size(2007, 449);
            this.grpMarkets.TabIndex = 66;
            this.grpMarkets.TabStop = false;
            this.grpMarkets.Text = "Market 1";
            // 
            // txtMode
            // 
            this.txtMode.BackColor = System.Drawing.Color.White;
            this.txtMode.ForeColor = System.Drawing.Color.Crimson;
            this.txtMode.Location = new System.Drawing.Point(1776, 327);
            this.txtMode.Name = "txtMode";
            this.txtMode.ReadOnly = true;
            this.txtMode.Size = new System.Drawing.Size(208, 39);
            this.txtMode.TabIndex = 69;
            this.txtMode.TabStop = false;
            this.txtMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMode
            // 
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(1786, 279);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(112, 43);
            this.lblMode.TabIndex = 68;
            this.lblMode.Text = "Mode:";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMisc1
            // 
            this.lblMisc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMisc1.Location = new System.Drawing.Point(1004, 379);
            this.lblMisc1.Name = "lblMisc1";
            this.lblMisc1.Size = new System.Drawing.Size(182, 48);
            this.lblMisc1.TabIndex = 67;
            this.lblMisc1.Text = "Misc Code:";
            this.lblMisc1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdRunMisc1
            // 
            this.cmdRunMisc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRunMisc1.Location = new System.Drawing.Point(1674, 379);
            this.cmdRunMisc1.Name = "cmdRunMisc1";
            this.cmdRunMisc1.Size = new System.Drawing.Size(99, 48);
            this.cmdRunMisc1.TabIndex = 66;
            this.cmdRunMisc1.TabStop = false;
            this.cmdRunMisc1.Text = "Run";
            this.cmdRunMisc1.Click += new System.EventHandler(this.cmdRunMisc1_Click);
            // 
            // cboMisc1
            // 
            this.cboMisc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMisc1.Location = new System.Drawing.Point(1196, 379);
            this.cboMisc1.Name = "cboMisc1";
            this.cboMisc1.Size = new System.Drawing.Size(468, 39);
            this.cboMisc1.Sorted = true;
            this.cboMisc1.TabIndex = 65;
            this.cboMisc1.TabStop = false;
            // 
            // lblLastPrice
            // 
            this.lblLastPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastPrice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblLastPrice.Location = new System.Drawing.Point(1058, 279);
            this.lblLastPrice.Name = "lblLastPrice";
            this.lblLastPrice.Size = new System.Drawing.Size(156, 48);
            this.lblLastPrice.TabIndex = 25;
            this.lblLastPrice.Text = "Price:";
            this.lblLastPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOfferPrice
            // 
            this.lblOfferPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfferPrice.ForeColor = System.Drawing.Color.Crimson;
            this.lblOfferPrice.Location = new System.Drawing.Point(819, 279);
            this.lblOfferPrice.Name = "lblOfferPrice";
            this.lblOfferPrice.Size = new System.Drawing.Size(156, 48);
            this.lblOfferPrice.TabIndex = 24;
            this.lblOfferPrice.Text = "Price:";
            this.lblOfferPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBidPrice
            // 
            this.lblBidPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBidPrice.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblBidPrice.Location = new System.Drawing.Point(580, 279);
            this.lblBidPrice.Name = "lblBidPrice";
            this.lblBidPrice.Size = new System.Drawing.Size(156, 48);
            this.lblBidPrice.TabIndex = 23;
            this.lblBidPrice.Text = "Price:";
            this.lblBidPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(29, 279);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(546, 48);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "Market Description:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOfferVol1
            // 
            this.txtOfferVol1.BackColor = System.Drawing.Color.MistyRose;
            this.txtOfferVol1.Location = new System.Drawing.Point(985, 327);
            this.txtOfferVol1.Name = "txtOfferVol1";
            this.txtOfferVol1.ReadOnly = true;
            this.txtOfferVol1.Size = new System.Drawing.Size(73, 39);
            this.txtOfferVol1.TabIndex = 17;
            this.txtOfferVol1.TabStop = false;
            this.txtOfferVol1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLastVolTotal1
            // 
            this.txtLastVolTotal1.BackColor = System.Drawing.Color.Honeydew;
            this.txtLastVolTotal1.Location = new System.Drawing.Point(1303, 327);
            this.txtLastVolTotal1.Name = "txtLastVolTotal1";
            this.txtLastVolTotal1.ReadOnly = true;
            this.txtLastVolTotal1.Size = new System.Drawing.Size(156, 39);
            this.txtLastVolTotal1.TabIndex = 21;
            this.txtLastVolTotal1.TabStop = false;
            this.txtLastVolTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLast1
            // 
            this.txtLast1.BackColor = System.Drawing.Color.Honeydew;
            this.txtLast1.Location = new System.Drawing.Point(1063, 327);
            this.txtLast1.Name = "txtLast1";
            this.txtLast1.ReadOnly = true;
            this.txtLast1.Size = new System.Drawing.Size(156, 39);
            this.txtLast1.TabIndex = 18;
            this.txtLast1.TabStop = false;
            this.txtLast1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNet1
            // 
            this.txtNet1.BackColor = System.Drawing.Color.White;
            this.txtNet1.Location = new System.Drawing.Point(1464, 327);
            this.txtNet1.Name = "txtNet1";
            this.txtNet1.ReadOnly = true;
            this.txtNet1.Size = new System.Drawing.Size(99, 39);
            this.txtNet1.TabIndex = 46;
            this.txtNet1.TabStop = false;
            this.txtNet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNet
            // 
            this.lblNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNet.Location = new System.Drawing.Point(1459, 279);
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(98, 43);
            this.lblNet.TabIndex = 48;
            this.lblNet.Text = "Net:";
            this.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLastVol1
            // 
            this.txtLastVol1.BackColor = System.Drawing.Color.Honeydew;
            this.txtLastVol1.Location = new System.Drawing.Point(1225, 327);
            this.txtLastVol1.Name = "txtLastVol1";
            this.txtLastVol1.ReadOnly = true;
            this.txtLastVol1.Size = new System.Drawing.Size(72, 39);
            this.txtLastVol1.TabIndex = 20;
            this.txtLastVol1.TabStop = false;
            this.txtLastVol1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSells
            // 
            this.lblSells.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSells.Location = new System.Drawing.Point(1667, 279);
            this.lblSells.Name = "lblSells";
            this.lblSells.Size = new System.Drawing.Size(106, 43);
            this.lblSells.TabIndex = 50;
            this.lblSells.Text = "Sells:";
            this.lblSells.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBuys1
            // 
            this.txtBuys1.BackColor = System.Drawing.Color.White;
            this.txtBuys1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtBuys1.Location = new System.Drawing.Point(1568, 327);
            this.txtBuys1.Name = "txtBuys1";
            this.txtBuys1.ReadOnly = true;
            this.txtBuys1.Size = new System.Drawing.Size(99, 39);
            this.txtBuys1.TabIndex = 51;
            this.txtBuys1.TabStop = false;
            this.txtBuys1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSells1
            // 
            this.txtSells1.BackColor = System.Drawing.Color.White;
            this.txtSells1.ForeColor = System.Drawing.Color.Crimson;
            this.txtSells1.Location = new System.Drawing.Point(1672, 327);
            this.txtSells1.Name = "txtSells1";
            this.txtSells1.ReadOnly = true;
            this.txtSells1.Size = new System.Drawing.Size(99, 39);
            this.txtSells1.TabIndex = 53;
            this.txtSells1.TabStop = false;
            this.txtSells1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdGet1
            // 
            this.cmdGet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGet1.Location = new System.Drawing.Point(653, 224);
            this.cmdGet1.Name = "cmdGet1";
            this.cmdGet1.Size = new System.Drawing.Size(91, 48);
            this.cmdGet1.TabIndex = 10;
            this.cmdGet1.TabStop = false;
            this.cmdGet1.Text = "Get";
            this.cmdGet1.Click += new System.EventHandler(this.cmdGet1_Click);
            // 
            // txtMarketDescription1
            // 
            this.txtMarketDescription1.BackColor = System.Drawing.Color.White;
            this.txtMarketDescription1.Location = new System.Drawing.Point(39, 327);
            this.txtMarketDescription1.Name = "txtMarketDescription1";
            this.txtMarketDescription1.ReadOnly = true;
            this.txtMarketDescription1.Size = new System.Drawing.Size(541, 39);
            this.txtMarketDescription1.TabIndex = 11;
            this.txtMarketDescription1.TabStop = false;
            // 
            // txtBid1
            // 
            this.txtBid1.BackColor = System.Drawing.Color.LightCyan;
            this.txtBid1.Location = new System.Drawing.Point(585, 327);
            this.txtBid1.Name = "txtBid1";
            this.txtBid1.ReadOnly = true;
            this.txtBid1.Size = new System.Drawing.Size(156, 39);
            this.txtBid1.TabIndex = 12;
            this.txtBid1.TabStop = false;
            this.txtBid1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdSell1
            // 
            this.cmdSell1.BackColor = System.Drawing.Color.Crimson;
            this.cmdSell1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSell1.ForeColor = System.Drawing.Color.White;
            this.cmdSell1.Location = new System.Drawing.Point(819, 379);
            this.cmdSell1.Name = "cmdSell1";
            this.cmdSell1.Size = new System.Drawing.Size(156, 48);
            this.cmdSell1.TabIndex = 58;
            this.cmdSell1.TabStop = false;
            this.cmdSell1.Text = "Sell";
            this.cmdSell1.UseVisualStyleBackColor = false;
            this.cmdSell1.Click += new System.EventHandler(this.cmdSell1_Click);
            // 
            // lblBuys
            // 
            this.lblBuys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuys.Location = new System.Drawing.Point(1563, 279);
            this.lblBuys.Name = "lblBuys";
            this.lblBuys.Size = new System.Drawing.Size(98, 43);
            this.lblBuys.TabIndex = 49;
            this.lblBuys.Text = "Buys:";
            this.lblBuys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOffer1
            // 
            this.txtOffer1.BackColor = System.Drawing.Color.MistyRose;
            this.txtOffer1.Location = new System.Drawing.Point(824, 327);
            this.txtOffer1.Name = "txtOffer1";
            this.txtOffer1.ReadOnly = true;
            this.txtOffer1.Size = new System.Drawing.Size(156, 39);
            this.txtOffer1.TabIndex = 14;
            this.txtOffer1.TabStop = false;
            this.txtOffer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdBuy1
            // 
            this.cmdBuy1.BackColor = System.Drawing.Color.RoyalBlue;
            this.cmdBuy1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuy1.ForeColor = System.Drawing.Color.White;
            this.cmdBuy1.Location = new System.Drawing.Point(580, 379);
            this.cmdBuy1.Name = "cmdBuy1";
            this.cmdBuy1.Size = new System.Drawing.Size(156, 48);
            this.cmdBuy1.TabIndex = 55;
            this.cmdBuy1.TabStop = false;
            this.cmdBuy1.Text = "Buy";
            this.cmdBuy1.UseVisualStyleBackColor = false;
            this.cmdBuy1.Click += new System.EventHandler(this.cmdBuy1_Click);
            // 
            // txtBidVol1
            // 
            this.txtBidVol1.BackColor = System.Drawing.Color.LightCyan;
            this.txtBidVol1.Location = new System.Drawing.Point(746, 327);
            this.txtBidVol1.Name = "txtBidVol1";
            this.txtBidVol1.ReadOnly = true;
            this.txtBidVol1.Size = new System.Drawing.Size(73, 39);
            this.txtBidVol1.TabIndex = 16;
            this.txtBidVol1.TabStop = false;
            this.txtBidVol1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalVol
            // 
            this.lblTotalVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVol.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalVol.Location = new System.Drawing.Point(1297, 279);
            this.lblTotalVol.Name = "lblTotalVol";
            this.lblTotalVol.Size = new System.Drawing.Size(167, 48);
            this.lblTotalVol.TabIndex = 29;
            this.lblTotalVol.Text = "Total Vol:";
            this.lblTotalVol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastVol
            // 
            this.lblLastVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastVol.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblLastVol.Location = new System.Drawing.Point(1219, 279);
            this.lblLastVol.Name = "lblLastVol";
            this.lblLastVol.Size = new System.Drawing.Size(84, 48);
            this.lblLastVol.TabIndex = 28;
            this.lblLastVol.Text = "Vol:";
            this.lblLastVol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOfferVol
            // 
            this.lblOfferVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfferVol.ForeColor = System.Drawing.Color.Crimson;
            this.lblOfferVol.Location = new System.Drawing.Point(980, 279);
            this.lblOfferVol.Name = "lblOfferVol";
            this.lblOfferVol.Size = new System.Drawing.Size(83, 48);
            this.lblOfferVol.TabIndex = 27;
            this.lblOfferVol.Text = "Vol:";
            this.lblOfferVol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBidVol
            // 
            this.lblBidVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBidVol.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblBidVol.Location = new System.Drawing.Point(741, 279);
            this.lblBidVol.Name = "lblBidVol";
            this.lblBidVol.Size = new System.Drawing.Size(83, 48);
            this.lblBidVol.TabIndex = 26;
            this.lblBidVol.Text = "Vol:";
            this.lblBidVol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMisc2
            // 
            this.lblMisc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMisc2.Location = new System.Drawing.Point(1004, 172);
            this.lblMisc2.Name = "lblMisc2";
            this.lblMisc2.Size = new System.Drawing.Size(182, 47);
            this.lblMisc2.TabIndex = 64;
            this.lblMisc2.Text = "Misc Code:";
            this.lblMisc2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdRunMisc2
            // 
            this.cmdRunMisc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRunMisc2.Location = new System.Drawing.Point(1674, 172);
            this.cmdRunMisc2.Name = "cmdRunMisc2";
            this.cmdRunMisc2.Size = new System.Drawing.Size(99, 47);
            this.cmdRunMisc2.TabIndex = 63;
            this.cmdRunMisc2.TabStop = false;
            this.cmdRunMisc2.Text = "Run";
            this.cmdRunMisc2.Click += new System.EventHandler(this.cmdRunMisc2_Click);
            // 
            // cboMisc2
            // 
            this.cboMisc2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMisc2.Location = new System.Drawing.Point(1196, 172);
            this.cboMisc2.Name = "cboMisc2";
            this.cboMisc2.Size = new System.Drawing.Size(468, 39);
            this.cboMisc2.Sorted = true;
            this.cboMisc2.TabIndex = 62;
            this.cboMisc2.TabStop = false;
            // 
            // txtLast2
            // 
            this.txtLast2.BackColor = System.Drawing.Color.Honeydew;
            this.txtLast2.Location = new System.Drawing.Point(1063, 119);
            this.txtLast2.Name = "txtLast2";
            this.txtLast2.ReadOnly = true;
            this.txtLast2.Size = new System.Drawing.Size(156, 39);
            this.txtLast2.TabIndex = 36;
            this.txtLast2.TabStop = false;
            this.txtLast2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOfferVol2
            // 
            this.txtOfferVol2.BackColor = System.Drawing.Color.MistyRose;
            this.txtOfferVol2.Location = new System.Drawing.Point(985, 119);
            this.txtOfferVol2.Name = "txtOfferVol2";
            this.txtOfferVol2.ReadOnly = true;
            this.txtOfferVol2.Size = new System.Drawing.Size(73, 39);
            this.txtOfferVol2.TabIndex = 35;
            this.txtOfferVol2.TabStop = false;
            this.txtOfferVol2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBidVol2
            // 
            this.txtBidVol2.BackColor = System.Drawing.Color.LightCyan;
            this.txtBidVol2.Location = new System.Drawing.Point(746, 119);
            this.txtBidVol2.Name = "txtBidVol2";
            this.txtBidVol2.ReadOnly = true;
            this.txtBidVol2.Size = new System.Drawing.Size(73, 39);
            this.txtBidVol2.TabIndex = 34;
            this.txtBidVol2.TabStop = false;
            this.txtBidVol2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOffer2
            // 
            this.txtOffer2.BackColor = System.Drawing.Color.MistyRose;
            this.txtOffer2.Location = new System.Drawing.Point(824, 119);
            this.txtOffer2.Name = "txtOffer2";
            this.txtOffer2.ReadOnly = true;
            this.txtOffer2.Size = new System.Drawing.Size(156, 39);
            this.txtOffer2.TabIndex = 33;
            this.txtOffer2.TabStop = false;
            this.txtOffer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBid2
            // 
            this.txtBid2.BackColor = System.Drawing.Color.LightCyan;
            this.txtBid2.Location = new System.Drawing.Point(585, 119);
            this.txtBid2.Name = "txtBid2";
            this.txtBid2.ReadOnly = true;
            this.txtBid2.Size = new System.Drawing.Size(156, 39);
            this.txtBid2.TabIndex = 32;
            this.txtBid2.TabStop = false;
            this.txtBid2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMarketDescription2
            // 
            this.txtMarketDescription2.BackColor = System.Drawing.Color.White;
            this.txtMarketDescription2.Location = new System.Drawing.Point(39, 119);
            this.txtMarketDescription2.Name = "txtMarketDescription2";
            this.txtMarketDescription2.ReadOnly = true;
            this.txtMarketDescription2.Size = new System.Drawing.Size(541, 39);
            this.txtMarketDescription2.TabIndex = 31;
            this.txtMarketDescription2.TabStop = false;
            // 
            // cmdGet2
            // 
            this.cmdGet2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGet2.Location = new System.Drawing.Point(36, 57);
            this.cmdGet2.Name = "cmdGet2";
            this.cmdGet2.Size = new System.Drawing.Size(151, 48);
            this.cmdGet2.TabIndex = 30;
            this.cmdGet2.TabStop = false;
            this.cmdGet2.Text = "Picker";
            this.cmdGet2.Click += new System.EventHandler(this.cmdGet2_Click);
            // 
            // txtNet2
            // 
            this.txtNet2.BackColor = System.Drawing.Color.White;
            this.txtNet2.Location = new System.Drawing.Point(1464, 119);
            this.txtNet2.Name = "txtNet2";
            this.txtNet2.ReadOnly = true;
            this.txtNet2.Size = new System.Drawing.Size(99, 39);
            this.txtNet2.TabIndex = 47;
            this.txtNet2.TabStop = false;
            this.txtNet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBuys2
            // 
            this.txtBuys2.BackColor = System.Drawing.Color.White;
            this.txtBuys2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtBuys2.Location = new System.Drawing.Point(1568, 119);
            this.txtBuys2.Name = "txtBuys2";
            this.txtBuys2.ReadOnly = true;
            this.txtBuys2.Size = new System.Drawing.Size(99, 39);
            this.txtBuys2.TabIndex = 52;
            this.txtBuys2.TabStop = false;
            this.txtBuys2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdBuy2
            // 
            this.cmdBuy2.BackColor = System.Drawing.Color.RoyalBlue;
            this.cmdBuy2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuy2.ForeColor = System.Drawing.Color.White;
            this.cmdBuy2.Location = new System.Drawing.Point(580, 172);
            this.cmdBuy2.Name = "cmdBuy2";
            this.cmdBuy2.Size = new System.Drawing.Size(156, 47);
            this.cmdBuy2.TabIndex = 56;
            this.cmdBuy2.TabStop = false;
            this.cmdBuy2.Text = "Buy";
            this.cmdBuy2.UseVisualStyleBackColor = false;
            this.cmdBuy2.Click += new System.EventHandler(this.cmdBuy2_Click);
            // 
            // cmdSell2
            // 
            this.cmdSell2.BackColor = System.Drawing.Color.Crimson;
            this.cmdSell2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSell2.ForeColor = System.Drawing.Color.White;
            this.cmdSell2.Location = new System.Drawing.Point(819, 172);
            this.cmdSell2.Name = "cmdSell2";
            this.cmdSell2.Size = new System.Drawing.Size(156, 47);
            this.cmdSell2.TabIndex = 59;
            this.cmdSell2.TabStop = false;
            this.cmdSell2.Text = "Sell";
            this.cmdSell2.UseVisualStyleBackColor = false;
            this.cmdSell2.Click += new System.EventHandler(this.cmdSell2_Click);
            // 
            // txtSells2
            // 
            this.txtSells2.BackColor = System.Drawing.Color.White;
            this.txtSells2.ForeColor = System.Drawing.Color.Crimson;
            this.txtSells2.Location = new System.Drawing.Point(1672, 119);
            this.txtSells2.Name = "txtSells2";
            this.txtSells2.ReadOnly = true;
            this.txtSells2.Size = new System.Drawing.Size(99, 39);
            this.txtSells2.TabIndex = 54;
            this.txtSells2.TabStop = false;
            this.txtSells2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLastVol2
            // 
            this.txtLastVol2.BackColor = System.Drawing.Color.Honeydew;
            this.txtLastVol2.Location = new System.Drawing.Point(1225, 119);
            this.txtLastVol2.Name = "txtLastVol2";
            this.txtLastVol2.ReadOnly = true;
            this.txtLastVol2.Size = new System.Drawing.Size(72, 39);
            this.txtLastVol2.TabIndex = 37;
            this.txtLastVol2.TabStop = false;
            this.txtLastVol2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLastVolTotal2
            // 
            this.txtLastVolTotal2.BackColor = System.Drawing.Color.Honeydew;
            this.txtLastVolTotal2.Location = new System.Drawing.Point(1303, 119);
            this.txtLastVolTotal2.Name = "txtLastVolTotal2";
            this.txtLastVolTotal2.ReadOnly = true;
            this.txtLastVolTotal2.Size = new System.Drawing.Size(156, 39);
            this.txtLastVolTotal2.TabIndex = 38;
            this.txtLastVolTotal2.TabStop = false;
            this.txtLastVolTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(21, 935);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(364, 62);
            this.cmdSave.TabIndex = 40;
            this.cmdSave.TabStop = false;
            this.cmdSave.Text = "Save Selected Markets";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblSaveInfo
            // 
            this.lblSaveInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveInfo.Location = new System.Drawing.Point(400, 935);
            this.lblSaveInfo.Name = "lblSaveInfo";
            this.lblSaveInfo.Size = new System.Drawing.Size(962, 62);
            this.lblSaveInfo.TabIndex = 66;
            this.lblSaveInfo.Text = "Click Save to store the current markets in an XML file on the server.  The market" +
    "s will be loaded automatically on the next login.";
            this.lblSaveInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpOrders
            // 
            this.grpOrders.Controls.Add(this.lstOrders);
            this.grpOrders.Controls.Add(this.lblOrderInfo);
            this.grpOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOrders.Location = new System.Drawing.Point(21, 1011);
            this.grpOrders.Name = "grpOrders";
            this.grpOrders.Size = new System.Drawing.Size(2007, 453);
            this.grpOrders.TabIndex = 67;
            this.grpOrders.TabStop = false;
            this.grpOrders.Text = "Orders";
            // 
            // lstOrders
            // 
            this.lstOrders.ItemHeight = 31;
            this.lstOrders.Location = new System.Drawing.Point(21, 50);
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(1963, 283);
            this.lstOrders.TabIndex = 60;
            this.lstOrders.TabStop = false;
            this.lstOrders.DoubleClick += new System.EventHandler(this.lstOrders_DoubleClick);
            // 
            // lblOrderInfo
            // 
            this.lblOrderInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderInfo.Location = new System.Drawing.Point(104, 396);
            this.lblOrderInfo.Name = "lblOrderInfo";
            this.lblOrderInfo.Size = new System.Drawing.Size(1648, 43);
            this.lblOrderInfo.TabIndex = 67;
            this.lblOrderInfo.Text = "Double Click orders to Pull them.  Volume is displayed Filled/Working to clarify " +
    "which orders have been Pulled.";
            this.lblOrderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpMarket2
            // 
            this.grpMarket2.Controls.Add(this.txtMarketDescription2);
            this.grpMarket2.Controls.Add(this.txtLastVolTotal2);
            this.grpMarket2.Controls.Add(this.txtLastVol2);
            this.grpMarket2.Controls.Add(this.lblMisc2);
            this.grpMarket2.Controls.Add(this.txtSells2);
            this.grpMarket2.Controls.Add(this.cmdRunMisc2);
            this.grpMarket2.Controls.Add(this.cmdSell2);
            this.grpMarket2.Controls.Add(this.cboMisc2);
            this.grpMarket2.Controls.Add(this.cmdBuy2);
            this.grpMarket2.Controls.Add(this.txtBuys2);
            this.grpMarket2.Controls.Add(this.txtNet2);
            this.grpMarket2.Controls.Add(this.cmdGet2);
            this.grpMarket2.Controls.Add(this.txtBid2);
            this.grpMarket2.Controls.Add(this.txtOffer2);
            this.grpMarket2.Controls.Add(this.txtBidVol2);
            this.grpMarket2.Controls.Add(this.txtLast2);
            this.grpMarket2.Controls.Add(this.txtOfferVol2);
            this.grpMarket2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMarket2.Location = new System.Drawing.Point(21, 670);
            this.grpMarket2.Name = "grpMarket2";
            this.grpMarket2.Size = new System.Drawing.Size(2007, 250);
            this.grpMarket2.TabIndex = 68;
            this.grpMarket2.TabStop = false;
            this.grpMarket2.Text = "Market 2";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(13, 31);
            this.ClientSize = new System.Drawing.Size(2572, 1840);
            this.Controls.Add(this.grpMarket2);
            this.Controls.Add(this.grpOrders);
            this.Controls.Add(this.grpMarkets);
            this.Controls.Add(this.grpAccountPicker);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lblSaveInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "T4 Example 2";
            this.grpAccountPicker.ResumeLayout(false);
            this.grpAccountPicker.PerformLayout();
            this.grpMarkets.ResumeLayout(false);
            this.grpMarkets.PerformLayout();
            this.grpOrders.ResumeLayout(false);
            this.grpMarket2.ResumeLayout(false);
            this.grpMarket2.PerformLayout();
            this.ResumeLayout(false);

        }



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            System.Windows.Forms.Application.Run(new Form1());
        }

        #endregion

        #region Member Variables

        // Reference to the main api host object.
        internal Host moHost;

        //  Reference to the current account.
        internal Account moAccount;

        // Reference to the current exchange.
        internal Exchange moExchange;

        // Reference to the current contract.
        internal Contract moContract;

        // Reference to the current market.
        internal Market moPickerMarket;

        // References to selected markets.
        internal Market moMarket1;
        internal Market moMarket2;

        // References to marketid's retrieved from saved settings.
        internal string mstrMarketID1;
        internal string mstrMarketID2;

        #endregion

        #region " Initialization "

        // Initialize the application.
        private void Init()
        {

            Trace.WriteLine("Init");

            SetupMiscExamples();

            // Populate the available exchanges.
            DisplayExchanges();

            // Populate the accounts.
            DisplayAccounts();

            // Register the accountlist events.
            moHost.Accounts.AccountDetails += new T4.API.AccountList.AccountDetailsEventHandler(moAccounts_AccountDetails);

            try
            {

                // Read saved markets.
                // XML Doc.
                XmlDocument oDoc;

                // XML Nodes for viewing the doc.
                XmlNode oMarkets;

                // Pull the xml doc from the server.
                oDoc = moHost.MasterUser.UserSettings;

                // Reference the saved markets via xml node.
                oMarkets = oDoc.ChildNodes[0];

                if (oMarkets != null)
                {

                    // Load the saved markets.
                    foreach (XmlNode oMarket in oMarkets)
                    {

                        // Check each child node for existance of saved markets.
                        switch (oMarket.Name)
                        {
                            case "market1":
                                mstrMarketID1 = oMarket.Attributes["MarketID"].Value;

                                // Get the market.
                                moHost.MarketData.GetMarket(mstrMarketID1, e =>
                                {
                                // Subscribe to market1.
                                if (e.Markets.Count > 0)
                                        NewMarketSubscription(ref moMarket1, e.Markets.First());
                                });
                                break;

                            case "market2":
                                mstrMarketID2 = oMarket.Attributes["MarketID"].Value;

                                // Get the market.
                                moHost.MarketData.GetMarket(mstrMarketID2, e =>
                                {
                                // Subscribe to market1.
                                if (e.Markets.Count > 0)
                                        NewMarketSubscription(ref moMarket2, e.Markets.First());
                                });
                                break;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Trace the exception.
                Trace.WriteLine("Error: " + ex.ToString());
            }
        }

        #endregion

        #region Market Picker

        private void DisplayExchanges()
        {
            // First clear all the combo's.
            cboExchanges.Items.Clear();
            cboContracts.Items.Clear();
            cboMarkets.Items.Clear();

            // Eliminate any previous references.
            moExchange = null;
            moContract = null;
            moPickerMarket = null;

            // Populate the list of exchanges.
            try
            {
                // Add the exchanges to the dropdown list.
                foreach (Exchange oExchange in moHost.MarketData.Exchanges.GetSortedList())
                {
                    cboExchanges.Items.Add(oExchange);
                }


            }
            catch (Exception ex)
            {
                // Trace the error.
                Trace.WriteLine("Error " + ex.ToString());
            }
        }

        private void cboExchanges_SelectedIndexChanged(Object sender, System.EventArgs e)
        {

            // Populate the current exchange's available contracts.
            if (cboExchanges.SelectedItem != null)
            {

                // Reference the current exchange.
                moExchange = ((Exchange)(cboExchanges.SelectedItem));

                // Display the contracts
                DisplayContracts();
            }
        }

        // Populate the list of contracts available for the current exchange.
        private void DisplayContracts()
        {

            // First clear all the combo's.
            cboContracts.Items.Clear();
            cboMarkets.Items.Clear();

            // Eliminate any previous references.
            moContract = null;
            moPickerMarket = null;


            if (moExchange != null)
            {

                try
                {
                    // Add the exchanges to the dropdown list.
                    foreach (Contract oContract in moExchange.Contracts)
                    {
                        cboContracts.Items.Add(oContract);
                    }


                }
                catch (Exception ex)
                {
                    // Trace the error.
                    Trace.WriteLine("Error " + ex.ToString());
                }
            }
        }

        private void cboContracts_SelectedIndexChanged(Object sender, System.EventArgs e)
        {

            // Populate the current contract's available markets.

            {

                if ((cboContracts.SelectedItem != null))
                {
                    // Reference the current contract.
                    moContract = (Contract)cboContracts.SelectedItem;

                    // This will return outrights only.
                    moContract.GetMarkets(0, StrategyType.None, e2 =>
                    {
                        if (this.InvokeRequired)
                            this.BeginInvoke(new OnMarketListComplete(DisplayMarkets), new Object[] { e2 });
                        else
                            DisplayMarkets(e2);
                    });

                }
            }
        }


        private void DisplayMarkets(MarketListEventArgs e)
        {
            // Populate the list of markets available for the current contract.

            // First clear the combo.
            cboMarkets.Items.Clear();

            // Eliminate any previous references.
            moPickerMarket = null;

            try
            {
                // Add the markets to the dropdown list.
                foreach (Market oMarket in e.Markets.GetSortedList())
                {
                    cboMarkets.Items.Add(oMarket);

                }
            }
            catch (Exception ex)
            {
                // Trace the error.
                Trace.WriteLine("Error " + ex.ToString());
            }
        }

        private void cboMarkets_SelectedIndexChanged(Object sender, System.EventArgs e)
        {
            if (cboMarkets.SelectedItem != null)
            {
                // Store a reference to the current market.
                moPickerMarket = ((Market)(cboMarkets.SelectedItem));
            }
        }

        #endregion

        #region Account Data

        // Event that is raised when details for an account have 
        // changed, or a new account is recieved.
        private void moAccounts_AccountDetails(AccountDetailsEventArgs e)
        {
            //  Invoke the update.
            //  This places process on GUI thread.
            if (this.InvokeRequired)
            {
                BeginInvoke(new AccountList.AccountDetailsEventHandler(OnAccountDetails), new Object[] { e });
            }
            else
            {
                OnAccountDetails(e);
            }
        }

        private void OnAccountDetails(AccountDetailsEventArgs e)
        {
            // Check to see if the account exists prior to adding/subscribing to it.
            if (e.Account.Subscribed != true)
            {

                // Add the account to the list.
                cboAccounts.Items.Add(e.Account);

                // Subscribe to the account.
                e.Account.Subscribe(e2 =>
                {
                    if (this.InvokeRequired)
                        BeginInvoke(new OnAccountComplete(moAccounts_AccountComplete), new object[] { e2 });
                    else
                        moAccounts_AccountComplete(e2);
                });

            }
        }

        private void moAccounts_AccountComplete(AccountCompleteEventArgs e)
        {
            DisplayAccount();

            // Refresh positions.
            DisplayPosition(moMarket1, 1);
            DisplayPosition(moMarket2, 2);

            DisplayOrders();
        }

        // Event that is raised when the accounts overall balance,
        // P&L or margin details have changed.
        private void moAccounts_AccountUpdate(AccountUpdateEventArgs e)
        {
            // Invoke the update.
            // This places process on GUI thread.
            if (this.InvokeRequired)
            {
                BeginInvoke(new Account.AccountUpdateEventHandler(OnAccountUpdate), new Object[] { e });
            }
            else
            {
                OnAccountUpdate(e);
            }

        }

        private void OnAccountUpdate(AccountUpdateEventArgs e)
        {
            // Just refresh the current account.
            DisplayAccount();
        }

        private void DisplayAccounts()
        {

            try
            {
                // Lock the API.
                moHost.EnterLock();

                // Display the account list.

                foreach (Account oAccount in moHost.Accounts)
                {
                    OnAccountDetails(new AccountDetailsEventArgs(oAccount));
                }

                if (cboAccounts.Items.Count > 0)
                {
                    cboAccounts.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                // Trace Errors.
                Trace.WriteLine(ex.ToString());
            }
            finally
            {
                // Unlock the api.
                moHost.ExitLock();
            }

        }

        //' Event that is raised when positions for accounts have changed.
        private void moAccounts_PositionUpdate(PositionUpdateEventArgs e)
        {

            // Display the position details.

            // If the position is for the current account
            // then update the value.

            if (e.Account == moAccount)
            {
                // Invoke the update.
                // This places process on GUI thread.
                // Must use a delegate to pass arguments.
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Account.PositionUpdateEventHandler(OnPositionUpdate), new object[] { e });
                }
                else
                {
                    OnPositionUpdate(e);
                }
            }
        }

        private void OnPositionUpdate(PositionUpdateEventArgs e)
        {
            // Display the position details.
            if (e.Position.Market == moMarket1)
                DisplayPosition(e.Position.Market, 1);
            else if (e.Position.Market == moMarket2)
                DisplayPosition(e.Position.Market, 2);
        }

        private void DisplayAccount()
        {

            if ((moAccount != null))
            {

                try
                {
                    // Display the current account balance.
                    txtCash.Text = String.Format("{0:#,###,##0.00}", moAccount.AvailableCash);

                }
                catch (Exception ex)
                {
                    // Trace the error.
                    Trace.WriteLine("Error: " + ex.ToString());

                }
            }
        }

        private void DisplayPosition(Market poMarket, int piID)
        {
            string strNet = "";
            string strBuys = "";
            string strSells = "";

            try
            {

                if ((poMarket != null) && (moAccount != null))
                {

                    // Display positions for current account and market1.

                    // Reference the market's positions.
                    Position oPosition = moAccount.Positions[poMarket.MarketID];

                    if ((oPosition != null))
                    {
                        // Reference the net position.
                        strNet = oPosition.Net.ToString();
                        strBuys = oPosition.Buys.ToString();
                        strSells = oPosition.Sells.ToString();
                    }

                    switch (piID)
                    {
                        case 1:

                            // Display the net position.
                            txtNet1.Text = strNet;
                            // Display the total Buys.
                            txtBuys1.Text = strBuys;
                            // Display the total Sells.
                            txtSells1.Text = strSells;

                            break;
                        case 2:

                            // Display the net position.
                            txtNet2.Text = strNet;
                            // Display the total Buys.
                            txtBuys2.Text = strBuys;
                            // Display the total Sells.
                            txtSells2.Text = strSells;

                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                // Trace the error.
                Trace.WriteLine("Error " + ex.ToString());

            }
        }

        private void cboAccounts_SelectedIndexChanged(Object sender, System.EventArgs e)
        {

            if ((cboAccounts.SelectedItem != null))
            {
                // Reference the current account.
                moAccount = (Account)cboAccounts.SelectedItem;

                // Register the account's events.
                if (moAccount != null)
                {
                    moAccount.OrderUpdate += new T4.API.Account.OrderUpdateEventHandler(moAccount_OrderUpdate);
                    moAccount.PositionUpdate += new T4.API.Account.PositionUpdateEventHandler(moAccounts_PositionUpdate);
                    moAccount.AccountUpdate += new T4.API.Account.AccountUpdateEventHandler(moAccounts_AccountUpdate);

                    // Display the current account balance.
                    DisplayAccount();

                    // Refresh positions.
                    DisplayPosition(moMarket1, 1);
                    DisplayPosition(moMarket2, 2);

                }

            }

        }


        #endregion

        #region Startup and shutdown code

        // Initialise the api when the application starts.
        private void frmMain_Load(object sender, System.EventArgs e)
        {

            moHost = Host.Login(APIServerType.Simulator, "T4Example", "112A04B0-5AAF-42F4-994E-FA7CB959C60B");

            // Check for success.

            if (moHost == null)
            {
                // Host object not returned which means the user cancelled the login dialog.
                this.Close();

            }
            else
            {
                // Login was successfull.
                Trace.WriteLine("Login Success");

                // Initialize.
                Init();

            }

        }

        // Shutdown the api when the application exits.
        private void frmMain_Closed(object sender, System.EventArgs e)
        {

            // Check to see that we have an api object.
            if (moHost != null)
            {

                // Unregister events.

                // Markets.
                if (moMarket1 != null)
                {
                    moMarket1.MarketCheckSubscription -= new T4.API.Market.MarketCheckSubscriptionEventHandler(Markets_MarketCheckSubscription);
                    moMarket1.MarketDepthUpdate -= new T4.API.Market.MarketDepthUpdateEventHandler(Markets_MarketDepthUpdate);
                }
                if (moMarket2 != null)
                {
                    moMarket2.MarketCheckSubscription -= new T4.API.Market.MarketCheckSubscriptionEventHandler(Markets_MarketCheckSubscription);
                    moMarket2.MarketDepthUpdate -= new T4.API.Market.MarketDepthUpdateEventHandler(Markets_MarketDepthUpdate);
                }

                // Account events.
                moHost.Accounts.AccountDetails -= new T4.API.AccountList.AccountDetailsEventHandler(moAccounts_AccountDetails);

                if (moAccount != null)
                {
                    moAccount.OrderUpdate -= new T4.API.Account.OrderUpdateEventHandler(moAccount_OrderUpdate);
                    moAccount.PositionUpdate -= new T4.API.Account.PositionUpdateEventHandler(moAccounts_PositionUpdate);
                    moAccount.AccountUpdate -= new T4.API.Account.AccountUpdateEventHandler(moAccounts_AccountUpdate);
                }

                // Dispose of the api.
                moHost.Dispose();
                moHost = null;
            }
        }

        #endregion

        #region Market Subscription 

        private void cmdGet1_Click(System.Object sender, System.EventArgs e)
        {

            // Clear the values.
            DisplayMarketDetails(null, 1);

            // Subscribe to market1.
            NewMarketSubscription(ref moMarket1, moPickerMarket);

            // Start the morket mode countdown.
            StartModeCountdown();

            // Refresh the positions.
            DisplayPosition(moMarket1, 1);

        }


        private void cmdGet2_Click(System.Object sender, System.EventArgs e)
        {
            Market oMarket = moHost.MarketData.MarketPicker(ref moMarket2);

            // Clear the values.
            DisplayMarketDetails(null, 2);

            // Subscribe to market2.
            NewMarketSubscription(ref moMarket2, oMarket);

            // Refresh the positions.
            DisplayPosition(moMarket2, 2);

        }

        private void NewMarketSubscription(ref Market poMarket, Market poNewMarket)
        {
            // Update an existing market reference to subscribe to a new/different market.

            // If they are the same then don't do anything.
            // We don't need to resubscribe to the same market.

            // Explicitly register events as opposed to declaring withevents.
            // This gives us more control.  
            // It is important to unregister the marketchecksubscription prior to unsubscribing or the event will override and maintain the subscription.


            if ((!object.ReferenceEquals(poMarket, poNewMarket)))
            {
                // Unsubscribe from the currently selected market.
                if ((poMarket != null))

                {
                    // Unregister the events for this market.
                    poMarket.MarketCheckSubscription -= new T4.API.Market.MarketCheckSubscriptionEventHandler(Markets_MarketCheckSubscription);
                    poMarket.MarketDepthUpdate -= new T4.API.Market.MarketDepthUpdateEventHandler(Markets_MarketDepthUpdate);

                    poMarket.DepthUnsubscribe();

                }

                // Update the market reference.
                poMarket = poNewMarket;

                if ((poMarket != null))
                {

                    // Register the events.
                    poMarket.MarketCheckSubscription += new T4.API.Market.MarketCheckSubscriptionEventHandler(Markets_MarketCheckSubscription);
                    poMarket.MarketDepthUpdate += new T4.API.Market.MarketDepthUpdateEventHandler(Markets_MarketDepthUpdate);

                    // Subscribe to the market.
                    // Use smart buffering.
                    poMarket.DepthSubscribe(DepthBuffer.Smart, DepthLevels.BestOnly);

                }

            }

        }

        private void Markets_MarketCheckSubscription(MarketCheckSubscriptionEventArgs e)
        {
            // No need to invoke on the gui thread.
            e.DepthSubscribeAtLeast(DepthBuffer.Smart, DepthLevels.BestOnly);

        }

        private void Markets_MarketDepthUpdate(MarketDepthUpdateEventArgs e)
        {
            // Invoke the update.
            // This places process on GUI thread.
            // Must use a delegate to pass arguments.
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Market.MarketDepthUpdateEventHandler(OnMarketDepthUpdate), new object[] { e });
            }
            else
            {
                OnMarketDepthUpdate(e);
            }

        }

        private void OnMarketDepthUpdate(MarketDepthUpdateEventArgs e)
        {

            try
            {

                if (e.Market == moMarket1)
                {
                    DisplayMarketDetails(e.Market, 1);
                }
                else if (e.Market == moMarket2)
                {
                    DisplayMarketDetails(e.Market, 2);
                }


            }
            catch (Exception ex)
            {
                // Trace the error.
                Trace.WriteLine("Error " + ex.ToString());

            }
        }

        /// <summary>
        /// Update the market display values.
        /// </summary>

        private void DisplayMarketDetails(Market poMarket, int piID)
        {
            string strDescription = "";
            string strBid = "";
            string strBidVol = "";
            string strOffer = "";
            string strOfferVol = "";
            string strLast = "";
            string strLastVol = "";
            string strLastVolTotal = "";

            if ((poMarket != null))
            {

                try
                {
                    // Display the market description.
                    strDescription = poMarket.Description;

                    MarketDepth d = poMarket.GetDepth();

                    // Best bid.
                    if (d.Bids.Count > 0)
                    {
                        strBid = poMarket.PriceToDisplay(d.Bids[0].Price);
                        strBidVol = d.Bids[0].Volume.ToString();
                    }

                    // Best offer.
                    if (d.Offers.Count > 0)
                    {
                        strOffer = poMarket.PriceToDisplay(d.Offers[0].Price);
                        strOfferVol = d.Offers[0].Volume.ToString();
                    }

                    MarketTrade t = poMarket.GetTrade();

                    // Last trade.
                    strLast = poMarket.PriceToDisplay(t.Price);
                    strLastVol = t.Volume.ToString();
                    strLastVolTotal = t.TotalVolume.ToString();


                }
                catch (Exception ex)
                {
                    // Trace the error.
                    Trace.WriteLine("Error " + ex.ToString());

                }

            }

            switch (piID)
            {
                case 1:

                    // Update the market1 display values.
                    txtMarketDescription1.Text = strDescription;
                    txtBid1.Text = strBid;
                    txtBidVol1.Text = strBidVol;
                    txtOffer1.Text = strOffer;
                    txtOfferVol1.Text = strOfferVol;
                    txtLast1.Text = strLast;
                    txtLastVol1.Text = strLastVol;
                    txtLastVolTotal1.Text = strLastVolTotal;

                    break;
                case 2:

                    // Update the market2 display values.
                    txtMarketDescription2.Text = strDescription;
                    txtBid2.Text = strBid;
                    txtBidVol2.Text = strBidVol;
                    txtOffer2.Text = strOffer;
                    txtOfferVol2.Text = strOfferVol;
                    txtLast2.Text = strLast;
                    txtLastVol2.Text = strLastVol;
                    txtLastVolTotal2.Text = strLastVolTotal;

                    break;
            }

        }

        #endregion

        #region Save Settings

        private void cmdSave_Click(System.Object sender, System.EventArgs e)
        {
            try
            {

                // XML Doc.
                XmlDocument oDoc = new XmlDocument();

                // XML Node.
                XmlNode oMarket;
                XmlNode oMarkets;
                XmlAttribute oAttribute;

                // Create the main node.
                oMarkets = oDoc.CreateNode(XmlNodeType.Element, "markets", "");
                oDoc.AppendChild(oMarkets);

                if (moMarket1 != null)
                {

                    // Create a node.
                    oMarket = oDoc.CreateNode(XmlNodeType.Element, "market1", "");

                    // Market ID.
                    oAttribute = oDoc.CreateAttribute("MarketID");
                    oAttribute.Value = moMarket1.MarketID;
                    oMarket.Attributes.Append(oAttribute);

                    // Add the node to the xml document.
                    oMarkets.AppendChild(oMarket);
                }

                if (moMarket2 != null)
                {

                    // Create a node.
                    oMarket = oDoc.CreateNode(XmlNodeType.Element, "market2", "");

                    // Market ID.
                    oAttribute = oDoc.CreateAttribute("MarketID");
                    oAttribute.Value = moMarket2.MarketID;
                    oMarket.Attributes.Append(oAttribute);

                    // Add the node to the xml document.
                    oMarkets.AppendChild(oMarket);

                }

                // Save the xml to the server.
                moHost.MasterUser.UserSettings = oDoc;
                moHost.MasterUser.SaveUserSettings();
            }
            catch (Exception ex)
            {
                // Trace.
                Trace.WriteLine(ex.ToString());
            }

        }

        public string App_Path()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }


        #endregion

        #region Single Order

        // Method that submits a single order.
        private void SubmitSingleOrder(Market poMarket, BuySell peBuySell, decimal pdecLimitPrice)
        {
            if (moAccount != null && poMarket != null)
            {

                // Submit an order.
                Order oOrder = moHost.SubmitOrder(
                    moAccount,
                    poMarket,
                    peBuySell,
                    PriceType.Limit,
                    1,
                    pdecLimitPrice);

                // Display the orders.
                DisplayOrders();

            }
        }

        // Pull the single order that was submitted.
        private void PullSingleOrder(Order poOrder)
        {
            // Check to see that we have an order.
            if (poOrder != null)
            {
                // Check to see if the order is working.
                if (poOrder.IsWorking)
                {
                    // Pull the order.
                    poOrder.Pull();
                }
            }
        }


        #endregion

        #region Submission/Cancelation

        private void cmdBuy1_Click(System.Object sender, System.EventArgs e)
        {
            // Submit a single order.
            decimal decPrice = 0;
            if (decimal.TryParse(txtBid1.Text, out decPrice))
            {
                SubmitSingleOrder(moMarket1, BuySell.Buy, decPrice);
            }
        }
        private void cmdSell1_Click(System.Object sender, System.EventArgs e)
        {
            // Submit a single order.
            decimal decPrice = 0;
            if (decimal.TryParse(txtOffer1.Text, out decPrice))
            {
                SubmitSingleOrder(moMarket1, BuySell.Sell, decPrice);
            }
        }

        private void cmdSell2_Click(System.Object sender, System.EventArgs e)
        {
            // Submit a single order.
            decimal decPrice = 0;
            if (decimal.TryParse(txtOffer2.Text, out decPrice))
            {
                SubmitSingleOrder(moMarket2, BuySell.Sell, decPrice);
            }
        }

        private void cmdBuy2_Click(System.Object sender, System.EventArgs e)
        {
            // Submit a single order.
            decimal decPrice = 0;
            if (decimal.TryParse(txtBid2.Text, out decPrice))
            {
                SubmitSingleOrder(moMarket2, BuySell.Buy, decPrice);
            }
        }

        private void lstOrders_DoubleClick(Object sender, System.EventArgs e)
        {
            // Attempt to pull the order.
            OrderInfo oOrder = (OrderInfo)lstOrders.SelectedItem;
            if (oOrder != null)
            {
                PullSingleOrder(oOrder.Order);
            }
        }

        #endregion

        #region  Order Data

        private void moAccount_OrderUpdate(OrderUpdateEventArgs e)
        {
            // Invoke the update.
            // This places process on GUI thread.
            // Must use a delegate to pass arguments.
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Account.OrderUpdateEventHandler(OnAccountOrderUpdate), new Object[] { e });
            }
            else
            {
                OnAccountOrderUpdate(e);
            }
        }

        private void OnAccountOrderUpdate(OrderUpdateEventArgs e)
        {
            // Redraw the order list.
            DisplayOrders();
        }

        private void DisplayOrders()
        {
            try
            {

                // Lock the api.
                moHost.EnterLock();

                // Suspend the layout of the listbox.
                lstOrders.SuspendLayout();

                // Clear and repopulate the list.
                lstOrders.Items.Clear();

                // Itterate through the orders, newest is first.
                foreach (Order oOrder in moAccount.Orders.GetSortedList())
                {
                    // Display some order details.
                    lstOrders.Items.Add(new OrderInfo(oOrder));

                }
            }
            catch (Exception ex)
            {
                // Trace the error.
                Trace.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                // Unlock the api.
                moHost.ExitLock();

                // Resume layout of the listbox.
                lstOrders.ResumeLayout();
            }
        }

        /// <summary>
        /// Class to hold and display details of an order in a list box.
        /// </summary>
        class OrderInfo
        {
            public readonly Order Order;
            public OrderInfo(Order poOrder)
            {
                Order = poOrder;
            }

            public override string ToString()
            {
                return Order.Market.Description + "   " +
                        Order.BuySell.ToString() + "   " +
                        Order.TotalFillVolume + "/" + Order.CurrentVolume + " @ " +
                        Order.Market.PriceToDisplay(Order.CurrentLimitPrice) + "   " +
                        Order.Status.ToString() + "   " +
                        Order.StatusDetail + "  " +
                        Order.SubmitTime;
            }
        }


        #endregion

        #region Misc Examples

        const string AUTOOCO = "Submit Auto OCO";
        const string FIVETICKSOFF = "Work 5 Ticks Off Market";

        // Setup misc example combos.
        private void SetupMiscExamples()
        {
            // Add examples to combos.
            cboMisc1.Items.Add(AUTOOCO);
            cboMisc1.Items.Add(FIVETICKSOFF);

            cboMisc2.Items.Add(AUTOOCO);
            cboMisc2.Items.Add(FIVETICKSOFF);

            // Be sure the first items are selected.
            cboMisc1.SelectedIndex = 0;
            cboMisc2.SelectedIndex = 0;

        }

        private void cmdRunMisc1_Click(Object sender, System.EventArgs e)
        {
            if (moMarket1 != null)
            {
                switch (cboMisc1.Text)
                {
                    case AUTOOCO:
                        {
                            // Run autooco sample code.
                            SubmitAOCO(moMarket1, BuySell.Buy, txtBid1.Text);
                            break;
                        }
                    case FIVETICKSOFF:
                        {
                            // Run the five ticks off code.
                            SubmitFiveTicksOff(moMarket1, BuySell.Buy, txtBid1.Text);
                            break;
                        }
                }
            }
        }

        private void cmdRunMisc2_Click(Object sender, System.EventArgs e)
        {
            if (moMarket2 != null)
            {

                switch (cboMisc2.Text)
                {
                    case AUTOOCO:
                        {
                            // Run autooco sample code.
                            SubmitAOCO(moMarket2, BuySell.Sell, txtOffer2.Text);
                            break;
                        }
                    case FIVETICKSOFF:
                        {
                            // Run the five ticks off code.
                            SubmitFiveTicksOff(moMarket2, BuySell.Sell, txtOffer2.Text);
                            break;
                        }
                }
            }
        }

        #region Auto OCO

        // Simple example of how to submit and cancel an Auto OCO.
        private void SubmitAOCO(Market poMarket, BuySell peBuySell, string pstrLimitDisplayPrice)
        {
            if (moAccount != null && poMarket != null)
            {

                // Limit price reference.
                decimal decLimitPrice = 0;
                if (decimal.TryParse(pstrLimitDisplayPrice, out decLimitPrice))
                {
                    // Create the batch submission object for AutoOCO
                    OrderSubmissionBatch oBatch = moHost.GetOrderSubmission(OrderLink.AutoOCO);

                    // Add an order to the batch.
                    // This is the trigger order.
                    oBatch.Add(
                        moAccount,
                        poMarket,
                        peBuySell,
                        PriceType.Limit,
                        1,
                        decLimitPrice);

                    // Add an order to the batch.
                    // This is the sell limit of the oco above the market.
                    // Note the flip of Buy/Sell.
                    // Note the ticks is a distance not a price representation.
                    oBatch.Add(
                        moAccount,
                        poMarket,
                        (BuySell)(-(int)peBuySell),
                        PriceType.Limit,
                        0,
                        poMarket.AddPriceIncrements(5 * (int)peBuySell, 0));

                    // Add an order to the batch.
                    // This is the stop of the oco below the market.
                    // Note the flip of Buy/Sell.
                    // Note the ticks is a distance not a price representation.
                    oBatch.Add(
                        moAccount,
                        poMarket,
                        (BuySell)(-(int)peBuySell),
                        PriceType.StopMarket,
                        0,
                        null,
                        poMarket.AddPriceIncrements(-5 * (int)peBuySell, 0),
                        "");


                    // Submit the batch.
                    List<Order> oSent = oBatch.Send();

                    // Display the orders.
                    DisplayOrders();

                }
            }
        }

        #endregion

        #region  Work Order Five Ticks From Market

        // Place an order five ticks off the market.
        private void SubmitFiveTicksOff(Market poMarket, BuySell peBuySell, string pstrLimitDisplayPrice)
        {
            // Limit price reference.
            decimal decLimitPrice = 0;
            if (decimal.TryParse(pstrLimitDisplayPrice, out decLimitPrice))
            {
                // Add or subtract five ticks from the current price depending on what side of the market we are.
                if (peBuySell == BuySell.Buy)
                    decLimitPrice = poMarket.AddPriceIncrements(-5, decLimitPrice);
                else
                    decLimitPrice = poMarket.AddPriceIncrements(5, decLimitPrice);

                // Submit a single order five ticks off the market.
                SubmitSingleOrder(poMarket, peBuySell, decLimitPrice);
            }

        }

        #endregion

        #endregion

        #region Market Mode Countdown 

        /// <summary>
        ///     ''' Timer for providing a countdown to the next market mode change.
        ///     ''' </summary>
        ///     ''' <remarks></remarks>
        private System.Threading.Timer moModeCountdown;

        /// <summary>
        ///     ''' Timer interval when no countdown is currently in process.
        ///     ''' </summary>
        ///     ''' <remarks></remarks>
        private const int mciModeCountdownSlow = 1000;

        /// <summary>
        ///     ''' Timer interval while we are counting down.
        ///     ''' </summary>
        ///     ''' <remarks></remarks>
        private const int mciModeCountdownFast = 200;

        /// <summary>
        ///     ''' The number of seconds to countdown to the next market mode change.
        ///     ''' For test purposes set to 24 hours so we can see it function.
        ///     ''' </summary>
        private const int mciCountDownSeconds = 86400;

        /// <summary>
        ///     ''' The timer interval we are currently using.
        ///     ''' </summary>
        ///     ''' <remarks></remarks>
        private int miModeCountdownInterval = mciModeCountdownSlow;

        /// <summary>
        ///     ''' Start the market mode countdown support.
        ///     ''' </summary>
        ///     ''' <remarks></remarks>
        private void StartModeCountdown()
        {
            moModeCountdown = new System.Threading.Timer(OnModeCountdown, null, 1000, miModeCountdownInterval);
        }

        /// <summary>
        ///     ''' Stop the market mode countdown support.
        ///     ''' </summary>
        ///     ''' <remarks></remarks>
        private void StopModeCountdown()
        {
            if (moModeCountdown != null)
            {
                moModeCountdown.Dispose();
                moModeCountdown = null;
            }
        }


        /// <summary>
        ///     ''' Timer event to provide a countdown to the next market mode change.
        ///     ''' </summary>
        ///     ''' <param name="state"></param>
        ///     ''' <remarks></remarks>
        private void OnModeCountdown(object state)
        {
            try
            {
                if (moMarket1 != null && moMarket1.Contract.Exchange.MarketDataType != MarketDataType.Delayed)
                {

                    // Get the next trading event.
                    DateTime dTime = moHost.RemoteTime();
                    T4.API.TradingSchedule.SessionEvent oSE = moMarket1.Contract.TradingSchedule.GetNextEvent(dTime, moMarket1.LastTradingDate);

                    // Check to see if we are within the countdown time.
                    if (oSE != null && dTime.AddSeconds(mciCountDownSeconds) >= oSE.Time)
                    {

                        // Check to see we are updating frequently enough.
                        if (miModeCountdownInterval != mciModeCountdownFast)
                        {
                            miModeCountdownInterval = mciModeCountdownFast;
                            moModeCountdown.Change(mciModeCountdownFast, mciModeCountdownFast);
                        }

                        // Get the current market mode.
                        MarketMode enCurrentMode = moMarket1.GetDepth().Mode;

                        // Check to see if the mode is actually changing.
                        if (enCurrentMode != oSE.Mode)
                        {

                            // Mode is changing, update the display to a countdown to the new mode.
                            TimeSpan dTimeToGo = oSE.Time.Subtract(dTime);
                            string sText = "";
                            if (dTimeToGo.Hours > 0)
                                sText = dTimeToGo.ToString(@"h\:mm\:ss");
                            else
                                sText = dTimeToGo.ToString(@"m\:ss");

                            // Invoke the update.
                            this.BeginInvoke(new MethodInvoker(() =>
                            {
                                txtMode.Text = sText;
                            }));
                        }
                    }
                    else
                    {

                        // Check to see we are updating frequently enough.
                        if (miModeCountdownInterval != mciModeCountdownSlow)
                        {
                            miModeCountdownInterval = mciModeCountdownSlow;
                            moModeCountdown.Change(mciModeCountdownSlow, mciModeCountdownSlow);
                        }

                        // Get the current market mode.
                        MarketMode enCurrentMode = moMarket1.GetDepth().Mode;

                        // Check to see if the mode is actually changing.
                        if (enCurrentMode != oSE.Mode)
                        {
                            string sText = enCurrentMode.ToString();

                            // Invoke the update.
                            this.BeginInvoke(new MethodInvoker(() =>
                            {
                                txtMode.Text = sText;
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error " + ex.ToString());
            }
        }
        #endregion
    }
}
