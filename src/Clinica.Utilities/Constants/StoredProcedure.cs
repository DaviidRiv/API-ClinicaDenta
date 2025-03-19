namespace Clinica.Utilities.Constants
{
    public class StoredProcedure
    {
        #region uspAnalysis
        public const string uspAnalysisList = "uspAnalysisList";
        public const string uspAnalysisById = "uspAnalysisById";
        public const string uspAnalysisRegister = "uspAnalysisRegister";
        public const string uspAnalysisDelete = "uspAnalysisDelete";
        public const string uspAnalysisEdit = "uspAnalysisEdit";
        public const string uspAnalysisChangeState = "uspAnalysisChangeState";
        #endregion

        #region uspExams
        public const string uspExamList = "uspExamList";
        public const string uspExamById = "uspExamById";
        public const string uspExamRegister = "uspExamRegister";
        public const string uspExamEdit = "uspExamEdit";
        public const string uspExamDelete = "uspExamDelete";
        public const string uspExamChangeState = "uspExamChangeState";
        #endregion

        #region uspPatients
        public const string uspPatientList = "uspPatientList";
        public const string uspPatientById = "uspPatientById";
        public const string uspPatientRegister = "uspPatientRegister";
        public const string uspPatientEdit = "uspPatientEdit";
        public const string uspPatientDelete = "uspPatientDelete";
        public const string uspPatientChangeState = "uspPatientChangeState";

        #endregion

        #region uspMedics
        public const string uspMedicList = "uspMedicList";
        public const string uspMedicById = "uspMedicById";
        public const string uspMedicRegister = "uspMedicRegister";
        public const string uspMedicEdit = "uspMedicEdit";
        public const string uspMedicDelete = "uspMedicDelete";
        public const string uspMedicChangeState = "uspMedicChangeState";

        #endregion
        
        #region uspTakeExams
        public const string uspTakeExamList = "uspTakeExamList";
        #endregion

        #region uspResults
        public const string uspResultList = "uspResultList";

        #endregion

        #region uspUsers
        public const string uspUserRegister = "uspUserRegister";
        public const string uspUserByEmail = "uspUserByEmail";

        #endregion

    }

    public class Table
    {
        public const string Analysis = "Analysis";
        public const string Exams = "Exams";
        public const string Medics = "Medics";
        public const string Patients = "Patients";
        public const string TakeExam = "TakeExam";
        public const string Results = "Results";
        public const string Users = "Users";
    }
}
