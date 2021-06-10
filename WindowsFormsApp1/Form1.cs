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

    public delegate double OperationMethod(double a, double b);

    public partial class CalculatorWindow : Form
    {
        public CalculatorWindow()
        {
            InitializeComponent();

        }
        public static int PanelCounter = -1;
        internal static OperationMethod currentOperationMethod;

        private void CalculatorWindow_Load(object sender, EventArgs e)
        {
            OperationPanel Panel1 = new OperationPanel();
            Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Panel1.Location = new System.Drawing.Point(289, 12);
            Panel1.Name = "Panel1";
            Panel1.Size = new System.Drawing.Size(228, 318);
            Panel1.TabIndex = 6;
            this.Controls.Add(Panel1);
            Panel1.InitializePanel();
        }

        internal static double Calculate(CalculatorWindow CalculatorWindow, OperationMethod Operation)
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
        private void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = Convert.ToString(Calculate(this, currentOperationMethod));

        }
        protected bool ValidateInput()
        {
            
            if (Regex.IsMatch(TextBox1.Text, @"^\-*\d*\,*\d+$") && Regex.IsMatch(TextBox2.Text, @"^\-*\d*\,*\d+$"))
                return true;
            return false;
        }

    }
    public partial class OperationPanel : Panel
    {
        private static int PanelCounter = -1;
        const int X = 2;
        const int Y = 6;
        public void AddOperation(string OperationName, OperationMethod operationMethod)
        {
            this.Controls.Add(new OperationButton(OperationName, operationMethod));

        }
        private void OperationButton_Setter(Button newButton, byte PanelCounter)
        {
            int x = Width * PanelCounter + Width * ((((OperationButton)newButton).Index - 1) % 2) / (byte)X + Width / 16;
            int y = -Height * PanelCounter + Height * ((((OperationButton)newButton).Index - 1) / 2) / (byte)Y + Height / 25;
            int width = Convert.ToInt32(Math.Round(Width * ((double)1 / X - (double)1 / 8)));
            int heigth = Convert.ToInt32(Math.Round(Height * ((double)1 / Y - (double)2 / 25)));
            newButton.Location = new Point(x, y);
            newButton.Size = new Size(width, heigth);
            newButton.UseVisualStyleBackColor = true;
        }
        internal void InitializePanel()
        {
            InitializeDefaultOperations();
            InitializeUserOperations();

            foreach (Button btn in Controls)
            {
                if ((((OperationButton)btn).Index - 1) % (X * Y) == 0) PanelCounter++;
                OperationButton_Setter(btn, (byte)PanelCounter);
            }
            Width += Width * Convert.ToInt32((OperationButton.Number - 2) / (X * Y));
        }
        private void InitializeDefaultOperations()
        {
            AddOperation("+", Add);
            AddOperation("-", Substract);
            AddOperation("*", Multiply);
            AddOperation("/", Divide);

        }

        private static double Add(double a, double b)
        {
            return a + b;
        }
        private static double Substract(double a, double b)
        {
            return a - b;
        }
        private static double Multiply(double a, double b)
        {
            return a * b;
        }
        private static double Divide(double a, double b)
        {
            return a / b;
        }
    }

}