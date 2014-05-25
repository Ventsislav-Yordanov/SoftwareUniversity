import java.util.Scanner;
public class _03_Sandglass {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		
		for (int i = 0; i <= n/2; i++) {
			String dots = new String(new char[i]).replace("\0", ".");
			String stars = new String(new char[n - 2 * i]).replace("\0", "*");
			System.out.printf("%s%s%s", dots, stars, dots);
			System.out.println();
		}
		
		for (int i = n/2 - 1; i >= 0; i--) {
			String dots = new String(new char[i]).replace("\0", ".");
			String stars = new String(new char[n - 2 * i]).replace("\0", "*");
			System.out.printf("%s%s%s", dots, stars, dots);
			System.out.println();
		}
	}

}
