namespace Clinica.Infraestructure.Authentication
{
    public enum Permission
    {
        ListAnalysis = 1,
        AnalysisById = 2,
        AnalysisRegister = 3,
        AnalysisEdit = 4,
        AnalysisDelete = 5,
        ChangeStateAnalysis = 6,

        ListExams = 7,
        ExamById = 8,
        RegisterExam = 9,
        EditExam = 10,
        DeleteExam = 11,
        ChangeStateExam = 12,

        ListPatients = 13,
        PatientById = 14,
        RegisterPatient = 15,
        EditPatient = 16,
        DeletePatient = 17,
        ChangeStatePatient = 18,

        ListTakeExams = 19,
        TakeExamById = 20,
        RegisterTakeExam = 21,
        UpdateTakeExam = 22,
        ChangeStateTakeExam = 23,

        RegisterUser = 24,

        ListMedics = 25,
        MedicById = 26,
        RegisterMedic = 27,
        EditMedic = 28,
        DeleteMedic = 29,
        ChangeStateMedic = 30,

        ListResults = 31,
        ResultById = 32,
        RegisterResult = 33,
        EditResult = 34

    }
}
