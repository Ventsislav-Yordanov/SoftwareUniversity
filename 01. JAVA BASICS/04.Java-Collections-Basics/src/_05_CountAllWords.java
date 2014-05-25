import java.util.Scanner;


public class _05_CountAllWords {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		String wordsString = input.nextLine();		
		String[] words = wordsString.split("\\W+");				
		System.out.println(words.length);
	}

}