import java.math.BigInteger;
import java.util.Scanner;
public class _02_Tribonacci {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		long t1 = input.nextLong();
		BigInteger first = BigInteger.valueOf(t1);
		long t2 = input.nextLong();
		BigInteger second = BigInteger.valueOf(t2);
		long t3 = input.nextLong();
		BigInteger third = BigInteger.valueOf(t3);
		
		BigInteger next = BigInteger.valueOf(0);
		
		int n = input.nextInt();
		
		if (n == 1) {
			System.out.println(t1);
		}
		else if (n == 2) {
			System.out.println(t2);
		}
		else if (n== 3) {
			System.out.println(t3);
		}
		else {
			for (int i = 4; i <= n; i++) {
				next = next.add(first);
				next = next.add(second);
				next = next.add(third);
				
				first = BigInteger.valueOf(0);
				first = first.add(second);
				
				second = BigInteger.valueOf(0);
				second = second.add(third);
				
				third = BigInteger.valueOf(0);
				third = third.add(next);
				
				next = BigInteger.valueOf(0);
			}
			System.out.println(third);
		}
	}

}
