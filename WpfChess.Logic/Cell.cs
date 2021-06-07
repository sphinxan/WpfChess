
namespace WpfChess.Logic
{
    public class Cell
    {
        public Figures Name { get; set; }
        public Colors Color { get; set; }

        public Cell(Figures figure, Colors color)
        {
            Name = figure;
            Color = color;
        }
    }
}
