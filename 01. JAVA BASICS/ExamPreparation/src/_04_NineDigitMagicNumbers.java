import java.util.Scanner;


public class _04_NineDigitMagicNumbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int sum = input.nextInt();
		int diff = input.nextInt();
		int wholeNumsCounter = 0;
		
		for (int i = 111; i <= 777; i++) {
			int num1 = i;
			int num2 = num1 + diff;
			int num3 = num2 + diff;
			
			if (num3 > 777) {
				break;
			}
			
			String wholeNum = Integer.toString(num1) + num2 + num3;
			int result = 0;
			
			for (int j = 0; j < wholeNum.length(); j++) {
				result += Integer.parseInt(wholeNum.charAt(j) + "");
			}
			if (result == sum) {
				if (wholeNum.contains("0") || wholeNum.contains("8") || wholeNum.contains("9")) {
					continue;
				}
				else {
					System.out.println(wholeNum);
					wholeNumsCounter++;
				}
			}
		}
		if (wholeNumsCounter == 0) {
			System.out.println("No");
		}
	}

}
