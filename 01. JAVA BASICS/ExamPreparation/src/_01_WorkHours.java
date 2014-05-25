import java.util.Scanner;


public class _01_WorkHours {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
        int h = input.nextInt();
        int d = input.nextInt();
        Double p = input.nextDouble() / 100;
       
        double availableDays = d - (0.1 * d);
        double workingTime = availableDays * 12;
        int totalTime = (int)(workingTime * p);
       
        int diff = (int)(totalTime - h);
       
        if (diff >= 0) {
                System.out.println("Yes");
                System.out.println(diff);
        }
        else if (diff < 0) {
                System.out.println("No");
                System.out.println(diff);
        }
	}

}