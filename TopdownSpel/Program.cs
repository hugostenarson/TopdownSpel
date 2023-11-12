using System.Numerics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Raylib_cs;

// Random generator = new Random();

// List<string> names = new List<string>() {"Martin", "Lena", "Nicholas", "Christian"};
// names.Add("Micke");
// names.Add("Yoko");


// foreach(string name in names)
// {
//     Console.WriteLine(name);
// }

// int i = generator.Next(names.Count);

// int i = 0;

// for (int i = 0; i < names.Count; i++)
// {
//     Console.WriteLine(names[i]);
// }
// while (i < 6)
// {
// Console.WriteLine(names[i]);
// i++;
// }

// Console.WriteLine(names[i]);
// i++;
// Console.WriteLine(names[i]);
// i++;
// Console.WriteLine(names[i]);
// i++;
// Console.WriteLine(names[i]);
// i++;
// Console.WriteLine(names[i]);

// Console.WriteLine(names[i]);

// Console.ReadLine();

Raylib.InitWindow(800,600,"Hello");
Raylib.SetTargetFPS(60);
// int x = 0;



Color hotPink = new Color(255, 105, 180, 255);
Vector2 position = new Vector2(0, 100);
Vector2 movement = new Vector2(2, 1);

Rectangle characterRect = new Rectangle(300, 400, 64, 64);
Rectangle doorRect = new Rectangle(600, 50, 50, 50);
Rectangle doorRect2 = new Rectangle(200, 300, 50, 50);

Texture2D gubbe = Raylib.LoadTexture("gubbe.png");

List<Rectangle> walls = new();

walls.Add(new Rectangle(32, 32, 32, 128));
walls.Add(new Rectangle(32, 32, 128, 32));
walls.Add(new Rectangle(128, 32, 32, 128));
walls.Add(new Rectangle(128, 32, 128, 32));


UndoX = Boolean;
UndoY = Boolean;
float speed = 5;

string scene = "start";

string yes = "YES";


while (!Raylib.WindowShouldClose())
{
    if (scene == "game")
    {
     movement = Vector2.Zero;

if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
{
    movement.Y = -1;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_S))
{
    movement.Y = 1;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_A))
{
    movement.X = -1;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_D))
{
    movement.X = 1;
}

if (movement.Length() > 0)
{
    movement = Vector2.Normalize(movement) * speed;
}
characterRect.x += movement.X;
characterRect.y += movement.Y;
}


// Kolla kollisioner

if(Raylib.CheckCollisionRecs(characterRect, doorRect))
{
    doorRect.x = 0;
    Console.WriteLine(yes);
    Console.WriteLine("NO");
    scene = "room2";
}
foreach(Rectangle wall in walls)
{
if (Raylib.CheckCollisionRecs(characterRect, wall))
{
    scene = "finished";
    UndoX == true;
    UndoY == true;
}
}

if (UndoX == true)
{
    characterRect.x -= movement.X;
}

if (UndoY == true)
{
characterRect.y -= movement.Y;
}

if (doorRect.x == 0)
{
if(Raylib.CheckCollisionRecs(characterRect, doorRect2))
{
    doorRect2.x = 0;
    scene = "finished";
}
}

if (doorRect2.x == 0)
{
    scene = "finished";
}

if (scene == "room2") 
{
    movement = Vector2.Zero;

if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
{
    movement.Y = -1;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_S))
{
    movement.Y = 1;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_A))
{
    movement.X = -1;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_D))
{
    movement.X = 1;
}

    if (movement.Length() > 0)
{
    movement = Vector2.Normalize(movement) * speed;
}
characterRect.x += movement.X;
characterRect.y += movement.Y;
}

else if (scene == "start")
{
if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) {
    scene = "game";
}
}






// Gubben hamnar på andra motsatt sida ifall den åker utanför rutan
if (characterRect.x > 744)
{
    characterRect.x = 744;
}

if (characterRect.x < -8)
{
    characterRect.x = -8;
}

if(characterRect.y > 536)
{
    characterRect.y = 536;
}

if (characterRect.y < -16)
{
    characterRect.y = -16;
}


Raylib.BeginDrawing();
if (scene == "game")
{
    Raylib.ClearBackground(Color.VIOLET);
    Raylib.DrawText("ROOM 1", 10, 10, 32, Color.WHITE);
    Raylib.DrawTexture(gubbe, (int)characterRect.x, (int)characterRect.y, Color.WHITE);
    Raylib.DrawRectangleRec(doorRect, Color.MAGENTA);
    foreach(Rectangle wall in walls)
    {
        Raylib.DrawRectangleRec(wall, Color.BLACK);
    }
    Raylib.DrawRectangleRec(walls[0], Color.BLACK);
    Raylib.DrawRectangleRec(walls[1], Color.BLACK);
    // Raylib.DrawRectangleRec(walls[2], Color.BLACK);
}

else if (scene == "start")
{
    Raylib.ClearBackground(Color.GREEN);
    Raylib.DrawText("PRESS SPACE TO START", 10, 10, 32, Color.WHITE);
}

if (scene == "room2")
{
    Raylib.ClearBackground(Color.WHITE);
    Raylib.DrawText("ROOM 2", 10, 10, 32, Color.BLACK);
    Raylib.DrawTexture(gubbe, (int)characterRect.x, (int)characterRect.y, Color.WHITE);
    Raylib.DrawRectangleRec(doorRect2, Color.BLACK);
}

else if (scene == "finished")
{
    Raylib.DrawText("FINISH!", 310, 280, 40, Color.WHITE);
    Raylib.ClearBackground(Color.RED);
    
}

// Raylib.DrawTexture(gubbe, (int)characterRect.x, (int)characterRect.y, Color.WHITE);
// Raylib.DrawRectangleRec(doorRect, Color.BLACK);

    // Raylib.DrawCircleV(position, 50, hotPink);
    // Raylib.DrawCircle(x,300,25, hotPink);

    // Raylib.DrawRectangle(20, 500, 400, 50, Color.BLACK);
   // Raylib.DrawRectangleRec(characterRect, Color.WHITE);



Raylib.EndDrawing();
}
