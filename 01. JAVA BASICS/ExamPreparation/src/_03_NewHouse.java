import java.util.Scanner;


public class _03_NewHouse {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		
		int stars = 1;
		int dashes = n / 2;
		
		for (int i = 0; i < n / 2 + 1; i++) {
			System.out.print(newString('-', dashes));
			System.out.print(newString('*', stars));
			System.out.print(newString('-', dashes));
			System.out.println();
			dashes--;
            stars += 2;
		}
		
		//reset
		stars = 0; 
        stars = n - 2;
        
        for (int i = n; i > 0 ; i--) {
			System.out.print("|");
			System.out.print(newString('*', stars));
			System.out.print("|");
			System.out.println();
		}

	}
	
	public static String newString(char ch, int size) {
	    return new String(new char[size]).replace('\0', ch);
	}
}
