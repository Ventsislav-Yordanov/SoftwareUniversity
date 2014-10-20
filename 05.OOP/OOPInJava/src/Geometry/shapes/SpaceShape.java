package Geometry.shapes;

import Geometry.interfaces.AreaMeasurable;
import Geometry.interfaces.VolumeMeasurable;
import Geometry.vertices.Vertex3D;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {
	
	public SpaceShape(Vertex3D[] vertices){
		this.setVertices(vertices);
	}
	
	public abstract double getArea();
	
	public abstract double getVolume();

	@Override
	public String toString() {
		String superToString = super.toString();
		String volumeAndArea = String.format(
				"Volume: %.2f, Area: %.2f",
				this.getVolume(),
				this.getArea());
		
		return superToString + volumeAndArea;
	}
}
