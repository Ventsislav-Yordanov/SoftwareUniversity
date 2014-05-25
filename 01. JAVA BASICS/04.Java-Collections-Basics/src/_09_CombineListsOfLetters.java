import java.util.ArrayList;
import java.util.Scanner;


public class _09_CombineListsOfLetters {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		ArrayList<Character> firstList = new ArrayList<Character>();
		ArrayList<Character> secondList = new ArrayList<Character>();
		ArrayList<Character> finalList = new ArrayList<Character>();
		
		for (char character : input.nextLine().toCharArray()) {
			firstList.add(character);
		}
		for (char character : input.nextLine().toCharArray()) {
			secondList.add(character);
		}

		finalList.addAll(firstList);
		
		for (int i = 0; i < secondList.size(); i++) {
			if (firstList.contains(secondList.get(i))) {
				continue;
			}
			else {
				finalList.add(' ');
				finalList.add(secondList.get(i));
			}
		}
		
		for (int i = 0; i < finalList.size(); i++) {
			System.out.print(finalList.get(i));
		}
	}

}
