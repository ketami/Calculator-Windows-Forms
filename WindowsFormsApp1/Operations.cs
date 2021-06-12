using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class OperationPanel : Panel
    {
    
        private void InitializeUserOperations()
        {
            AddOperation("sample00000", Sample);
            AddOperation("sample00001", Sample);
            AddOperation("sample00002", Sample);
            AddOperation("sample00003", Sample);
            AddOperation("sample00004", Sample);
            AddOperation("sample00005", Sample);
            /*  AddOperation("sample00005", Sample);
              AddOperation("sample00006", Sample);
              AddOperation("sample00007", Sample);
              AddOperation("sample000", Sample); //  (+ РЕСАЙЗ, 4 столбца операций)
              AddOperation("sample00204", Sample);
              AddOperation("sample00105", Sample);
              AddOperation("sample00306", Sample);
              AddOperation("sample00407", Sample);
              AddOperation("sample00008", Sample);
                 AddOperation("sample00009", Sample);
                 AddOperation("sample00010", Sample);
                 AddOperation("sample00011", Sample);
                 AddOperation("sample00012", Sample); 
                 AddOperation("sample000011", Sample);
                 AddOperation("sample000022", Sample);
                 AddOperation("sample000013", Sample); //  (+ РЕСАЙЗ, 6 столбцов операций)
                AddOperation("sample000014", Sample);
                AddOperation("sample000015", Sample);
                AddOperation("sample000016", Sample);
                AddOperation("sample000017", Sample);
                AddOperation("sample000018", Sample);
                AddOperation("sample000019", Sample);
                AddOperation("sample000110", Sample);
                AddOperation("sample000111", Sample);
                AddOperation("sample000113", Sample);
                AddOperation("sample000114", Sample);*/
        }
        private static double Sample(double a, double b)
        {
            return 0;
        }
    }
}
