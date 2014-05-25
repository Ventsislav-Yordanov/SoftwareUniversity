import java.util.Scanner;


public class _04_LongestIncreasingSequence {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		String[] numberString = input.nextLine().split(" ");
		int[] numbers = new int[numberString.length];
		
		
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = Integer.parseInt(numberString[i]);
		}
		
		
		int counterTemp = 1;
		int counter = 1;
		int positionOfInt = 0; // positionOfInt shows the position of the
							   // largest integer in the longest increasing
					           // sequence

		System.out.print(numbers[0]);
		
		for (int i = 1; i < numberString.length; i++) {
			if (numbers[i] > numbers[i - 1]) {
				counterTemp++;
				System.out.print(" " + numbers[i]);
			} 
			else {
				counterTemp = 1;
				System.out.println();
				System.out.print(numbers[i]);
			}
			if (counterTemp > counter) {
				counter = counterTemp;
				positionOfInt = i;
			}
		}
		System.out.println();

		System.out.print("Longest: ");
		for (int j = 0; j < counter - 1; j++) {
			System.out.print(numbers[positionOfInt - counter + 1 + j] + " ");
		}
		System.out.println(numbers[positionOfInt]);
	}
}