import java.text.DecimalFormat;
import java.util.Scanner;


public class TheSmallestOf3Numbers {

	public static void main(String[] args) 
	{
		DecimalFormat format = new DecimalFormat();
        format.setDecimalSeparatorAlwaysShown(false);
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		double a = input.nextDouble();
		double b = input.nextDouble();
		double c = input.nextDouble();
		
		
		if (a < b) 
		{
			if (a < c) 
			{
				System.out.println(format.format(a));
			} 
			else 
			{
				System.out.println(format.format(c));
			}
		} 
		else 
		{
			if (b < c) 
			{
				System.out.println(format.format(b));
			} 
			else 
			{
				System.out.println(c);
			}
		}
	}

}