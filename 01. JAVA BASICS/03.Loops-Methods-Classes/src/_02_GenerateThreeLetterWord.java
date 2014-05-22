import java.util.Scanner;


public class _02_GenerateThreeLetterWord {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		char[] letters = scan.next().toCharArray();

		for (int i = 0; i < letters.length; i++) {
			for (int j = 0; j < letters.length; j++) {
				for (int m = 0; m < letters.length; m++) {
					System.out.printf("%c%c%c ", letters[i], letters[j], letters[m]);
				}
			}
		}
	}	
}
