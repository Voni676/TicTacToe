using System;
namespace Mission3Assignment
{
    class Driver
    {
        static void Main(string[] args)
        {
            // welcome user to game
            Console.WriteLine("Welcome to Group 3 - 7s Game of Tic - Tac - Toe!");
            //Create a game board array to store the players’ choices
            char[] game_board = new char[9];
            for (int i = 0; i < game_board.Length; i++)
            {
                game_board[i] =  Convert.ToChar (i + 1);
            }
            Supporter support = new Supporter();
            support.board = game_board;
            support.display_board();
            //Ask each player in turn for their choice and update the game board array
            
            for (int i = 0; i < game_board.Length; i++)
            {
            Console.WriteLine("Player" + ((i % 2) + 1) + ", please make your choice: ");
            int position = int.Parse(Console.ReadLine());
            if ((game_board[position - 1] == 'X') || (game_board[position - 1] == 'O'))
        {
                Console.WriteLine("That position already has been Selected");
                i--;
            }
        else
            {
                if ((i % 2) == 0)
                {
                    game_board[position - 1] = 'X';
                }
                else
                {
                    game_board[position - 1] = 'O';
                }
                // Print the board by calling the method in the supporting class
                support.display_board();
                // Check for a winner by calling the method in the supporting class, and notify the players when a win has occurred and which player won the game
                  
                    int winner = support.Check_winner(game_board, i);
                    
                    if (winner > 0)
                    {
                        Console.WriteLine("Player " + winner + " wins!");
                        break;
                   
                    }
                    else if (i == 8)
                    {
                        Console.WriteLine("It’s a draw!");
                        break;
                    }
            }
        }
    }
}
class Supporter
{
    // Receive the “board” array from the driver class
    public char[] board { get; set; }
    // Contain a method that prints the board based on the information passed in
    public void display_board()
    {
        Console.WriteLine("-------------");
        for (int j = 0; j < board.Length; j++)
        {
            if (board[j] == 'X' || board[j] == 'O')
        {
            Console.Write("| " +board[j] + " |");
        }
        else
        {
            Console.Write("| "+(j + 1) + " |");
        }
        if ((j + 1) % 3 == 0)
        {
            Console.WriteLine();
        }
    }
    Console.WriteLine("-------------");
    }
// Contain a method that receives the game board array as input and returns if there is a winner and who it was
    public int Check_winner(char[] board, int turn)
    {
            bool yay = true;
            while (yay) 
            { 
                int winner = 0;
                
                if (
                  (board[0] == board[1] && board[1] == board[2])
                  || (board[3] == board[4] && board[4] == board[5])
                  || (board[6] == board[7] && board[7] == board[8])
                  || (board[0] == board[3] && board[3] == board[6])
                  || (board[1] == board[4] && board[4] == board[7])
                  || (board[2] == board[5] && board[5] == board[8])
                  || (board[0] == board[4] && board[4] == board[8])
                  || (board[2] == board[4] && board[4] == board[6])
                  )
                {
                    winner = (turn % 2) + 1;
                }
                
                return winner;
                
              
            }
            return 1;
}
  }
}