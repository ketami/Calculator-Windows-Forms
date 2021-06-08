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
            string operationName;
            static byte number = 1;
            bool isPushed;

            public OperationButton(Form1 Form1, string operationName, OperationMethod operationMethod)
            {
                this.operationName = operationName;
                mappers.Add(operationName, operationMethod);
                Button newButton = new Button();
                ButtonSetter(Form1, operationName, newButton);
                newButton.Click += new EventHandler(Click);
                Form1.panel1.Controls.Add(newButton);
                number++;
            }

            void ButtonSetter(Form1 Form1, string operationName, Button newButton)
            {
                int x = Form1.panel1.Width * ((number - 1) % 2) / 2 + Form1.panel1.Width / 16;
                int y = Form1.panel1.Height * ((number - 1) / 2) / 6 + Form1.panel1.Height / 25;
                int weigth = Convert.ToInt32(Math.Round(Form1.panel1.Width * ((double)1 / 2 - (double)1 / 8)));
                int heigth = Convert.ToInt32(Math.Round(Form1.panel1.Height * ((double)1 / 6 - (double)2 / 25)));
                newButton.Name = operationName;
                newButton.Text = operationName;
                newButton.Location = new Point(x, y);
                newButton.Size = new Size(weigth, heigth);
                newButton.UseVisualStyleBackColor = true;
            }
            

            static Dictionary<string, OperationMethod> mappers = new Dictionary<string, OperationMethod>();

            private new void Click(object sender, EventArgs e)
            {
                mappers.TryGetValue(operationName, out currentOperationMethod);
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.BackColor = System.Drawing.Color.MediumPurple;
            }

            public static double ExecuteOperation(Form1 Form, OperationMethod Operation)
            {
                switch (Form.ValidateInput())
                {
                    case true:
                        break;
                    case false:
                        MessageBox.Show("Введите число");
                        return 0;
                }
                return Operation(Convert.ToDouble(Form.textBox1.Text), Convert.ToDouble(Form.textBox2.Text));
            }
        }

    }

}