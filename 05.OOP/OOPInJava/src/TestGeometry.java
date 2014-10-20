import Geometry.interfaces.VolumeMeasurable;
import Geometry.shapes.Circle;
import Geometry.shapes.Cuboid;
import Geometry.shapes.PlaneShape;
import Geometry.shapes.Rectangle;
import Geometry.shapes.Shape;
import Geometry.shapes.Sphere;
import Geometry.shapes.SquarePyramid;
import Geometry.shapes.Triangle;
import Geometry.vertices.Vertex2D;
import Geometry.vertices.Vertex3D;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Stream;

public class TestGeometry {
	
	public static void main(String[] args) {
		// Triangle test
        Triangle triangle = new Triangle(new Vertex2D[]{new Vertex2D(-1, 3), new Vertex2D(2, 3), new Vertex2D(2, 6)});
        double trianglePerimeter = triangle.getPerimeter();
        System.out.println(String.format("Triangle perimeter: %f", trianglePerimeter));

        double triangle1Area = triangle.getArea();
        System.out.println(String.format("Triangle area: %f", triangle1Area));

        // Rectangle test
        Rectangle rectangle = new Rectangle(new Vertex2D(2, 3), 12.5, 33);
        double rectanglePerimeter = rectangle.getPerimeter();
        System.out.println(String.format("Rectangle perimeter: %f", rectanglePerimeter));

        double rectangleArea = rectangle.getArea();
        System.out.println(String.format("Rectangle area: %f", rectangleArea));

        // Circle test
        Circle circle = new Circle(new Vertex2D(2, 3), 12.5);
        double circlePerimeter = circle.getPerimeter();
        System.out.println(String.format("Circle perimeter: %f", circlePerimeter));

        double circleArea = circle.getArea();
        System.out.println(String.format("Circle area: %f", circleArea));

        // Square Pyramid test
        SquarePyramid pyramid = new SquarePyramid(new Vertex3D(2, 3.4, 4), 5.2, 8);
        
        double pyramidArea = pyramid.getArea();
        System.out.println(String.format("Pyramid area: %f", pyramidArea));
        
        double pyramidVolume = pyramid.getVolume();
        System.out.println(String.format("Pyramid volume: %f", pyramidVolume));

        // Cuboid test
        Cuboid cuboid = new Cuboid(new Vertex3D(2, 3.4, 4), 0.2, 8, 9);

        double cuboidArea = cuboid.getArea();
        System.out.println(String.format("Cuboid area: %f", cuboidArea));
        
        double cunoidVolume = cuboid.getVolume();
        System.out.println(String.format("Cuboid volume: %f", cunoidVolume));

        // Sphere test
        Sphere sphere = new Sphere(new Vertex3D(2, 3.4, 4), 5.2);
       
        double sphereArea = sphere.getArea();
        System.out.println(String.format("Sphere area: %f", sphereArea));
        
        double sphereVolume = sphere.getVolume();
        System.out.println(String.format("Sphere volume: %f", sphereVolume));

        List<Shape> shapes = new ArrayList<Shape>();
        shapes.add(triangle);
        shapes.add(rectangle);
        shapes.add(cuboid);
        shapes.add(sphere);
        shapes.add(pyramid);
        shapes.add(circle);

        System.out.println("");
        System.out.println("Get all VolumeMeasurables with volume bigger than 40 :");
        Stream<Object> biggerVolumeMeasurables = shapes.stream()
                .filter((sh) -> sh instanceof VolumeMeasurable)
                .filter((sh) -> ((VolumeMeasurable) sh).getVolume() > 40)
                .map(sh -> sh.toString());

        biggerVolumeMeasurables.forEach(shape -> System.out.println(shape));

        System.out.println("");
        System.out.println("Get all PlaneShapes sorted ascending by perimeter :");
        
        Stream<String> sortedPlaneShapes = shapes.stream().
                filter(shape -> shape instanceof PlaneShape).
                sorted((first, second) -> Double.compare(
                                ((PlaneShape) first).getPerimeter(), ((PlaneShape) second).getPerimeter())).
                map(shape -> shape.toString());

        sortedPlaneShapes.forEachOrdered(shape -> System.out.println(shape));
	}
}
