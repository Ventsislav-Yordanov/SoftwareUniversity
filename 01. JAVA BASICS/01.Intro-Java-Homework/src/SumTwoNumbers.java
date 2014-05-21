import java.util.Scanner;


public class SumTwoNumbers {

	public static void main(String[] args) {
		System.out.print("Enter first number : ");
		Scanner input1 = new Scanner(System.in);
        int number1 = input1.nextInt();
        
        System.out.print("Enter first number : ");
		Scanner input2 = new Scanner(System.in);
        int number2 = input2.nextInt();
        
        int sum = number1 + number2;
        
        System.out.println();
        System.out.print("Sum = " + sum);

        // second variant
        
        //Scanner scanner = new Scanner(System.in);
        //int first = scanner.nextInt();
        //int second = scanner.nextInt();
        //System.out.println(first+second);
	}

}
