package Geometry.shapes;

import Geometry.vertices.Vertex;

public abstract class Shape {
	
	private Vertex[] vertices;

	public Vertex[] getVertices() {
		return vertices;
	}

	public void setVertices(Vertex[] vertices) {
		if(vertices == null){
			throw new NullPointerException("Vertices can't be null!");
		}
		
		this.vertices = vertices;
	}

	@Override
	public String toString() {
		StringBuilder verticesStringBuilder = new StringBuilder();
		for (Vertex vertex : this.getVertices()) {
			verticesStringBuilder.append(vertex.toString());
			verticesStringBuilder.append(" ");
		}
		
		return String.format(
				"Shape type: %s, Vertices[%s]",
				this.getClass().getName(),
				verticesStringBuilder.toString());
	}
	
}
