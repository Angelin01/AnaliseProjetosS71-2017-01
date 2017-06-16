using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceWpf.Entity
{
    class RelatorioOrcamentario
    {
        private DateTime dataInicio;
        private DateTime dataFinal;

        public RelatorioOrcamentario(DateTime dataInicio, DateTime dataFinal)
        {
            this.dataInicio = dataInicio;
            this.dataFinal = dataFinal;
        }

        public DateTime DataInicio { get => dataInicio; set => dataInicio = value; }
        public DateTime DataFinal { get => dataFinal; set => dataFinal = value; }

        public void AtualizarRelatorio() { }
    }
}