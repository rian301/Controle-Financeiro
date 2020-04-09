using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.JsonRetornoErro
{
    public class JsonRetornoDefault
    {
        public List<JsonRetornoErro> Erros { get; private set; }

        public JsonRetornoDefault(IList<ValidationFailure> erros)
        {
            this.Erros = new List<JsonRetornoErro>();
            if (erros != null) setErrosPorValidationFailure(erros.ToList());
        }

        public JsonRetornoDefault(IList<JsonRetornoErro> erros)
        {
            this.Erros = new List<JsonRetornoErro>();
            if (erros != null) this.Erros = erros.ToList();
        }

        private void setErrosPorValidationFailure(List<ValidationFailure> erros)
        {
            foreach (var erro in erros)
            {
                this.Erros.Add(new JsonRetornoErro(erro.PropertyName, erro.ErrorMessage));
            }
        }

    }
}
