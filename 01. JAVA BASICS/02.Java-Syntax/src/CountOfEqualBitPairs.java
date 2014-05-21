import java.util.Scanner;


public class CountOfEqualBitPairs {

	public static void main(String[] args) {
		System.out.print("n: ");
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		int number = inputScanner.nextInt();
		int semiNumber = number >> 1;
		int count = 0;
		while (semiNumber != 0) {
		    int numberBit = 1 & number;
		    int semiNumberBit = 1 & semiNumber;
		    if (numberBit == semiNumberBit) {
			count++;
		    }

		    semiNumber = semiNumber >> 1;
		    number = number >> 1;
		}

		System.out.println(count);
	}

}