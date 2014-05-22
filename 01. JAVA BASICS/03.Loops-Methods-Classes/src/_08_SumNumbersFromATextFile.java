import java.io.BufferedReader;
import java.io.FileReader;


public class _08_SumNumbersFromATextFile {

	public static void main(String[] args) {
		BufferedReader reader;
		int sum = 0;
		try {
			reader = new BufferedReader(new FileReader("src/numbers.txt"));
			String line = null;
			while ((line = reader.readLine()) != null) {
				int number = Integer.parseInt(line);
				sum = sum + number; 
			}
			System.out.println(sum);
		} catch (Exception e) {
			System.out.println("Error");
		}
	}

}
