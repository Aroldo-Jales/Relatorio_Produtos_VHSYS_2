// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.mainForm
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using Relatorio_Produtos_VHSYS.Classes.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Relatorio_Produtos_VHSYS
{
  public class mainForm : Form
  {
    private string status = "";
    private IContainer components;
    private Label labelTitle;
    private Button buttonClose;
    private Button buttonConfig;
    private Button buttonSearchConfirm;
    private TextBox textBoxSellerName;
    private DateTimePicker dateTimePickerInitial;
    private Label labelSeller;
    private GroupBox groupBoxDatePickers;
    private Label labelInitialDate;
    private DateTimePicker dateTimePickerFinal;
    private GroupBox groupBoxOrderStatus;
    private Button buttonMinimize;
    private Label labelFinalDate;
    private Label labelClient;
    private TextBox textBoxClientName;
    private RadioButton radioButtonAllStatus;
    private RadioButton radioButtonOpened;
    private RadioButton radioButtonAttended;
    private FileSystemWatcher fileSystemWatcher1;
    private CheckBox checkBoxSellerSearch;
    private FileSystemWatcher fileSystemWatcher2;
    private CheckBox checkBoxClientSearch;
    private GroupBox groupBoxOrders;
    private Label labelFinalOrder;
    private Label labelInitialOrder;
    private CheckBox checkBoxDatas;
    private CheckBox checkBoxPedidos;
    private MaskedTextBox maskedTextBoxPedidoFinal;
    private MaskedTextBox maskedTextBoxPedidoInicial;

    public mainForm() => this.InitializeComponent();

    private void mainForm_Load(object sender, EventArgs e)
    {
      this.dateTimePickerFinal.Value = DateTime.Now;
      this.dateTimePickerInitial.Value = DateTime.Now.AddDays(-1.0);
    }

    private void buttonClose_Click(object sender, EventArgs e) => Application.Exit();

    private void buttonMinimize_Click(object sender, EventArgs e)
    {
      if (this.WindowState != FormWindowState.Normal)
        return;
      this.WindowState = FormWindowState.Minimized;
    }

    private void buttonConfig_Click(object sender, EventArgs e)
    {
      int num = (int) new configForm().ShowDialog();
    }

    private void checkBoxSellerSearch_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.textBoxSellerName.Enabled)
      {
        this.textBoxSellerName.Enabled = true;
      }
      else
      {
        this.textBoxSellerName.Clear();
        this.textBoxSellerName.Enabled = false;
      }
    }

    private void checkBoxClientSearch_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.textBoxClientName.Enabled)
      {
        this.textBoxClientName.Enabled = true;
      }
      else
      {
        this.textBoxClientName.Clear();
        this.textBoxClientName.Enabled = false;
      }
    }

    private void buttonSearchConfirm_Click(object sender, EventArgs e)
    {
      if (this.checkBoxDatas.Checked)
      {
        int num1 = (int) new datagridForm((IDictionary<string, string>) new Dictionary<string, string>()
        {
          {
            "vendedor",
            this.textBoxSellerName.Text
          },
          {
            "cliente",
            this.textBoxClientName.Text
          },
          {
            "status",
            this.status
          },
          {
            "lixeira",
            "Nao"
          }
        }, (IDictionary<string, DateTime>) new Dictionary<string, DateTime>()
        {
          {
            "initial",
            this.dateTimePickerInitial.Value
          },
          {
            "final",
            this.dateTimePickerFinal.Value
          }
        }).ShowDialog();
      }
      else if (this.maskedTextBoxPedidoInicial.Text == "" || this.maskedTextBoxPedidoFinal.Text == "")
      {
        int num2 = (int) MessageBox.Show("Preencha os campos de pedido", "Valores Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        int int32_1 = Convert.ToInt32(this.maskedTextBoxPedidoInicial.Text);
        int int32_2 = Convert.ToInt32(this.maskedTextBoxPedidoFinal.Text);
        if (int32_1 > int32_2)
        {
          int num3 = (int) MessageBox.Show("O id de pedido inicial não pode ser maior que o id final", "Valores Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          int num4 = (int) new datagridForm((IDictionary<string, string>) new Dictionary<string, string>()
          {
            {
              "vendedor",
              this.textBoxSellerName.Text
            },
            {
              "cliente",
              this.textBoxClientName.Text
            },
            {
              "status",
              this.status
            },
            {
              "lixeira",
              "Nao"
            }
          }, GenerateListPedidos.returnListIdPedidos(int32_1, int32_2)).ShowDialog();
        }
      }
    }

    private void dateTimePickerFinal_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dateTimePickerInitial.Value > this.dateTimePickerFinal.Value))
        return;
      this.dateTimePickerInitial.Value = this.dateTimePickerFinal.Value;
      int num = (int) MessageBox.Show("A data inicial não pode ser maior que a data final", "Valores Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    private void dateTimePickerInitial_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dateTimePickerInitial.Value > this.dateTimePickerFinal.Value))
        return;
      this.dateTimePickerInitial.Value = this.dateTimePickerFinal.Value;
      int num = (int) MessageBox.Show("A data inicial não pode ser maior que a data final", "Valores Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    private void radioButtonOpened_CheckedChanged(object sender, EventArgs e) => this.status = "Em Aberto";

    private void radioButtonAttended_CheckedChanged(object sender, EventArgs e) => this.status = "Atendido";

    private void radioButtonAllStatus_CheckedChanged(object sender, EventArgs e) => this.status = "";

    private void checkBoxPedidos_Click(object sender, EventArgs e)
    {
      if (!this.checkBoxPedidos.Checked)
      {
        this.checkBoxPedidos.Checked = true;
        this.checkBoxPedidos.CheckState = CheckState.Checked;
      }
      this.checkBoxDatas.Checked = false;
      this.dateTimePickerInitial.Enabled = false;
      this.dateTimePickerFinal.Enabled = false;
      this.maskedTextBoxPedidoInicial.Enabled = true;
      this.maskedTextBoxPedidoFinal.Enabled = true;
    }

    private void checkBoxDatas_Click(object sender, EventArgs e)
    {
      if (!this.checkBoxDatas.Checked)
      {
        this.checkBoxDatas.Checked = true;
        this.checkBoxDatas.CheckState = CheckState.Checked;
      }
      this.checkBoxPedidos.Checked = false;
      this.maskedTextBoxPedidoInicial.Enabled = false;
      this.maskedTextBoxPedidoFinal.Enabled = false;
      this.dateTimePickerInitial.Enabled = true;
      this.dateTimePickerFinal.Enabled = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      //ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (mainForm));
      this.labelTitle = new Label();
      this.buttonClose = new Button();
      this.buttonConfig = new Button();
      this.buttonSearchConfirm = new Button();
      this.textBoxSellerName = new TextBox();
      this.labelSeller = new Label();
      this.dateTimePickerInitial = new DateTimePicker();
      this.dateTimePickerFinal = new DateTimePicker();
      this.groupBoxOrderStatus = new GroupBox();
      this.radioButtonAllStatus = new RadioButton();
      this.radioButtonOpened = new RadioButton();
      this.radioButtonAttended = new RadioButton();
      this.groupBoxDatePickers = new GroupBox();
      this.checkBoxDatas = new CheckBox();
      this.labelFinalDate = new Label();
      this.labelInitialDate = new Label();
      this.buttonMinimize = new Button();
      this.textBoxClientName = new TextBox();
      this.labelClient = new Label();
      this.fileSystemWatcher1 = new FileSystemWatcher();
      this.fileSystemWatcher2 = new FileSystemWatcher();
      this.checkBoxSellerSearch = new CheckBox();
      this.checkBoxClientSearch = new CheckBox();
      this.groupBoxOrders = new GroupBox();
      this.checkBoxPedidos = new CheckBox();
      this.maskedTextBoxPedidoFinal = new MaskedTextBox();
      this.maskedTextBoxPedidoInicial = new MaskedTextBox();
      this.labelFinalOrder = new Label();
      this.labelInitialOrder = new Label();
      this.groupBoxOrderStatus.SuspendLayout();
      this.groupBoxDatePickers.SuspendLayout();
      this.fileSystemWatcher1.BeginInit();
      this.fileSystemWatcher2.BeginInit();
      this.groupBoxOrders.SuspendLayout();
      this.SuspendLayout();
      this.labelTitle.AutoSize = true;
      this.labelTitle.Font = new Font("Segoe UI", 18f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelTitle.Location = new Point(12, 17);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new Size(288, 32);
      this.labelTitle.TabIndex = 0;
      this.labelTitle.Text = "Relatório Produtos VHSYS";
      this.buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.buttonClose.BackColor = Color.Transparent;
      this.buttonClose.BackgroundImageLayout = ImageLayout.None;
      this.buttonClose.FlatAppearance.BorderSize = 0;
      this.buttonClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.buttonClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
      this.buttonClose.FlatStyle = FlatStyle.Flat;
      this.buttonClose.ForeColor = Color.FromArgb((int) byte.MaxValue, 192, 192);
      //this.buttonClose.Image = (Image) componentResourceManager.GetObject("buttonClose.Image");
      this.buttonClose.Location = new Point(702, 9);
      this.buttonClose.Margin = new Padding(0);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new Size(40, 40);
      this.buttonClose.TabIndex = 1;
      this.buttonClose.UseVisualStyleBackColor = false;
      this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
      this.buttonConfig.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.buttonConfig.BackColor = Color.Transparent;
      this.buttonConfig.BackgroundImageLayout = ImageLayout.None;
      this.buttonConfig.FlatAppearance.BorderSize = 0;
      this.buttonConfig.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.buttonConfig.FlatAppearance.MouseOverBackColor = Color.Transparent;
      this.buttonConfig.FlatStyle = FlatStyle.Flat;
      //this.buttonConfig.Image = (Image) componentResourceManager.GetObject("buttonConfig.Image");
      this.buttonConfig.Location = new Point(604, 9);
      this.buttonConfig.Margin = new Padding(0);
      this.buttonConfig.Name = "buttonConfig";
      this.buttonConfig.Size = new Size(40, 40);
      this.buttonConfig.TabIndex = 2;
      this.buttonConfig.UseVisualStyleBackColor = false;
      this.buttonConfig.Click += new EventHandler(this.buttonConfig_Click);
      this.buttonSearchConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.buttonSearchConfirm.BackColor = Color.SteelBlue;
      this.buttonSearchConfirm.Cursor = Cursors.Hand;
      this.buttonSearchConfirm.FlatAppearance.BorderSize = 0;
      this.buttonSearchConfirm.FlatStyle = FlatStyle.Flat;
      this.buttonSearchConfirm.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point);
      this.buttonSearchConfirm.ForeColor = Color.White;
      this.buttonSearchConfirm.Location = new Point(559, 342);
      this.buttonSearchConfirm.Name = "buttonSearchConfirm";
      this.buttonSearchConfirm.Size = new Size(180, 40);
      this.buttonSearchConfirm.TabIndex = 3;
      this.buttonSearchConfirm.Text = "Confirmar";
      this.buttonSearchConfirm.UseVisualStyleBackColor = false;
      this.buttonSearchConfirm.Click += new EventHandler(this.buttonSearchConfirm_Click);
      this.textBoxSellerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBoxSellerName.Enabled = false;
      this.textBoxSellerName.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point);
      this.textBoxSellerName.Location = new Point(12, 160);
      this.textBoxSellerName.Name = "textBoxSellerName";
      this.textBoxSellerName.Size = new Size(310, 27);
      this.textBoxSellerName.TabIndex = 1;
      this.labelSeller.AutoSize = true;
      this.labelSeller.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelSeller.Location = new Point(12, 140);
      this.labelSeller.Name = "labelSeller";
      this.labelSeller.Size = new Size(65, 17);
      this.labelSeller.TabIndex = 4;
      this.labelSeller.Text = "Vendedor";
      this.dateTimePickerInitial.CustomFormat = "dd/MM/yyyy - HH:mm:ss";
      this.dateTimePickerInitial.Enabled = false;
      this.dateTimePickerInitial.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point);
      this.dateTimePickerInitial.Format = DateTimePickerFormat.Custom;
      this.dateTimePickerInitial.Location = new Point(6, 52);
      this.dateTimePickerInitial.Name = "dateTimePickerInitial";
      this.dateTimePickerInitial.Size = new Size(181, 27);
      this.dateTimePickerInitial.TabIndex = 2;
      this.dateTimePickerInitial.Value = new DateTime(2022, 4, 1, 0, 0, 0, 0);
      this.dateTimePickerInitial.ValueChanged += new EventHandler(this.dateTimePickerInitial_ValueChanged);
      this.dateTimePickerFinal.CustomFormat = "dd/MM/yyyy - HH:mm:ss";
      this.dateTimePickerFinal.Enabled = false;
      this.dateTimePickerFinal.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point);
      this.dateTimePickerFinal.Format = DateTimePickerFormat.Custom;
      this.dateTimePickerFinal.Location = new Point(193, 52);
      this.dateTimePickerFinal.Name = "dateTimePickerFinal";
      this.dateTimePickerFinal.Size = new Size(181, 27);
      this.dateTimePickerFinal.TabIndex = 5;
      this.dateTimePickerFinal.Value = new DateTime(2022, 4, 2, 0, 0, 0, 0);
      this.dateTimePickerFinal.ValueChanged += new EventHandler(this.dateTimePickerFinal_ValueChanged);
      this.groupBoxOrderStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.groupBoxOrderStatus.Controls.Add((Control) this.radioButtonAllStatus);
      this.groupBoxOrderStatus.Controls.Add((Control) this.radioButtonOpened);
      this.groupBoxOrderStatus.Controls.Add((Control) this.radioButtonAttended);
      this.groupBoxOrderStatus.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.groupBoxOrderStatus.Location = new Point(12, 252);
      this.groupBoxOrderStatus.Name = "groupBoxOrderStatus";
      this.groupBoxOrderStatus.Size = new Size(341, 77);
      this.groupBoxOrderStatus.TabIndex = 6;
      this.groupBoxOrderStatus.TabStop = false;
      this.groupBoxOrderStatus.Text = "Status ";
      this.radioButtonAllStatus.AutoSize = true;
      this.radioButtonAllStatus.Checked = true;
      this.radioButtonAllStatus.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.radioButtonAllStatus.Location = new Point(179, 31);
      this.radioButtonAllStatus.Name = "radioButtonAllStatus";
      this.radioButtonAllStatus.Size = new Size(67, 21);
      this.radioButtonAllStatus.TabIndex = 2;
      this.radioButtonAllStatus.TabStop = true;
      this.radioButtonAllStatus.Text = "Ambos";
      this.radioButtonAllStatus.UseVisualStyleBackColor = true;
      this.radioButtonAllStatus.CheckedChanged += new EventHandler(this.radioButtonAllStatus_CheckedChanged);
      this.radioButtonOpened.AutoSize = true;
      this.radioButtonOpened.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.radioButtonOpened.Location = new Point(92, 31);
      this.radioButtonOpened.Name = "radioButtonOpened";
      this.radioButtonOpened.Size = new Size(88, 21);
      this.radioButtonOpened.TabIndex = 1;
      this.radioButtonOpened.Text = "Em Aberto";
      this.radioButtonOpened.UseVisualStyleBackColor = true;
      this.radioButtonOpened.CheckedChanged += new EventHandler(this.radioButtonOpened_CheckedChanged);
      this.radioButtonAttended.AutoSize = true;
      this.radioButtonAttended.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.radioButtonAttended.Location = new Point(7, 31);
      this.radioButtonAttended.Name = "radioButtonAttended";
      this.radioButtonAttended.Size = new Size(79, 21);
      this.radioButtonAttended.TabIndex = 0;
      this.radioButtonAttended.Text = "Atendido";
      this.radioButtonAttended.UseVisualStyleBackColor = true;
      this.radioButtonAttended.CheckedChanged += new EventHandler(this.radioButtonAttended_CheckedChanged);
      this.groupBoxDatePickers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.groupBoxDatePickers.Controls.Add((Control) this.checkBoxDatas);
      this.groupBoxDatePickers.Controls.Add((Control) this.labelFinalDate);
      this.groupBoxDatePickers.Controls.Add((Control) this.labelInitialDate);
      this.groupBoxDatePickers.Controls.Add((Control) this.dateTimePickerFinal);
      this.groupBoxDatePickers.Controls.Add((Control) this.dateTimePickerInitial);
      this.groupBoxDatePickers.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.groupBoxDatePickers.Location = new Point(359, 238);
      this.groupBoxDatePickers.Name = "groupBoxDatePickers";
      this.groupBoxDatePickers.Size = new Size(380, 91);
      this.groupBoxDatePickers.TabIndex = 7;
      this.groupBoxDatePickers.TabStop = false;
      this.groupBoxDatePickers.Text = "Datas";
      this.checkBoxDatas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.checkBoxDatas.AutoSize = true;
      this.checkBoxDatas.Cursor = Cursors.Hand;
      this.checkBoxDatas.FlatStyle = FlatStyle.System;
      this.checkBoxDatas.Location = new Point(355, 19);
      this.checkBoxDatas.Name = "checkBoxDatas";
      this.checkBoxDatas.Size = new Size(25, 13);
      this.checkBoxDatas.TabIndex = 14;
      this.checkBoxDatas.UseVisualStyleBackColor = true;
      this.checkBoxDatas.Click += new EventHandler(this.checkBoxDatas_Click);
      this.labelFinalDate.AutoSize = true;
      this.labelFinalDate.Location = new Point(193, 32);
      this.labelFinalDate.Name = "labelFinalDate";
      this.labelFinalDate.Size = new Size(37, 17);
      this.labelFinalDate.TabIndex = 7;
      this.labelFinalDate.Text = "Final:";
      this.labelInitialDate.AutoSize = true;
      this.labelInitialDate.Location = new Point(6, 32);
      this.labelInitialDate.Name = "labelInitialDate";
      this.labelInitialDate.Size = new Size(43, 17);
      this.labelInitialDate.TabIndex = 6;
      this.labelInitialDate.Text = "Inicial:";
      this.buttonMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.buttonMinimize.BackColor = Color.Transparent;
      this.buttonMinimize.BackgroundImageLayout = ImageLayout.None;
      this.buttonMinimize.FlatAppearance.BorderSize = 0;
      this.buttonMinimize.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.buttonMinimize.FlatAppearance.MouseOverBackColor = Color.Transparent;
      this.buttonMinimize.FlatStyle = FlatStyle.Flat;
      //this.buttonMinimize.Image = (Image) componentResourceManager.GetObject("buttonMinimize.Image");
      this.buttonMinimize.Location = new Point(662, 9);
      this.buttonMinimize.Margin = new Padding(0);
      this.buttonMinimize.Name = "buttonMinimize";
      this.buttonMinimize.Size = new Size(40, 40);
      this.buttonMinimize.TabIndex = 8;
      this.buttonMinimize.UseVisualStyleBackColor = false;
      this.buttonMinimize.Click += new EventHandler(this.buttonMinimize_Click);
      this.textBoxClientName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBoxClientName.Enabled = false;
      this.textBoxClientName.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point);
      this.textBoxClientName.Location = new Point(12, 219);
      this.textBoxClientName.Name = "textBoxClientName";
      this.textBoxClientName.Size = new Size(310, 27);
      this.textBoxClientName.TabIndex = 9;
      this.labelClient.AutoSize = true;
      this.labelClient.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelClient.Location = new Point(12, 199);
      this.labelClient.Name = "labelClient";
      this.labelClient.Size = new Size(47, 17);
      this.labelClient.TabIndex = 10;
      this.labelClient.Text = "Cliente";
      this.fileSystemWatcher1.EnableRaisingEvents = true;
      this.fileSystemWatcher1.SynchronizingObject = (ISynchronizeInvoke) this;
      this.fileSystemWatcher2.EnableRaisingEvents = true;
      this.fileSystemWatcher2.SynchronizingObject = (ISynchronizeInvoke) this;
      this.checkBoxSellerSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.checkBoxSellerSearch.AutoSize = true;
      this.checkBoxSellerSearch.Cursor = Cursors.Hand;
      this.checkBoxSellerSearch.FlatStyle = FlatStyle.System;
      this.checkBoxSellerSearch.Location = new Point(328, 160);
      this.checkBoxSellerSearch.Name = "checkBoxSellerSearch";
      this.checkBoxSellerSearch.Size = new Size(25, 13);
      this.checkBoxSellerSearch.TabIndex = 12;
      this.checkBoxSellerSearch.UseVisualStyleBackColor = true;
      this.checkBoxSellerSearch.CheckedChanged += new EventHandler(this.checkBoxSellerSearch_CheckedChanged);
      this.checkBoxClientSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.checkBoxClientSearch.AutoSize = true;
      this.checkBoxClientSearch.Cursor = Cursors.Hand;
      this.checkBoxClientSearch.FlatStyle = FlatStyle.System;
      this.checkBoxClientSearch.Location = new Point(328, 219);
      this.checkBoxClientSearch.Name = "checkBoxClientSearch";
      this.checkBoxClientSearch.Size = new Size(25, 13);
      this.checkBoxClientSearch.TabIndex = 13;
      this.checkBoxClientSearch.UseVisualStyleBackColor = true;
      this.checkBoxClientSearch.CheckedChanged += new EventHandler(this.checkBoxClientSearch_CheckedChanged);
      this.groupBoxOrders.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.groupBoxOrders.Controls.Add((Control) this.checkBoxPedidos);
      this.groupBoxOrders.Controls.Add((Control) this.maskedTextBoxPedidoFinal);
      this.groupBoxOrders.Controls.Add((Control) this.maskedTextBoxPedidoInicial);
      this.groupBoxOrders.Controls.Add((Control) this.labelFinalOrder);
      this.groupBoxOrders.Controls.Add((Control) this.labelInitialOrder);
      this.groupBoxOrders.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.groupBoxOrders.Location = new Point(359, 141);
      this.groupBoxOrders.Name = "groupBoxOrders";
      this.groupBoxOrders.Size = new Size(380, 91);
      this.groupBoxOrders.TabIndex = 7;
      this.groupBoxOrders.TabStop = false;
      this.groupBoxOrders.Text = "Pedidos";
      this.checkBoxPedidos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.checkBoxPedidos.AutoSize = true;
      this.checkBoxPedidos.Checked = true;
      this.checkBoxPedidos.CheckState = CheckState.Checked;
      this.checkBoxPedidos.Cursor = Cursors.Hand;
      this.checkBoxPedidos.FlatStyle = FlatStyle.System;
      this.checkBoxPedidos.Location = new Point(355, 19);
      this.checkBoxPedidos.Name = "checkBoxPedidos";
      this.checkBoxPedidos.Size = new Size(25, 13);
      this.checkBoxPedidos.TabIndex = 15;
      this.checkBoxPedidos.UseVisualStyleBackColor = true;
      this.checkBoxPedidos.Click += new EventHandler(this.checkBoxPedidos_Click);
      this.maskedTextBoxPedidoFinal.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.maskedTextBoxPedidoFinal.Location = new Point(193, 52);
      this.maskedTextBoxPedidoFinal.Mask = "00000000000";
      this.maskedTextBoxPedidoFinal.Name = "maskedTextBoxPedidoFinal";
      this.maskedTextBoxPedidoFinal.Size = new Size(100, 25);
      this.maskedTextBoxPedidoFinal.TabIndex = 11;
      this.maskedTextBoxPedidoFinal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.maskedTextBoxPedidoInicial.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.maskedTextBoxPedidoInicial.Location = new Point(6, 52);
      this.maskedTextBoxPedidoInicial.Mask = "00000000000";
      this.maskedTextBoxPedidoInicial.Name = "maskedTextBoxPedidoInicial";
      this.maskedTextBoxPedidoInicial.Size = new Size(100, 25);
      this.maskedTextBoxPedidoInicial.TabIndex = 10;
      this.maskedTextBoxPedidoInicial.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.labelFinalOrder.AutoSize = true;
      this.labelFinalOrder.Location = new Point(193, 32);
      this.labelFinalOrder.Name = "labelFinalOrder";
      this.labelFinalOrder.Size = new Size(37, 17);
      this.labelFinalOrder.TabIndex = 9;
      this.labelFinalOrder.Text = "Final:";
      this.labelInitialOrder.AutoSize = true;
      this.labelInitialOrder.Location = new Point(6, 32);
      this.labelInitialOrder.Name = "labelInitialOrder";
      this.labelInitialOrder.Size = new Size(43, 17);
      this.labelInitialOrder.TabIndex = 8;
      this.labelInitialOrder.Text = "Inicial:";
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ButtonFace;
      this.ClientSize = new Size(751, 394);
      this.Controls.Add((Control) this.groupBoxOrders);
      this.Controls.Add((Control) this.checkBoxClientSearch);
      this.Controls.Add((Control) this.checkBoxSellerSearch);
      this.Controls.Add((Control) this.labelClient);
      this.Controls.Add((Control) this.textBoxClientName);
      this.Controls.Add((Control) this.buttonMinimize);
      this.Controls.Add((Control) this.groupBoxDatePickers);
      this.Controls.Add((Control) this.groupBoxOrderStatus);
      this.Controls.Add((Control) this.labelSeller);
      this.Controls.Add((Control) this.textBoxSellerName);
      this.Controls.Add((Control) this.buttonSearchConfirm);
      this.Controls.Add((Control) this.buttonConfig);
      this.Controls.Add((Control) this.buttonClose);
      this.Controls.Add((Control) this.labelTitle);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (mainForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Consulta de Vendas";
      this.Load += new EventHandler(this.mainForm_Load);
      this.groupBoxOrderStatus.ResumeLayout(false);
      this.groupBoxOrderStatus.PerformLayout();
      this.groupBoxDatePickers.ResumeLayout(false);
      this.groupBoxDatePickers.PerformLayout();
      this.fileSystemWatcher1.EndInit();
      this.fileSystemWatcher2.EndInit();
      this.groupBoxOrders.ResumeLayout(false);
      this.groupBoxOrders.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
