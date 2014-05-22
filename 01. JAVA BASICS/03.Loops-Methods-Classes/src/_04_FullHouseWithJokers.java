public class _04_FullHouseWithJokers {

	public static void main(String[] args) {
		String[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
		char[] suits = { '♣', '♦', '♠', '♥' };
		char joker = '*';
		
		// declare these variables here to avoid multiple declarations later
		int currentFoundIndex = 0;
		String numberAsBinary = "";
		
		String[] cards = new String[5]; // contains current 5 cards 
		String[] tempCards = new String[5]; // use after overwriting with jokers
		
		int counter = 0;
		for (int i = 0; i < faces.length; i++) { // first three cards
			for (int q = 0; q < faces.length; q++) { // last two cards
				if (q == i) continue; // avoid repetition
				for (int suit = 0; suit < suits.length; suit++) {
					// suits for first three cards
					for (int suitTriple = 0; suitTriple < 3; suitTriple++) {
						cards[suitTriple] = faces[i] + suits[(suit+suitTriple)%suits.length];
					}
					// suits for last two cards
					for (int fourthSuit = 0; fourthSuit < suits.length; fourthSuit++) {
						for (int fifthSuit = fourthSuit + 1; fifthSuit < suits.length; fifthSuit++) {
							cards[3] = faces[q] + suits[fourthSuit];
							cards[4] = faces[q] + suits[fifthSuit];
							// find all possible placements for joker
							for (int j = 0; j < 32; j++) {
								tempCards = cards.clone(); // save current hand
								numberAsBinary = Integer.toBinaryString(j);
								currentFoundIndex = numberAsBinary.indexOf('1');
								while(currentFoundIndex != -1) {
									cards[numberAsBinary.length() - 1 - currentFoundIndex] = Character.toString(joker);
									currentFoundIndex = numberAsBinary.indexOf('1', currentFoundIndex + 1);
								}
								
								counter++;
								printCards(cards);
								cards = tempCards; // load initial hand
							}
						}
					}
				}
			}
		}
		System.out.println(counter + " full houses");
	}
	
	public static void printCards(String[] cards) {
		System.out.print('(');
		for (int i = 0; i < cards.length; i++) {
			if (i != 0) System.out.print(' '); // better formatting
			System.out.print(cards[i]);
		}
		System.out.println(')');
	}

}