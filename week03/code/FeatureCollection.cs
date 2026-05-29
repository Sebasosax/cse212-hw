public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    // List of all earthquakes returned by the USGS API
    public List<Feature> Features { get; set; } = [];
}

// Represents a single earthquake event
public class Feature
{
    public EarthquakeProperties Properties { get; set; } = new();
}

// The details we care about from each earthquake
public class EarthquakeProperties
{
    // Location description
    public string Place { get; set; } = "";

    // Magnitude, can be null if not reported
    public double? Mag { get; set; }
}