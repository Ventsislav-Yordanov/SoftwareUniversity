package Geometry.shapes;

import Geometry.vertices.Vertex3D;

public class SquarePyramid extends SpaceShape {
	private double baseWidth;
	private double height;
	
	public SquarePyramid(Vertex3D baseCenter, double baseWidth, double height) {
		super(new Vertex3D[]{baseCenter});
		this.setBaseWidth(baseWidth);
		this.setHeight(height);
	}

	public double getBaseWidth() {
		return baseWidth;
	}

	public void setBaseWidth(double baseWidth) {
		this.baseWidth = baseWidth;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		this.height = height;
	}

	@Override
	public double getArea() {
		double baseSide = this.getBaseWidth();
		double area = baseSide * baseSide + 
				2 * baseSide *
				Math.sqrt(baseSide * baseSide / 4 + this.getHeight() * this.getHeight());
		
		return area;
	}

	@Override
	public double getVolume() {
		double baseSide = this.getBaseWidth();
		double volume = baseSide * baseSide * this.getHeight() / 3;
		
		return volume;
	}
	
	
}
