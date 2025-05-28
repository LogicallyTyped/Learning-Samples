/// Is a Design Patter to acchieve inversion of control (IoC) Dependency Injection is a programming technique that makes a class independent of its dependencies.
/// Instead of the builder buying tools, somebody brings the tools to the builder.
/// There are different types, as contructor injection (class constructor), setter (property ,method) or ,Interface that uses an interface that clase implements.
/// https://www.youtube.com/watch?v=wwzhReyKV2Y

namespace DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        // Create and bring the tools to the builder
        Hammer hammer = new Hammer();
        Saw saw = new Saw();

        //2. Create the builder and pass the tools with constructor injection
        //Builder builder = new Builder(hammer, saw);

        //3.  Create the builder and pass the tools with setter injection
        //Builder builder = new Builder();
        // Inject dependencies via setters
        //builder.Hammer = hammer; 
        //builder.Saw = saw;

        // Interface Injection
        BuilderIn builder = new BuilderIn();
        builder.SetHammer(hammer);
        builder.SetSaw(saw);

        // Run the methods in the builders
        builder.Build();

        Console.ReadLine();
    }
}

public class Builder
{
    //private readonly Hammer _hammer;
    //private readonly Saw _saw;

    // 1. The builder depends on bringing its own tools. (No DI)
    //private Hammer _hammer;
    //private Saw _saw;

    //public Builder()  // constructor without dependency injection
    //{
    //    _hammer = new Hammer();
    //    _saw = new Saw();
    //}

    //========================================================================================
    //2. Construction Dependency Injection
    //public Builder(Hammer hammer, Saw saw) // constructor
    //{
    //    _hammer = hammer;
    //    _saw = saw;
    //}

    //public void Build()
    //{
    //    _hammer.Hit();
    //    _saw.Cut();
    //    Console.WriteLine("Building");
    //}

    //3. Setter Injection does not need a constructure.
    public Hammer Hammer { get; set; }
    public Saw Saw { get; set; }

    public void Build()
    {
        Hammer.Hit();
        Saw.Cut();
        Console.WriteLine("Building");
    }

    // 4. Interface Injection


}

//Interface
public interface IToolUser
{
    void SetHammer(Hammer hammer);
    void SetSaw(Saw saw);

}

public class BuilderIn : IToolUser
{
    private Hammer _hammer;
    private Saw _saw;
    public void SetHammer(Hammer hammer)
    {
        _hammer = hammer;
    }
    public void SetSaw(Saw saw)
    {
        _saw = saw;
    }
    public void Build()
    {
        _hammer.Hit();
        _saw.Cut();
        Console.WriteLine("Building");
    }
}

//End of Interface Injection

// Classes Methods for the tools
public class Hammer
{
    // Method performs the action
    public void Hit()
    {
        Console.WriteLine("Hammering Nails");
    }
}

public class Saw
{
    public void Cut()
    {
        Console.WriteLine("Sawing Wood");
    }
}
