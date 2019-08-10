//Ruler:=1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3**
//Author: Michael Li
//Author's email: limichael@csu.fullerton.edu
//Course: CPSC223N
//Assignment number: 2

//Source files in this program: MouseClick.cs , TicTacToeF.cs , TicTacToeM.cs
//
//Name of this file: MouseClick.cs
//Purpose of this file: Gets the location of the mouse wherever you click.

//Compile this file: 
//mcs -target:library -r:System.Windows.Forms -r:System.Drawing -out:MouseClick.dll MouseClick.cs






using System;
using System.Drawing;
using System.Windows.Forms;

public class MouseClick: Button
{ Point p = new Point();
  public Point get_mouse_location()
  {return p;
  }
  protected override void OnMouseDown(MouseEventArgs me)
   {  p.X = me.X;
      p.Y = me.Y;
   }
}//End of Enhanced_button
