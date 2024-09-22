namespace Drawers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearCanvas()
        {
            canvas.Refresh();
        }

        private void DrawHTree(Graphics g, float x, float y, float distance)
        {
            if (distance < 5)
            {
                return;
            }

            Pen p = Pens.DarkRed;

            float line_distance = distance / 2;

            // horizontal part
            g.DrawLine(p, x, y, x + line_distance, y);
            g.DrawLine(p, x, y, x - line_distance, y);

            // vertical left
            float nx = x - line_distance;
            g.DrawLine(p, nx, y, nx, y + line_distance);
            g.DrawLine(p, nx, y, nx, y - line_distance);

            // vertical right
            nx = x + line_distance;
            g.DrawLine(p, nx, y, nx, y + line_distance);
            g.DrawLine(p, nx, y, nx, y - line_distance);

            // recursion
            float new_distance = line_distance;
            DrawHTree(g, x - line_distance, y - line_distance, new_distance);
            DrawHTree(g, x - line_distance, y + line_distance, new_distance);
            DrawHTree(g, x + line_distance, y - line_distance, new_distance);
            DrawHTree(g, x + line_distance, y + line_distance, new_distance);
        }

        private void DrawSierpinskiTriangle(Graphics g, float x, float y, int size)
        {
            if (size > 1)
            {
                int new_size = size / 2;
                DrawSierpinskiTriangle(g, x, y - new_size, new_size);
                DrawSierpinskiTriangle(g, x - new_size, y + new_size, new_size);
                DrawSierpinskiTriangle(g, x + new_size, y + new_size, new_size);
            }

            if (size != 1)
            {
                return;
            }

            Pen p = Pens.Blue;

            PointF[] points = new PointF[]
            {
                new(x, y),
                new(x - size, y + size),
                new(x + size, y + size)
            };

            g.DrawPolygon(p, points);
        }

        // where x,y is the coordinate of the bottom left point of the rectangle
        private void DrawPythagorasTree(Graphics g, float x, float y, float size, float angle = 0, int blueness = 128)
        {
            // clamp
            blueness = Math.Max(0, blueness);

            if (size < 2)
            {
                return;
            }

            // compute self
            PointF[] points = new PointF[4];
            PointF last;

            points[0] = new(x, y);
            points[1] = last = Transformer.Transform(x, y, angle, size); // move right
            points[2] = last = Transformer.Transform(last.X, last.Y, angle - 90, size); // turn left, up
            points[3] = Transformer.Transform(last.X, last.Y, angle - 180, size); // turn left, left

            // draw self
            Brush b = new SolidBrush(Color.FromArgb(127 + blueness, blueness, 128, 0));
            g.FillPolygon(b, points);

            // compute next
            float new_size = (float)(size * (Math.Sqrt(2) / 2));

            PointF l = last = Transformer.Transform(x, y, angle - 90, size);
            last = Transformer.Transform(last.X, last.Y, angle, size / 2);
            PointF r = Transformer.Transform(last.X, last.Y, angle - 90, size / 2);
            
            // recursion
            DrawPythagorasTree(g, l.X, l.Y, new_size, angle - 45, blueness - 9);
            DrawPythagorasTree(g, r.X, r.Y, new_size, angle + 45, blueness - 9);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCanvas();
        }

        private void btnHTree_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            using Graphics g = canvas.CreateGraphics();

            // 1:1 ratio
            var distance = Math.Min(canvas.Width, canvas.Height);

            DrawHTree(g, x: canvas.Width / 2, y: canvas.Height / 2, distance / 2);
        }

        private void btnSierpinskiTriangle_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            using Graphics g = canvas.CreateGraphics();

            // 1:1 ratio
            var size = Math.Min(canvas.Width, canvas.Height);

            DrawSierpinskiTriangle(g, x: canvas.Width / 2, canvas.Height / 2, size / 2);
        }

        private void btnPythagoras_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            using Graphics g = canvas.CreateGraphics();

            // 1:1 ratio
            var size = Math.Min(canvas.Width, canvas.Height);

            DrawPythagorasTree(g, x: canvas.Width / 2 - (size / 4), canvas.Height, size / 4);
        }
    }
}
