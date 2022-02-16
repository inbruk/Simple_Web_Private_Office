using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace BusinessLogicLayer.Auxiliary
{
    internal static class InternetUserAccountEntitiesHandler // это хорошо бы сделать шаблоном и использовать в похожих ситуациях
    {
        private static InternetUserAccountEntities ctx = null;
        public static InternetUserAccountEntities Get()
        {
            if( ctx == null )
                ctx = new InternetUserAccountEntities();

            return ctx;
        }
    }
}
