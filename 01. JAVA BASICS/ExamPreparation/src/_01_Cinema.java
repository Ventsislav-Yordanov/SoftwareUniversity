import java.util.Scanner;


public class _01_Cinema {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		String movieType = input.next();
		int rows = input.nextInt();
		int cols = input.nextInt();

		double price = 0;
		
		switch (movieType) {
		case "Premiere":
			price = 12;
			break;
		case "Normal":
			price = 7.5;
			break;
		case "Discount":
			price = 5;
			break;
		}
		
		double result = rows * cols * price;
		System.out.printf("%.2f leva", result);
	}

}
