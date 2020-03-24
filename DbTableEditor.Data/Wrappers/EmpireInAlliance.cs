using DbTableEditor.Data.Model;

namespace DbTableEditor.Data.Wrappers
{
    public class EmpireInAlliance
    {
        public Empire Empire { get; set; }
        public bool IsInAlliance { get; set; }

        public EmpireInAlliance()
        {

        }

        public EmpireInAlliance(Empire empire, bool isInAlliance)
        {
            Empire = empire;
            IsInAlliance = isInAlliance;
        }

        public void Deconstruct(out Empire empire, out bool isInAlliance)
        {
            empire = Empire;
            isInAlliance = IsInAlliance;
        }
    }
}
