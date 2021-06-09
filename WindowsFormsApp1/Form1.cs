﻿using System;
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
        internal delegate double OperationMethod(double a, double b);
        internal static OperationMethod currentOperationMethod;
        public CalculatorWindow()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            InitializeDefaultOperations();
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = Convert.ToString(OperationButton.ExecuteOperation(this, currentOperationMethod));

        }
        protected bool ValidateInput()
        {

            if (Regex.IsMatch(TextBox1.Text, @"^\-*\d*\,*\d+$") && Regex.IsMatch(TextBox2.Text, @"^\-*\d*\,*\d+$"))
                return true;
            return false;
        }
       
        private void AddOperation(string OperationName, OperationMethod operationMethod)
        {
            new OperationButton(this, OperationName, operationMethod);
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
        private void InitializeDefaultOperations()
        {
            AddOperation("+", Add);
            AddOperation("-", Substract);
            AddOperation("*", Multiply);
            AddOperation("/", Divide);
            InitializeUserOperations();

        }
        private static double Sample(double a, double b)
        {
            return 0;
        }
        private void InitializeUserOperations()
        {
          //  AddOperation("sample00000", Sample);

        }

    }
}