import java.util.Scanner;


public class _05_AngleUnitConverter {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner in = new Scanner(System.in);
		int n = in.nextInt();
		String input = "";
		String measure = "";
		
		 for (int i = 0; i <= n; i++) {
             input = in.nextLine();
             input = input.replaceAll("\\s+", "");
             measure = input.replaceAll("\\d+", "");
             measure = measure.replace(".", "");
             input = input.replaceAll("[^0-9.,]+", "");
             if (measure.equals("deg")) {
                     System.out.printf("%.6f rad", convertToRadian(Double.parseDouble(input)));
                     System.out.println();
             }
             else if (measure.equals("rad")) {
                     System.out.printf("%.6f deg", convertToDegrees(Double.parseDouble(input)));
                     System.out.println();
             }
         }
	}

	private static double convertToRadian(double n) {
		 n = n * 0.0174532925;
         return n;
	}
	
	public static double convertToDegrees(double n) {
        n = n / 0.0174532925;
        return n;
}

}
