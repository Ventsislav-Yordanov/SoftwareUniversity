import java.util.Scanner;


public class _03_WineGlass {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();

        int stars = n - 2;

        // print first row
        System.out.print("\\");
        System.out.print(newString('*', stars));
        System.out.print("/");
        System.out.println();

        stars -= 2;
        int dots = 1;

        for (int i = 0; i < n / 2 - 1; i++)
        {
        	System.out.print(newString('.', dots));
        	System.out.print("\\");
        	System.out.print(newString('*', stars));
        	System.out.print("/");
        	System.out.print(newString('.', dots));
        	System.out.println();

            stars -= 2;
            dots++;
        }

        dots--; //reset

        int RowsCount = 0;

        if (n >= 12){
            RowsCount = (n / 2) - 2;
        }
        else {
            RowsCount = (n / 2) - 1;
        }

        for (int i = RowsCount; i > 0; i--)
        {
        	System.out.print(newString('.', dots));
        	System.out.print("||");
        	System.out.print(newString('.', dots));
        	System.out.println();
        }

        int height = n;
        int dashes = height - (n / 2 + RowsCount); // calculate rows of dashes

        // print dashes
        for (int i = 0; i < dashes; i++)
        {
        	System.out.print(newString('-', n));
        	System.out.println();
        }

	}
	
	public static String newString(char ch, int size) {
	    return new String(new char[size]).replace('\0', ch);
	}

}