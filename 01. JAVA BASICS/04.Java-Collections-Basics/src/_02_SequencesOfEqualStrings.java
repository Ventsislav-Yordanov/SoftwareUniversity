import java.util.Scanner;


public class _02_SequencesOfEqualStrings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		String strings = input.nextLine();
		String[] stringsArray = strings.split(" ");
		
		for (int i = 0; i < stringsArray.length; i++) {
            if (i == 0) {
                    System.out.print(stringsArray[i] + " ");
            }
            else if (stringsArray[i].equals(stringsArray[i - 1])) {
                    System.out.print(stringsArray[i] + " ");
            }
            else {
                    System.out.println();
                    System.out.print(stringsArray[i] + " ");
            }
    }
	}

}
