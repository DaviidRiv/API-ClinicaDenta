using Clinica.Domain.Entities;
using System.Transactions;

namespace Clinica.Application.Interface.Interfaces
{
    //Unidad de trabajo, se utiliza para agregar o agrupar multiples operacion de acceso a datos en una unica transaccion
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analysis>Analysis { get; }
        IExamRepository Exam { get; }
        IPatientRepository Patient { get; }
        IMedicRepository Medic { get; }
        ITakeExamRepository TakeExam { get; }
        IResultRepository Result { get; }
        IUserRepository User { get; }
        TransactionScope BeginTransaction();
    }
}
