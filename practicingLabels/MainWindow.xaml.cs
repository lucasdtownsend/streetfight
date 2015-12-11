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
using WpfAnimatedGif;

namespace practicingLabels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StringBuilder builder;
        public bool inAnimation = false;
        public bool opponentAnimation = false;
        public bool jumping = false;
        public bool isKeyPressed = false;
        public bool perfectInput = false;
        public bool guide = false;
        public bool opponent = false;
        string dir = "invisible";
        public MainWindow()
        {
            InitializeComponent();
            if (guide == true)
            {
                HowToOverhead();
            }
        }

        public void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string pressed = "";
            isKeyPressed = true;
            Storyboard stance = this.FindResource("stance") as Storyboard;
            int last = (inputs.Text.Length) - 1;
            int lastDir = (dir.Length) - 1;
            // KEY DOWN! IN ANIMATION!
            if (e.IsRepeat == false)
            {
                if (inAnimation == true)
                {
                    //First, handlers for diagonals.
                    if (e.Key == Key.Down || e.Key == Key.S)
                    {
                        Storyboard sb = this.FindResource("joyDown") as Storyboard;
                        sb.Begin();
                        pressed = "down";
                        dir += "d";
                        if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                        {
                            pressed = "downright";
                            dir += "!";
                        }
                        else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                        {
                            pressed = "downleft";
                            dir += "!";
                        }
                    }
                    else if (e.Key == Key.Right || e.Key == Key.D)
                    {
                        Storyboard sb = this.FindResource("joyRight") as Storyboard;
                        sb.Begin();
                        pressed = "right";
                        dir += "r";
                        if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                        {
                            pressed = "upright";
                        }
                        else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                        {
                            pressed = "downright";
                            dir += "!";
                        }
                    }
                    else if (e.Key == Key.Left || e.Key == Key.A)
                    {
                        Storyboard sb = this.FindResource("joyLeft") as Storyboard;
                        sb.Begin();
                        pressed = "left";
                        dir += "l";
                        if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                        {
                            pressed = "upleft";
                        }
                        else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                        {
                            pressed = "downleft";
                            dir += "!";
                        }
                    }
                    else if (e.Key == Key.Up || e.Key == Key.W)
                    {
                        Storyboard sb = this.FindResource("joyUp") as Storyboard;
                        sb.Begin();
                        pressed = "up";
                        dir += "u";
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
                        dir += "d";
                        if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                        {
                            pressed = "downright";
                            dir += "!";
                        }
                        else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                        {
                            pressed = "downleft";
                            dir += "!";
                        }
                    }
                    else if (e.Key == Key.Right || e.Key == Key.D)
                    {
                        Storyboard sb = this.FindResource("joyRight") as Storyboard;
                        sb.Begin();
                        Storyboard ryu = this.FindResource("walkF") as Storyboard;
                        ryu.Begin();
                        pressed = "right";
                        dir += "r";
                        if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                        {
                            pressed = "upright";
                            Storyboard alt = this.FindResource("jumpF") as Storyboard;
                            alt.Begin();
                            Jump("jumpF", 1000);
                        }
                        else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                        {
                            pressed = "downright";
                            dir += "!";
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
                        dir += "l";
                        if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                        {
                            pressed = "upleft";
                            Storyboard alt = this.FindResource("jumpB") as Storyboard;
                            alt.Begin();
                            Jump("jumpB", 1000);
                        }
                        else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                        {
                            pressed = "downleft";
                            dir += "!";
                            Storyboard alt = this.FindResource("crouch") as Storyboard;
                            alt.Begin();
                        }
                    }
                    else if (e.Key == Key.Up || e.Key == Key.W)
                    {
                        Storyboard sb = this.FindResource("joyUp") as Storyboard;
                        sb.Begin();
                        inAnimation = true;
                        pressed = "up";
                        dir += "u";
                        if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                        {
                            pressed = "upright";
                            Storyboard alt = this.FindResource("jumpF") as Storyboard;
                            alt.Begin();
                            Jump("jumpF", 1000);
                        }
                        else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                        {
                            pressed = "upleft";
                            Storyboard alt = this.FindResource("jumpB") as Storyboard;
                            alt.Begin();
                            Jump("jumpB", 1000);
                        }
                        else
                        {
                            Storyboard ryu = this.FindResource("jumpN") as Storyboard;
                            ryu.Begin();
                            Jump("jumpN", 900);
                        }
                    }
                    else if (e.Key == Key.U)
                    {
                        Storyboard sb = this.FindResource("pushButton1") as Storyboard;
                        sb.Begin();
                        if (jumping == true)
                        {
                            Storyboard ryu = this.FindResource("airLP") as Storyboard;
                            ryu.Begin();
                            Jump("airLP", 150);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && inputs.Text[last - 1] == 'E' && dir[lastDir - 2] == 'd' && (dir[lastDir - 3] == 'r' || dir[lastDir - 4] == 'r') && inputs.Text[last - 4] == 'E' && inputs.Text[last - 5] == 'C')
                        {
                            Storyboard ryu = this.FindResource("taunt") as Storyboard;
                            ryu.Begin();
                            move.Text += "METSU HADOKEN";
                            Attack("taunt", 800);
                        }
                        else if ((Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D)) && (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S)) && inputs.Text[last - 1] == 'C' && inputs.Text[last - 2] == 'B')
                        {
                            Storyboard shoryu = this.FindResource("shoryukenL") as Storyboard;
                            shoryu.Begin();
                            move.Text += "L SHORYUKEN";
                            Attack("shoryukenL", 650);
                        }
                        else if ((Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D)) && (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S)) && inputs.Text[last - 1] == 'C')
                        {
                            if (perfectInput == false)
                            {
                                Storyboard shoryu = this.FindResource("shoryukenL") as Storyboard;
                                shoryu.Begin();
                                move.Text += "L SHORYUKEN";
                                Attack("shoryukenL", 650);
                            }
                            else
                            {
                                Storyboard ryu = this.FindResource("crouchLP") as Storyboard;
                                ryu.Begin();
                                CrouchAttack("crouchLP", 150);
                            }
                        }
                        else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                        {
                            Storyboard ryu = this.FindResource("crouchLP") as Storyboard;
                            ryu.Begin();
                            CrouchAttack("crouchLP", 150);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && inputs.Text[last - 1] == 'E' && dir[lastDir - 2] == 'd')
                        {
                            Storyboard hado = this.FindResource("hadokenL") as Storyboard;
                            hado.Begin();
                            move.Text += "L HADOKEN";
                            Attack("hadokenL", 600);
                        }
                        else
                        {
                            Storyboard ryu = this.FindResource("punchL") as Storyboard;
                            ryu.Begin();
                            Attack("punchL", 150);
                        }
                        pressed = "1";
                    }
                    else if (e.Key == Key.I)
                    {
                        Storyboard sb = this.FindResource("pushButton2") as Storyboard;
                        sb.Begin();
                        if (jumping == true)
                        {
                            Storyboard ryu = this.FindResource("airMP") as Storyboard;
                            ryu.Begin();
                            Jump("airMP", 250);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && inputs.Text[last - 1] == 'E' && dir[lastDir - 2] == 'd' && (dir[lastDir - 3] == 'r' || dir[lastDir - 4] == 'r') && inputs.Text[last - 4] == 'E' && inputs.Text[last - 5] == 'C')
                        {
                            Storyboard ryu = this.FindResource("taunt") as Storyboard;
                            ryu.Begin();
                            move.Text += "METSU HADOKEN";
                            Attack("taunt", 800);
                        }
                        else if ((Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D)) && (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S)) && inputs.Text[last - 1] == 'C' && inputs.Text[last - 2] == 'B')
                        {
                            Storyboard shoryu = this.FindResource("shoryukenM") as Storyboard;
                            shoryu.Begin();
                            move.Text += "M SHORYUKEN";
                            Attack("shoryukenM", 750);
                        }
                        else if ((Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D)) && (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S)) && inputs.Text[last - 1] == 'C' && inputs.Text[last - 2] == 'E')
                        {
                            if (perfectInput == false)
                            {
                                Storyboard shoryu = this.FindResource("shoryukenM") as Storyboard;
                                shoryu.Begin();
                                move.Text += "M SHORYUKEN";
                                Attack("shoryukenM", 750);
                            }
                            else
                            {
                                Storyboard ryu = this.FindResource("crouchMP") as Storyboard;
                                ryu.Begin();
                                CrouchAttack("crouchMP", 400);
                            }
                        }
                        else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                        {
                            Storyboard ryu = this.FindResource("crouchMP") as Storyboard;
                            ryu.Begin();
                            CrouchAttack("crouchMP", 400);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && inputs.Text[last - 1] == 'E' && dir[lastDir - 2] == 'd')
                        {
                            Storyboard hado = this.FindResource("hadokenM") as Storyboard;
                            hado.Begin();
                            move.Text += "M HADOKEN";
                            Attack("hadokenM", 650);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                        {
                            Storyboard overhead = this.FindResource("f-mp") as Storyboard;
                            overhead.Begin();
                            move.Text += "OVERHEAD PUNCH";
                            Attack("f-mp", 500);
                        }
                        else
                        {
                            Storyboard ryu = this.FindResource("punchM") as Storyboard;
                            ryu.Begin();
                            Attack("punchM", 400);
                        }
                        pressed = "2";
                    }
                    else if (e.Key == Key.O)
                    {
                        Storyboard sb = this.FindResource("pressButton3") as Storyboard;
                        sb.Begin();
                        if (jumping == true)
                        {
                            Storyboard ryu = this.FindResource("airHP") as Storyboard;
                            ryu.Begin();
                            Jump("airHP", 200);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && inputs.Text[last - 1] == 'E' && dir[lastDir - 2] == 'd' && (dir[lastDir - 3] == 'r' || dir[lastDir - 4] == 'r') && inputs.Text[last - 4] == 'E' && inputs.Text[last - 5] == 'C')
                        {
                            Storyboard ryu = this.FindResource("taunt") as Storyboard;
                            ryu.Begin();
                            move.Text += "METSU HADOKEN";
                            Attack("taunt", 800);
                        }
                        else if ((Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D)) && (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S)) && inputs.Text[last - 1] == 'C' && inputs.Text[last - 2] == 'B')
                        {
                            Storyboard shoryu = this.FindResource("shoryukenH") as Storyboard;
                            shoryu.Begin();
                            move.Text += "H SHORYUKEN";
                            Attack("shoryukenH", 900);
                        }
                        else if ((Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D)) && (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S)) && inputs.Text[last - 1] == 'C' && inputs.Text[last - 2] == 'E')
                        {
                            if (perfectInput == false)
                            {
                                Storyboard shoryu = this.FindResource("shoryukenH") as Storyboard;
                                shoryu.Begin();
                                move.Text += "H SHORYUKEN";
                                Attack("shoryukenH", 900);
                            }
                            else
                            {
                                Storyboard ryu = this.FindResource("crouchHP") as Storyboard;
                                ryu.Begin();
                                CrouchAttack("crouchHP", 600);
                            }
                        }
                        else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                        {
                            Storyboard ryu = this.FindResource("crouchHP") as Storyboard;
                            ryu.Begin();
                            CrouchAttack("crouchHP", 600);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && inputs.Text[last - 1] == 'E' && dir[lastDir - 2] == 'd')
                        {
                            Storyboard hado = this.FindResource("hadokenH") as Storyboard;
                            hado.Begin();
                            move.Text += "H HADOKEN";
                            Attack("hadokenH", 700);
                        }
                        else if (Keyboard.IsKeyDown(Key.L))
                        {
                            Storyboard showmeyourmoves = this.FindResource("taunt") as Storyboard;
                            showmeyourmoves.Begin();
                            move.Text += "SHOW ME\nYOUR MOVES!";
                            Attack("taunt", 800);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                        {
                            Storyboard overhead = this.FindResource("f-hp") as Storyboard;
                            overhead.Begin();
                            move.Text += "DASH PUNCH";
                            Attack("f-hp", 800);
                        }
                        else
                        {
                            Storyboard ryu = this.FindResource("punchH") as Storyboard;
                            ryu.Begin();
                            Attack("punchH", 600);
                        }
                        pressed = "3";
                    }
                    else if (e.Key == Key.J)
                    {
                        Storyboard sb = this.FindResource("pressButton4") as Storyboard;
                        sb.Begin();
                        if (jumping == true)
                        {
                            Storyboard ryu = this.FindResource("airLK") as Storyboard;
                            ryu.Begin();
                            Jump("airLK", 200);
                        }
                        else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                        {
                            Storyboard ryu = this.FindResource("crouchLK") as Storyboard;
                            ryu.Begin();
                            CrouchAttack("crouchLK", 300);
                        }
                        else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A) && inputs.Text[last - 1] == 'F' && dir[lastDir - 2] == 'd')
                        {
                            Storyboard tatsu = this.FindResource("tatsuL") as Storyboard;
                            tatsu.Begin();
                            move.Text += "L TATSUMAKI";
                            Attack("tatsuL", 700);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && (inputs.Text[last - 2] == 'C') && (dir[lastDir - 4] == 'l') && (inputs.Text[last] != '4' && inputs.Text[last] != '5' && inputs.Text[last] != '6'))
                        {
                            Storyboard overhead = this.FindResource("stepkickL") as Storyboard;
                            overhead.Begin();
                            move.Text += "L STEPKICK";
                            Attack("stepkickL", 600);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && (dir[lastDir - 2] == 'd' || dir[lastDir - 1] == 'd' || dir[lastDir - 3] == 'd') && (dir[lastDir - 4] == 'l' || dir[lastDir - 5] == 'l') && (inputs.Text[last] != '4' && inputs.Text[last] != '5' && inputs.Text[last] != '6'))
                        {
                            if (perfectInput == false)
                            {
                                Storyboard overhead = this.FindResource("stepkickL") as Storyboard;
                                overhead.Begin();
                                move.Text += "L STEPKICK";
                                Attack("stepkickL", 600);
                            }
                            else
                            {
                                Storyboard ryu = this.FindResource("kickL") as Storyboard;
                                ryu.Begin();
                                Attack("kickL", 200);
                            }
                        }
                        else
                        {
                            Storyboard ryu = this.FindResource("kickL") as Storyboard;
                            ryu.Begin();
                            Attack("kickL", 200);
                        }
                        pressed = "4";
                    }
                    else if (e.Key == Key.K)
                    {
                        Storyboard sb = this.FindResource("pressButton5") as Storyboard;
                        sb.Begin();
                        if (jumping == true)
                        {
                            Storyboard ryu = this.FindResource("airMK") as Storyboard;
                            ryu.Begin();
                            Jump("airMK", 250);
                        }
                        else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                        {
                            Storyboard ryu = this.FindResource("crouchMK") as Storyboard;
                            ryu.Begin();
                            CrouchAttack("crouchMK", 500);
                        }
                        else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A) && inputs.Text[last - 1] == 'F' && dir[lastDir - 2] == 'd')
                        {
                            Storyboard tatsu = this.FindResource("tatsuM") as Storyboard;
                            tatsu.Begin();
                            move.Text += "M TATSUMAKI";
                            Attack("tatsuM", 1000);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && (inputs.Text[last - 2] == 'C') && (dir[lastDir - 4] == 'l') && (dir[lastDir - 4] == 'l') && (inputs.Text[last] != '4' && inputs.Text[last] != '5' && inputs.Text[last] != '6'))
                        {
                            Storyboard overhead = this.FindResource("stepkickM") as Storyboard;
                            overhead.Begin();
                            move.Text += "M STEPKICK";
                            Attack("stepkickM", 650);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && (dir[lastDir - 2] == 'd' || dir[lastDir - 1] == 'd' || dir[lastDir - 3] == 'd') && (dir[lastDir - 4] == 'l' || dir[lastDir - 5] == 'l') && (dir[lastDir - 4] == 'l') && (inputs.Text[last] != '4' && inputs.Text[last] != '5' && inputs.Text[last] != '6'))
                        {
                            if (perfectInput == false)
                            {
                                Storyboard overhead = this.FindResource("stepkickM") as Storyboard;
                                overhead.Begin();
                                move.Text += "M STEPKICK";
                                Attack("stepkickM", 650);
                            }
                            else
                            {
                                Storyboard ryu = this.FindResource("kickM") as Storyboard;
                                ryu.Begin();
                                Attack("kickM", 500);
                            }
                        }
                        else
                        {
                            Storyboard ryu = this.FindResource("kickM") as Storyboard;
                            ryu.Begin();
                            Attack("kickM", 500);
                        }
                        pressed = "5";
                    }
                    else if (e.Key == Key.L)
                    {
                        Storyboard sb = this.FindResource("pressButton6") as Storyboard;
                        sb.Begin();
                        if (jumping == true)
                        {
                            Storyboard ryu = this.FindResource("airHK") as Storyboard;
                            ryu.Begin();
                            Jump("airHK", 350);
                        }
                        else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                        {
                            Storyboard ryu = this.FindResource("crouchHK") as Storyboard;
                            ryu.Begin();
                            CrouchAttack("crouchHK", 700);
                        }
                        else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A) && inputs.Text[last - 1] == 'F' && dir[lastDir - 2] == 'd')
                        {
                            Storyboard tatsu = this.FindResource("tatsuH") as Storyboard;
                            tatsu.Begin();
                            move.Text += "H TATSUMAKI";
                            Attack("tatsuH", 1350);
                        }
                        else if (Keyboard.IsKeyDown(Key.O))
                        {
                            Storyboard showmeyourmoves = this.FindResource("taunt") as Storyboard;
                            showmeyourmoves.Begin();
                            Attack("taunt", 800);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && (inputs.Text[last - 2] == 'C') && (dir[lastDir - 4] == 'l') && (dir[lastDir - 4] == 'l') && (inputs.Text[last] != '4' && inputs.Text[last] != '5' && inputs.Text[last] != '6'))
                        {
                            Storyboard overhead = this.FindResource("stepkick") as Storyboard;
                            overhead.Begin();
                            move.Text += "H STEPKICK";
                            Attack("stepkick", 750);
                        }
                        else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D) && (dir[lastDir - 2] == 'd' || dir[lastDir - 1] == 'd' || dir[lastDir - 3] == 'd') && (dir[lastDir - 4] == 'l' || dir[lastDir - 5] == 'l') && (dir[lastDir - 4] == 'l') && (inputs.Text[last] != '4' && inputs.Text[last] != '5' && inputs.Text[last] != '6'))
                        {
                            if (perfectInput == false)
                            {
                                Storyboard overhead = this.FindResource("stepkick") as Storyboard;
                                overhead.Begin();
                                move.Text += "H STEPKICK";
                                Attack("stepkick", 750);
                            }
                            else
                            {
                                Storyboard ryu = this.FindResource("kickH") as Storyboard;
                                ryu.Begin();
                                Attack("kickH", 700);
                            }
                        }
                        else
                        {
                            Storyboard ryu = this.FindResource("kickH") as Storyboard;
                            ryu.Begin();
                            Attack("kickH", 700);
                        }
                        pressed = "6";
                    }
                }

                // CHUN LI attack commands
                if (opponentAnimation == false && opponent == true)
                {
                    if (e.Key == Key.H)
                    {
                        Storyboard chunli = this.FindResource("chunMK") as Storyboard;
                        chunli.Begin();
                        if ((Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left)) && inAnimation == false)
                        {
                            ChunHit(900, 260, "med", true);
                        }
                        else
                        {
                            ChunHit(900, 260, "med", false);
                        }
                    }
                    if (e.Key == Key.M)
                    {
                        Storyboard chunli = this.FindResource("chunLow") as Storyboard;
                        chunli.Begin();
                        if ((Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left)) && (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down)) && inAnimation == false)
                        {
                            ChunHit(900, 260, "lo", true);
                        }
                        else
                        {
                            ChunHit(900, 260, "lo", false);
                        }
                    }
                }


                e.Handled = e.IsRepeat;
                int len = inputs.Text.Length;
                string theList = AddToList(pressed);
                inputs.Text += theList;
                CleanUp();
                Testing();
            }
            
        }

        public void Window_KeyUp(object sender, KeyEventArgs e)
        {
            string pressed = "";
            isKeyPressed = false;
            Storyboard stance = this.FindResource("stance") as Storyboard;

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
                    stance.Begin();
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
                    stance.Begin();
                    if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    {
                        pressed = "up";
                    }
                    else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    {
                        Storyboard alt = this.FindResource("crouch") as Storyboard;
                        alt.Begin();
                        pressed = "down";
                    }
                }
                else if (e.Key == Key.Left || e.Key == Key.A)
                {
                    Storyboard sb = this.FindResource("joyLeft") as Storyboard;
                    sb.Stop();
                    Storyboard ryu = this.FindResource("walkB") as Storyboard;
                    ryu.Stop();
                    stance.Begin();
                    if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    {
                        pressed = "up";
                    }
                    else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    {
                        Storyboard alt = this.FindResource("crouch") as Storyboard;
                        alt.Begin();
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
            else if (e.Key == Key.D1)
            {
                HowToOverhead();
            }
            else if (e.Key == Key.D2)
            {
                HowToDashPunch();
            }
            else if (e.Key == Key.D3)
            {
                HowToHadoken();
            }
            else if (e.Key == Key.D4)
            {
                HowToShoryuken();
            }
            else if (e.Key == Key.D5)
            {
                HowToTatsumaki();
            }
            else if (e.Key == Key.D6)
            {
                HowToStepkick();
            }
            else if (e.Key == Key.G)
            {
                if (guide == true)
                {
                    guide = false;
                    moveName.Text = string.Empty;
                    instructions.Text = string.Empty;
                }
                else if (guide == false)
                {
                    guide = true;
                    HowToOverhead();
                }
            }
            else if (e.Key == Key.P)
            {
                if (perfectInput == false)
                {
                    perfectInput = true;
                    inputMode.Text = "Perfect";
                    perfect.Content = "Easy Inputs";
                }
                else if (perfectInput == true)
                {
                    perfectInput = false;
                    inputMode.Text = "Standard";
                    perfect.Content = "Perfect Inputs";
                }
            }
            else if (e.Key == Key.N)
            {
                if (opponentAnimation == false)
                {
                    if (opponent == false)
                    {
                        opponent = true;
                        Storyboard stepIn = this.FindResource("chunWalkf") as Storyboard;
                        stepIn.Begin();
                        Animation(1600);
                    }
                    else
                    {
                        Storyboard taunt = this.FindResource("chunTaunt") as Storyboard;
                        taunt.Begin();
                        Animation(1300);
                    }
                }
            }
            

            string theList = AddToList(pressed);

            inputs.Text += theList;

            if (theList == "c")
            {
                inputs.Text = "Inputs:";
            }
            else
            {
                Storyboard goBack = this.FindResource("stance") as Storyboard;
                CleanUp();
                Tick();
            }
        }

        static string AddToList(string s)
        {
            StringBuilder builder = new StringBuilder();
            switch (s)
            {
                case "down":
                    builder.Append("C");
                    break;
                case "right":
                    builder.Append("B");
                    break;
                case "left":
                    builder.Append("A");
                    break;
                case "up":
                    builder.Append("D");
                    break;
                case "downright":
                    builder.Append("E");
                    break;
                case "downleft":
                    builder.Append("F");
                    break;
                case "upright":
                    builder.Append("G");
                    break;
                case "upleft":
                    builder.Append("H");
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
                    builder.Append("c");
                    break;
            }
            return (builder.ToString());
        }

        private void inputs_Loaded(object sender, RoutedEventArgs e)
        {
            // Text block holds 22 characters.
            var block = sender as TextBlock;
            block.Text = "inputs";
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
            await Task.Delay(200);
            if (isAnyKeyDown() != true)
            {
                string current = inputs.Text;
                if (current.Length > 0)
                {
                    int len = (current.Length) - 1;
                    char last = current[len];
                    if (last != '.')
                    {
                        inputs.Text += ".";
                    }
                }
            }
        }
        public async void Jump(string anim, int ms)
        {
            inAnimation = true;
            jumping = true;
            Storyboard leap = this.FindResource(anim) as Storyboard;
            await Task.Delay(ms);
            leap.Stop();
            inAnimation = false;
            jumping = false;
            
            if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
            {
                if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                {
                    Storyboard crouch = this.FindResource("crouch") as Storyboard;
                    crouch.Begin();
                }
                else if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                {
                    Storyboard jumpAgain = this.FindResource("jumpF") as Storyboard;
                    jumpAgain.Begin();
                    Jump("jumpF", 1000);
                }
                else
                {
                    Storyboard walk = this.FindResource("walkF") as Storyboard;
                    walk.Begin();
                }
            }
            else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
            {
                if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                {
                    Storyboard crouch = this.FindResource("crouch") as Storyboard;
                    crouch.Begin();
                }
                else if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                {
                    Storyboard jumpAgain = this.FindResource("jumpB") as Storyboard;
                    jumpAgain.Begin();
                    Jump("jumpB", 1000);
                }
                else
                {
                    Storyboard walk = this.FindResource("walkB") as Storyboard;
                    walk.Begin();
                }
            }
            else if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
            {
                Storyboard crouch = this.FindResource("crouch") as Storyboard;
                crouch.Begin();
            }
            else if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
            {
                if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                {
                    Storyboard jumpAgain = this.FindResource("jumpF") as Storyboard;
                    jumpAgain.Begin();
                    Jump("jumpF", 1000);
                }
                else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                {
                    Storyboard jumpAgain = this.FindResource("jumpB") as Storyboard;
                    jumpAgain.Begin();
                    Jump("jumpB", 1000);
                }
                else
                {
                    Storyboard jumpAgain = this.FindResource("jumpN") as Storyboard;
                    jumpAgain.Begin();
                    Jump("jumpN", 900);
                }
            }
            else
            {
                Storyboard stance = this.FindResource("stance") as Storyboard;
                stance.Begin();
            }
        }
        public async void Attack(string anim, int ms)
        {
            inAnimation = true;
            Storyboard hit = this.FindResource(anim) as Storyboard;
            await Task.Delay(ms);
            hit.Stop();
            move.Text = string.Empty;
            inAnimation = false;
            if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
            {
                Storyboard crouch = this.FindResource("crouch") as Storyboard;
                crouch.Begin();
            }
            else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
            {
                Storyboard walk = this.FindResource("walkF") as Storyboard;
                walk.Begin();
            }
            else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
            {
                Storyboard walk = this.FindResource("walkB") as Storyboard;
                walk.Begin();
            }
            else
            {
                Storyboard stand = this.FindResource("stance") as Storyboard;
                stand.Begin();
            }
        }
        public async void Animation(int ms)
        {
            opponentAnimation = true;
            await Task.Delay(ms);
            opponentAnimation = false;
        }
        public async void ChunHit(int attacklen, int active, string zone, bool isBlocked)
        {
            int remaining = attacklen - active;
            opponentAnimation = true;
            await Task.Delay(active);
            if (zone == "med")
            {
                if (isBlocked == false)
                {
                    Storyboard react = this.FindResource("standHit") as Storyboard;
                    react.Begin();
                    Attack("standHit", 500);
                }
                else
                {
                    Storyboard react = this.FindResource("standBlock") as Storyboard;
                    react.Begin();
                    Attack("standBlock", 500);
                }
            }
            else if (zone == "lo")
            {
                if (isBlocked == false)
                {
                    Storyboard react = this.FindResource("standHit") as Storyboard;
                    react.Begin();
                    Attack("crouchHit", 500);
                }
                else
                {
                    Storyboard react = this.FindResource("standHit") as Storyboard;
                    react.Begin();
                    Attack("crouchBlock", 500);
                }
            }
            await Task.Delay(remaining);
            opponentAnimation = false;
        }
        public async void CrouchAttack(string anim, int ms)
        {
            int len = inputs.Text.Length - 1;
            inAnimation = true;
            Storyboard hit = this.FindResource(anim) as Storyboard;
            await Task.Delay(ms);
            hit.Stop();
            if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
            {
                Storyboard crouch = this.FindResource("crouch") as Storyboard;
                crouch.Begin();
            }
            else if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
            {
                Storyboard walk = this.FindResource("walkF") as Storyboard;
                walk.Begin();
            }
            else if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
            {
                Storyboard walk = this.FindResource("walkB") as Storyboard;
                walk.Begin();
            }
            else
            {
                Storyboard stand = this.FindResource("stance") as Storyboard;
                stand.Begin();
            }
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
        public async void Testing ()
        {
            if (instructions.Text == "↓↘→ + P" && (move.Text.Contains("HADOKEN")))
            {
                instructions.Text = "COMPLETE!";
                await Task.Delay(500);
                instructions.Text = string.Empty;
                moveName.Text = string.Empty;
                await Task.Delay(100);
                if (guide == true)
                {
                    HowToShoryuken();
                }
            }
            else if (instructions.Text == "→↓↘ + P" && (move.Text.Contains("SHORYUKEN")))
            {
                instructions.Text = "COMPLETE!";
                await Task.Delay(500);
                instructions.Text = string.Empty;
                moveName.Text = string.Empty;
                await Task.Delay(100);
                if (guide == true)
                {
                    HowToTatsumaki();
                }
            }
            else if (instructions.Text == "↓↙← + K" && (move.Text.Contains("TATSUMAKI")))
            {
                instructions.Text = "COMPLETE!";
                await Task.Delay(500);
                instructions.Text = string.Empty;
                moveName.Text = string.Empty;
                await Task.Delay(100);
                if (guide == true)
                {
                    HowToStepkick();
                }
            }
            else if (instructions.Text == "←↙↓↘→ + K" && (move.Text.Contains("STEPKICK")))
            {
                instructions.Text = "COMPLETE!";
                await Task.Delay(500);
                instructions.Text = string.Empty;
                moveName.Text = string.Empty;
            }
            else if (instructions.Text == "→ + MP" && (move.Text == "OVERHEAD PUNCH"))
            {
                instructions.Text = "COMPLETE!";
                await Task.Delay(500);
                instructions.Text = string.Empty;
                moveName.Text = string.Empty;
                await Task.Delay(100);
                if (guide == true)
                {
                    HowToDashPunch();
                }
            }
            else if (instructions.Text == "→ + HP" && (move.Text == "DASH PUNCH"))
            {
                instructions.Text = "COMPLETE!";
                await Task.Delay(500);
                instructions.Text = string.Empty;
                moveName.Text = string.Empty;
                await Task.Delay(100);
                if (guide == true)
                {
                    HowToHadoken();
                }
            }
            if (instructions.Text == "COMPLETE!")
            {
                instructions.Text = string.Empty;
                moveName.Text = string.Empty;
            }
        }
        public void HowToOverhead()
        {
            instructions.Text = "→ + MP";
            moveName.Text = "How to Overhead Punch";
        }
        public void HowToDashPunch()
        {
            instructions.Text = "→ + HP";
            moveName.Text = "How to Dash Punch";
        }
        public void HowToHadoken()
        {
            instructions.Text = "↓↘→ + P";
            moveName.Text = "How to Hadoken";
        }
        public void HowToShoryuken()
        {
            instructions.Text = "→↓↘ + P";
            moveName.Text = "How to Shoryuken";
        }
        public void HowToTatsumaki()
        {
            instructions.Text = "↓↙← + K";
            moveName.Text = "How to Tatsumaki";
        }
        public void HowToStepkick()
        {
            instructions.Text = "←↙↓↘→ + K";
            moveName.Text = "How to Stepkick";
        }
        public async void onDeck (int i)
        {
            await Task.Delay(1500);

        }
        private void instructions_Loaded(object sender, RoutedEventArgs e)
        {
            var block = sender as TextBlock;
        }

        private void perfect_Click(object sender, RoutedEventArgs e)
        {
            if (perfectInput == false)
            {
                perfectInput = true;
                inputMode.Text = "Perfect";
                perfect.Content = "Easy Inputs";
            }
            else if (perfectInput == true)
            {
                perfectInput = false;
                inputMode.Text = "Standard";
                perfect.Content = "Perfect Inputs";
            }
        }

        private void guideButton_Click(object sender, RoutedEventArgs e)
        {
            if (guide == true)
            {
                guide = false;
                moveName.Text = string.Empty;
                instructions.Text = string.Empty;
            }
            else if (guide == false)
            {
                guide = true;
                HowToOverhead();
            }
        }

        private void chunWalkf_Completed(object sender, EventArgs e)
        {
            Storyboard stand = this.FindResource("chunStand") as Storyboard;
            stand.Begin();
        }

        private void chunTaunt_Completed(object sender, EventArgs e)
        {
            Storyboard stand = this.FindResource("chunStand") as Storyboard;
            stand.Begin();
        }

        private void chunMK_Completed(object sender, EventArgs e)
        {
            Storyboard stand = this.FindResource("chunStand") as Storyboard;
            stand.Begin();
        }
    }
}
