import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class keyCapturer implements KeyListener{
	
	public keyCapturer(Player game){
		game.addKeyListener(this);
	}
	
	public void keyPressed(KeyEvent e) {
		int keyCode = e.getKeyCode();
		
		if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
			if(Player.snake.getVelocityY() != 20){
				Player.snake.setVelocityX(0);
				Player.snake.setVelocityY(-20);
			}
		}
		if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
			if(Player.snake.getVelocityY() != -20){
				Player.snake.setVelocityX(0);
				Player.snake.setVelocityY(20);
			}
		}
		if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
			if(Player.snake.getVelocityX() != -20){
			Player.snake.setVelocityX(20);
			Player.snake.setVelocityY(0);
			}
		}
		if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
			if(Player.snake.getVelocityX() != 20){
				Player.snake.setVelocityX(-20);
				Player.snake.setVelocityY(0);
			}
		}
		//Other controls
		if (keyCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent e) {
	}
	
	public void keyTyped(KeyEvent e) {
		
	}

}
