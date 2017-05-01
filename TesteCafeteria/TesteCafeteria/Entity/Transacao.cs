using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCafeteria.Entity
{
    interface ITransacao
    {
        int Valor { get; set; }
        DateTime Data { get; set; }
    }
}
