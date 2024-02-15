using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Relatorio
	{
		public string MaterialCodigo { get; set; }
		public DateTime Data { get; set; }
		public decimal QtdEntrada { get; set; }
		public decimal ValorEntrada { get; set; }

		public decimal QtdSaida { get; set; }
		public decimal ValorSaida { get; set; }

		public decimal QtdSaldo { get; set; }
		public decimal ValorSaldo { get; set; }
	}
}
