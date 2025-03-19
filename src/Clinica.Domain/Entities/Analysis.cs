namespace Clinica.Domain.Entities
{
    public class Analysis
    {
        public int? AnalysisId { get; set; }
        public string? AnalysisName { get; set; }
        public int? State { get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}
