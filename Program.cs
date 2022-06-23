using iText.IO.Image;

using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.Kernel.Colors;

using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout;


namespace taoPDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int masv = 20110702;
            string tenMon = "toán cao cấp";
            float diem1 = 5.6f;
            float diem2 = 4.4f;
            int nam  = 20;
            string hk = "Học kì 2";
            taoPDF(masv,tenMon,diem1,diem2,nam,hk);
        }

        static void taoPDF(int maSV, string tenMon, float diemGiuaKy, float diemCuoiKy,int namHoc, string HK)
        {
            PdfDocument PDFdoc = new PdfDocument(new PdfWriter("../doc.pdf"));
            PageSize pageSize = PageSize.A4.Rotate();
            Document doc = new Document(PDFdoc, pageSize);

            System.Drawing.Color mau = System.Drawing.Color.FromName("SlateBlue");

            Table bangdiem = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
            Image anh = new Image( ImageDataFactory.Create(Resource1.SPKT, mau));
            PdfFont font = PdfFontFactory.CreateFont(Resource1.vuArial, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);

            //ảnh
            anh.SetMarginLeft(100);
            anh.SetMarginRight(100);
            doc.Add(anh);

            //title
            Paragraph title = new Paragraph("BẢNG ĐIỂM CHI TIẾT");
            title.SetMarginTop(10);
            title.SetMarginLeft(250);
            title.SetFont(font).SetFontSize(25);
            doc.Add(title);

            ///header
            Paragraph id = new Paragraph("Mã số sinh viên: " + maSV.ToString()).Add("          Môn học: " + tenMon);
            id.SetMarginTop(10);
            id.SetMarginLeft(100);
            id.SetMarginRight(100);
            id.SetFont(font);
            doc.Add(id);

            Paragraph nam = new Paragraph("Năm học: " + namHoc.ToString() + "  -  " + HK);
            nam.SetMarginLeft(100);
            nam.SetMarginRight(100);
            nam.SetMarginBottom(10);
            nam.SetFont(font);
            doc.Add(nam);

            //bảng điểm
            Cell header = new Cell().Add(new Paragraph("Tên thành phần")).SetFontColor(ColorConstants.WHITE);
            header.SetBackgroundColor(new DeviceRgb(51, 51, 255));
            bangdiem.AddCell(header);

            header = new Cell().Add(new Paragraph("Điểm số")).SetFontColor(ColorConstants.WHITE);
            header.SetBackgroundColor(new DeviceRgb(51, 51, 255));
            bangdiem.AddCell(header);

            bangdiem.AddCell("Điểm thi giữa kỳ"); 
            bangdiem.AddCell(diemGiuaKy.ToString()); 
            bangdiem.AddCell("Điểm thi cuối kỳ"); 
            bangdiem.AddCell(diemCuoiKy.ToString());
            bangdiem.AddCell("Điểm tổng kết");
            bangdiem.AddCell(((diemCuoiKy + diemGiuaKy) / 2).ToString());

            bangdiem.SetMarginLeft(100);
            bangdiem.SetMarginRight(100);
            bangdiem.SetFont(font);

            doc.Add(bangdiem);

            doc.Close();
        }


    }
}
