namespace Clinica.Application.Dtos.Exam.Response
{
    //SEGUN EL SP
    public class GetAllExamResponseDto
    {
        public int? ExamId { get; set; }
        public string? Name { get; set; }
        public string? Analysis { get; set; }
        public string? StateExam { get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}
