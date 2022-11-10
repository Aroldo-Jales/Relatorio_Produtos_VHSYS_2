// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.datagridForm
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using ClosedXML.Excel;
using Relatorio_Produtos_VHSYS.Classes;
using Relatorio_Produtos_VHSYS.Classes.Products_Deserialize;
using Relatorio_Produtos_VHSYS.Classes.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;



namespace Relatorio_Produtos_VHSYS
{
  public class datagridForm : Form
  {
    private int total_produtos;
    private double total_peso_bruto;
    private double total_peso_liquido;
    private int quantidade_vendida;
    private double valor_total_vendido;
    private int total_pedidos;

    IContainer components;
    private Button button1;
    private Label labelTitle;
    private Button buttonPdfSave;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn nome;
    private DataGridViewTextBoxColumn qtd_vendido;
    private DataGridViewTextBoxColumn valor_vendido;
    private Panel panelProductsInfo;
    private Label labelValorTotalVendido;
    private Label labelQuantidadeVendida;
    private Label labelTotalPesoLiquido;
    private Label labelTotalPesoBruto;
    private Label labelTotalProducts;
    private Label label7;
    private Label label5;
    private Label label3;
    private Label label1;
    private Label labelProductTotal;
    private Panel panelOrdersCount;
    private Label labelOrdersCount;
    private Label labelTotalOrders;
    private Button buttonExcelSave;

    private IDictionary<string, string> mapSearchParams { get; set; }

    private IDictionary<string, System.DateTime> searchDates { get; set; }

    private List<int> orders_ids { get; set; }

    public datagridForm(
      IDictionary<string, string> mapSearchParams_,
      IDictionary<string, System.DateTime> searchDates_)
    {
      this.InitializeComponent();
      this.mapSearchParams = mapSearchParams_;
      this.searchDates = searchDates_;
    }

    public datagridForm(IDictionary<string, string> mapSearchParams_, List<int> orders_ids)
    {
      this.InitializeComponent();
      this.mapSearchParams = mapSearchParams_;
      this.orders_ids = orders_ids;
    }

    private async void datagridForm_Load(object sender, EventArgs e)
    {
      datagridForm datagridForm = this;
      datagridForm.dataGridView1.Columns["valor_vendido"].DefaultCellStyle.Format = "N2";
      List<OrderFormatted> orderFormattedList = new List<OrderFormatted>();
      List<OrderFormatted> OrdersList;
      if (datagridForm.searchDates != null)
        OrdersList = await ReturnLists.returnOrdersList(datagridForm.mapSearchParams, datagridForm.searchDates);
      else
        OrdersList = await ReturnLists.returnOrdersListByRangeOrder(datagridForm.mapSearchParams, datagridForm.orders_ids);
      if (OrdersList.Count > 0)
      {
        datagridForm.calcproducts(OrdersList);
      }
      else
      {
        int num = (int) MessageBox.Show("Nenhum resultado encontrado", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        datagridForm.Close();
      }
    }

    private async void calcproducts(List<OrderFormatted> OrdersList)
    {
      this.panelOrdersCount.Visible = true;
      this.total_pedidos = OrdersList.Count;
      this.labelOrdersCount.Text = this.total_pedidos.ToString();
      this.panelProductsInfo.Visible = true;
      List<Product> source = await ReturnLists.returnProductsList(OrdersList);
      foreach (Product product in source)
      {
        int num1 = int.Parse(StringFormatUtils.excludeNumberAfterPoint(product.qtde_produto));
        double num2 = double.Parse(StringFormatUtils.excludeNumberAfterPoint(product.peso_produto)) * (double) num1;
        double num3 = double.Parse(StringFormatUtils.excludeNumberAfterPoint(product.peso_liq_produto)) * (double) num1;
        this.total_peso_bruto += num2;
        this.total_peso_liquido += num3;
        this.quantidade_vendida += num1;
        this.valor_total_vendido += double.Parse(StringFormatUtils.excludeNumberAfterPoint(product.valor_total_produto));
        this.labelTotalProducts.Text = this.total_produtos.ToString();
        this.labelTotalPesoBruto.Text = this.total_peso_bruto.ToString("N2");
        this.labelTotalPesoLiquido.Text = this.total_peso_liquido.ToString("N2");
        this.labelQuantidadeVendida.Text = this.quantidade_vendida.ToString();
        this.labelValorTotalVendido.Text = this.valor_total_vendido.ToString("N2");
      }
      List<ProductList> list = source.GroupBy<Product, int>((Func<Product, int>) (p => p.id_produto)).Select<IGrouping<int, Product>, ProductList>((Func<IGrouping<int, Product>, ProductList>) (pf => new ProductList()
      {
        nome = pf.First<Product>().desc_produto,
        qtd_vendido = pf.Sum<Product>((Func<Product, int>) (s => int.Parse(StringFormatUtils.excludeNumberAfterPoint(s.qtde_produto)))),
        valor_vendido = pf.Sum<Product>((Func<Product, double>) (s => double.Parse(StringFormatUtils.excludeNumberAfterPoint(s.valor_total_produto))))
      })).ToList<ProductList>();
      this.dataGridView1.DataSource = (object) new BindingSource((object) new BindingList<ProductList>((IList<ProductList>) list), (string) null);
      this.buttonPdfSave.Enabled = true;
      this.buttonExcelSave.Enabled = true;
      this.total_produtos = list.Count;
      this.labelTotalProducts.Text = this.total_produtos.ToString();
      this.labelTotalPesoBruto.Text = this.total_peso_bruto.ToString("N2");
      this.labelTotalPesoLiquido.Text = this.total_peso_liquido.ToString("N2");
      this.labelQuantidadeVendida.Text = this.quantidade_vendida.ToString();
      this.labelValorTotalVendido.Text = this.valor_total_vendido.ToString("N2");
    }

    private void buttonPdfSave_Click(object sender, EventArgs e)
    {
      string titulo = "Relatório de Produtos";
      if (this.searchDates != null)
        titulo = titulo + "\n" + this.searchDates["initial"].ToShortDateString() + " - " + this.searchDates["final"].ToShortDateString() + "\n";
      string resumo = "Total Pedidos: " + this.total_pedidos.ToString() + "\nTotal Peso Bruto: " + this.total_peso_bruto.ToString("N2") + "\nTotal Peso Líquido: " + this.total_peso_liquido.ToString("N2") + "\nQuantidade Vendida: " + this.quantidade_vendida.ToString() + "\nValor Total Vendido: " + this.valor_total_vendido.ToString("N2") + "\n\n";
      GenerateReport.generatePdf(titulo, resumo, this.dataGridView1);
    }

    private void buttonExcelSave_Click(object sender, EventArgs e)
    {
      DataTable dataTable = new DataTable();
      foreach (DataGridViewColumn column in (BaseCollection) this.dataGridView1.Columns)
        dataTable.Columns.Add(column.HeaderText, column.ValueType);
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        dataTable.Rows.Add();
        foreach (DataGridViewCell cell in (BaseCollection) row.Cells)
          dataTable.Rows[dataTable.Rows.Count - 1][cell.ColumnIndex] = (object) cell.Value.ToString();
      }
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.FileName = "";
      saveFileDialog.DefaultExt = ".xlsx";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        using (XLWorkbook xlWorkbook = new XLWorkbook())
        {
          xlWorkbook.Worksheets.Add(dataTable, "Relatório Produtos");
          xlWorkbook.SaveAs(saveFileDialog.FileName);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Erro ao tentar salvar documento.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      //ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (datagridForm));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      this.button1 = new Button();
      this.labelTitle = new Label();
      this.buttonPdfSave = new Button();
      this.dataGridView1 = new DataGridView();
      this.nome = new DataGridViewTextBoxColumn();
      this.qtd_vendido = new DataGridViewTextBoxColumn();
      this.valor_vendido = new DataGridViewTextBoxColumn();
      this.panelProductsInfo = new Panel();
      this.labelValorTotalVendido = new Label();
      this.labelQuantidadeVendida = new Label();
      this.labelTotalPesoLiquido = new Label();
      this.labelTotalPesoBruto = new Label();
      this.labelTotalProducts = new Label();
      this.label7 = new Label();
      this.label5 = new Label();
      this.label3 = new Label();
      this.label1 = new Label();
      this.labelProductTotal = new Label();
      this.panelOrdersCount = new Panel();
      this.labelOrdersCount = new Label();
      this.labelTotalOrders = new Label();
      this.buttonExcelSave = new Button();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.panelProductsInfo.SuspendLayout();
      this.panelOrdersCount.SuspendLayout();
      this.SuspendLayout();
      this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.button1.Location = new Point(1009, 876);
      this.button1.Margin = new Padding(3, 2, 3, 2);
      this.button1.Name = "button1";
      this.button1.Size = new Size(64, 21);
      this.button1.TabIndex = 1;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.labelTitle.AutoSize = true;
      this.labelTitle.Font = new Font("Segoe UI", 18f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelTitle.ForeColor = Color.Black;
      this.labelTitle.Location = new Point(10, 26);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new Size(0, 32);
      this.labelTitle.TabIndex = 3;
      this.buttonPdfSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.buttonPdfSave.BackColor = Color.FromArgb(0, 174, 240);
      this.buttonPdfSave.BackgroundImageLayout = ImageLayout.None;
      this.buttonPdfSave.Cursor = Cursors.Hand;
      this.buttonPdfSave.Enabled = false;
      this.buttonPdfSave.FlatAppearance.BorderColor = Color.FromArgb(0, 174, 240);
      this.buttonPdfSave.FlatAppearance.BorderSize = 0;
      this.buttonPdfSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
      this.buttonPdfSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 174, 240);
      this.buttonPdfSave.FlatStyle = FlatStyle.Flat;
      this.buttonPdfSave.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point);
      this.buttonPdfSave.ForeColor = Color.White;
      //this.buttonPdfSave.Image = (Image) componentResourceManager.GetObject("buttonPdfSave.Image");
      this.buttonPdfSave.Location = new Point(947, 96);
      this.buttonPdfSave.Margin = new Padding(0);
      this.buttonPdfSave.Name = "buttonPdfSave";
      this.buttonPdfSave.Size = new Size((int) sbyte.MaxValue, 35);
      this.buttonPdfSave.TabIndex = 9;
      this.buttonPdfSave.Text = "Salvar PDF";
      this.buttonPdfSave.TextImageRelation = TextImageRelation.TextBeforeImage;
      this.buttonPdfSave.UseVisualStyleBackColor = false;
      this.buttonPdfSave.Click += new EventHandler(this.buttonPdfSave_Click);
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.BackgroundColor = Color.White;
      this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.Format = "N2";
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.nome, (DataGridViewColumn) this.qtd_vendido, (DataGridViewColumn) this.valor_vendido);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      gridViewCellStyle2.ForeColor = SystemColors.Control;
      gridViewCellStyle2.NullValue = (object) null;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = gridViewCellStyle2;
      this.dataGridView1.GridColor = Color.White;
      this.dataGridView1.Location = new Point(11, 144);
      this.dataGridView1.Margin = new Padding(3, 2, 3, 2);
      this.dataGridView1.MultiSelect = false;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      gridViewCellStyle3.ForeColor = Color.Black;
      this.dataGridView1.RowsDefaultCellStyle = gridViewCellStyle3;
      this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
      this.dataGridView1.RowTemplate.Height = 25;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1062, 657);
      this.dataGridView1.TabIndex = 18;
      this.nome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.nome.DataPropertyName = "nome";
      this.nome.HeaderText = "Nome Produto";
      this.nome.Name = "nome";
      this.qtd_vendido.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.qtd_vendido.DataPropertyName = "qtd_vendido";
      this.qtd_vendido.HeaderText = "Quantidade";
      this.qtd_vendido.Name = "qtd_vendido";
      this.valor_vendido.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.valor_vendido.DataPropertyName = "valor_vendido";
      this.valor_vendido.HeaderText = "Valor";
      this.valor_vendido.Name = "valor_vendido";
      this.panelProductsInfo.BackColor = Color.White;
      this.panelProductsInfo.BorderStyle = BorderStyle.FixedSingle;
      this.panelProductsInfo.Controls.Add((Control) this.labelValorTotalVendido);
      this.panelProductsInfo.Controls.Add((Control) this.labelQuantidadeVendida);
      this.panelProductsInfo.Controls.Add((Control) this.labelTotalPesoLiquido);
      this.panelProductsInfo.Controls.Add((Control) this.labelTotalPesoBruto);
      this.panelProductsInfo.Controls.Add((Control) this.labelTotalProducts);
      this.panelProductsInfo.Controls.Add((Control) this.label7);
      this.panelProductsInfo.Controls.Add((Control) this.label5);
      this.panelProductsInfo.Controls.Add((Control) this.label3);
      this.panelProductsInfo.Controls.Add((Control) this.label1);
      this.panelProductsInfo.Controls.Add((Control) this.labelProductTotal);
      this.panelProductsInfo.Location = new Point(10, 11);
      this.panelProductsInfo.Margin = new Padding(3, 2, 3, 2);
      this.panelProductsInfo.Name = "panelProductsInfo";
      this.panelProductsInfo.Size = new Size(220, 120);
      this.panelProductsInfo.TabIndex = 17;
      this.labelValorTotalVendido.AutoSize = true;
      this.labelValorTotalVendido.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelValorTotalVendido.ForeColor = Color.Black;
      this.labelValorTotalVendido.Location = new Point(142, 96);
      this.labelValorTotalVendido.Margin = new Padding(0);
      this.labelValorTotalVendido.Name = "labelValorTotalVendido";
      this.labelValorTotalVendido.Size = new Size(13, 14);
      this.labelValorTotalVendido.TabIndex = 21;
      this.labelValorTotalVendido.Text = "0";
      this.labelQuantidadeVendida.AutoSize = true;
      this.labelQuantidadeVendida.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelQuantidadeVendida.ForeColor = Color.Black;
      this.labelQuantidadeVendida.Location = new Point(130, 73);
      this.labelQuantidadeVendida.Margin = new Padding(0);
      this.labelQuantidadeVendida.Name = "labelQuantidadeVendida";
      this.labelQuantidadeVendida.Size = new Size(13, 14);
      this.labelQuantidadeVendida.TabIndex = 20;
      this.labelQuantidadeVendida.Text = "0";
      this.labelTotalPesoLiquido.AutoSize = true;
      this.labelTotalPesoLiquido.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelTotalPesoLiquido.ForeColor = Color.Black;
      this.labelTotalPesoLiquido.Location = new Point(117, 50);
      this.labelTotalPesoLiquido.Margin = new Padding(0);
      this.labelTotalPesoLiquido.Name = "labelTotalPesoLiquido";
      this.labelTotalPesoLiquido.Size = new Size(13, 14);
      this.labelTotalPesoLiquido.TabIndex = 19;
      this.labelTotalPesoLiquido.Text = "0";
      this.labelTotalPesoBruto.AutoSize = true;
      this.labelTotalPesoBruto.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelTotalPesoBruto.ForeColor = Color.Black;
      this.labelTotalPesoBruto.Location = new Point(106, 26);
      this.labelTotalPesoBruto.Margin = new Padding(0);
      this.labelTotalPesoBruto.Name = "labelTotalPesoBruto";
      this.labelTotalPesoBruto.Size = new Size(13, 14);
      this.labelTotalPesoBruto.TabIndex = 18;
      this.labelTotalPesoBruto.Text = "0";
      this.labelTotalProducts.AutoSize = true;
      this.labelTotalProducts.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelTotalProducts.ForeColor = Color.Black;
      this.labelTotalProducts.Location = new Point(96, 4);
      this.labelTotalProducts.Margin = new Padding(0);
      this.labelTotalProducts.Name = "labelTotalProducts";
      this.labelTotalProducts.Size = new Size(13, 14);
      this.labelTotalProducts.TabIndex = 17;
      this.labelTotalProducts.Text = "0";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(4, 96);
      this.label7.Margin = new Padding(4, 4, 3, 4);
      this.label7.Name = "label7";
      this.label7.Size = new Size(135, 14);
      this.label7.TabIndex = 16;
      this.label7.Text = "Valor Total Vendido:  R$";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.label5.ForeColor = Color.Black;
      this.label5.Location = new Point(4, 73);
      this.label5.Margin = new Padding(4);
      this.label5.Name = "label5";
      this.label5.Size = new Size(122, 14);
      this.label5.TabIndex = 15;
      this.label5.Text = "Quantidade Vendida:";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(4, 50);
      this.label3.Margin = new Padding(4);
      this.label3.Name = "label3";
      this.label3.Size = new Size(109, 14);
      this.label3.TabIndex = 14;
      this.label3.Text = "Total Peso Líquido:";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(4, 26);
      this.label1.Margin = new Padding(4);
      this.label1.Name = "label1";
      this.label1.Size = new Size(98, 14);
      this.label1.TabIndex = 13;
      this.label1.Text = "Total Peso Bruto:";
      this.labelProductTotal.AutoSize = true;
      this.labelProductTotal.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelProductTotal.ForeColor = Color.Black;
      this.labelProductTotal.Location = new Point(4, 4);
      this.labelProductTotal.Margin = new Padding(4);
      this.labelProductTotal.Name = "labelProductTotal";
      this.labelProductTotal.Size = new Size(88, 14);
      this.labelProductTotal.TabIndex = 12;
      this.labelProductTotal.Text = "Total Produtos:";
      this.panelOrdersCount.BackColor = Color.White;
      this.panelOrdersCount.BorderStyle = BorderStyle.FixedSingle;
      this.panelOrdersCount.Controls.Add((Control) this.labelOrdersCount);
      this.panelOrdersCount.Controls.Add((Control) this.labelTotalOrders);
      this.panelOrdersCount.Location = new Point(236, 97);
      this.panelOrdersCount.Margin = new Padding(3, 2, 3, 2);
      this.panelOrdersCount.Name = "panelOrdersCount";
      this.panelOrdersCount.Size = new Size(146, 34);
      this.panelOrdersCount.TabIndex = 22;
      this.labelOrdersCount.AutoSize = true;
      this.labelOrdersCount.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelOrdersCount.ForeColor = Color.Black;
      this.labelOrdersCount.Location = new Point(96, 10);
      this.labelOrdersCount.Margin = new Padding(4);
      this.labelOrdersCount.Name = "labelOrdersCount";
      this.labelOrdersCount.Size = new Size(13, 14);
      this.labelOrdersCount.TabIndex = 17;
      this.labelOrdersCount.Text = "0";
      this.labelTotalOrders.AutoSize = true;
      this.labelTotalOrders.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelTotalOrders.ForeColor = Color.Black;
      this.labelTotalOrders.Location = new Point(4, 10);
      this.labelTotalOrders.Margin = new Padding(4);
      this.labelTotalOrders.Name = "labelTotalOrders";
      this.labelTotalOrders.Size = new Size(84, 14);
      this.labelTotalOrders.TabIndex = 12;
      this.labelTotalOrders.Text = "Total Pedidos:";
      this.buttonExcelSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.buttonExcelSave.BackColor = Color.FromArgb(0, 174, 240);
      this.buttonExcelSave.BackgroundImageLayout = ImageLayout.None;
      this.buttonExcelSave.Cursor = Cursors.Hand;
      this.buttonExcelSave.Enabled = false;
      this.buttonExcelSave.FlatAppearance.BorderColor = Color.FromArgb(0, 174, 240);
      this.buttonExcelSave.FlatAppearance.BorderSize = 0;
      this.buttonExcelSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
      this.buttonExcelSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 174, 240);
      this.buttonExcelSave.FlatStyle = FlatStyle.Flat;
      this.buttonExcelSave.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point);
      this.buttonExcelSave.ForeColor = Color.White;
      //this.buttonExcelSave.Image = (Image) componentResourceManager.GetObject("buttonExcelSave.Image");
      this.buttonExcelSave.Location = new Point(807, 97);
      this.buttonExcelSave.Margin = new Padding(0);
      this.buttonExcelSave.Name = "buttonExcelSave";
      this.buttonExcelSave.Size = new Size((int) sbyte.MaxValue, 35);
      this.buttonExcelSave.TabIndex = 23;
      this.buttonExcelSave.Text = "Salvar EXCEL";
      this.buttonExcelSave.TextImageRelation = TextImageRelation.TextBeforeImage;
      this.buttonExcelSave.UseVisualStyleBackColor = false;
      this.buttonExcelSave.Click += new EventHandler(this.buttonExcelSave_Click);
      this.AutoScaleDimensions = new SizeF(6f, 14f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1083, 811);
      this.Controls.Add((Control) this.buttonExcelSave);
      this.Controls.Add((Control) this.panelOrdersCount);
      this.Controls.Add((Control) this.panelProductsInfo);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.buttonPdfSave);
      this.Controls.Add((Control) this.labelTitle);
      this.Controls.Add((Control) this.button1);
      this.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.ForeColor = SystemColors.Control;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Margin = new Padding(3, 2, 3, 2);
      this.Name = nameof (datagridForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Relatório Produtos";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.datagridForm_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.panelProductsInfo.ResumeLayout(false);
      this.panelProductsInfo.PerformLayout();
      this.panelOrdersCount.ResumeLayout(false);
      this.panelOrdersCount.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
