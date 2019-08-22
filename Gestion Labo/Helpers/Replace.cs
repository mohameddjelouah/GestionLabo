using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Labo.Helpers
{
    public static class Replace
    {

        public static void ReplaceItem<T>(List<T> source, T oldValue, T newValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var index = source.IndexOf(oldValue);
            if (index != -1)
                source[index] = newValue;

        }
    }
}
