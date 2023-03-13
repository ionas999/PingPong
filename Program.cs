const int COLUMS = 80;
const int ROWS = 25;
const int DELAY = 50;
int xPos;
int yPos;
int hoizontalMulitplyer = 1;
int verticalMultiplyer = -1;
Random random = new Random();
bool xBeforePoitive = true, yBeforePositive = false;

void Initialize()
{
    Console.SetWindowSize(COLUMS, ROWS);
    Console.CursorVisible = false;
}

void DeleteBall(int x, int y)
{
    Console.SetCursorPosition(x, y);
    Console.Write(" ");
}

void ShowBall(int x, int y)
{
    Console.SetCursorPosition(x, y);
    Console.Write("*");
}

void MoveBall(ref int xPos, ref int yPos, ref int xMovement, ref int yMovement)
{
    xPos += xMovement;
    yPos += yMovement;

    if(xPos <= 0 || xPos > COLUMS)
    {
        if (xMovement == 0)
        {
            if (xBeforePoitive)
                xMovement = 1;
            else
                xMovement = -1;

        }

        if (random.Next(1, 5) == 3)
        {
            xBeforePoitive = xMovement > 0;
            xMovement *= 0;
        }
            
        else
            xMovement *= -1;
    }

    if(yPos <= 0 || yPos > ROWS)
    {
        if (yBeforePositive)
            yMovement = 1;
        else
            yMovement = -1;


        if (random.Next(1, 5) == 3)
        {
            yBeforePositive = yMovement > 0;
            yMovement *= 0;
            
        }

        else
            yMovement *= -1;
    }
}


Initialize();
xPos = COLUMS / 2;
yPos = ROWS / 2;
ShowBall(COLUMS/2, ROWS/2);


while (!Console.KeyAvailable)
{
    DeleteBall(xPos, yPos);
    MoveBall(ref xPos, ref yPos, ref hoizontalMulitplyer, ref verticalMultiplyer);
    ShowBall(xPos, yPos);
    Thread.Sleep(TimeSpan.FromMilliseconds(DELAY));
    
}
