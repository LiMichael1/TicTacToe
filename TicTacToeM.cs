//Ruler:=1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3**
//Author: Michael Li
//Author's email: limichael@csu.fullerton.edu
//Course: CPSC223N

//Source files in this program: MouseClick.cs , TicTacToeF.cs, TicTacToeM.cs
//Purpose of this entire program:  Draw an X or O on a desired square on a tic tac toe grid. 
//determine the winner. 


//Name of this file: TicTacToeM.cs
//Purpose of this file: Launch the window showing the form where the graphical images will be displayed.
//
//Linux: The source files in this program should be compiled in the order specified below in order to satisfy dependencies.
//  1. MouseClick.cs  compiles into library file MouseClick.dll
//  2. TicTacToeF.cs      compiles into library file TicTacToeF.dll
//  3. TicTacToeM.cs       compiles and links with needed system files to created the executable file TicTacToe.exe
//Run the executable file by entering the command: ./TicTacToe.exe
//
//Compile (& link) this file: 
//mcs -r:System -r:System.Windows.Forms -r:TicTacToeF.dll -out:TicTacToe.exe TicTacToeM.cs
//Execute (Linux shell): ./TicTacToe.exe





using System;
using System.Windows.Forms;            //Needed for "Application.Run" near the end of Main function.
public class TicTacToeM
{  public static void Main()
   {  System.Console.WriteLine("The graphics program will begin now.");
      TicTacToeF tictactoe = new TicTacToeF();
      Application.Run(tictactoe);
      System.Console.WriteLine("This graphics program has ended.  Bye.");
   }//End of Main function
}//End of TicTacToeM class
