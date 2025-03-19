using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Application.Dtos.Analysis.Response
{
    public class GetAnalysisByIdResponseDto
    {
        public int AnalysisId { get; set; }
        public string? AnalysisName { get; set; }
    }
}
