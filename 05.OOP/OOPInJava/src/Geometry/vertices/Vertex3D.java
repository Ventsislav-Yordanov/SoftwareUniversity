package Geometry.vertices;

public class Vertex3D extends Vertex {
	
	private double z;
	
	public Vertex3D(double x, double y, double z) {
        super(x, y);
        this.setZ(z);
    }
	
	public double getZ() {
		return z;
	}

	public void setZ(double z) {
		this.z = z;
	}

	@Override
	public double getDistanceTo(Vertex other) {
		double z = 0;
		if(other instanceof Vertex3D){
			z = ((Vertex3D) other).getZ();
		}
		
		double distance = 
				Math.pow(this.getX() + other.getX(), 2) +
				Math.pow(this.getY() + other.getY(), 2) +
				Math.pow(this.getX() + z, 2);
		
		return distance;
	}

	@Override
	public String toString() {
		String toString = String.format(
				"[ x: %.2f, y: %.2f, z: %.2f",
				this.getX(),
				this.getY(),
				this.getZ());
		
		return toString;
	}
}
