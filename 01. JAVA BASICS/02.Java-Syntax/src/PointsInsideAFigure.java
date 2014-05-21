import java.util.Locale;
import java.util.Scanner;


public class PointsInsideAFigure {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT); // invariant culture
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		double x = input.nextDouble();
		double y = input.nextDouble();
		
		boolean insideFirstFigure = (x >= 12.5) && (x <= 22.5) && (y >= 6) && (y <= 8.5);
		boolean insideSecondFigure = (x >= 12.5) && (x <= 17.5) && (y >= 8.5) && (y <= 13.5);
		boolean insideThirdFigure = (x >= 20) && (x <= 22.5) && (y >= 8.5) && (y <= 13.5);
		boolean inside = insideFirstFigure | insideSecondFigure | insideThirdFigure;
		String result = inside ? "Inside" : "Outside";
		System.out.println(result);
	}

}