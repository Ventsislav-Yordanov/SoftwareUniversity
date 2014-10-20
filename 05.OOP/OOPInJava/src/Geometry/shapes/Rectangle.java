package Geometry.shapes;

import Geometry.vertices.Vertex2D;

public class Rectangle extends PlaneShape {
	
	private double width;
	private double height;

	public Rectangle(Vertex2D startPoint, double width, double height) {
		super(new Vertex2D[]{startPoint});
		this.setHeight(height);
		this.setWidth(width);
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

	@Override
	public double getPerimeter() {
		double perimeter = 2 * this.getWidth() * this.getHeight();
		return perimeter;
	}

	@Override
	public double getArea() {
		double area = this.getWidth() * this.getHeight();
		return area;
	}
}
