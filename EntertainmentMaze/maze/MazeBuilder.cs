﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentMaze.maze
{
    public class MazeBuilder
    {
        internal Maze Maze = new Maze();
        private bool FinishedBuild = false;

        public Maze Build()
        {
            Maze.CompleteBuild();
            FinishedBuild = true;
            return Maze;
        }

        public MazeBuilder SetRows(int rows)
        {
            Check();
            Maze.Rows = rows;
            return this;
        }

        public MazeBuilder SetColumns(int columns)
        {
            Check();
            Maze.Columns = columns;
            return this;
        }

        public MazeBuilder SetPlayer(Player player)
        {
            Check();
            Maze.Player = player;
            return this;
        }


        private void Check()
        {
            if(FinishedBuild)
            {
                throw new ArgumentException("Do use other builder to create new instance");
            }
        }
    }
}
