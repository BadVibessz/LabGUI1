using System.Drawing;

namespace Core;

public class Figure
{
    public Rectangle Rectangle { get; set; }
    public bool IsCutting { get; set; } = false;
    public string Name { get; set; } = "Unknown";
}