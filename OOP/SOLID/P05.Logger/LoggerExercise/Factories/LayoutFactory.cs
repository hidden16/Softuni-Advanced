
namespace LoggerExercise.Factories
{
    using System;
    using LoggerExercise.Layouts;
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            ILayout layout = type switch
            {
                "SimpleLayout" => new SimpleLayout(),
                "XmlLayout" => new XmlLayout(),
                _ => throw new ArgumentException("Invalid type"),
            };
            return layout;
        }
    }
}
