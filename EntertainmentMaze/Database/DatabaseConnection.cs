﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EntertainmentMaze.maze;
using System.IO;

namespace EntertainmentMaze.Database
{
    public class DatabaseConnection
    {
        //NEED TO MAKE DYNAMIC
        private static readonly string connectionString = @"Data Source = C:\Users\Sam\source\repos\TriviaMaze_cs\TriviaMaze\EntertainmentMaze\bin\TriviaDatabase.db;";
        private static readonly string cmdString = "SELECT * FROM QUESTION;";
        public SQLiteConnection GetConnection()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=TriviaDatabase.db");

            try
            {
                sqlite_conn.Open();
                return sqlite_conn;
            }
            catch(Exception)
            {
                throw new ArgumentException(nameof(sqlite_conn));
            }
        }

        public List<Question> ReadData()
        {
            List<Question> questionCollection = new List<Question>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using(SQLiteCommand sQLiteCommand = new SQLiteCommand(cmdString,connection))
                {
                    SQLiteDataReader sqliteDatareader = sQLiteCommand.ExecuteReader();

                    while (sqliteDatareader.Read())
                    {

                        int questionID = sqliteDatareader.GetInt32(0);
                        int answerID = sqliteDatareader.GetInt32(1);
                        string answer = "";
                        int typeID = sqliteDatareader.GetInt32(2);
                        var question = sqliteDatareader.GetString(3);

                        string answerIDString = answerID.ToString();

                        SQLiteCommand answerCommand = new SQLiteCommand("SELECT ANSWER FROM ANSWER WHERE ANSWERID ="+ answerIDString + ";", connection);

                        SQLiteDataReader sqliteDatareaderForAnswer = answerCommand.ExecuteReader();

                        while(sqliteDatareaderForAnswer.Read())
                        {
                            answer = sqliteDatareaderForAnswer.GetString(0);
                        }
                        
                        Question q = new Question(questionID, answerID, typeID, question, answer);
                        questionCollection.Add(q);
                    }

                    connection.Close();

                    return questionCollection;
                }
            }
        }

        private string GetDirForDatabase()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
