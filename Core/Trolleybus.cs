using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Core;

public class Trolleybus
{
    private List<Figure> _figures;

    private static List<Figure> GetDoors(Point position)
    {
        int w = 50;
        int h = 165;
        int gap = 2;

        return new List<Figure>(4)
        {
            new() { Rectangle = new Rectangle(position.X, position.Y, w, h), Name = "Door" },
            new() { Rectangle = new Rectangle(position.X + w + gap, position.Y, w, h), Name = "Door" },

            new() { Rectangle = new Rectangle(position.X + 5, position.Y + 5, w - 10, 100), Name = "DoorWindow" },
            new() { Rectangle = new Rectangle(position.X + w + gap + 5, position.Y + 5, w - 10, 100), Name = "DoorWindow" },
        };
    }

    private static List<Figure> GetTwoWindows(Point position)
    {
        int w = 100;
        int h = 80;
        int gap = 5;

        return new List<Figure>(2)
        {
            new() { Rectangle = new Rectangle(position.X, position.Y, w, h), Name = "Window" },
            new() { Rectangle = new Rectangle(position.X + w + gap, position.Y, w, h), Name = "Window" },
        };
    }

    private static List<Figure> GetWheel(Point position)
    {
        int tyreDim = 85;
        int wheelDim = 40;

        return new List<Figure>()
        {
            new() { Rectangle = new Rectangle(position.X, position.Y, tyreDim, tyreDim), Name = "Tyre" },
            new()
            {
                Rectangle = new Rectangle(position.X + tyreDim / 2 - wheelDim / 2
                    , position.Y + tyreDim / 2 - wheelDim / 2, wheelDim, wheelDim),
                Name = "Wheel"
            },
        };
    }

    private static List<Figure> GetPantograph(Point position)
    {
        int w = 300;
        int h = 20;
        int gap = 150;

        return new List<Figure>()
        {
            new() { Rectangle = new Rectangle(position.X, position.Y, w, h), Name = "Pantograph Base" },
            new() { Rectangle = new Rectangle(position.X + gap, position.Y - 15, 100, 15), Name = "Pantograph" },
            new() { Rectangle = new Rectangle(position.X - 200, position.Y - 55, 180 + gap + 20, 40), Name = "Horns" },
        };
    }

    public Trolleybus(Point position)
    {
        _figures = new List<Figure>();
        _figures.Add(new() { Rectangle = new Rectangle(position.X, position.Y, 820, 200) });
        _figures.AddRange(GetDoors(new Point(position.X + 25, position.Y + 25)));
        _figures.AddRange(GetTwoWindows(new Point(position.X + 25 + 100 + 2 + 10, position.Y + 25)));
        _figures.AddRange(GetDoors(new Point(position.X + 25 + 100 + 2 + 10 + 200 + 5 + 10, position.Y + 25)));
        _figures.AddRange(GetTwoWindows(new Point(position.X + 25 + 100 + 2 + 10 + 200 + 5 + 10 + 100 + 2 + 10,
            position.Y + 25)));
        _figures.AddRange(GetDoors(new Point(position.X + 25 + 100 + 2 + 10 + 200 + 5 + 10 + 100 + 2 + 10 + 200 + 10 + 5,
            position.Y + 25)));

        _figures.Add(new() { Rectangle = new Rectangle(position.X + 779 + 5 + 20, position.Y + 25, 15, 100) });

        _figures.AddRange(GetWheel(new Point(position.X + 25 + 100 + 2 + 10 + 10, position.Y + 25 + 120)));
        _figures.AddRange(GetWheel(new Point(position.X + 464 + 120, position.Y + 25 + 120)));

        _figures.AddRange(GetPantograph(new Point(position.X + 200, position.Y - 20)));
    }

    private static void DrawRectangleWithBorder(Graphics g, Brush brush, Pen pen, Figure figure)
    {
        g.FillRectangle(brush, figure.Rectangle);
        g.DrawRectangle(pen, figure.Rectangle);
    }

    private void DrawDoors(Graphics graphics, Brush mainBrush, Brush windowBrush, Pen pen)
    {
        // 1
        DrawRectangleWithBorder(graphics, mainBrush, pen, _figures[1]);
        DrawRectangleWithBorder(graphics, mainBrush, pen, _figures[2]);
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[3]);
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[4]);

        // 2
        DrawRectangleWithBorder(graphics, mainBrush, pen, _figures[7]);
        DrawRectangleWithBorder(graphics, mainBrush, pen, _figures[8]);
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[9]);
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[10]);

        // 3
        DrawRectangleWithBorder(graphics, mainBrush, pen, _figures[13]);
        DrawRectangleWithBorder(graphics, mainBrush, pen, _figures[14]);
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[15]);
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[16]);
    }

    private void DrawWindows(Graphics graphics, Brush windowBrush, Pen pen)
    {
        // 1
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[5]);
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[6]);

        // 2
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[11]);
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[12]);

        // 3
        DrawRectangleWithBorder(graphics, windowBrush, pen, _figures[17]);
    }

    private static void DrawEllipseWithBorder(Graphics g, Brush brush, Pen pen, Figure figure)
    {
        g.FillEllipse(brush, figure.Rectangle);
        g.DrawEllipse(pen, figure.Rectangle);
    }

    private void DrawWheels(Graphics graphics, Brush tyreBrush, Brush wheelBrush, Pen pen)
    {
        // 1
        DrawEllipseWithBorder(graphics, tyreBrush, pen, _figures[18]);
        DrawEllipseWithBorder(graphics, wheelBrush, pen, _figures[19]);

        // 2 
        DrawEllipseWithBorder(graphics, tyreBrush, pen, _figures[20]);
        DrawEllipseWithBorder(graphics, wheelBrush, pen, _figures[21]);
    }

    private void DrawPantograph(Graphics graphics, Brush brush, Pen pen)
    {
        DrawRectangleWithBorder(graphics, brush, pen, _figures[22]);
        DrawRectangleWithBorder(graphics, brush, pen, _figures[23]);

        var rect = _figures[24].Rectangle;

        pen.Width = 2;
        pen.EndCap = pen.StartCap = LineCap.Round;

        graphics.DrawLine(pen, rect.Location, new Point(rect.X + rect.Size.Width, rect.Y + rect.Size.Height));
    }

    public void Draw(Graphics graphics, Color color)
    {
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        var mainBrush = new SolidBrush(color);
        var windowBrush = new SolidBrush(Color.PowderBlue);
        var tyreBrush = new SolidBrush(Color.FromArgb(46, 46, 46));
        var wheelBrush = new SolidBrush(Color.SlateGray);

        var pen = new Pen(Color.Black, 1);


        graphics.FillRectangle(mainBrush, _figures[0].Rectangle);

        DrawDoors(graphics, mainBrush, windowBrush, pen);
        DrawWindows(graphics, windowBrush, pen);
        DrawWheels(graphics, tyreBrush, wheelBrush, pen);
        DrawPantograph(graphics, mainBrush, pen);
    }
}