import java.util.Scanner;


public class _01_Garden {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int tomatoSeeds = input.nextInt();
		int tomatoArea = input.nextInt();
		int cucumberSeeds = input.nextInt();
		int cucumberArea = input.nextInt();
		int potatoSeeds = input.nextInt();
		int potatoArea = input.nextInt();
		int carrotSeeds = input.nextInt();
		int carrotArea = input.nextInt();
		int cabbageSeeds = input.nextInt();
		int cabbageArea = input.nextInt();
		
		double beansSeeds  = input.nextDouble();

		int totalArea = 250;

		double cost = tomatoSeeds * 0.5 + cucumberSeeds * 0.4 + potatoSeeds * 0.25 + carrotSeeds * 0.6
                + cabbageSeeds * 0.3 + beansSeeds * 0.4;
		
		int beansArea = totalArea - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);
		
		System.out.printf("Total costs : %.2f", cost);
		System.out.println();
		
        if (beansArea > 0){
        	System.out.printf("Beans area : %d",beansArea);
        }
        if (beansArea == 0){
        	System.out.printf("No area for beans");
        }
        if (beansArea < 0){
        	System.out.printf("Insufficient area");
        }
        
        
	}

}
