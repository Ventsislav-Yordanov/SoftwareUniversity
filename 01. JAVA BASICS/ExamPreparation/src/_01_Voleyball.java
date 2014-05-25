import java.util.Scanner;

public class _01_Voleyball {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		String leap = input.next();
		int holidaysCount = input.nextInt();
		int weekendsHomeCount = input.nextInt();
		
		int weekendsInYear = 48;
		
		int normalWeekends = weekendsInYear - weekendsHomeCount;
		double gamesCount =
				normalWeekends * 3.0/4.0 +
				weekendsHomeCount * 1.0 +
				holidaysCount * 2.0/3.0;
		
		if (leap.equals("leap")) {
			gamesCount = gamesCount * 1.15;
		}
		System.out.println((int)gamesCount);
	}

}