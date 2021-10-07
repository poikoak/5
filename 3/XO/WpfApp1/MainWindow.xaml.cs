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

namespace WpfApp1
{
   
    public partial class MainWindow : Window
    {   
        #region Variables
        Random rand = new Random();
        int[,] Matrix = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        bool mode = true;
        int x = 0;
        int y = 0;
        int user = 0;
        #endregion

        #region Start
        public MainWindow()
        {
            InitializeComponent();

        }

        #endregion

        #region Click


        int UserClick(object sender, MouseButtonEventArgs e)
        {
            int columnNumber = 0;
            int rowNumber = 0;          
            Point mousePos = e.GetPosition(field);
            double width = 0;
            for (int i = 0; i < field.ColumnDefinitions.Count; i++)
            {
                width += field.ColumnDefinitions[i].ActualWidth;
                if (width > mousePos.X)
                {
                    columnNumber = i;
                    break;
                }
            }         
            double height = 0;
            for (int i = 0; i < field.RowDefinitions.Count; i++)
            {
                height += field.RowDefinitions[i].ActualHeight;
                if (height > mousePos.Y)
                {
                    rowNumber = i;
                    break;
                }
            }
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"/Reference/Krest.png", UriKind.Relative));
            if (Matrix[rowNumber, columnNumber] != 1 && Matrix[rowNumber, columnNumber] != 2)
            {
                Grid.SetColumn(image, columnNumber);
                Grid.SetRow(image, rowNumber);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                Matrix[rowNumber, columnNumber] = 1;
                return 1;
            }
            else
            {
                return 0;
            }

        }
        private void field_MouseDown(object sender, MouseButtonEventArgs e)
        {
            user = UserClick(sender, e);
            if (user == 1)
            {
                user = 0;
                x = Win(Matrix);
                if (x == 1)
                {
                    RestartGame();
                    x = 0;
                    y = 0;
                    return;
                }
                BotClik(Matrix);
                y = LoseGame(Matrix);
                if (y == 1)
                {
                    RestartGame();
                }
                int draw = Draw(Matrix);
                if (draw == 1 && x == 0 && y == 0)
                {
                    MessageBox.Show("It's a tie");
                    RestartGame();
                }
            }
        }
        #endregion

        void RestartGame()
        {
            this.field.Children.Clear();
            this.Matrix = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        #region Chekers

       
        int Win(int[,] Matrix)
        {
            if (Matrix[0, 0] == 1 && Matrix[1, 1] == 1 && Matrix[2, 2] == 1)
            {
                MessageBox.Show($"You win");
                return 1;

            }
            if (Matrix[2, 0] == 1 && Matrix[1, 1] == 1 && Matrix[0, 2] == 1)
            {
                MessageBox.Show($"You win");

                return 1;
            }
            if (Matrix[0, 0] == 1 && Matrix[0, 1] == 1 && Matrix[0, 2] == 1)
            {
                MessageBox.Show($"You win");

                return 1;

            }
            if (Matrix[1, 0] == 1 && Matrix[1, 1] == 1 && Matrix[1, 2] == 1)
            {
                MessageBox.Show($"You win");

                return 1;

            }
            if (Matrix[2, 0] == 1 && Matrix[2, 1] == 1 && Matrix[2, 2] == 1)
            {
                MessageBox.Show($"You win");

                return 1;

            }
            if (Matrix[0, 0] == 1 && Matrix[1, 0] == 1 && Matrix[2, 0] == 1)
            {
                MessageBox.Show($"You win");

                return 1;

            }
            if (Matrix[0, 1] == 1 && Matrix[1, 1] == 1 && Matrix[2, 1] == 1)
            {
                MessageBox.Show($"You win");

                return 1;

            }
            if (Matrix[0, 2] == 1 && Matrix[1, 2] == 1 && Matrix[2, 2] == 1)
            {
                MessageBox.Show($"You win");
                return 1;

            }
            else
            {
                return 0;
            }
        }

        int LoseGame(int[,] Matrix)
        {
            if (Matrix[0, 0] == 2 && Matrix[1, 1] == 2 && Matrix[2, 2] == 2)
            {
                MessageBox.Show($"You lose");
                return 1;
            }
            if (Matrix[2, 0] == 2 && Matrix[1, 1] == 2 && Matrix[0, 2] == 2)
            {
                MessageBox.Show($"You lose");
                return 1;
            }
         


            if (Matrix[0, 1] == 2 && Matrix[0, 2] == 2 && Matrix[0, 0] == 2)
            {
                MessageBox.Show($"You lose");
                return 1;
            }
            if (Matrix[1, 1] == 2 && Matrix[1, 2] == 2 && Matrix[1, 0] == 2)
            {
                MessageBox.Show($"You lose");
                return 1;
            }
            if (Matrix[2, 1] == 2 && Matrix[2, 2] == 2 && Matrix[2, 0] == 2)
            {
                MessageBox.Show($"You lose");
                return 1;
            }
            

            if (Matrix[0, 0] == 2 && Matrix[1, 0] == 2 && Matrix[2, 0] == 2)
            {
                MessageBox.Show($"You lose");
                return 1;
            }
            if (Matrix[0, 1] == 2 && Matrix[1, 1] == 2 && Matrix[2, 1] == 2)
            {
                MessageBox.Show($"You lose");
                return 1;
            }
            if (Matrix[0, 2] == 2 && Matrix[1, 2] == 2 && Matrix[2, 2] == 2)
            {
                MessageBox.Show($"You lose");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        void BotClik(int[,] Matrix)
        {

            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"\Reference\Nol.png", UriKind.Relative));
            if (Matrix[2, 0] == 2 && Matrix[1, 1] == 2 && Matrix[0, 2] == 0)
            {
                this.Matrix[0, 2] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 2);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[2, 0] == 2 && Matrix[2, 2] == 2 && Matrix[2, 1] == 0)
            {
                this.Matrix[2, 1] = 2;
                Grid.SetRow(image, 2);
                Grid.SetColumn(image, 1);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[0, 2] == 1 && Matrix[1, 2] == 1 && Matrix[2, 2] == 0)
            {
                this.Matrix[2, 2] = 2;
                Grid.SetRow(image, 2);
                Grid.SetColumn(image, 2);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[0, 0] == 1 && Matrix[0, 2] == 1 && Matrix[0, 1] == 0)
            {
                this.Matrix[0, 1] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 1);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[0, 0] == 1 && Matrix[0, 1] == 1 && Matrix[0, 2] == 0)
            {
                this.Matrix[0, 2] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 2);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[0, 0] == 1 && Matrix[1, 0] == 1 && Matrix[2, 0] == 0)
            {
                this.Matrix[2, 0] = 2;
                Grid.SetRow(image, 2);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[2, 0] == 1 && Matrix[2, 2] == 1 && Matrix[2, 1] == 0)
            {
                this.Matrix[2, 1] = 2;
                Grid.SetRow(image, 2);
                Grid.SetColumn(image, 1);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[1, 1] == 2 && Matrix[2, 2] == 2 && Matrix[0, 0] == 0)
            {
                this.Matrix[0, 0] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[1, 1] == 2 && Matrix[2, 1] == 2 && Matrix[0, 0] == 0)
            {
                this.Matrix[0, 0] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[1, 1] == 1 && Matrix[1, 2] == 1 && Matrix[1, 0] == 0)
            {
                this.Matrix[1, 0] = 2;
                Grid.SetRow(image, 1);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[1, 1] == 1 && Matrix[1, 0] == 1 && Matrix[1, 2] == 0)
            {
                this.Matrix[1, 2] = 2;
                Grid.SetRow(image, 1);
                Grid.SetColumn(image, 2);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[0, 1] == 1 && Matrix[1, 1] == 1 && Matrix[2, 1] == 0)
            {
                this.Matrix[2, 1] = 2;
                Grid.SetRow(image, 2);
                Grid.SetColumn(image, 1);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[2, 0] == 2 && Matrix[2, 2] == 2 && Matrix[2, 1] == 0)
            {
                this.Matrix[2, 1] = 2;
                Grid.SetRow(image, 2);
                Grid.SetColumn(image, 1);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }

            if (Matrix[0, 0] == 1 && Matrix[2, 0] == 1 && Matrix[1, 0] == 0)
            {
                this.Matrix[1, 0] = 2;
                Grid.SetRow(image, 1);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[1, 1] == 1 && Matrix[2, 0] == 1 && Matrix[0, 2] == 0)
            {
                this.Matrix[0, 2] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 2);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[1, 1] == 1 && Matrix[2, 1] == 1 && Matrix[0, 1] == 0)
            {
                this.Matrix[0, 1] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 1);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[0, 0] == 1 && Matrix[2, 0] == 2 && Matrix[1, 0] == 0)
            {
                this.Matrix[1, 0] = 2;
                Grid.SetRow(image, 1);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[0, 0] == 0 && Matrix[1, 0] != 0 && Matrix[2, 0] != 0 && Matrix[0, 1] == 0)
            {
                this.Matrix[0, 0] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[1, 1] == 1 && Matrix[2, 2] == 2 && Matrix[2, 0] == 0)
            {
                this.Matrix[2, 0] = 2;
                Grid.SetRow(image, 2);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[0, 1] != 0 && Matrix[1, 1] != 0 && Matrix[2, 1] != 0 && Matrix[2, 0] != 0 && Matrix[2, 1] != 0 && Matrix[2, 2] != 0 &&
                Matrix[0, 0] == 0)
            {
                this.Matrix[0, 0] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[0, 0] == 1 && Matrix[1, 0] == 0 && Matrix[1, 1] != 0)
            {
                this.Matrix[1, 0] = 2;
                Grid.SetRow(image, 1);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[1, 1] == 2 && Matrix[0, 1] == 0 && Matrix[2, 1] == 0)
            {
                this.Matrix[0, 1] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 1);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[0, 0] != 0 && Matrix[1, 0] != 0 && Matrix[2, 0] == 0)
            {
                this.Matrix[2, 0] = 2;
                Grid.SetRow(image, 2);
                Grid.SetColumn(image, 0);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            if (Matrix[1, 1] != 0 && Matrix[2, 1] != 0 && Matrix[0, 1] == 0)
            {
                this.Matrix[0, 1] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 1);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            }
            for (int i = 0; i < 3; i++)
            {

                if (Matrix[0, i] == 2 && Matrix[1, i] == 2 && Matrix[2, i] == 0)
                {
                    this.Matrix[2, i] = 2;
                    Grid.SetRow(image, 2);
                    Grid.SetColumn(image, i);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

                if (Matrix[0, i] == 0 && Matrix[1, i] == 2 && Matrix[2, i] == 2)
                {
                    this.Matrix[0, i] = 2;
                    Grid.SetRow(image, 0);
                    Grid.SetColumn(image, i);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

                if (Matrix[0, i] == 2 && Matrix[1, i] == 0 && Matrix[2, i] == 2)
                {
                    this.Matrix[1, i] = 2;
                    Grid.SetRow(image, 1);
                    Grid.SetColumn(image, i);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

            }

            for (int i = 0; i < 3; i++)
            {
                if (Matrix[i, 0] == 2 && Matrix[i, 1] == 2 && Matrix[i, 2] == 0)
                {
                    this.Matrix[i, 2] = 2;
                    Grid.SetRow(image, i);
                    Grid.SetColumn(image, 2);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

                if (Matrix[i, 0] == 0 && Matrix[i, 1] == 2 && Matrix[i, 2] == 2)
                {
                    this.Matrix[i, 0] = 2;
                    Grid.SetRow(image, i);
                    Grid.SetColumn(image, 0);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

                if (Matrix[i, 0] == 2 && Matrix[i, 1] == 0 && Matrix[i, 2] == 2)
                {
                    this.Matrix[i, 1] = 2;
                    Grid.SetRow(image, i);
                    Grid.SetColumn(image, 1);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

            }
            for (int i = 0; i < 3; i++)
            {
                if (Matrix[0, i] == 1 && Matrix[1, i] == 1 && Matrix[2, i] == 0)
                {
                    this.Matrix[2, i] = 2;
                    Grid.SetRow(image, 2);
                    Grid.SetColumn(image, i);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

                if (Matrix[2, i] == 0 && Matrix[1, i] == 1 && Matrix[2, i] == 1)
                {
                    this.Matrix[0, i] = 2;
                    Grid.SetRow(image, 0);
                    Grid.SetColumn(image, i);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

                if (Matrix[0, i] == 1 && Matrix[1, i] == 0 && Matrix[2, i] == 1)
                {
                    this.Matrix[1, i] = 2;
                    Grid.SetRow(image, 1);
                    Grid.SetColumn(image, i);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

            }
            for (int i = 0; i < 3; i++)
            {
                if (Matrix[i, 0] == 1 && Matrix[i, 1] == 1 && Matrix[i, 2] == 0)
                {
                    this.Matrix[i, 2] = 2;
                    Grid.SetRow(image, i);
                    Grid.SetColumn(image, 2);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

                if (Matrix[i, 0] == 0 && Matrix[i, 1] == 1 && Matrix[i, 2] == 1)
                {
                    this.Matrix[i, 0] = 2;
                    Grid.SetRow(image, i);
                    Grid.SetColumn(image, 0);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

                if (Matrix[i, 0] == 1 && Matrix[i, 1] == 0 && Matrix[i, 2] == 1)
                {
                    this.Matrix[i, 1] = 2;
                    Grid.SetRow(image, i);
                    Grid.SetColumn(image, 1);
                    field.Children.Add(image);
                    Panel.SetZIndex(image, 3);
                    return;
                }

            }

            if (Matrix[1, 1] == 1 && Matrix[2, 1] == 1 && Matrix[0, 2] == 0)
            {
                this.Matrix[0, 2] = 2;
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 2);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            };

            if (Matrix[0, 1] == 0 && Matrix[1, 1] == 1 && Matrix[2, 1] == 0 && Matrix[0, 0] == 1)
            {
                this.Matrix[2, 1] = 2;
                Grid.SetRow(image, 2);
                Grid.SetColumn(image, 1);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            };

            if (Matrix[1, 1] == 0)
            {
                this.Matrix[1, 1] = 2;
                Grid.SetRow(image, 1);
                Grid.SetColumn(image, 1);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            };

           
            if (Matrix[2, 2] == 0)
            {
                this.Matrix[2, 2] = 2;
                Grid.SetRow(image, 2);
                Grid.SetColumn(image, 2);
                field.Children.Add(image);
                Panel.SetZIndex(image, 3);
                return;
            };

        }

        int Draw(int[,] Matrix)
        {
            if (Matrix[0, 0] * Matrix[0, 1] * Matrix[0, 2] * Matrix[1, 0] * Matrix[1, 1] * Matrix[1, 2] * Matrix[2, 0] * Matrix[2, 1] * Matrix[2, 2] == 16)
            {
                this.Matrix = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
                return 1;
            }
            return 0;
        }
        #endregion
    }
}
