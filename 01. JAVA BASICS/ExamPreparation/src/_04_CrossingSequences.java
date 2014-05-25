import java.util.Scanner;


public class _04_CrossingSequences {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int firstNum = input.nextInt();
		int secondNum = input.nextInt();
		int thirdNum = input.nextInt();
		int nextNum = 0;
		int[] tribonacci = new int[1000000];
		
		int firstNumber = input.nextInt();
		int step = input.nextInt();
		int stepNumber = 0;
		int[] spiral = new int[1000000];
		
		
		tribonacci[0] = firstNum;
		tribonacci[1] = secondNum;
		tribonacci[2] = thirdNum;
		
		for (int i = 3; i < tribonacci.length; i++) {
			nextNum = firstNum + secondNum + thirdNum;
			firstNum = secondNum;
			secondNum = thirdNum;
			thirdNum = nextNum;
			tribonacci[i] = nextNum;
		}
		
		
		spiral[0] = firstNumber;
		
		for (int i = 1; i < spiral.length; i++) {
			stepNumber = firstNumber + step;
			firstNumber = stepNumber;
			spiral[i] = stepNumber;
		}
		
		
		for (int i : tribonacci) {
			for (int j : spiral) {
				if (i == j) {
					System.out.println(i);
					return;
				}
				else {
					continue;
				}
			}
		}
		System.out.println("No");
	}

}