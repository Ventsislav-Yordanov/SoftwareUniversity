import java.util.Scanner;


public class DecimalToHexadecimal {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int number = input.nextInt();
		System.out.println(Integer.toHexString(number).toUpperCase());
	}

}