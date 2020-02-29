using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;


namespace projekt_bankomat
{
    public class Drukuje
    {
        
      virtual public string Operacja(int kwota)
        {
            // System.IO.FileStream fs = new FileStream("C:\\Users\\Marzis\\Desktop\\projekt_bankomat", FileMode.Create);
             Document document = new Document(PageSize.A4, 25, 25, 30, 30);//  System.IO.FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("pdf") + "\\" + "Potwierdzenie.pdf", FileMode.Create);
            PdfWriter wri = PdfWriter.GetInstance(document, new FileStream("ABC.pdf", FileMode.Create));
           
            document.AddAuthor("BANK");
            document.AddSubject("Wypłata pieniędzy");
            document.Open();
            document.Add(new Paragraph("Wypłata z Banku przy ul.Strumiennej 22"));
            document.Add(new Paragraph("kwota wypłacona" + kwota.ToString()));
            string workingDirectory = Environment.CurrentDirectory;
            string startupPath = Directory.GetParent(workingDirectory).Parent.FullName;
            Image image = Image.GetInstance(startupPath +  "\\Bank.png");
            document.Add(image);
            document.Close();
            //document.AddTitle("");
            // Create an instance to the PDF file by creating an instance of the PDF 
            // Writer class using the document and the filestrem in the constructor.
            //PdfWriter writer = PdfWriter.GetInstance(document, fs);
            string tekst = "Wydrukowano";
            return tekst;
        }
    }
}
