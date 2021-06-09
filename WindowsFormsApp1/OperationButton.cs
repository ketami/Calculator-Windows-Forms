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
           private string operationName;
           private static byte number = 1;
           CalculatorWindow CalculatorWindow;
           static Dictionary<string, OperationMethod> mappers = new Dictionary<string, OperationMethod>();

            internal OperationButton(CalculatorWindow CalculatorWindow, string operationName, OperationMethod operationMethod)
            {
                this.CalculatorWindow = CalculatorWindow;
                this.operationName = operationName;
                mappers.Add(operationName, operationMethod);
                Button newButton = new Button();
                Setter(newButton);
                newButton.Click += new EventHandler(Click);
                CalculatorWindow.Panel1.Controls.Add(newButton);
                number++;
            }
            private void Setter(Button newButton)
            {
                int x = CalculatorWindow.Panel1.Width * ((number - 1) % 2) / 2 + CalculatorWindow.Panel1.Width / 16;
                int y = CalculatorWindow.Panel1.Height * ((number - 1) / 2) / 6 + CalculatorWindow.Panel1.Height / 25;
                int weigth = Convert.ToInt32(Math.Round(CalculatorWindow.Panel1.Width * ((double)1 / 2 - (double)1 / 8)));
                int heigth = Convert.ToInt32(Math.Round(CalculatorWindow.Panel1.Height * ((double)1 / 6 - (double)2 / 25)));
                newButton.Name = operationName;
                newButton.Text = operationName;
                newButton.Location = new Point(x, y);
                newButton.Size = new Size(weigth, heigth);
                newButton.UseVisualStyleBackColor = true;
            }
            

            private new void Click(object sender, EventArgs e)
            {
                Button btn = sender as Button;
                if (PushedButton != null)
                {
                    PushedButton.FlatStyle = btn.FlatStyle;
                    PushedButton.BackColor = btn.BackColor;
                }
                PushedButton = btn;
                mappers.TryGetValue(operationName, out currentOperationMethod);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.BackColor = System.Drawing.Color.LightSteelBlue;
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