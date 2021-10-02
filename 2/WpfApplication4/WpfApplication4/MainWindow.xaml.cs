using System;
using System.Windows;
using System.Windows.Controls;


namespace FirstWpfApp
{
    public partial class MainWindow : Window
    {
        string leftop = ""; // Левый операнд
        string operation = ""; // Знак операции
        string rightop = ""; // Правый операнд

        public MainWindow()
        {
            InitializeComponent();
            // Добавляем обработчик для всех кнопок на гриде
            foreach (UIElement c in LayoutRoot.Children) // LayoutRoot это имя Grid
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текст кнопки
            string s = (string)((Button)e.OriginalSource).Content;
            // Добавляем его в текстовое поле
            textBlock.Text += s;

            int num;
            // Пытаемся преобразовать его в число
            bool result = Int32.TryParse(s, out num);
            // Если текст - это число
            if (result == true|s==",")
            {
                // Если операция не задана
                if (operation == "")
                {
                    // Добавляем к левому операнду
                    leftop += s;
                }
                else
                {
                    // Иначе к правому операнду
                    rightop += s;
                }
            }
            // Если было введено не число
            else
            {
                // Если равно, то выводим результат операции
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text = "";
                    textBlock.Text += rightop;
                    operation = "";
                }
                // Очищаем поле и переменные
                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else if (s == "SQRT" & leftop != "")
                {
                    if (leftop.Contains(","))
                    {
                        double numd1 = Double.Parse(leftop);
                        double result1 = Math.Sqrt(numd1);
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                    else
                    {
                        int num1 = Int32.Parse(leftop);
                        double result1 = Math.Sqrt(num1);
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                }
                else if (s == "x^2" & leftop != "")
                {
                    if (leftop.Contains(","))
                    {
                        double numd1 = Double.Parse(leftop);
                        double result1 = numd1*numd1;
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                    else
                    {
                        int num1 = Int32.Parse(leftop);
                        double result1 = num1*num1;
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                }
                else if (s == "1/x" & leftop != "")
                {
                    if (leftop.Contains(","))
                    {
                        double numd1 = Double.Parse(leftop);
                        double result1 = 1/ numd1;
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                    else
                    {
                        int num1 = Int32.Parse(leftop);
                        double result1 = 1/num1;
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                }
                // Получаем операцию
                else
                {
                    // Если правый операнд уже имеется, то присваиваем его значение левому
                    // операнду, а правый операнд очищаем
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }
        // Обновляем значение правого операнда
        private void Update_RightOp()
        {
            int num1=0;
            int num2=0;
            double numd1=0;
            double numd2=0;
            MessageBox.Show(leftop);
            MessageBox.Show(rightop);
            if (leftop.Contains(","))
            {
                
                numd1 = Double.Parse(leftop);
            }
            else  num1 = Int32.Parse(leftop); 

            if (rightop.Contains(","))
            {
                
                numd2 = Double.Parse(rightop);
            }
            else num2 = Int32.Parse(rightop);
            // И выполняем операцию
            switch (operation)
            {
                case "+":
                    if (leftop.Contains(",") & rightop.Contains(","))
                    { rightop = (numd1 + numd2).ToString(); }
                    else if(leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (numd1 + (double)num2).ToString(); }
                    else if (!leftop.Contains(",") & rightop.Contains(","))
                    { rightop = ((double)num1 + numd2).ToString(); }
                    else if (!leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (num1 + num2).ToString(); }
                    break;
                case "-":
                    if (leftop.Contains(",") & rightop.Contains(","))
                    { rightop = (numd1 -numd2).ToString(); }
                    else if (leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (numd1 - (double)num2).ToString(); }
                    else if (!leftop.Contains(",") & rightop.Contains(","))
                    { rightop = ((double)num1 -numd2).ToString(); }
                    else if (!leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (num1 - num2).ToString(); }
                    break;
                case "*":
                    if (leftop.Contains(",") & rightop.Contains(","))
                    { rightop = (numd1 *numd2).ToString(); }
                    else if (leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (numd1 * (double)num2).ToString(); }
                    else if (!leftop.Contains(",") & rightop.Contains(","))
                    { rightop = ((double)num1 * numd2).ToString(); }
                    else if (!leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (num1 * num2).ToString(); }
                    break;
                case "/":
                    if (leftop.Contains(",") & rightop.Contains(","))
                    { rightop = (numd1 / numd2).ToString(); }
                    else if (leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (numd1 / (double)num2).ToString(); }
                    else if (!leftop.Contains(",") & rightop.Contains(","))
                    { rightop = ((double)num1 / numd2).ToString(); }
                    else if (!leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (num1 / num2).ToString(); }
                    break;
            }
        }
    }
}