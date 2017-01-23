using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormExample
{
    public partial class Form1 : Form
    {

        int x;
        int y;
        int cellSize;
        int margin=10;
        int row = -1;
        int col = -1;
        TTTLog.TTT board = new TTTLog.TTT();


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            UpdateSize();
        }

        private void UpdateSize()
        {
            cellSize = (Math.Min(ClientSize.Width, ClientSize.Height) - 2 * margin)/3;
            if(ClientSize.Width> ClientSize.Height)
            {
                x = (ClientSize.Width - 3 * cellSize) / 2;
                y = margin;
            }
            else
            {
                x = margin;
                y= (ClientSize.Height - 3 * cellSize) / 2;
            }
        }

        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);
            UpdateSize();
            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            col = (int)Math.Floor((e.X - x)*1.0 / cellSize);
            row = (int)Math.Floor((e.Y - y)*1.0 / cellSize);
            board.Place(row, col);

            Refresh();
            //base.OnMouseDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            //base.OnPaint(e);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {

                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    System.Drawing.Font font = new System.Drawing.Font("Ubuntu", cellSize * 3 * 72 / 96 / 4);
                    System.Drawing.Font font2 = new System.Drawing.Font("Ubuntu", cellSize * 3 * 96);
                    Rectangle rect = new Rectangle(x + i * cellSize, y + j * cellSize, cellSize, cellSize);
                    Rectangle winbox = new Rectangle(ClientSize.Width, ClientSize.Height, ClientSize.Width/2, ClientSize.Height/2 );
                    if (board.playing == false)
                    {
                        e.Graphics.DrawString("PLAYER" + (board.winner + 1), font, Brushes.DeepPink, x-cellSize/3, y);
                        e.Graphics.DrawString("WINS", font, Brushes.DeepPink, x - cellSize / 3, y+cellSize);
                    }
                    if (board.grid[j, i] == 0) e.Graphics.DrawString("X", font, Brushes.Black, x + i * cellSize, y + j * cellSize);
                    if (board.grid[j, i] == 1) e.Graphics.DrawString("O", font, Brushes.Black, x + i * cellSize, y + j * cellSize);
                    e.Graphics.DrawRectangle(Pens.Chocolate,rect);
                }
        }

    }
    
}
