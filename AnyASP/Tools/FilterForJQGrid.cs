namespace AnyASP.Models
{
    public class FilterObject
    {
        public string groupOp { get; set; }
        public Rule[] rules { get; set; }
    }

    public class Rule
    {
        public string field { get; set; }
        public string op { get; set; }
        public string data { get; set; }
    }
}
