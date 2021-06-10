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
    public class OperationPanel : Panel
    {
        public static int PanelCounter = -1;
        public int X_Elements { get; set; }
        public int Y_Elements { get; set; }
        public void AddOperation(string OperationName, OperationMethod operationMethod)
        {
            this.Controls.Add(new OperationButton(OperationName, operationMethod));

        }
        private void OperationButton_Setter(Button newButton, byte PanelCounter)
        {
            int x = Width * PanelCounter + Width * ((((OperationButton)newButton).Index - 1) % 2) / 2 + Width / 16;
            int y = -Height * PanelCounter + Height * ((((OperationButton)newButton).Index - 1) / 2) / 6 + Height / 25;
            int width = Convert.ToInt32(Math.Round(Width * ((double)1 / 2 - (double)1 / 8)));
            int heigth = Convert.ToInt32(Math.Round(Height * ((double)1 / 6 - (double)2 / 25)));
            newButton.Location = new Point(x, y);
            newButton.Size = new Size(width, heigth);
            newButton.UseVisualStyleBackColor = true;
        }

    }
    public partial class CalculatorWindow : Form
    {
        public static int PanelCounter = -1;
        internal static OperationMethod currentOperationMethod;
        public CalculatorWindow()
        {
            InitializeComponent();

        }
        private void CalculatorWindow_Load(object sender, EventArgs e)
        {
            InitializeOperations();
            InitializeButtons();
            Initialize_OperationPanel();
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
        private void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = Convert.ToString(ExecuteOperation(this, currentOperationMethod));

        }
        protected bool ValidateInput()
        {
            
            if (Regex.IsMatch(TextBox1.Text, @"^\-*\d*\,*\d+$") && Regex.IsMatch(TextBox2.Text, @"^\-*\d*\,*\d+$"))
                return true;
            return false;
        }
       
        internal void AddOperation(string OperationName, OperationMethod operationMethod)
        {
            Panel1.Controls.Add(new OperationButton(OperationName, operationMethod));
        }

        private void InitializeButtons()
        {
            foreach (Button btn in Panel1.Controls)
            {
                if ((((OperationButton)btn).Index-1) % 12 == 0) PanelCounter++;
                 OperationButton_Setter(btn, (byte)PanelCounter);
            }
        }

        private void OperationButton_Setter(Button newButton, byte PanelCounter)
        {
                int x =  Panel1.Width * PanelCounter + Panel1.Width * ((((OperationButton)newButton).Index - 1) % 2) / 2 + Panel1.Width / 16;
                int y = - Panel1.Height * PanelCounter + Panel1.Height * ((((OperationButton)newButton).Index - 1) / 2) / 6 + Panel1.Height / 25;
                int width = Convert.ToInt32(Math.Round(Panel1.Width * ((double)1 / 2 - (double)1 / 8)));
                int heigth = Convert.ToInt32(Math.Round(Panel1.Height * ((double)1 / 6 - (double)2 / 25)));
                newButton.Location = new Point(x, y);
                newButton.Size = new Size(width, heigth);
                newButton.UseVisualStyleBackColor = true;
        }
        private void Initialize_OperationPanel()
        {
            Panel1.Width += Panel1.Width * Convert.ToInt32((OperationButton.Number-2)/ 12);

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
        internal void InitializeOperations()
        {
            InitializeDefaultOperations();
            InitializeUserOperations();
        }
        private void InitializeDefaultOperations()
        {
            AddOperation("+", Add);
            AddOperation("-", Substract);
            AddOperation("*", Multiply);
            AddOperation("/", Divide);

        }
        private static double Sample(double a, double b)
        {
            return 0;
        }
        public void InitializeUserOperations()
        {
            AddOperation("sample00000", Sample); 
            AddOperation("sample00001", Sample);
            AddOperation("sample00002", Sample);
               AddOperation("sample00003", Sample);
              AddOperation("sample00004", Sample);
               AddOperation("sample00005", Sample);
             AddOperation("sample00006", Sample);
             AddOperation("sample00007", Sample);
          AddOperation("sample000", Sample); //  (+ РЕСАЙЗ, 4 столбца операций)
            AddOperation("sample00204", Sample);
            AddOperation("sample00105", Sample);
            AddOperation("sample00306", Sample);
            AddOperation("sample00407", Sample);
             AddOperation("sample00008", Sample);
          /*   AddOperation("sample00009", Sample);
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


    }
}