using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGB
{


    class WhoIsDepartament
    {
        public static int _id = 1;
        public int IDempl { get; set; }
        public int IDdepr { get; set; }

        /// <summary>
        /// Конструктор класса принимает ID отдела. ID пользователя он подставляет исходя из своего счетчика, поэтому важно инициировать создание объекта сразу после создания объекта пользователя.
        /// </summary>
        /// <param name="_IDdepr"></param>
        public WhoIsDepartament(int _IDdepr)
        {
            IDempl = _id;
            _id++;
            IDdepr = _IDdepr;
        }

    }

}
