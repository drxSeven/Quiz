//Start Menu

using Quiz;

Console.WriteLine("Please select what core: 1 or 2");
int core = Convert.ToInt32(Console.ReadLine());

Random rnd = new Random();
int rNum = rnd.Next(1,1);

Quiz_One q = new Quiz_One();

bool on = true;
int wrong = 0;
int right = 0;

while (wrong <= 27)
{
    if (core == 1)
    {
        Console.WriteLine(q.Questions(1));
        Console.WriteLine(q.Options(1));
        int q1 = Convert.ToInt32(Console.ReadLine());
        string aa = q.Answering(rNum, q1);
        Console.WriteLine(aa);
        if (aa.Contains("Correct"))
        {
            right++;
            Console.WriteLine(right);
        }
        else
        {
            wrong++;
            Console.WriteLine(wrong);
        }
    }
    else if (core == 2)
    {

    }
    else
    {
        Console.WriteLine("Not a valid option");
    }
}