// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.loadingForm
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Relatorio_Produtos_VHSYS
{
  public class loadingForm : Form
  {
    private IContainer components;
    private Label labelStatus;
    private PictureBox pictureBoxLoadingGif;
    private Label labelCount;
    private Label labelPage;

    public loadingForm(string message)
    {
      this.InitializeComponent();
      this.labelStatus.Text = message;
    }

    public void labelCount_ChangeText(string text) => this.labelCount.Text = text;

    public void labelPage_ChangeText(string text) => this.labelPage.Text = text;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      //ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (loadingForm));
      this.labelStatus = new Label();
      this.pictureBoxLoadingGif = new PictureBox();
      this.labelCount = new Label();
      this.labelPage = new Label();
      ((ISupportInitialize) this.pictureBoxLoadingGif).BeginInit();
      this.SuspendLayout();
      this.labelStatus.Font = new Font("Microsoft JhengHei", 14.25f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelStatus.Location = new Point(12, 26);
      this.labelStatus.Name = "labelStatus";
      this.labelStatus.Size = new Size(420, 24);
      this.labelStatus.TabIndex = 0;
      this.labelStatus.TextAlign = ContentAlignment.MiddleCenter;
      this.pictureBoxLoadingGif.BackgroundImageLayout = ImageLayout.Stretch;
      //this.pictureBoxLoadingGif.Image = (Image) componentResourceManager.GetObject("pictureBoxLoadingGif.Image");
      this.pictureBoxLoadingGif.Location = new Point(176, 64);
      this.pictureBoxLoadingGif.Name = "pictureBoxLoadingGif";
      this.pictureBoxLoadingGif.Size = new Size(90, 90);
      this.pictureBoxLoadingGif.TabIndex = 1;
      this.pictureBoxLoadingGif.TabStop = false;
      this.labelCount.BackColor = Color.Transparent;
      this.labelCount.Font = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point);
      this.labelCount.ForeColor = Color.FromArgb(0, 174, 240);
      this.labelCount.Location = new Point(203, 98);
      this.labelCount.Name = "labelCount";
      this.labelCount.Size = new Size(37, 21);
      this.labelCount.TabIndex = 2;
      this.labelCount.Text = "0";
      this.labelCount.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPage.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelPage.Location = new Point(12, 157);
      this.labelPage.Name = "labelPage";
      this.labelPage.Size = new Size(420, 24);
      this.labelPage.TabIndex = 4;
      this.labelPage.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(444, 181);
      this.Controls.Add((Control) this.labelPage);
      this.Controls.Add((Control) this.labelCount);
      this.Controls.Add((Control) this.pictureBoxLoadingGif);
      this.Controls.Add((Control) this.labelStatus);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (loadingForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "loadingFromcs";
      this.TopMost = true;
      ((ISupportInitialize) this.pictureBoxLoadingGif).EndInit();
      this.ResumeLayout(false);
    }
  }
}
