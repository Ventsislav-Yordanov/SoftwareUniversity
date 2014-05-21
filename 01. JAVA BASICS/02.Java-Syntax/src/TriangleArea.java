import java.util.Scanner;


public class TriangleArea {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int ax = input.nextInt();
		int ay = input.nextInt();
		input.nextLine();
		int bx = input.nextInt();
		int by = input.nextInt();
		input.nextLine();
		int cx = input.nextInt();
		int cy = input.nextInt();
		
		int area = (ax*(by-cy) + bx*(cy-ay) + cx*(ay-by))/2;
		
		if (area >= 0) {
			System.out.println(area);
		}
		else {
			System.out.println(area * -1);
		}
	}

}