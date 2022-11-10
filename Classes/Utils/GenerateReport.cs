// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Classes.Utils.GenerateReport
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Relatorio_Produtos_VHSYS.Classes.Utils
{
  internal static class GenerateReport
  {
    public static void generatePdf(string titulo, string resumo, DataGridView datagridview)
    {
      iTextSharp.text.Font font1 = FontFactory.GetFont("Lucida Sans", 15f);
      iTextSharp.text.Font font2 = FontFactory.GetFont("Lucida Sans", 12f);
      iTextSharp.text.Font font3 = FontFactory.GetFont("Consolas", 9f, new BaseColor(108, 117, 125));
      Paragraph paragraph1 = new Paragraph(titulo);
      paragraph1.Font = font1;
      paragraph1.Alignment = 1;
      Paragraph paragraph2 = new Paragraph(resumo);
      paragraph2.Font = font2;
      paragraph2.Alignment = 0;
      PdfPTable pdfPtable = new PdfPTable(datagridview.Columns.Count);
      pdfPtable.DefaultCell.Padding = 7f;
      pdfPtable.WidthPercentage = 100f;
      pdfPtable.HorizontalAlignment = 0;
      pdfPtable.DefaultCell.BorderWidth = 1f;
      foreach (DataGridViewColumn column in (BaseCollection) datagridview.Columns)
      {
        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
        cell.BackgroundColor = new BaseColor(218, 242, 215);
        cell.FixedHeight = 25f;
        cell.HorizontalAlignment = 1;
        pdfPtable.AddCell(cell);
      }
      foreach (DataGridViewRow row in (IEnumerable) datagridview.Rows)
      {
        foreach (DataGridViewCell cell in (BaseCollection) row.Cells)
        {
          if (cell.Value != null)
          {
            if (cell.ColumnIndex == 2)
              pdfPtable.AddCell(string.Format("{0:F2}", cell.FormattedValue));
            else
              pdfPtable.AddCell(cell.Value.ToString());
          }
        }
      }
      Paragraph paragraph3 = new Paragraph("\n" + DateTime.Now.ToString());
      paragraph3.Font = font3;
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.FileName = "";
      saveFileDialog.DefaultExt = ".pdf";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        using (FileStream fstream = new FileStream(saveFileDialog.FileName, FileMode.Create))
        {
          Document document = new Document(PageSize.A4, 10f, 10f, 10f, 0.0f);
          GenerateReport.PdfWriter_GetInstance(document, fstream);
          document.Open();
          document.Add((IElement) paragraph1);
          document.Add((IElement) paragraph2);
          document.Add((IElement) pdfPtable);
          document.Add((IElement) paragraph3);
          document.Close();
          fstream.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Erro ao tentar salvar documento.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private static PdfWriter PdfWriter_GetInstance(Document document, FileStream fstream)
    {
      PdfWriter pdfWriter = (PdfWriter) null;
      for (int index = 0; index < 1000; ++index)
      {
        try
        {
          pdfWriter = PdfWriter.GetInstance(document, (Stream) fstream);
          break;
        }
        catch (Exception ex)
        {
          Thread.Sleep(250);
        }
      }
      return pdfWriter != null ? pdfWriter : throw new Exception("iTextSharp PdfWriter is null");
    }
  }
}
