//Start Menu

using Quiz;



Console.WriteLine("How many questions?");
int questions = Convert.ToInt32(Console.ReadLine());

Random rnd = new Random();
int rNum = rnd.Next(1,10);

Quiz_One q = new Quiz_One();

int wrong = 0;
int right = 0;
int total = 0;

while(questions > 0)
{
    //asks a random question
    Console.WriteLine(q.Questions(rNum));
    //correlating options for the question
    Console.WriteLine(q.Options(rNum));

    //answer to question
    int answer = Convert.ToInt32(Console.ReadLine());
    //checks if answer is corrct
    string correctOrWrong = q.Answering(rNum, answer);

    if (correctOrWrong.Contains("Correct"))
    {
        questions--;
        right++;
        total++;
        rNum = rnd.Next(1, 10);
        Console.Clear();
        Console.WriteLine("Correct!" + right + " total right " + total + " overall score ");
    }
    else if (correctOrWrong.Contains("Wrong"))
    {
        if(total < 0)
        {
            questions = -1;
            Console.Clear();
            Console.WriteLine("Game Over!");
        }
        else
        {
            questions--;
            wrong++;
            total--;
            Console.Clear();
            Console.WriteLine("Wrong! " + wrong + " total wrong " + total + " overall score");
        }
    }
}