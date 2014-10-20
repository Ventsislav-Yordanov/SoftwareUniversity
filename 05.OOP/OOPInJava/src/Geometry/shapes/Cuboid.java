package Geometry.shapes;

import Geometry.vertices.Vertex3D;

public class Cuboid extends SpaceShape {
	private double width;
	private double height;
	private double depth;
	
	
	
	public Cuboid(Vertex3D location, double width, double height, double depth) {
		super(new Vertex3D[]{location});
		this.setWidth(width);
		this.setHeight(height);
		this.setDepth(depth);
	}

	public double getWidth() {
		return width;
	}
	
	public void setWidth(double width) {
		this.width = width;
	}
	
	public double getHeight() {
		return height;
	}
	
	public void setHeight(double height) {
		this.height = height;
	}
	
	public double getDepth() {
		return depth;
	}
	
	public void setDepth(double depth) {
		this.depth = depth;
	}

	@Override
	public double getArea() {
		double area = 2 * (this.getHeight() * this.getWidth()) +
				this.getWidth() * this.getDepth() + 
				this.getDepth() * this.getHeight();
		
		return area;
	}

	@Override
	public double getVolume() {
		double volume = this.getHeight() * this.getDepth() * this.getWidth();
		return volume;
	}
}
