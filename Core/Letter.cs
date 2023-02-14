using System.Collections.Generic;
using System.Drawing;

namespace Core
{
    public class Letter
    {
        private List<Figure> _figures = new();

        public Letter(List<Figure> figures)
        {
            _figures = new(figures);
        }

        public void Draw(Graphics graphics, Color color, Color backgroundColor)
        {
            var mainBrush = new SolidBrush(color);
            var secondBrush = new SolidBrush(backgroundColor);

            foreach (var figure in _figures)
            {
                if (!figure.IsCutting)
                    graphics.FillRectangle(mainBrush, figure.Rectangle);
                else
                    graphics.FillRectangle(secondBrush, figure.Rectangle);
            }
        }

        public static Letter GetLetterЗ(Point position)
            => new Letter(new List<Figure>()
            {
                new() { Rectangle = new Rectangle(position.X, position.Y, 125, 290) },
                new() { Rectangle = new Rectangle(position.X, position.Y + 30, 80, 100), IsCutting = true },
                new() { Rectangle = new Rectangle(position.X, position.Y + 30 + 30 + 100, 80, 100), IsCutting = true }
            });
        
        public static Letter GetLetterН(Point position)
            => new Letter(new List<Figure>()
            {
                new() { Rectangle = new Rectangle(position.X, position.Y, 50, 290) },
                new() { Rectangle = new Rectangle(position.X+50, position.Y+120, 25, 50)},
                new() { Rectangle = new Rectangle(position.X+75, position.Y, 50, 290) }
            });
        
        public static Letter GetLetterЭ(Point position)
            => new Letter(new List<Figure>()
            {
                new() { Rectangle = new Rectangle(position.X, position.Y, 125, 290) },
                new() { Rectangle = new Rectangle(position.X, position.Y + 30, 80, 100), IsCutting = true },
                new() { Rectangle = new Rectangle(position.X, position.Y + 30 + 30 + 100, 80, 100), IsCutting = true },
                new() {Rectangle = new Rectangle(position.X, position.Y, 30, 50)},
                new() {Rectangle = new Rectangle(position.X, 290 - position.Y - 30, 30, 50)}
            });
    }
}