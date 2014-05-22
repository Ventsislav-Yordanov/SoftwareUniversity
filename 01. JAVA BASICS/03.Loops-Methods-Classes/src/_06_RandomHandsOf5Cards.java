import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;


public class _06_RandomHandsOf5Cards {

	public static void main(String[] args) {
		String clubs = "♣";
		String diamonds = "♦";
		String hearts = "♥";
		String spades = "♠";

		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int count = input.nextInt();
		String rank[] = new String[52];
		int counter = 0;
		
		for (int i = 1; i <= 13; i++) {
			String currentCard = "";
			if (i == 1) {
				currentCard = "A";
			}
			else if (i <= 10) {
				currentCard = currentCard + i;
			}
			else {
				switch (i) {
				case 11:
					currentCard = "J";
					break;
				case 12:
					currentCard = "Q";
					break;
				case 13:
					currentCard = "K";
					break;
				}
			}
			rank[counter] = "" + currentCard + clubs;
			rank[counter + 1] = "" + currentCard + diamonds;
			rank[counter + 2] = "" + currentCard + hearts;
			rank[counter + 3] = "" + currentCard + spades;
			counter += 4;
		}
		List<String> cards = Arrays.asList(rank);
		for (int i = 0; i < count; i++) {
			Collections.shuffle(cards);
			List<String> selectedCards = cards.subList(0, 5);
			System.out.println(selectedCards.toString());
		}
	}

}