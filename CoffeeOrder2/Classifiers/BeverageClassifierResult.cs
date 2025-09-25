namespace CoffeeOrder.Classifiers;

public sealed class BeverageClassifierResult
{
    public IReadOnlyList<string> Classifications { get; }

    public BeverageClassifierResult(IEnumerable<string> classifications)
    {
        Classifications = classifications.ToList();
    }

    public static BeverageClassifierResult Create(string[] classifications)
    {
        return new BeverageClassifierResult(classifications);
    }

}