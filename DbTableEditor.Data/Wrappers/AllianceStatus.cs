using DbTableEditor.Data.Model;

namespace DbTableEditor.Data.Wrappers
{
    public class AllianceStatus
    {
        public Alliance Alliance { get; set; }
        public bool HasEmpires { get; set; }

        public AllianceStatus()
        {

        }

        public AllianceStatus(Alliance alliance, bool hasEmpires)
        {
            Alliance = alliance;
            HasEmpires = hasEmpires;
        }

        public void Deconstruct(out Alliance alliance, out bool hasEmpires)
        {
            alliance = Alliance;
            hasEmpires = HasEmpires;
        }
    }
}
