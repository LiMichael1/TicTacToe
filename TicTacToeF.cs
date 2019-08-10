//Ruler:=1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3**
//Author: Michael Li
//Author's email: limichael@csu.fullerton.edu
//Course: CPSC223N

//Source files in this program: MouseClick.cs, TicTacToeF.cs, TicTacToeM.cs
//Purpose of this entire program:  Create a functional Tic Tac Toe game

//Name of this file: TicTacToeF.cs
//Purpose of this file: Define the user interface. 

//Compile this file: 
//mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:MouseClick.dll -out:TicTacToeF.dll TicTacToeF.cs

using System;
using System.Drawing;
using System.Windows.Forms;

public class TicTacToeF : Form
{  private const int formwidth = 1280;  
   private const int formheight = 720;  //form measurements
   
   private const int penwidth = 3;

   private Label title = new Label();
 
   private Font style_of_message = new System.Drawing.Font("Arial",12,FontStyle.Regular);
   private Button quitbutton = new Button();
   private Pen ballpointpen = new Pen(Color.Red,penwidth);
   private Brush writing_tool = new SolidBrush(System.Drawing.Color.Black);
   //LOCATIONS
   private Point location_of_message = new Point(425,640);
   private Point location_of_title = new Point(600,20);
   private Point location_of_group_box_button = new Point(150,635);
   private Point location_of_new_game_button= new Point(800,640);
   private Point location_of_quit_button = new Point(980,640);
   private int cursor_x = 0; //coordinate of mouse
   private int cursor_y = 0; //coordinate of mouse

   private String currentplayer = "";
   private Point winner_location = new Point(425, 645);
   private Font style_of_player = new System.Drawing.Font("Arial",150,FontStyle.Bold);
   //RADIO BUTTONS
   private RadioButton X_button = new RadioButton();
   private RadioButton O_button = new RadioButton();
   //GROUP BOX
   private GroupBox classLevel = new GroupBox();
   
   private Button newgamebutton= new Button();
   //MESSAGE
   private String winner= "(Undecided)."; 
   private String winner_message = "The winner is Player ";
   private String winning_message;
   private String big_message;
   private bool radiobutton_check = false;
   //Square
   
   private bool square1_visible= false;
   private bool square2_visible= false;
   private bool square3_visible= false;
   private bool square4_visible= false;
   private bool square5_visible= false;
   private bool square6_visible= false;
   private bool square7_visible= false;
   private bool square8_visible= false;
   private bool square9_visible= false;
   private String square1;
   private String square2;
   private String square3;
   private String square4;
   private String square5;
   private String square6;
   private String square7;
   private String square8;
   private String square9; 

   public TicTacToeF()   //The constructor of this class
   {  //Set the title of this form.
      Text = "Tic Tac Toe by Michael Li";
      System.Console.WriteLine("formwidth = {0}. formheight = {1}.",formwidth,formheight);
      //Set the initial size of this form
      Size = new Size(formwidth,formheight);
      //Set the background color of this form
      BackColor = Color.White;
      title.Text = "Game";
      title.Size = new Size(40,18);
      title.Location = location_of_title;
      title.BackColor = Color.SkyBlue;
      
      quitbutton.Text = "Exit";
      quitbutton.Size = new Size(85,25);
      quitbutton.Location = location_of_quit_button;
      quitbutton.BackColor = Color.Pink;
      //current player size
      
      //New Game button
      newgamebutton.Text = "New Game";                             
      newgamebutton.Size = new Size (85,25);
      newgamebutton.Location = location_of_new_game_button;
      newgamebutton.BackColor = Color.Pink;
      //x radio button
      X_button.Text = "X";
      X_button.Size = new Size(50,20);
      X_button.ForeColor = Color.Black;
      X_button.Enabled = true;
      X_button.AutoCheck= true;
      //y radio button
      O_button.Text = "O";
      O_button.Size = new Size(50,20);
      O_button.ForeColor = Color.Black;
      O_button.Enabled = true;
      
      //Group Box
      classLevel.Text = "Player";
      classLevel.Size= new System.Drawing.Size(200,55);
      classLevel.BackColor = Color.Gray;
      classLevel.ForeColor = Color.Black;
      classLevel.Font = new Font("Arial", 12,FontStyle.Bold);
      classLevel.Location= location_of_group_box_button;

      //location of radio button
      X_button.Location = new System.Drawing.Point(15,20);
      O_button.Location = new System.Drawing.Point(115,20);

      //Add radio buttons to group box
      classLevel.Controls.Add(X_button);
      classLevel.Controls.Add(O_button);
      
      //Controls
      Controls.Add(title);
      Controls.Add(classLevel);
      Controls.Add(quitbutton);
      Controls.Add(newgamebutton); 
      //Event Handlers
      newgamebutton.Click += new EventHandler(NewGame);
      X_button.Click += new EventHandler(WelcomePlayer);
      O_button.Click += new EventHandler(WelcomePlayer);
      quitbutton.Click += new EventHandler(exitfromthisprogram);
   }//End of constructor

   //start of ONPAINT GRAPHICS
   protected override void OnPaint(PaintEventArgs ee)
   {  Graphics graph = ee.Graphics;
      
      graph.FillRectangle(Brushes.Yellow,0,620,formwidth,73);
      
      winning_message = winner_message + winner;
      //THE WINNER
      graph.DrawString(winning_message,style_of_message,writing_tool,winner_location);
      //GRID LINES FOR TIC TAC TOE
      graph.DrawLine(ballpointpen, 426, 0, 426,620);
      graph.DrawLine(ballpointpen, 853, 0, 853,620);
      graph.DrawLine(ballpointpen, 0, 206, 1280, 206);
      graph.DrawLine(ballpointpen, 0, 413, 1280, 413);

         
      //DEPENDING ON WHICH SQUARE IS CLICKED, PROGRAM WILL DRAW X OR O TO THAT SQUARE. 
      if(square1_visible){
      graph.DrawString(square1, style_of_player,writing_tool, 200, 0);
      }  //alternates between x and o 
      if(square2_visible){
      graph.DrawString(square2, style_of_player,writing_tool, 600,0);
      }
      if(square3_visible){
      graph.DrawString(square3, style_of_player,writing_tool, 1000, 0);
      }
      if(square4_visible){
      graph.DrawString(square4, style_of_player,writing_tool, 200, 206);
      }
      if(square5_visible){
      graph.DrawString(square5, style_of_player,writing_tool, 600, 206);
      }
      if(square6_visible){
      graph.DrawString(square6, style_of_player,writing_tool, 1000, 206);
      }
      if(square7_visible){
      graph.DrawString(square7, style_of_player,writing_tool, 200, 413);
      }
      if(square8_visible){
      graph.DrawString(square8, style_of_player,writing_tool, 600, 413);
      }
      if(square9_visible){
      graph.DrawString(square9, style_of_player,writing_tool, 1000, 413);
      }
      //The next statement looks like recursion, but it really is not recursion.
      //In fact, it calls the method with the same name located in the super class.
      base.OnPaint(ee);
   }
   //reaction to radio buttons
   protected void WelcomePlayer(Object sender, EventArgs events)
   {  
      if (sender == X_button)
        {
            currentplayer = X_button.Text;
            X_button.Enabled = false;
            O_button.Enabled = true;
	    O_button.Checked = true;
	    
	    //radiobutton alternating
	    
	    System.Console.WriteLine("X");
	    
        }
      else if (sender == O_button)
        {
            currentplayer = O_button.Text;
	    O_button.Enabled = false;
            X_button.Enabled = true;
            X_button.Checked = true;
	    //radiobutton alternating
	    
	    System.Console.WriteLine("O");    
	    
        }
   }
   //CHANGES THE X AND O BASED ON WHAT CURRENT PLAYER WAS PREVIOUSLY 
   protected void Check_changed()
   {    radiobutton_check = !radiobutton_check;
	if(radiobutton_check)
		currentplayer = O_button.Text;
	if(radiobutton_check == false)
		currentplayer = X_button.Text;
   }
   
   protected void NewGame(Object sender, EventArgs events)
   {     //clear the board first, then select first player
	square1_visible = false;
	square2_visible = false;
	square3_visible = false;
	square4_visible = false;
	square5_visible = false;
	square6_visible = false;
	square7_visible = false;
	square8_visible = false;
	square9_visible = false;

	X_button.Enabled = true;
	O_button.Enabled = true;
	X_button.Checked = false;
        O_button.Checked = false;
        
	Invalidate();
   }
   //determines where you click
   protected void WhichSquare(int x , int y){  
	
		if(x > 0 && x < 426 && y > 0 && y < 206){//1
		square1 = currentplayer;
		square1_visible= true;
		Check_changed();
          	}
		else if(x > 427 && x < 853 && y > 0 && y < 206){//2
		square2 = currentplayer;
		square2_visible= true;
		Check_changed();
          	}
		else if(x > 854 && x < 1280 && y > 0 && y < 206){//3
		square3 = currentplayer;
		square3_visible= true;
		Check_changed();
          	}
		else if(x > 0 && x < 426 && y > 207 && y < 413){//4
		square4 = currentplayer;
		square4_visible= true;
		Check_changed();
          	}
		else if(x > 427 && x < 853 && y > 207 && y < 413){//5
		square5 = currentplayer;
		square5_visible= true;
		Check_changed();
          	}
   		else if(x > 854  && x < 1280 && y > 207 && y < 413){//6
		square6 = currentplayer;
		square6_visible= true;
		Check_changed();
          	}
		else if(x > 0 && x < 426 && y > 413 && y < 620){//7
		square7 = currentplayer;
		square7_visible= true;
		Check_changed();
          	}
		else if(x > 427 && x < 853 && y > 413 && y < 620){//8
		square8 = currentplayer;
		square8_visible= true;
		Check_changed();
          	}
		else if(x > 854 && x < 1280 && y > 413 && y < 620){//9
		square9 = currentplayer;
		square9_visible= true;
		Check_changed();
          	}
        
   }
   
   //Determines the winner
   protected void Winner() 
   {
	
		if(square1 == square2 && square2 == square3)
			winner= square1;
		else if(square1 == square5 && square5 == square9)
			winner= square1;
		else if(square1 == square4 && square4 == square7)
			winner= square1;
		else if(square2 == square5 && square5 == square8)
			winner= square2;
		else if(square3 == square6 && square6 == square9)
			winner= square3;
		else if(square3 == square5 && square5 == square7)
			winner= square3;
		else if(square4 == square5 && square5 == square6)
			winner= square4;
		else if(square7 == square8 && square8 == square9)
			winner= square7;
		else
			winner= "Nobody";
	
   }
   
   

   protected override void OnMouseDown( MouseEventArgs me)
   {  cursor_x = me.X;
      cursor_y = me.Y;
      WhichSquare(cursor_x,cursor_y);            //determines the square
      Invalidate();   
      Winner();
   }

   protected void exitfromthisprogram(Object sender,EventArgs events)
   {  System.Console.WriteLine("This program will end execution.");
      Close();
   }
 
   

}//End of class TicTacToe Frame class




