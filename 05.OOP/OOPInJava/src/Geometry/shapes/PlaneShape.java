package Geometry.shapes;

import Geometry.interfaces.AreaMeasurable;
import Geometry.interfaces.PerimeterMeasurable;
import Geometry.vertices.Vertex2D;

public abstract class PlaneShape extends Shape implements AreaMeasurable, PerimeterMeasurable {
	
	public PlaneShape(Vertex2D[] vertices) {
		this.setVertices(vertices);
	}

	public abstract double getArea();
	
	public abstract double getPerimeter();
	
	@Override
	public String toString(){
		String superToString = super.toString();
		String perimeterAndArea = String.format(
				"Perimeter: %.2f, Area: %.2f",
				this.getPerimeter(),
				this.getArea());
		
		return superToString + perimeterAndArea;		
	}
}
