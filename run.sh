#!/bin/bash


#Author: Michael Li
#Course: CPSC223n

#Linux: The source files in this program should be compiled in the order specified below in order to satisfy dependencies.
#  1. MouseClick.cs      compiles into library file MouseClick.dll
#  2. TicTacToeF.cs      compiles into library file TicTacToeF.dll
#  3. TicTacToeM.cs      compiles and links with needed system files to created the executable file TicTacToe.exe

#enter the command: sh run.sh

echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo Compile MouseClick.cs to create the file: MouseClick.dll
mcs -target:library -r:System.Windows.Forms -r:System.Drawing -out:MouseClick.dll MouseClick.cs

echo Compile TicTacToeF.cs to create the file: TicTacToeF.dll
mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:MouseClick.dll -out:TicTacToeF.dll TicTacToeF.cs

echo "Compile TicTacToeM.cs and link previously created dll file(s) to create an executable file."
mcs -r:System -r:System.Windows.Forms -r:TicTacToeF.dll -out:TicTacToe.exe TicTacToeM.cs

echo View the list of files in the current folder
ls -l

echo Run the Assignment 1 program.
./TicTacToe.exe

echo The script has terminated.












