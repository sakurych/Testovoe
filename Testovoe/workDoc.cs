using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Testovoe.Db_CMD;
using static Testovoe.Form1;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Windows.Forms;

namespace Testovoe
{
    internal class workDoc
    {
        public void work(DataGridView dg)
        {
            Word._Application word_app = new Word.ApplicationClass();

            object missing = Type.Missing;

            Word._Document word_doc = word_app.Documents.Add(

                ref missing, ref missing, ref missing, ref missing);

            Word.Paragraph para = word_doc.Paragraphs.Add(ref missing);

            para.Range.Font.Size = 14;
            para.Range.Font.Bold = 2;
            para.Range.Font.Name = "Arial";
            para.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            para.Range.Text = "Справка о неисполненных документах и обращениях граждан";
            para.Range.InsertParagraphAfter();

            para.Range.Font.Size = 10;
            para.Range.Font.Bold = 2;
            para.Range.Font.Name = "Arial";
            para.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            para.Range.Font.Bold = 0;
            para.Range.Text = "Не исполнено в срок "+ Db_CMD.total + " документов, из них:";
            para.Range.InsertParagraphAfter();
            Word.Range rng = word_doc.Range(76, 79);
            rng.Font.Bold = 2;

            para.Range.Text = "- количество неисполненных входящих документов: " + Db_CMD.sumRKK + ";";
            para.Range.InsertParagraphAfter();
            Word.Range rng1 = word_doc.Range(148, 151);
            rng1.Font.Bold = 2;

            para.Range.Text = "- количество неисполненных письменных обращений граждан: " + Db_CMD.sumObr + ";";
            para.Range.InsertParagraphAfter();
            Word.Range rng2 = word_doc.Range(210, 213);
            rng2.Font.Bold = 2;

            para.Range.Text = "Сортировка: по общему количеству документов. ";
            para.Range.InsertParagraphAfter();
            Word.Range rng3 = word_doc.Range(226, 258);
            rng3.Font.Bold = 2;

            rng.Tables.Add(word_doc.Paragraphs[word_doc.Paragraphs.Count].Range, Db_CMD.count, 5, ref missing, ref missing);
            Word.Table tbl = word_doc.Tables[word_doc.Tables.Count];


            Word.Border[] borders = new Word.Border[6];
            borders[0] = tbl.Borders[Word.WdBorderType.wdBorderLeft];
            borders[1] = tbl.Borders[Word.WdBorderType.wdBorderRight];
            borders[2] = tbl.Borders[Word.WdBorderType.wdBorderTop];
            borders[3] = tbl.Borders[Word.WdBorderType.wdBorderBottom];
            borders[4] = tbl.Borders[Word.WdBorderType.wdBorderHorizontal];
            borders[5] = tbl.Borders[Word.WdBorderType.wdBorderVertical];

            foreach (Word.Border border in borders)
            {
                border.LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                border.Color = Word.WdColor.wdColorBlack;
            }

            foreach (Row row in tbl.Rows)
            {
                foreach (Cell c in row.Cells)
                {
                    c.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    c.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                }
            }

            tbl.Range.Font.Size = 10;
            tbl.Range.Font.Name = "Arial";
            tbl.Range.Font.Bold = 2;
            tbl.Cell(1, 1).Range.Text = "№ п.п.";
            tbl.Cell(1, 2).Range.Text = "Ответственный исполнитель";
            tbl.Cell(1, 3).Range.Text = "Количество неисполненных входящих документов";
            tbl.Cell(1, 4).Range.Text = "Количество неисполненных письменных обращений граждан";
            tbl.Cell(1, 5).Range.Text = "Общее количество документов и обращений";
            tbl.Range.Font.Bold = 0;

            int ii = 1;
            for(int i = 2; ii< dg.Rows.Count; i++)
            {
                tbl.Cell(i, 1).Range.Text =  ii.ToString();
                tbl.Cell(i, 1).Range.Font.Name = "Arial";
                ii++;
            }
            int j = 2;
            int ci = 0;
            for (int i = 2; ci < dg.Rows.Count - 1; i++)
            {
                tbl.Cell(i, j).Range.Text = dg.Rows[ci].Cells[1].Value.ToString() + "\t";
                tbl.Cell(i, j).Range.Font.Name = "Arial";
                j++;
                tbl.Cell(i, j).Range.Text = dg.Rows[ci].Cells[2].Value.ToString() + "\t";
                tbl.Cell(i, j).Range.Font.Name = "Arial";
                j++;
                tbl.Cell(i, j).Range.Text = dg.Rows[ci].Cells[3].Value.ToString() + "\t";
                tbl.Cell(i, j).Range.Font.Name = "Arial";
                j++;
                tbl.Cell(i, j).Range.Text = dg.Rows[ci].Cells[4].Value.ToString() + "\t";
                tbl.Cell(i, j).Range.Font.Name = "Arial";
                ci++;
                j = 2;
            }

            para.Range.InsertParagraphAfter();
            para.Range.Font.Size = 10;
            para.Range.Font.Name = "Arial";
            para.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            para.Range.Font.Bold = 0;
            para.Range.Text = "Дата составления справки:\t " + Form1.time.ToString("dd.MM.yyyy");

            word_doc.Save();

            object save_changes = false;

            word_doc.Close(ref save_changes, ref missing, ref missing);

            word_app.Quit(ref save_changes, ref missing, ref missing);
        }
    }
}
