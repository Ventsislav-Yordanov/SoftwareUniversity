import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;
 
import java.io.FileOutputStream;
 
public class GeneratePDF {
       
        public static void main(String[] args) {
                try {
                        Document document = new Document();
                        PdfWriter.getInstance(document, new FileOutputStream("Deck-Of-Cards.pdf"));                      
                        document.open();
                       
                        PdfPTable table = new PdfPTable(4);
                        table.setWidthPercentage(110);
                        table.getDefaultCell().setFixedHeight(180);
                       
                        BaseFont baseFont = BaseFont.createFont("times.ttf", BaseFont.IDENTITY_H, true);
                        Font black = new Font(baseFont, 75f, 0, BaseColor.BLACK);
                        Font red = new Font(baseFont, 75f, 0, BaseColor.RED);
                       
                        char[] suits = new char[] {'♠', '♥', '♦', '♣'};
                        String[] values = new String[] {"A", "2", "3", "4", "5", "6", "7", "8",
                                                                        "9", "10","J", "Q", "K"};
                       
                        for (int i = 0; i < suits.length; i++) {
                                for (int j = 0; j < values.length; j++) {
                                        if (suits[i] == '♠' || suits[i] == '♣') {
                                                table.addCell(new Paragraph(suits[i] + " " + values[j] + " ", black));                                 
                                        }
                                        else {
                                                table.addCell(new Paragraph(suits[i] + " " + values[j] + " ", red));
                                        }
                                }
                        }
                        
                        document.add(table);
                        document.close();                      
                }
                catch (Exception e) {
                        e.printStackTrace();
                }
        }
 
}
