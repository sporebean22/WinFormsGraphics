using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Timer = System.Threading.Timer;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Color[] ColorSet { get; set; } = { Color.FromArgb(255, 255, 255, 1), Color.FromArgb(51, 51, 51, 1), Color.FromArgb(136, 136, 136, 1), Color.FromArgb(221, 221, 221, 1), Color.FromArgb(0, 0, 0, 1) };

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var Objects = InitialiseGraphicsObjects(Color.Red);
            //var rectangle = Square(Objects.Item1, Objects.Item3, 15, 24);
            //Thread.Sleep(5000);
            //RemoveSquare(rectangle);
            //AnimatedSquare(Objects.Item1, Objects.Item3);
            DrawTriangle(Objects.Item1, Objects.Item3, Objects.Item2, 22);
        }

        private (Graphics, Pen, Brush) InitialiseGraphicsObjects(Color color)
        {
            Graphics graphicsObject = this.CreateGraphics();

            Pen myPen = new Pen(color, 5);

            var brush = new SolidBrush(color);

            var tuple = (graphicsObject, myPen, brush);

            return tuple;
        }

        private void Line(Graphics graphicsObject, Pen myPen)
        {
            graphicsObject.DrawLine(myPen, 20, 20, 200, 210);
        }

        private Rectangle Square(Graphics graphics, Brush brush, int xCoordinate, int yCoordinate)
        {
            var rectangle = new Rectangle(xCoordinate, yCoordinate, 50, 50);
            graphics.FillRectangle(brush, rectangle);
            return rectangle;
        }

        private void RemoveSquare(Rectangle rectangle)
        {
            rectangle.Height = 0;
            rectangle.Width = 0;
        }

        private void AnimatedSquare(Graphics graphics, Brush brush)
        {
            //var callback = new TimerCallback();

            //Timer timer = new Timer();

            //bool IsColourIndexOutOfBounds = false;

            for (int Xaxis = 0, Yaxis = 0/*, colourIndex = 0*/; Xaxis + Yaxis < 10000/* && IsColourIndexOutOfBounds != false */; Xaxis += 51/*, colourIndex++*/)
            {
                /*if (colourIndex > 5)
                {
                    IsColourIndexOutOfBounds = true;
                    colourIndex = 0;
                }*/
                
                var rectangle = Square(graphics, brush, Xaxis, Yaxis);
                Thread.Sleep(450);
                //RemoveSquare(rectangle);
            }

            //timer.Dispose();
        }

        public void DrawTriangle(Graphics graphicsObject, Brush brush, Pen pen, int multiplyer)
        {
            var points = new Point[] {new Point(10,5), new Point(7,10), new Point(13,10)};
            graphicsObject.DrawPolygon(pen, MultiplyAllArrayItems(points, multiplyer));
            var path = new GraphicsPath(FillMode.Alternate);
            graphicsObject.FillPath(brush, path);
        }

        public Point[] MultiplyAllArrayItems(Point[] types, int multiplier)
        {
            for (int typeIndex = 0; typeIndex < types.Length; typeIndex++)
            {
                types[typeIndex].X *= multiplier;
                types[typeIndex].Y *= multiplier;
            }
            return types;

        }

    }
}
