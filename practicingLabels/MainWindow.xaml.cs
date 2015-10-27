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
using System.Windows.Media.Animation;
using System.Timers;

namespace practicingLabels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StringBuilder builder;
        public bool inAnimation = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string pressed = "";
            // KEY DOWN! IN ANIMATION!
            if (inAnimation == true)
            {
                //First, handlers for diagonals.
                if (e.Key == Key.Down || e.Key == Key.S)
                {
                    Storyboard sb = this.FindResource("joyDown") as Storyboard;
                    sb.Begin();
                    pressed = "down";
                    if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                    {
                        pressed = "downright";
                    }
                    else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                    {
                        pressed = "downleft";
                    }
                }
                else if (e.Key == Key.Right || e.Key == Key.D)
                {
                    Storyboard sb = this.FindResource("joyRight") as Storyboard;
                    sb.Begin();
                    pressed = "right";
                    if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    {
                        pressed = "upright";
                    }
                    else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    {
                        pressed = "downright";
                    }
                }
                else if (e.Key == Key.Left || e.Key == Key.A)
                {
                    Storyboard sb = this.FindResource("joyLeft") as Storyboard;
                    sb.Begin();
                    pressed = "left";
                    if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    {
                        pressed = "upleft";
                    }
                    else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    {
                        pressed = "downleft";
                    }
                }
                else if (e.Key == Key.Up || e.Key == Key.W)
                {
                    Storyboard sb = this.FindResource("joyUp") as Storyboard;
                    sb.Begin();
                    pressed = "up";
                    if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                    {
                        pressed = "upright";
                    }
                    else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                    {
                        pressed = "upleft";
                    }
                }
                else if (e.Key == Key.U)
                {
                    Storyboard sb = this.FindResource("pushButton1") as Storyboard;
                    sb.Begin();
                    pressed = "1";
                }
                else if (e.Key == Key.I)
                {
                    Storyboard sb = this.FindResource("pushButton2") as Storyboard;
                    sb.Begin();
                    pressed = "2";
                }
                else if (e.Key == Key.O)
                {
                    Storyboard sb = this.FindResource("pressButton3") as Storyboard;
                    sb.Begin();
                    pressed = "3";
                }
                else if (e.Key == Key.J)
                {
                    Storyboard sb = this.FindResource("pressButton4") as Storyboard;
                    sb.Begin();
                    pressed = "4";
                }
                else if (e.Key == Key.K)
                {
                    Storyboard sb = this.FindResource("pressButton5") as Storyboard;
                    sb.Begin();
                    pressed = "5";
                }
                else if (e.Key == Key.L)
                {
                    Storyboard sb = this.FindResource("pressButton6") as Storyboard;
                    sb.Begin();
                    pressed = "6";
                }
            }
            // KEY DOWN! OUT OF ANIMATION!
            else
            {
                //First, handlers for diagonals.
                if (e.Key == Key.Down || e.Key == Key.S)
                {
                    Storyboard sb = this.FindResource("joyDown") as Storyboard;
                    sb.Begin();
                    Storyboard ryu = this.FindResource("crouch") as Storyboard;
                    ryu.Begin();
                    pressed = "down";
                    if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                    {
                        pressed = "downright";
                    }
                    else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                    {
                        pressed = "downleft";
                    }
                }
                else if (e.Key == Key.Right || e.Key == Key.D)
                {
                    Storyboard sb = this.FindResource("joyRight") as Storyboard;
                    sb.Begin();
                    Storyboard ryu = this.FindResource("walkF") as Storyboard;
                    ryu.Begin();
                    pressed = "right";
                    if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    {
                        pressed = "upright";
                        Storyboard alt = this.FindResource("jumpF") as Storyboard;
                        alt.Begin();
                        Jump("jumpF");
                    }
                    else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    {
                        pressed = "downright";
                        Storyboard alt = this.FindResource("crouch") as Storyboard;
                        alt.Begin();
                    }
                }
                else if (e.Key == Key.Left || e.Key == Key.A)
                {
                    Storyboard sb = this.FindResource("joyLeft") as Storyboard;
                    sb.Begin();
                    Storyboard ryu = this.FindResource("walkB") as Storyboard;
                    ryu.Begin();
                    pressed = "left";
                    if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    {
                        pressed = "upleft";
                        Storyboard alt = this.FindResource("jumpB") as Storyboard;
                        alt.Begin();
                        Jump("jumpB");
                    }
                    else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    {
                        pressed = "downleft";
                        Storyboard alt = this.FindResource("crouch") as Storyboard;
                        alt.Begin();
                    }
                }
                else if (e.Key == Key.Up || e.Key == Key.W)
                {
                    Storyboard sb = this.FindResource("joyUp") as Storyboard;
                    sb.Begin();
                    Storyboard ryu = this.FindResource("jumpN") as Storyboard;
                    ryu.Begin();
                    Jump("jumpN");
                    pressed = "up";
                    if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                    {
                        pressed = "upright";
                        Storyboard alt = this.FindResource("jumpF") as Storyboard;
                        alt.Begin();
                        Jump("jumpF");
                    }
                    else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                    {
                        pressed = "upleft";
                        Storyboard alt = this.FindResource("jumpB") as Storyboard;
                        alt.Begin();
                        Jump("jumpB");
                    }
                }
                else if (e.Key == Key.U)
                {
                    Storyboard sb = this.FindResource("pushButton1") as Storyboard;
                    sb.Begin();
                    pressed = "1";
                }
                else if (e.Key == Key.I)
                {
                    Storyboard sb = this.FindResource("pushButton2") as Storyboard;
                    sb.Begin();
                    pressed = "2";
                }
                else if (e.Key == Key.O)
                {
                    Storyboard sb = this.FindResource("pressButton3") as Storyboard;
                    sb.Begin();
                    pressed = "3";
                }
                else if (e.Key == Key.J)
                {
                    Storyboard sb = this.FindResource("pressButton4") as Storyboard;
                    sb.Begin();
                    pressed = "4";
                }
                else if (e.Key == Key.K)
                {
                    Storyboard sb = this.FindResource("pressButton5") as Storyboard;
                    sb.Begin();
                    pressed = "5";
                }
                else if (e.Key == Key.L)
                {
                    Storyboard sb = this.FindResource("pressButton6") as Storyboard;
                    sb.Begin();
                    pressed = "6";
                }
            }

            int len = inputs.Text.Length;
            string theList = AddToList(pressed);
            inputs.Text += theList;
            CleanUp();
        }

        public void Window_KeyUp(object sender, KeyEventArgs e)
        {
            string pressed = "";

            // KEY UP! IN ANIMATION!
            if (inAnimation == true)
            {
                //These have to contain conditionals to write the end direction on a quarter circle.
                if (e.Key == Key.Down || e.Key == Key.S)
                {
                    Storyboard sb = this.FindResource("joyDown") as Storyboard;
                    sb.Stop();
                    if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                    {
                        pressed = "right";
                    }
                    else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                    {
                        pressed = "left";
                    }
                }
                else if (e.Key == Key.Right || e.Key == Key.D)
                {
                    Storyboard sb = this.FindResource("joyRight") as Storyboard;
                    sb.Stop();
                    if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    {
                        pressed = "up";
                    }
                    else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    {
                        pressed = "down";
                    }
                }
                else if (e.Key == Key.Left || e.Key == Key.A)
                {
                    Storyboard sb = this.FindResource("joyLeft") as Storyboard;
                    sb.Stop();
                    if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    {
                        pressed = "up";
                    }
                    else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    {
                        pressed = "down";
                    }
                }
                else if (e.Key == Key.Up || e.Key == Key.W)
                {
                    Storyboard sb = this.FindResource("joyUp") as Storyboard;
                    sb.Stop();
                    if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                    {
                        pressed = "right";
                    }
                    else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                    {
                        pressed = "left";
                    }
                }
                else if (e.Key == Key.U)
                {
                    Storyboard sb = this.FindResource("pushButton1") as Storyboard;
                    sb.Stop();
                }
                else if (e.Key == Key.I)
                {
                    Storyboard sb = this.FindResource("pushButton2") as Storyboard;
                    sb.Stop();
                }
                else if (e.Key == Key.O)
                {
                    Storyboard sb = this.FindResource("pressButton3") as Storyboard;
                    sb.Stop();
                }
                else if (e.Key == Key.J)
                {
                    Storyboard sb = this.FindResource("pressButton4") as Storyboard;
                    sb.Stop();
                }
                else if (e.Key == Key.K)
                {
                    Storyboard sb = this.FindResource("pressButton5") as Storyboard;
                    sb.Stop();
                }
                else if (e.Key == Key.L)
                {
                    Storyboard sb = this.FindResource("pressButton6") as Storyboard;
                    sb.Stop();
                }
            }
            // KEY UP! OUT OF ANIMATION!
            else
            {
                //These have to contain conditionals to write the end direction on a quarter circle.
                if (e.Key == Key.Down || e.Key == Key.S)
                {
                    Storyboard sb = this.FindResource("joyDown") as Storyboard;
                    sb.Stop();
                    Storyboard ryu = this.FindResource("crouch") as Storyboard;
                    ryu.Stop();
                    if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                    {
                        pressed = "right";
                        Storyboard alt = this.FindResource("walkF") as Storyboard;
                        alt.Begin();
                    }
                    else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                    {
                        pressed = "left";
                        Storyboard alt = this.FindResource("walkB") as Storyboard;
                        alt.Begin();
                    }
                }
                else if (e.Key == Key.Right || e.Key == Key.D)
                {
                    Storyboard sb = this.FindResource("joyRight") as Storyboard;
                    sb.Stop();
                    Storyboard ryu = this.FindResource("walkF") as Storyboard;
                    ryu.Stop();
                    if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    {
                        pressed = "up";
                    }
                    else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    {
                        pressed = "down";
                    }
                }
                else if (e.Key == Key.Left || e.Key == Key.A)
                {
                    Storyboard sb = this.FindResource("joyLeft") as Storyboard;
                    sb.Stop();
                    Storyboard ryu = this.FindResource("walkB") as Storyboard;
                    ryu.Stop();
                    if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    {
                        pressed = "up";
                    }
                    else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    {
                        pressed = "down";
                    }
                }
                else if (e.Key == Key.Up || e.Key == Key.W)
                {
                    Storyboard sb = this.FindResource("joyUp") as Storyboard;
                    sb.Stop();
                    if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                    {
                        pressed = "right";
                    }
                    else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                    {
                        pressed = "left";
                    }
                }
                else if (e.Key == Key.U)
                {
                    Storyboard sb = this.FindResource("pushButton1") as Storyboard;
                    sb.Stop();
                }
                else if (e.Key == Key.I)
                {
                    Storyboard sb = this.FindResource("pushButton2") as Storyboard;
                    sb.Stop();
                }
                else if (e.Key == Key.O)
                {
                    Storyboard sb = this.FindResource("pressButton3") as Storyboard;
                    sb.Stop();
                }
                else if (e.Key == Key.J)
                {
                    Storyboard sb = this.FindResource("pressButton4") as Storyboard;
                    sb.Stop();
                }
                else if (e.Key == Key.K)
                {
                    Storyboard sb = this.FindResource("pressButton5") as Storyboard;
                    sb.Stop();
                }
                else if (e.Key == Key.L)
                {
                    Storyboard sb = this.FindResource("pressButton6") as Storyboard;
                    sb.Stop();
                }
            }

            if (e.Key == Key.Space)
            {
                pressed = " ";
            }
            else if (e.Key == Key.Escape)
            {
                Environment.Exit(1);
            }
            
            string theList = AddToList(pressed);
            inputs.Text += theList;
            if (theList == "clear")
            {
                inputs.Text = string.Empty;
            }
            CleanUp();
            Tick();
        }

        static string AddToList(string s)
        {
            StringBuilder builder = new StringBuilder();
            switch (s)
            {
                case "down":
                    builder.Append("↓");
                    break;
                case "right":
                    builder.Append("→");
                    break;
                case "left":
                    builder.Append("←");
                    break;
                case "up":
                    builder.Append("↑");
                    break;
                case "downright":
                    builder.Append("↘");
                    break;
                case "downleft":
                    builder.Append("↙");
                    break;
                case "upright":
                    builder.Append("↗");
                    break;
                case "upleft":
                    builder.Append("↖");
                    break;


                case "1":
                    builder.Append(s);
                    break;
                case "2":
                    builder.Append(s);
                    break;
                case "3":
                    builder.Append(s);
                    break;
                case "4":
                    builder.Append(s);
                    break;
                case "5":
                    builder.Append(s);
                    break;
                case "6":
                    builder.Append(s);
                    break;

                case " ":
                    builder.Append("clear");
                    break;
            }
            return (builder.ToString());
        }

        private void inputs_Loaded(object sender, RoutedEventArgs e)
        {
            // Text block holds 22 characters.
            var block = sender as TextBlock;
            block.Text = "";
        }
        public void CleanUp()
        {
            if (inputs.Text.Length > 20)
            {
                int overflow = inputs.Text.Length - 20;
                inputs.Text = inputs.Text.Remove(0, overflow);
            }
        }
        public async void Tick()
        {
            await Task.Delay(500);
            if (isAnyKeyDown() != true)
            {
                string current = inputs.Text;
                int len = (current.Length) - 1;
                char last = current[len];
                if (last != '.')
                {
                    inputs.Text += ".";
                    CleanUp();
                }
            }
        }
        public async void Jump(string anim)
        {
            inAnimation = true;
            Storyboard leap = this.FindResource(anim) as Storyboard;
            await Task.Delay(500);
            leap.Stop();
            inAnimation = false;
        }
        public static bool isAnyKeyDown()
        {
            if (Keyboard.IsKeyDown(Key.W)) return true;
            if (Keyboard.IsKeyDown(Key.A)) return true;
            if (Keyboard.IsKeyDown(Key.S)) return true;
            if (Keyboard.IsKeyDown(Key.D)) return true;
            if (Keyboard.IsKeyDown(Key.U)) return true;
            if (Keyboard.IsKeyDown(Key.I)) return true;
            if (Keyboard.IsKeyDown(Key.O)) return true;
            if (Keyboard.IsKeyDown(Key.J)) return true;
            if (Keyboard.IsKeyDown(Key.K)) return true;
            if (Keyboard.IsKeyDown(Key.L)) return true;
            else return false;
        }
    }
}
