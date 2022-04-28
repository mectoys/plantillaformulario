using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantillaformulario.Clases
{
    public class Propiedades
    {
        public static string formName;

        public string fullFormName
        {
            get { return formName; }
            set { formName = value; }
        }



        private static string tableName;

        public string FullTableName
        {
            get { return tableName; }

            set { tableName = value; }
        }

        private static string columnId;

        public string FullcolumnId
        {
            get { return columnId; }

            set { columnId = value; }
        }

        private static string columnDescrip;

        public string FullcampoDescrip
        {
            get { return columnDescrip; }

            set { columnDescrip = value; }
        }

    }
}
