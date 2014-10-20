package Geometry.shapes;

import java.security.InvalidParameterException;

import Geometry.vertices.Vertex2D;

public class Triangle extends PlaneShape {

	public Triangle(Vertex2D[] vertices) {
		super(vertices);
		
		if(vertices.length != 3){
			throw new InvalidParameterException("A triangle must hold exactly 3 vertices");
		}
		
		double a = vertices[0].getDistanceTo(vertices[1]);
		double b = vertices[1].getDistanceTo(vertices[2]);
		double c = vertices[2].getDistanceTo(vertices[0]);
		
		if(
			(a + b) <= c ||
			(a + c) <= b ||
			(b + c) <= a){
			throw new IllegalArgumentException("The passed vertices can't build a valid triangle!");
		}
	}

	@Override
	public double getArea() {
		double semiPerimeter = this.getPerimeter() / 2;
		double a = this.getVertices()[0].getDistanceTo(this.getVertices()[1]);
		double b = this.getVertices()[1].getDistanceTo(this.getVertices()[2]);
		double c = this.getVertices()[2].getDistanceTo(this.getVertices()[0]);
		
		double area = Math.sqrt(
				semiPerimeter *
				(semiPerimeter - a) *
				(semiPerimeter - b) *
				(semiPerimeter - c));
		
		return area;
	}

	@Override
	public double getPerimeter() {
		double a = this.getVertices()[0].getDistanceTo(this.getVertices()[1]);
		double b = this.getVertices()[1].getDistanceTo(this.getVertices()[2]);
		double c = this.getVertices()[2].getDistanceTo(this.getVertices()[0]);
		
		double perimeter = a + b + c;
		
		return perimeter;
	}
}
