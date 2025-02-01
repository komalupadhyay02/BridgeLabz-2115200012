import java.util.Scanner;

public class DistanceConverter {
    public static void main(String[] args) {
        // Create a Scanner object to take user input
        Scanner input = new Scanner(System.in);

        // Take user input for kilometers
        System.out.print("Enter the distance in kilometers: ");
        double km = input.nextDouble();

        // Call the method to convert kilometers to miles and display the result
        convertAndDisplayDistance(km);

        // Close the scanner object to avoid resource leak
        input.close();
    }

    // Method to convert kilometers to miles and display the result
    static void convertAndDisplayDistance(double km) {
        // Convert kilometers to miles (1 mile = 1.6 km)
        double miles = km / 1.6;

        // Display the result
        System.out.printf("The total miles is %.2f mile for the given %.2f km%n", miles, km);
    }
}