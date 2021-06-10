using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public class OperationButton : Button
    {
        private static Button PushedButton;
        public byte Index { get; }
        public static byte Number = 1;

        static Dictionary<string, OperationMethod> OperationMap = new Dictionary<string, OperationMethod>();
        internal OperationButton(string operationName, OperationMethod operationMethod)
        {
            this.Name = operationName;
            this.Text = operationName;
            this.Index = Number;
            this.UseVisualStyleBackColor = true;
            ((Button)this).Click += Click;
            OperationMap.Add(operationName, operationMethod);
            Number++;
        }



        private new void Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (PushedButton != null)
            {
                PushedButton.BackColor = btn.BackColor;
            }
            PushedButton = btn;
            btn.BackColor = System.Drawing.Color.LightSteelBlue;
            OperationMap.TryGetValue(this.Text, out CalculatorWindow.currentOperationMethod);
        }



    }

    public partial class CalculatorWindow : Form
    {


    }

}