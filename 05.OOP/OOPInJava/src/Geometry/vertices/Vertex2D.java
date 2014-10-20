package Geometry.vertices;

public class Vertex2D extends Vertex {
	public Vertex2D(double x, double y) {
		super(x, y);
	}

	@Override
	public double getDistanceTo(Vertex other) {
		double distance = Math.sqrt(
				Math.pow(this.getX() - other.getX(), 2) +
				Math.pow(this.getY() - other.getY(), 2));
		
		return distance;
	}

	@Override
	public String toString() {
		return super.toString();
	}
}
