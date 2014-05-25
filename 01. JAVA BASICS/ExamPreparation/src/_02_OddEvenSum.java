import java.util.Scanner;


public class _02_OddEvenSum {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		int sumOdd = 0;
		int sumEven = 0;
		boolean odd = true;
		
		for (int i = 0; i < 2 * n; i++) {
			@SuppressWarnings("resource")
			int element = new Scanner(System.in).nextInt();
			if (odd) {
				sumOdd += element;
			}
			else {
				sumEven += element;
			}
			odd = !odd;
		}
		
		if (sumOdd == sumEven) {
			System.out.println("Yes, sum=" +  sumOdd);
		} else {
			int diff = sumEven - sumOdd;
			if (diff < 0) {
				diff *= -1;
			}
			System.out.println("No, diff=" + diff);
		}

	}

}