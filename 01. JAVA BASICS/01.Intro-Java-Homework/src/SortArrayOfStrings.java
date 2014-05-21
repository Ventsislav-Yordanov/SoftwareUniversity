import java.util.Arrays;
import java.util.Scanner;


public class SortArrayOfStrings {

	public static void main(String[] args) 
	{
		
		Scanner scan = new Scanner(System.in);
		int n = scan.nextInt();
		
		String[] allWords = new String[n];
		
		scan.nextLine();
		for (int i = 0; i < n; i++) 
		{
			allWords[i] = scan.nextLine();
		}
		
		Arrays.sort(allWords);
		System.out.println();
		
		for(int i=0;i<n;i++)
        {
                System.out.println(allWords[i]);
        }
	}

}