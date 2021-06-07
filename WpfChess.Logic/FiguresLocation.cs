using System.IO;

namespace WpfChess.Logic
{
    public enum Figures { P , R , H , B , K , Q  }
    public enum Colors { Black, White }

    public class FiguresLocation
    {
        public Cell[,] cell = new Cell[8, 8];

        public void FigureStartLocaton()
        {
            for (int i = 0; i < 8; i++)
            {
                cell[i, 1] = new Cell(Figures.P, Colors.Black);
                cell[i, 6] = new Cell(Figures.P, Colors.White);
            }

            cell[0, 0] = new Cell(Figures.R, Colors.Black);
            cell[0, 7] = new Cell(Figures.R, Colors.White);
            cell[7, 0] = new Cell(Figures.R, Colors.Black);
            cell[7, 7] = new Cell(Figures.R, Colors.White);

            cell[1, 0] = new Cell(Figures.H, Colors.Black);
            cell[1, 7] = new Cell(Figures.H, Colors.White);
            cell[6, 0] = new Cell(Figures.H, Colors.Black);
            cell[6, 7] = new Cell(Figures.H, Colors.White);

            cell[2, 0] = new Cell(Figures.B, Colors.Black);
            cell[2, 7] = new Cell(Figures.B, Colors.White);
            cell[5, 0] = new Cell(Figures.B, Colors.Black);
            cell[5, 7] = new Cell(Figures.B, Colors.White);

            cell[3, 0] = new Cell(Figures.Q, Colors.Black);
            cell[3, 7] = new Cell(Figures.Q, Colors.White);

            cell[4, 0] = new Cell(Figures.K, Colors.Black);
            cell[4, 7] = new Cell(Figures.K, Colors.White);
        }

        public void FigureContinueLocaton()
        {
            string[] boardInFile = File.ReadAllLines("Board.txt");
            string[,] board = new string[8, 8];

            for (int i = 0; i < 8; i++)
            {
                string[] a = boardInFile[i].Split(' ');

                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = a[j];
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < boardInFile.Length; j++)
                {
                    switch (board[j, i][0])
                    {
                        case 'P':
                            cell[i, j] = new Cell(Figures.P, Colors.Black);
                            break;
                        case 'R':
                            cell[i, j] = new Cell(Figures.R, Colors.Black);
                            break;
                        case 'H':
                            cell[i, j] = new Cell(Figures.H, Colors.Black);
                            break;
                        case 'B':
                            cell[i, j] = new Cell(Figures.B, Colors.Black);
                            break;
                        case 'Q':
                            cell[i, j] = new Cell(Figures.Q, Colors.Black);
                            break;
                        case 'K':
                            cell[i, j] = new Cell(Figures.K, Colors.Black);
                            break;
                    }
                    if (board[j, i - 1][1] == 'W')
                        cell[i, j].Color = Colors.White;
                }
            }
        }
    }
}
