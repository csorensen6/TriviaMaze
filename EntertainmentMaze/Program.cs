﻿using EntertainmentMaze.maze;
using System;

namespace EntertainmentMaze
{
    public class Program
    {
        public static void Main()
        {
            var mazeBuilder = new MazeBuilder();
            var newPlayer = new Player(Player.GetName("FirstName"), Player.GetName("LastName"));
            Maze playerMaze = mazeBuilder
                .SetRows(5)
                .SetColumns(5)
                .SetPlayer(newPlayer)
                .Build();
        }

    }
}
