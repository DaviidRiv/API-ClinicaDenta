using Clinica.Application.Interface.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Persistence.Context;
using System.Transactions;

namespace Clinica.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Analysis> Analysis { get; }
        public IExamRepository Exam { get; }
        public IPatientRepository Patient { get; }
        public IMedicRepository Medic { get; }
        public ITakeExamRepository TakeExam { get; }
        public IResultRepository Result { get; }

        public IUserRepository User { get; }

        public UnitOfWork(ApplicationDbContext context, IGenericRepository<Analysis> analysis)
        {
            Analysis = analysis;
            _context = context;
            Exam = new ExamRepository(_context);
            Patient = new PatientRepository(_context);
            Medic = new MedicRepository(_context);
            TakeExam = new TakeExamRepository(_context);
            Result = new ResultRepository(_context);
            User = new UserRepository(_context);
        }

        //liberar recursos no administrados, y conexion, desde el system
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //Realizar una transaccion a la ves a la bd
        public TransactionScope BeginTransaction()
        {
            var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);//Habilitar flujo async
            return transaction; //retornar la instancia
        }
    }
}
