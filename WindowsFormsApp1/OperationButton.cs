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
    public partial class Form1 : Form
    {
        public class OperationButton : Button
        {
           private string operationName;
           private static byte number = 1;

            static Dictionary<string, OperationMethod> mappers = new Dictionary<string, OperationMethod>();

            internal OperationButton(Form1 Form1, string operationName, OperationMethod operationMethod)
            {
                this.operationName = operationName;
                mappers.Add(operationName, operationMethod);
                Button newButton = new Button();
                Setter(Form1, newButton);
                newButton.Click += new EventHandler(Click);
                Form1.Panel1.Controls.Add(newButton);
                number++;
            }

            private void Setter(Form1 Form1, Button newButton)
            {   
                int x = Form1.Panel1.Width * ((number - 1) % 2) / 2 + Form1.Panel1.Width / 16;
                int y = Form1.Panel1.Height * ((number - 1) / 2) / 6 + Form1.Panel1.Height / 25;
                int weigth = Convert.ToInt32(Math.Round(Form1.Panel1.Width * ((double)1 / 2 - (double)1 / 8)));
                int heigth = Convert.ToInt32(Math.Round(Form1.Panel1.Height * ((double)1 / 6 - (double)2 / 25)));
                newButton.Name = operationName;
                newButton.Text = operationName;
                newButton.Location = new Point(x, y);
                newButton.Size = new Size(weigth, heigth);
                newButton.UseVisualStyleBackColor = true;
            }
            

            private new void Click(object sender, EventArgs e)
            {
                mappers.TryGetValue(operationName, out currentOperationMethod);
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.BackColor = System.Drawing.Color.MediumPurple;
            }


            internal static double ExecuteOperation(Form1 Form, OperationMethod Operation)
            {
                switch (Form.ValidateInput())
                {
                    case true:
                        break;
                    case false:
                        MessageBox.Show("Введите число");
                        return 0;
                }
                if (Operation != null) return Operation(Convert.ToDouble(Form.TextBox1.Text), Convert.ToDouble(Form.TextBox2.Text));
                else
                    MessageBox.Show("Не выбрана операция");
                    return 0;
            }
        }

    }

}