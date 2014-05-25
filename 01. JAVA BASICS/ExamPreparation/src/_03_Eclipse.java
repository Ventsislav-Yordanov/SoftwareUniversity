import java.util.Scanner;


public class _03_Eclipse {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		
		// print first row
		System.out.print(" ");
		System.out.print(newString('*', 2*n - 2));
		System.out.print(" ");
		System.out.print(newString(' ', n - 1));
		System.out.print(" ");
		System.out.print(newString('*', 2*n - 2));
		System.out.print(" ");
		System.out.println();
		
		for (int row = 0; row < n - 2; row++) {
			if (row == n / 2 - 1) {
				System.out.print("*");
				System.out.print(newString('/', 2*n - 2));
				System.out.print("*");
				System.out.print(newString('-', n - 1));
				System.out.print("*");
				System.out.print(newString('/', 2*n - 2));
				System.out.print("*");
				System.out.println();
			}
			else {
				System.out.print("*");
				System.out.print(newString('/', 2*n - 2));
				System.out.print("*");
				System.out.print(newString(' ', n - 1));
				System.out.print("*");
				System.out.print(newString('/', 2*n - 2));
				System.out.print("*");
				System.out.println();
			}	
		}
		// print last row
		System.out.print(" ");
		System.out.print(newString('*', 2*n - 2));
		System.out.print(" ");
		System.out.print(newString(' ', n - 1));
		System.out.print(" ");
		System.out.print(newString('*', 2*n - 2));
		System.out.print(" ");
	}
	
	
	public static String newString(char ch, int size) {
	    return new String(new char[size]).replace('\0', ch);
	}

}