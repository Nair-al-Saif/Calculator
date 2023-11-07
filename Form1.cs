using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // контексное меню
            lblResult.ContextMenuStrip = contextMenuStrip1;
        }
        protected double firstOperand = 0;
        protected char operationSign;
        // блок методов
        private void zeroUp(int num)
        {
            if (lblResult.Text == "0") lblResult.Text = num.ToString();
            else lblResult.Text += num.ToString();
            return;
        }
        // мат.операции
        private void symUp(char a)
        {
            if (firstOperand != 0)
            {
                lblPast.Text = firstOperand.ToString();
                equal("");
                firstOperand = double.Parse(lblResult.Text);
            }
            else firstOperand = double.Parse(lblResult.Text);
            lblResult.Text = "0";
            operationSign = a;
            lblPast.Text = firstOperand + " " + a.ToString();
        }
        // очистка
        private void clearLabels(string type)
        {
            switch (type)
            {
                case "all":
                    lblResult.Text = "0";
                    firstOperand = 0;
                    operationSign = ' ';
                    lblPast.Text = "";
                    break;
                case "main":
                    lblResult.Text = "0";
                    lblPast.Text = "";
                    break;
                case "result":
                    lblResult.Text = "0";
                    break;
                case "none":
                    break;
                case "past":
                    firstOperand = 0;
                    operationSign = ' ';
                    lblPast.Text = "";
                    break;
                default:
                    firstOperand = 0;
                    operationSign = ' ';
                    break;
            }
        }
        // вычисление факториала
        public int calcFactorial(int inputInt)
        {
            int factorial = 1;
            for (int i = 1; i <= inputInt; i++)
                factorial *= i;
            return factorial;
        }
        // вычисления через равно
        private void equal(string clearType = "past")
        {
            double tmp = double.Parse(lblResult.Text);
            if (firstOperand != 0)
                switch (operationSign)
                {
                    case '+':
                        lblPast.Text = firstOperand.ToString() + " + " + tmp.ToString();
                        firstOperand = firstOperand + tmp;
                        lblResult.Text = firstOperand.ToString();
                        clearLabels(clearType);
                        break;
                    case '-':
                        lblPast.Text = firstOperand.ToString() + " - " + tmp.ToString();
                        firstOperand = firstOperand - tmp;
                        lblResult.Text = firstOperand.ToString();
                        clearLabels(clearType);
                        break;
                    case '*':
                        lblPast.Text = firstOperand.ToString() + " * " + tmp.ToString();
                        firstOperand = firstOperand * tmp;
                        lblResult.Text = firstOperand.ToString();
                        clearLabels(clearType);
                        break;
                    case '/':
                        lblPast.Text = firstOperand.ToString() + " / " + tmp.ToString();
                        firstOperand = firstOperand / tmp;
                        lblResult.Text = firstOperand.ToString();
                        clearLabels(clearType);
                        break;
                    case '^':
                        lblPast.Text = firstOperand.ToString() + " ^ " + tmp.ToString();
                        firstOperand = Math.Pow(firstOperand, tmp);
                        lblResult.Text = firstOperand.ToString();
                        clearLabels(clearType);
                        break;
                }
        }
        private void deleteLast()
        {
            if (lblResult.Text.Count() <= 1)
                clearLabels("main");
            else
                lblResult.Text = lblResult.Text.Remove(lblResult.Text.Count() - 1, 1);
        }
        // Конец блока
        // 0
        private void btnNumZero_Click(object sender, EventArgs e)
        {
            zeroUp(0);
        }
        // 1
        private void btnNumOne_Click(object sender, EventArgs e)
        {
            zeroUp(1);
        }
        // 2
        private void btnNumTwo_Click(object sender, EventArgs e)
        {
            zeroUp(2);
        }
        // 3
        private void btnNumThree_Click(object sender, EventArgs e)
        {
            zeroUp(3);
        }
        // 4
        private void btnNumFour_Click(object sender, EventArgs e)
        {
            zeroUp(4);
        }
        // 5
        private void btnNumFive_Click(object sender, EventArgs e)
        {
            zeroUp(5);
        }
        // 6
        private void btnNumSix_Click(object sender, EventArgs e)
        {
            zeroUp(6);
        }
        // 7
        private void btnNumSeven_Click(object sender, EventArgs e)
        {
            zeroUp(7);
        }
        // 8
        private void btnNumEight_Click(object sender, EventArgs e)
        {
            zeroUp(8);
        }
        // 9
        private void btnNumNine_Click(object sender, EventArgs e)
        {
            zeroUp(9);
        }
        // преобразование за 0
        private void btnNumPM_Click(object sender, EventArgs e)
        {
            if (lblResult.Text != "0")
                if (lblResult.Text.Contains("-"))
                    lblResult.Text = lblResult.Text.Remove(0, 1);
                else
                    lblResult.Text = lblResult.Text.Insert(0, "-");
        }
        // сложение
        protected void btnPlus_Click(object sender, EventArgs e)
        {
            symUp('+');
        }
        // вычитание
        private void btnMinus_Click(object sender, EventArgs e)
        {
            symUp('-');
        }
        // умножение
        private void btnMult_Click(object sender, EventArgs e)
        {
            symUp('*');
        }
        // деление
        private void btnDiv_Click(object sender, EventArgs e)
        {
            symUp('/');
        }
        // точка
        protected void btnNumComma_Click(object sender, EventArgs e)
        {
            if (!lblResult.Text.Contains(",")) lblResult.Text += ",";
        }
        // вычисление
        protected void btnEquals_Click(object sender, EventArgs e)
        {
            equal("");            
        }
        
        // удаление последнего введённой цифры
        private void btnDeleteLast_Click(object sender, EventArgs e)
        {
            deleteLast();
        }
        // полная очистка
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearLabels("all");
        }
        // очистка "главного" окна
        private void btnClearResult_Click(object sender, EventArgs e)
        {
            clearLabels("main");
        }

        // квадрат
        private void btnSQR_Click(object sender, EventArgs e)
        {
            if (btnSQRX.Text == "x^2")
                lblResult.Text = (Math.Pow(double.Parse(lblResult.Text), 2)).ToString();
            else
            {
                firstOperand = double.Parse(lblResult.Text);
                operationSign = '^';
                lblPast.Text = firstOperand.ToString() + " ^ ";
                clearLabels("result");
            }
        }
        // корень квадратный
        private void btnSQRT_Click(object sender, EventArgs e)
        {
            if (btnSQRT.Text == "√")
            {
                lblPast.Text = "√" + lblResult.Text;
                lblResult.Text = Math.Sqrt(double.Parse(lblResult.Text)).ToString();
            }
            else
            {
                lblPast.Text = "∛" + lblResult.Text;
                lblResult.Text = Math.Pow(double.Parse(lblResult.Text), 1.0/3.0).ToString();
            }
        }

        // ввод с клавиатуры
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    zeroUp(0);
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    zeroUp(1);
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    zeroUp(2);
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    zeroUp(3);
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    zeroUp(4);
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    zeroUp(5);
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    zeroUp(6);
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    zeroUp(7);
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    zeroUp(8);
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    zeroUp(9);
                    break;
                case Keys.Add:
                case Keys.Oemplus:
                    symUp('+');
                    break;
                case Keys.Subtract:
                case Keys.OemMinus:
                    symUp('-');
                    break;
                case Keys.Multiply:
                    symUp('*');
                    break;
                case Keys.Divide:
                    symUp('/');
                    break;
                case Keys.Enter:
                    equal("");
                    break;
                case Keys.Oemcomma:
                case Keys.Decimal:
                    if (!lblResult.Text.Contains(",")) lblResult.Text += ",";
                    break;
                case Keys.Delete:
                    clearLabels("all");
                    break;
                case Keys.Back:
                    deleteLast();
                    break;
            }
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (toolMenuCopy.Pressed)
            {
                Clipboard.SetText(lblResult.Text);
            }
            else if (toolMenuPaste.Pressed)
            {
                lblResult.Text = Clipboard.GetText();
            }
        }
        private void btnReverseFact_Click(object sender, EventArgs e)
        {
            // факториал
            if (btnReverseFact.Text == "x!")
            {
                if (!lblResult.Text.Contains('-') && !lblResult.Text.Contains(','))
                {
                    int tmpF = int.Parse(lblResult.Text);
                    if (tmpF == 0 && tmpF < 20) lblResult.Text = "1";
                    else
                    {
                        if (tmpF > 0 && tmpF < 20)
                        {
                            if (firstOperand == 0)
                            {
                                lblResult.Text = calcFactorial(tmpF).ToString();
                                lblPast.Text = (tmpF + "! =").ToString();
                            }
                            else lblResult.Text = calcFactorial(tmpF).ToString();
                        }
                        else lblResult.Text = "too much";
                    }
                }
                else lblResult.Text = "null";
            }
            else // 1/x
            {
                lblResult.Text = (1 / double.Parse(lblResult.Text)).ToString();
            }
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            if (btnSecond.BackColor == SystemColors.Control)
            {
                btnSQRT.Text = "∛";
                btnSQRX.Text = "x^y";
                btnReverseFact.Text = "x!";
                btnSecond.BackColor = SystemColors.ActiveCaption;
            }
            else
            {
                btnSQRT.Text = "√";
                btnSQRX.Text = "x^2";
                btnReverseFact.Text = "1/x";
                btnSecond.BackColor = SystemColors.Control;
            }
            
        }
    }
}
