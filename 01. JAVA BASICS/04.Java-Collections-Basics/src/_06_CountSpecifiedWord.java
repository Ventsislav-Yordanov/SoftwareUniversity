import java.util.Scanner;


public class _06_CountSpecifiedWord {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		String wordsString = input.nextLine();	
		String chosenWord = input.next();
		String[] words = wordsString.split("\\W+");
		
		int count = 0;
		
		for (String word : words) {
			word = word.toLowerCase();
			if (word.equals(chosenWord)) {
				count++;
			}
		}
		
		System.out.println(count);
	}

}
