public class Test<T>
{
    private T provided;
    private T expected;

    public Test(T provided, T expected) {
        this.provided = provided;
        this.expected = expected;
    }

    public T Provided { get => provided; }
    public T Expected { get => expected; }
}