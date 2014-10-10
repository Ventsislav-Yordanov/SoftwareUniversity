import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

public class Apple {
	public static Random randomGenerator;
	private Point appleObject;
	private Color snakeColor;
	
	public Apple(Snake snake) {
		appleObject = createApple(snake);
		snakeColor = Color.RED;		
	}
	
	private Point createApple(Snake snake) {
		randomGenerator = new Random();
		int x = randomGenerator.nextInt(30) * 20; 
		int y = randomGenerator.nextInt(30) * 20;
		for (Point snakePoint : snake.snakeBody) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createApple(snake);				
			}
		}
		return new Point(x, y);
	}
	
	public void drawApple(Graphics graphics){
		appleObject.draw(graphics, snakeColor);
	}	
	
	public Point getPoint(){
		return appleObject;
	}
}