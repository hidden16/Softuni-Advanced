namespace LoggerExercise.Layouts
{
    public class XmlLayout : Layout
    {
        private const string xmlLayoutFormat = @"<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}></message>
</log>";
        public XmlLayout() : base(xmlLayoutFormat)
        {
        }
    }
}
