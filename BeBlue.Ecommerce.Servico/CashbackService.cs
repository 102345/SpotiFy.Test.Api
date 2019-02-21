using BeBlue.Ecommerce.Data.Repositories;
using BeBlue.Ecommerce.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeBlue.Ecommerce.Servico
{
    public class CashbackService : ICashback
    {
        private readonly CashbackRepository _cashbackRepository = new CashbackRepository();

        public decimal BuscarDesconto(string genero, int diaSemana)
        {
            decimal ret = 0;

            var cashBack =  _cashbackRepository.GetList(x => x.Genero == genero && x.DiaSemana == diaSemana).Single();

            if (cashBack != null) ret = cashBack.Percentual;

            return ret;

        }
    }
}
