import java.util.Scanner;


public class _02_Illuminati {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		String inputString = input.nextLine();
		inputString = inputString.toUpperCase();
		char[] chars = inputString.toCharArray();
		
		int numberOfVowels = 0;
		int sumOfLetters = 0;
		
		for (char character : chars) {
			if (character == 'A' || character == 'U' || 
					character == 'O' || character == 'E' || character == 'I'){
					sumOfLetters += character;
					numberOfVowels++;
			}
		}
		System.out.println(numberOfVowels);
		System.out.println(sumOfLetters);

	}

}
