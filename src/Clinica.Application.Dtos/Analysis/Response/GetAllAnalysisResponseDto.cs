namespace Clinica.Application.Dtos.Analysis.Response
{
    //SEGUN EL SP
    public class GetAllAnalysisResponseDto
    {
        public int AnalysisId { get; set; }
        public string? AnalysisName { get; set; }
        public int State { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string? StateAnalysis { get; set; }

    }
}
