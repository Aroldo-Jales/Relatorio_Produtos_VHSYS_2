// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.configForm
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using Relatorio_Produtos_VHSYS.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Relatorio_Produtos_VHSYS
{
  public class configForm : Form
  {
    private IContainer components;
    private Button buttonTokenConfirm;
    private TextBox textBoxAcessToken;
    private TextBox textBoxSecretToken;
    private Label labelAcessToken;
    private Label labelSecretToken;

    public configForm() => this.InitializeComponent();

    private void configForm_Load(object sender, EventArgs e)
    {
      this.textBoxAcessToken.Text = Settings.Default.accessToken;
      this.textBoxSecretToken.Text = Settings.Default.secretAccessToken;
    }

    private void buttonTokenConfirm_Click(object sender, EventArgs e)
    {
      if (this.textBoxAcessToken.Text == "" || this.textBoxSecretToken.Text == "")
      {
        int num1 = (int) MessageBox.Show("Preencha todos os campos.", "Ação inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (Settings.Default.accessToken != this.textBoxAcessToken.Text || Settings.Default.secretAccessToken != this.textBoxSecretToken.Text)
      {
        Settings.Default.accessToken = this.textBoxAcessToken.Text;
        Settings.Default.secretAccessToken = this.textBoxSecretToken.Text;
        Settings.Default.Save();
        int num2 = (int) MessageBox.Show("Configuração salva.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.Close();
      }
      else
        this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.buttonTokenConfirm = new Button();
      this.textBoxAcessToken = new TextBox();
      this.textBoxSecretToken = new TextBox();
      this.labelAcessToken = new Label();
      this.labelSecretToken = new Label();
      this.SuspendLayout();
      this.buttonTokenConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.buttonTokenConfirm.BackColor = Color.SteelBlue;
      this.buttonTokenConfirm.FlatAppearance.BorderSize = 0;
      this.buttonTokenConfirm.FlatStyle = FlatStyle.Flat;
      this.buttonTokenConfirm.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.buttonTokenConfirm.ForeColor = Color.White;
      this.buttonTokenConfirm.Location = new Point(324, 126);
      this.buttonTokenConfirm.Name = "buttonTokenConfirm";
      this.buttonTokenConfirm.Size = new Size(165, 35);
      this.buttonTokenConfirm.TabIndex = 0;
      this.buttonTokenConfirm.Text = "Confirmar";
      this.buttonTokenConfirm.UseVisualStyleBackColor = false;
      this.buttonTokenConfirm.Click += new EventHandler(this.buttonTokenConfirm_Click);
      this.textBoxAcessToken.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.textBoxAcessToken.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.textBoxAcessToken.Location = new Point(149, 30);
      this.textBoxAcessToken.Name = "textBoxAcessToken";
      this.textBoxAcessToken.Size = new Size(340, 25);
      this.textBoxAcessToken.TabIndex = 1;
      this.textBoxSecretToken.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.textBoxSecretToken.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.textBoxSecretToken.Location = new Point(149, 79);
      this.textBoxSecretToken.Name = "textBoxSecretToken";
      this.textBoxSecretToken.Size = new Size(340, 25);
      this.textBoxSecretToken.TabIndex = 2;
      this.labelAcessToken.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.labelAcessToken.AutoSize = true;
      this.labelAcessToken.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelAcessToken.Location = new Point(34, 33);
      this.labelAcessToken.Name = "labelAcessToken";
      this.labelAcessToken.Size = new Size(109, 17);
      this.labelAcessToken.TabIndex = 3;
      this.labelAcessToken.Text = "Token de Acesso:";
      this.labelSecretToken.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.labelSecretToken.AutoSize = true;
      this.labelSecretToken.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelSecretToken.Location = new Point(5, 82);
      this.labelSecretToken.Name = "labelSecretToken";
      this.labelSecretToken.Size = new Size(138, 17);
      this.labelSecretToken.TabIndex = 4;
      this.labelSecretToken.Text = "Token Acesso Secreto:";
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ButtonFace;
      this.ClientSize = new Size(501, 173);
      this.Controls.Add((Control) this.labelSecretToken);
      this.Controls.Add((Control) this.labelAcessToken);
      this.Controls.Add((Control) this.textBoxSecretToken);
      this.Controls.Add((Control) this.textBoxAcessToken);
      this.Controls.Add((Control) this.buttonTokenConfirm);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (configForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Load += new EventHandler(this.configForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
