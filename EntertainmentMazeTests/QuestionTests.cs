﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EntertainmentMaze;
using EntertainmentMaze.Database;
using EntertainmentMaze.maze;

namespace EntertainmentMazeTests
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void ConnectionToDatabase_Successful()
        {
            DatabaseListRetrieval databaseConnection = new DatabaseListRetrieval();
            //List<Question> expectedQuestions = databaseConnection.ReadData();

            Console.WriteLine();
        }
    }
}
