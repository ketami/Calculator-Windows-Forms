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
        public delegate double OperationMethod(double a, double b);
        public static OperationMethod currentOperationMethod;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDefaultOperations();

        }


        private void textBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            textBox1.Clear();

        }

        private void textBox2_MouseCaptureChanged(object sender, EventArgs e)
        {
            textBox2.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(OperationButton.ExecuteOperation(this, currentOperationMethod));

        }


        public bool ValidateInput()
        {
            
            if (Regex.IsMatch(textBox1.Text, @"^\-*\d*\,*\d+$") && Regex.IsMatch(textBox2.Text, @"^\-*\d*\,*\d+$"))
            return true;
            return false;
        }


         void AddOperation(string OperationName, OperationMethod operationMethod)
        {
            new OperationButton(this, OperationName, operationMethod);
        }

      

        public static double Add(double a, double b)
        {
            return a + b;
        }
        public static double Substract(double a, double b)
        {
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static double Divide(double a, double b)
        {
            return a / b;
        }
        public void InitializeDefaultOperations()
        {
            AddOperation("+", Add);
            AddOperation("-", Substract);
            AddOperation("*", Multiply);
            AddOperation("/", Divide);
            InitializeUserOperations();

        }
        public static double Sample(double a, double b)
        {
            return 0;
        }
        void InitializeUserOperations()
        {
       //     AddOperation("sample00000", Sample);

        }


    }
}