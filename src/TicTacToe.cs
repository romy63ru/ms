public class TicTacToe
{
    int[,] board;
    int n;

    public TicTacToe(int n)
    {
        board = new int[n, n];
        this.n = n;
    }

    public int Move(int row, int col, int player)
    {
        board[row, col] = player;
        int k = 0;
        //check rows
        for (int i = 0; i < n; i++)
        {
            k = 0;
            for (int j = 0; j < n; j++)
            {
                if (board[i, j] == board[i, 0] && board[i, j] > 0)
                {
                    k++;
                }
                else
                {
                    continue;
                }
                if (k == n)
                {
                    return board[i, 0];
                }
            }
        }
        //check columns
        for (int i = 0; i < n; i++)
        {
            k = 0;
            for (int j = 0; j < n; j++)
            {
                if (board[j, i] == board[0, i] && board[j, i] > 0)
                {
                    k++;
                }
                else
                {
                    continue;
                }
                if (k == n)
                {
                    return board[0, i];
                }
            }
        }
        //check diagonals
        k = 0;
        for (int i = 0; i < n; i++)
        {
            if (board[i, i] == board[0, 0] && board[i, i] > 0)
            {
                k++;
            }
            else
            {
                continue;
            }
            if (k == n)
            {
                return board[0, 0];
            }

        }
        k = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (board[n-i-1, i] == board[0, n - 1] && board[0, n - 1] > 0)
            {
                k++;
            }
            else
            {
                continue;
            }
            if (k == n)
            {
                return board[0, n - 1];
            }
        }
        return 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */