namespace LoggerExercise.Layouts
{
    public abstract class Layout : ILayout
    {
        public Layout(string format)
        {
            Format = format;
        }
        public string Format { get; }
    }
}
