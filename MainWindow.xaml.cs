using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool opFlag = false;
        private double memory;
        private double savedValue;
        private string op;

        private void Btn_Click(object sender, RoutedEventArgs e) 
        {
            Button btn = sender as Button;
            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = btn.Content.ToString();
                opFlag = false;
            }
            else
            {
                txtResult.Text += btn.Content.ToString();
            }
        }

        private void MC_Click(object sender, RoutedEventArgs e)
        {
            btnMR.IsEnabled = false;//IsEnabled 요소 사용 가능 여부. false사용안함
            btnMC.IsEnabled = false;
            memory = 0;
            memDisp.Text="";
        }

        private void MR_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = memory.ToString();
        }
        
        private void MS_Click(object sender, RoutedEventArgs e)
        {
            memory = Double.Parse(txtResult.Text);
            memDisp.Text = "M";
            btnMR.IsEnabled = true;
            btnMC.IsEnabled = true;
        }

        private void Mplus_Click(object sender, RoutedEventArgs e)
        {
            memDisp.Text = "M";
            btnMR.IsEnabled = true;
            btnMC.IsEnabled = true;
            opFlag = true;
            memory += double.Parse(txtResult.Text);
        }

        private void Mmius_Click(object sender, RoutedEventArgs e)
        {
            memDisp.Text = "M";
            btnMR.IsEnabled = true;
            btnMC.IsEnabled = true;
            opFlag = true;
            memory -= double.Parse(txtResult.Text);
        }

        //CE 처리기
        //txtResult의 숫자만 없앰
        private void CE_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "0";
        }


        //C처리기
        //수식을 다 없앰
        private void C_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "0";
            savedValue = 0;
            if (opFlag == true)
                opFlag = false;
            expDisp.Text = "";

        }


        //±처리기
        private void PM_Click(object sender, RoutedEventArgs e)
        {
            if (opFlag == false)
            {
                txtResult.Text = (Double.Parse(txtResult.Text)).ToString();
            }
        }

        //√처리기
        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            expDisp.Text = "√(" + txtResult + ")";
            txtResult.Text = (Math.Sqrt(double.Parse(txtResult.Text))).ToString();
        }

        //1/x처리기
        private void Reci_Click(object sender, RoutedEventArgs e)
        {
            expDisp.Text = "1/(" + txtResult + ")";
            txtResult.Text = (1 / double.Parse(txtResult.Text)).ToString();
        }

        private void op_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            op = btn.Content.ToString();
            expDisp.Text = txtResult.Text + btn.Content;
            savedValue = Double.Parse(txtResult.Text);
            opFlag = true;
        }


        //소수점 처리기
        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text.Contains(".") == false)
                txtResult.Text += ".";

        }


        private void result_Click(object sender, RoutedEventArgs e)
        {
            expDisp.Text += txtResult.Text;
            switch (op)
            {
                case "+":
                    txtResult.Text = (savedValue + Double.Parse(txtResult.Text)).ToString();
                    break;
                case "-":
                    txtResult.Text = (savedValue - Double.Parse(txtResult.Text)).ToString();
                    break;
                case "X":
                    txtResult.Text = (savedValue * Double.Parse(txtResult.Text)).ToString();
                    break;
                case "/":
                    txtResult.Text = (savedValue / Double.Parse(txtResult.Text)).ToString();
                    break;
            }
        }

        //BackSpace 처리기
        private void BS_Click(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text == "0" || opFlag == true)
                return;
            var s = txtResult.Text.Remove(txtResult.Text.Length - 1);
            if (s.Length == 0)
                txtResult.Text = "0";
            else
                txtResult.Text = s;
        }

        //%처리기
        private void Per_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = (double.Parse(txtResult.Text) / savedValue).ToString();
            expDisp.Text += txtResult.Text;
        }
    }
}
