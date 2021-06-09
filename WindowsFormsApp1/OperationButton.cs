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
    public partial class CalculatorWindow : Form
    {

        public class OperationButton : Button
        {
           private static Button PushedButton;
           public string OperationName;
           public byte Index { get; }
           public static byte Number = 1;
                
           static Dictionary<string, OperationMethod> OperationMap = new Dictionary<string, OperationMethod>();
            internal OperationButton(string operationName, OperationMethod operationMethod)
            {
                this.Name = operationName;
                this.Text = operationName;
                this.Index = Number;
                this.OperationName = operationName;
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
                OperationMap.TryGetValue(OperationName, out currentOperationMethod);
            }


            internal static double ExecuteOperation(CalculatorWindow CalculatorWindow, OperationMethod Operation)
            {
                switch (CalculatorWindow.ValidateInput())
                {
                    case true:
                        break;
                    case false:
                        MessageBox.Show("Введите число");
                        return 0;
                }
                if (Operation != null) return Operation(Convert.ToDouble(CalculatorWindow.TextBox1.Text), Convert.ToDouble(CalculatorWindow.TextBox2.Text));
                else
                    MessageBox.Show("Не выбрана операция");
                    return 0;
            }
        }

    }

}