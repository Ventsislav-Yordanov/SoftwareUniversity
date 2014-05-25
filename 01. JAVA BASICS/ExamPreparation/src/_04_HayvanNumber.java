import java.util.Scanner;


public class _04_HayvanNumber {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int sum = input.nextInt();
		int diff = input.nextInt();
		int resultCount = 0;
		
		for (int n1 = 555; n1 <= 999; n1++) {
			int n2 = n1 + diff;
			int n3 = n2 + diff;
			String number = "" + n1 + n2 + n3;
			
			if(isAllowed(number)&& (calculateSum(n1) + calculateSum(n2) + calculateSum(n3) == sum)) {
				resultCount++;
				System.out.println(number);
			}
		}
		if (resultCount == 0) {
			System.out.println("No");
		}
	}
	public static int calculateSum (int n) {
		int sum = 0;
		
		int n1 = n % 10;
		n = n / 10;
		int n2 = n % 10;
		n = n / 10;
		int n3 = n % 10;
		
		sum = n1 + n2 + n3;
		return sum;
	}
	public static boolean isAllowed(String n) {
		boolean isAllowed = true;
		char[] numbers = n.toCharArray();
		
		for (char c : numbers) {
			if (c != '5' && c != '6' && c != '7' && c != '8' && c!= '9') {
				isAllowed = false;
				return isAllowed;
			}
		}
		return isAllowed;
	}
}