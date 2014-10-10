import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

@SuppressWarnings("serial")
public class Player extends Canvas implements Runnable {
	public static Snake snake;
	public static Apple apple;
	static int score;
	
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension dimension = new Dimension(WIDTH, HEIGHT);
	
	static boolean isGameRunning = false;
	
	public void paint(Graphics graphics){
		this.setPreferredSize(dimension);
		globalGraphics = graphics.create();
		score = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			isGameRunning = true;
		}
	}
	
	public void run(){
		while(isGameRunning){
			snake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// to do
			}
		}
	}
	
	public Player(){	
		snake = new Snake();
		apple = new Apple(snake);
	}
		
	public void render(Graphics grapthics){
		grapthics.clearRect(0, 0, WIDTH, HEIGHT+25);
		
		grapthics.drawRect(0, 0, WIDTH, HEIGHT);			
		snake.drawSnake(grapthics);
		apple.drawApple(grapthics);
		grapthics.drawString("score= " + score, 10, HEIGHT + 25);		
	}
}