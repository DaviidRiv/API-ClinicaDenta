namespace Clinica.Application.UseCase.Commons.Bases
{
    public class BasePaginationResponse<T>:BaseGenericResponse<T>
    {
        public int PageNumber { get; set; } 
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage => PageNumber > 1; //Expresion Landa para saber si hay una pagina previa
        public bool HasNextPage => PageNumber < TotalPages; //Expresion Landa para saber si hay una pagina anterior
    }
}
