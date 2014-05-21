import java.util.Locale;
import java.util.Scanner;


public class FormattingNumbers {
	
	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT); // invariant culture
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		int a = scanner.nextInt();
		
		if (a < 0 | a > 500) {
			System.out.println("Please enter integer a (0 ≤ a ≤ 500)");
			a = scanner.nextInt();
		}
		
		String aHexString = Integer.toHexString(a).toUpperCase();
		String aBinary = String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0');
		double b = scanner.nextDouble();
		double c = scanner.nextDouble();
		
		if (c%1 == 0) {
            System.out.printf("|%-10s|%s|%10.2f|%-10.0f|",aHexString,aBinary,b,c);
		}
		else {
            System.out.printf("|%-10s|%s|%10.2f|%-10.3f|",aHexString,aBinary,b,c);
		}
	}
}
