using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal class Quiz_One
    {
        public int number { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        public string options { get; set; }
        public string correction { get; set; }

        SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=quizQ;user id=sa;password=p@s3rd!");

        public string Questions(int number)
        {

            SqlCommand cmd = new SqlCommand("select * from quiz where number=@number", con);
            cmd.Parameters.AddWithValue("number", number);
            con.Open();
            SqlDataReader readARow = cmd.ExecuteReader();
            if (readARow.Read())
            {
                Quiz_One s = new Quiz_One();
                {
                    question = Convert.ToString(readARow[1]);
                    con.Close();
                }; return question;
            }
            else
            {
                return "not a thing";
            }
        }

        public string Options(int number)
        {
            SqlCommand cmd = new SqlCommand("select * from quiz where number=@number", con);
            cmd.Parameters.AddWithValue("number", number);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Quiz_One s = new Quiz_One();
                {
                    options = Convert.ToString(reader[2]);
                    con.Close();
                }; return options.Replace(',', '\n');
            }
            else
            {
                return "Not a thing";
            }

        }

        public string Answering(int number, int ans)
        {
            SqlCommand cmd = new SqlCommand("select * from quiz where number=@number", con);
            cmd.Parameters.AddWithValue("number", number);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Quiz_One s = new Quiz_One();
                {
                    options = Convert.ToString(reader[2]);
                    answer = Convert.ToString(reader[3]);
                    correction = Convert.ToString(reader[4]);

                    string[] opArr = options.Split(',');

                    string plus = "";

                    switch (ans)
                    {
                        case 1:
                            if (opArr[0].Contains(answer))
                            {
                                plus = "Correct! " + correction;
                            }
                            else
                            {
                                
                                plus = "Wrong! " + correction;
                            }
                            break;
                        case 2:
                            if (opArr[1].Contains(answer))
                            {
                                plus = "Correct! " + correction;
                            }
                            else
                            {
                                plus = "Wrong! " + correction;
                            }
                            break;
                        case 3:
                            if (opArr[2].Contains(answer)){
                                plus = "Correct! " + correction;
                            }
                            else
                            {
                                plus = "Wrong! " + correction;
                            }
                            break;
                        default:
                            plus = "not an option";
                            break;
                    }
                    con.Close();
                    return plus;
                    
                } 
            }
            else
            {
                return "Not a thing";
            }




        }
    }

    }

