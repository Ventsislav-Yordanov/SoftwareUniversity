import java.util.Scanner;


public class _03_LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		String strings = input.nextLine();
		String[] stringsArray = strings.split(" ");
		
		int counterTemp = 1;
		int counter = 1;
		int positionOfWord = 0;
		
		for (int i = 0; i < stringsArray.length - 1; i++) {
			if (stringsArray[i].equals(stringsArray[i+1])) {
				counterTemp++;
			}
			else {
				counterTemp = 1;
			}
			if (counterTemp > counter) {
				counter = counterTemp;
				positionOfWord = i;
			}
		}
		
		for (int j = 0; j < counter - 1; j++) {
			System.out.print(stringsArray[positionOfWord] + " ");
		}
		System.out.println(stringsArray[positionOfWord]);
	}

}
