package Geometry.shapes;

import Geometry.vertices.Vertex3D;

public class Sphere extends SpaceShape {
	private double radius;
	
	public Sphere(Vertex3D center, double radius) {
		super(new Vertex3D[]{center});
		this.setRadius(radius);
	}

	public double getRadius() {
		return radius;
	}

	public void setRadius(double radius) {
		this.radius = radius;
	}

	@Override
	public double getArea() {
		double area = 4 * Math.PI * this.getRadius() * this.getRadius();
		return area;
	}

	@Override
	public double getVolume() {
		double volume = 4 * Math.PI * this.getRadius() * this.getRadius() * this.getRadius() / 3;
		return volume;
	}
}
