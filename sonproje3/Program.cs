using System;
using System.Threading;

namespace CENG_chess
{
    class Program
    {
        public static int green_piece_selector_x = 7;
        public static int green_piece_selector_y = 25;
        public static int tempx, tempy;
        //public static int[] green_pawnx = new int [] { 7, 12, 17, 22, 27, 32, 37, 42 }; // x locations of green pawns 
        //public static int[] green_pawny = new int[] { 22, 22, 22, 22, 22, 22, 22, 22 };//y locations of green pawns
        public static int[] green_piecesx = new int[] { 7, 12, 17, 22, 27, 32, 37, 42, 7, 12, 17, 22, 27, 32, 37, 42 };//x locations of pieces.special piece order:RNBQKBNR.  
        public static int[] green_piecesy = new int[] { 25, 25, 25, 25, 25, 25, 25, 25, 22, 22, 22, 22, 22, 22, 22, 22 };
        public static char[] green_piece_symbolls = new char[] { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R', 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' };//Symbol of pieces
        //public static char[] green_pawn_pieces = new char[] { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' };//Symbol of pieces

        public static int blue_piece_selector_x = 7;
        public static int blue_piece_selector_y = 4;
        //public static int[] blue_pawnx = new int[] { 7, 12, 17, 22, 27, 32, 37, 42 }; // x locations of blue pawns 
        //public static int[] blue_pawny = new int[] { 7, 7, 7, 7, 7, 7, 7, 7 };//y locations of blue pawns
        public static int[] blue_piecesx = new int[] { 7, 12, 17, 22, 27, 32, 37, 42, 7, 12, 17, 22, 27, 32, 37, 42 }; //x locations of special pieces.special piece order:RNBQKBNR.
        public static int[] blue_piecesy = new int[] { 4, 4, 4, 4, 4, 4, 4, 4, 7, 7, 7, 7, 7, 7, 7, 7 };//y locations of special pieces
        public static char[] blue_piece_symbolls = new char[] { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R', 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' };//Symbol of pieces
                                                                                                                                                 // public static char[] blue_pawn_pieces = new char[] { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' };//Symbol of pieces

        static void piece_writer()
        {
            Console.CursorVisible = false;//makes cursor invisible

            //Writes the green pieces
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 8; i < 16; i++)
            {
                Console.SetCursorPosition(green_piecesx[i], green_piecesy[i]);
                Console.Write(green_piece_symbolls[i]);
            }

            for (int i = 0; i < 8; i++)
            {
                Console.SetCursorPosition(green_piecesx[i], green_piecesy[i]);
                Console.Write(green_piece_symbolls[i]);
            }

            //Writes blue pieces
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 8; i < 16; i++)
            {
                Console.SetCursorPosition(blue_piecesx[i], blue_piecesy[i]);
                Console.Write(blue_piece_symbolls[i]);
            }
            for (int i = 0; i < 8; i++)
            {
                Console.SetCursorPosition(blue_piecesx[i], blue_piecesy[i]);
                Console.Write(green_piece_symbolls[i]);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;//makes cursor invisible
        }

        static void player1_selection()
        {
            int min = 10000;//we gave a big value because we want min to change

            for (int i = 0; i < green_piecesy.Length; i++)//Minimum y that cursor can go
            {
                if (min > green_piecesy[i])
                {
                    min = green_piecesy[i];
                }
            }


            while (true)
            {
                ConsoleKeyInfo cki;
                Console.SetCursorPosition(green_piece_selector_x, green_piece_selector_y);

                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.RightArrow && green_piece_selector_x < 40)
                    {   // key and boundary control
                        Console.SetCursorPosition(green_piece_selector_x, green_piece_selector_y);
                        green_piece_selector_x += 5;
                    }

                    if (cki.Key == ConsoleKey.LeftArrow && green_piece_selector_x > 7)
                    {
                        Console.SetCursorPosition(green_piece_selector_x, green_piece_selector_y);
                        green_piece_selector_x -= 5;
                    }

                    if (cki.Key == ConsoleKey.UpArrow && green_piece_selector_y > min)//cursor limited to the minimum y location of the piece
                    {
                        Console.SetCursorPosition(green_piece_selector_x, green_piece_selector_y);
                        green_piece_selector_y -= 3;
                    }

                    if (cki.Key == ConsoleKey.DownArrow && green_piece_selector_y < 23)
                    {
                        Console.SetCursorPosition(green_piece_selector_x, green_piece_selector_y);
                        green_piece_selector_y += 3;
                    }

                    if (cki.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    Thread.Sleep(50);
                }
            }
        }


        static void player2_selection()
        {
            int max = 0;//we gave a small value to max because we want max to change

            for (int i = 0; i < blue_piecesy.Length; i++)//Maximum y that cursor can go
            {
                if (max < blue_piecesy[i])
                {
                    max = blue_piecesy[i];
                }
            }


            while (true)
            {
                ConsoleKeyInfo cki;
                Console.SetCursorPosition(blue_piece_selector_x, blue_piece_selector_y);

                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.RightArrow && blue_piece_selector_x < 40)
                    {   // key and boundary control
                        Console.SetCursorPosition(blue_piece_selector_x, blue_piece_selector_y);
                        blue_piece_selector_x += 5;
                    }

                    if (cki.Key == ConsoleKey.LeftArrow && blue_piece_selector_x > 7)
                    {
                        Console.SetCursorPosition(blue_piece_selector_x, blue_piece_selector_y);
                        blue_piece_selector_x -= 5;
                    }

                    if (cki.Key == ConsoleKey.UpArrow && blue_piece_selector_y > 4)
                    {
                        Console.SetCursorPosition(blue_piece_selector_x, blue_piece_selector_y);
                        blue_piece_selector_y -= 3;
                    }

                    if (cki.Key == ConsoleKey.DownArrow && blue_piece_selector_y < max)//cursor limited to the maximum y location of the piece
                    {
                        Console.SetCursorPosition(blue_piece_selector_x, blue_piece_selector_y);
                        blue_piece_selector_y += 3;
                    }

                    if (cki.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    Thread.Sleep(50);
                }
            }
        }


        static void pawn_movement_green()
        {
            bool[] pawn_cont = new bool[8];
            bool[] take = new bool[2];//1.)left cross, 2.)right cross (controls taking an enemy piece oppurtinities)
            bool two = false;//controls special two block movement for pawns
            bool occupied = true; //this bool prevents pieces to overlap
            bool move = true;//this bool controls if piece is able to move or not
            char piece = 'K';//temporary piece symboll holder
            int takenx1 = 0, takeny1 = 0, takenx2 = 0, takeny2 = 0;


            for (int i = 8; i < 16; i++)//Taking x and y of the chosen piece to a temporary variable
            {
                if (green_piece_selector_x == green_piecesx[i] && green_piece_selector_y == green_piecesy[i])
                {
                    pawn_cont[i - 8] = true;//hata çıkarsa buraya bir bak!!!!!!!!!!
                    tempx = green_piecesx[i];//holding x and y placment of the chosen piece temporarly
                    tempy = green_piecesy[i];
                    piece = green_piece_symbolls[i];//holding the symboll of the chosen piece temporarly
                }

                else
                {
                    pawn_cont[i - 8] = false;
                }
            }


            int borderx = tempx;//start up placement values of piece
            int bordery = tempy;


            for (int i = 0; i < green_piecesy.Length; i++) //This loop controls if there is a piece above the pawn exists or not
            {
                if (tempy - 3 == green_piecesy[i])
                {
                    move = false;
                }


            }

            for (int i = 0; i < blue_piecesx.Length; i++)//taking a enemy piece with pawn
            {
                if (borderx - 5 == blue_piecesx[i] && bordery - 3 == blue_piecesy[i])//for left cross pawn
                {
                    take[0] = true;
                    takenx1 = blue_piecesx[i];
                    takeny1 = blue_piecesy[i];
                }

                if (borderx + 5 == blue_piecesx[i] && bordery - 3 == blue_piecesy[i])//for right cross pawn
                {
                    take[1] = true;
                    takenx2 = blue_piecesx[i];
                    takeny2 = blue_piecesy[i];
                }
            }

            if (move == true && (green_piece_selector_x == green_piecesx[8] && green_piece_selector_y == green_piecesy[8])
                || (green_piece_selector_x == green_piecesx[9] && green_piece_selector_y == green_piecesy[9])
                || (green_piece_selector_x == green_piecesx[10] && green_piece_selector_y == green_piecesy[10])
                || (green_piece_selector_x == green_piecesx[11] && green_piece_selector_y == green_piecesy[11])
                || (green_piece_selector_x == green_piecesx[12] && green_piece_selector_y == green_piecesy[12])
                || (green_piece_selector_x == green_piecesx[13] && green_piece_selector_y == green_piecesy[13])
                || (green_piece_selector_x == green_piecesx[14] && green_piece_selector_y == green_piecesy[14])
                || (green_piece_selector_x == green_piecesx[15] && green_piece_selector_y == green_piecesy[15]))
            {

                while (true)
                {
                    piece_writer();//Writes piece constantly
                    ConsoleKeyInfo cki;
                    Console.SetCursorPosition(tempx, tempy);

                    if (bordery == 22)//controls the two block movement condition
                    {
                        two = true;
                    }

                    if (Console.KeyAvailable)
                    {
                        // true: there is a key in keyboard buffer
                        cki = Console.ReadKey(true);       // true: do not write character 

                        if (cki.Key == ConsoleKey.RightArrow && tempx < 40 && (takenx2 != 0 && takeny2 != 0))//If there is a enemy piece that pawn can take it can move sideways
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempx += 5;
                        }

                        if (cki.Key == ConsoleKey.LeftArrow && tempx > 7 && (takenx1 != 0 && takeny1 != 0))//If there is a enemy piece that pawn can take it can move sideways
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempx -= 5;
                        }

                        if (cki.Key == ConsoleKey.UpArrow && tempy > 4)
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempy -= 3;
                        }

                        if (cki.Key == ConsoleKey.DownArrow && tempy < 23)
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempy += 3;
                        }

                        for (int i = 0; i < green_piecesx.Length; i++) //prevents piece overlap
                        {
                            if (tempx == green_piecesx[i] && tempy == green_piecesy[i])
                            {
                                occupied = false;
                                break;
                            }

                        }

                        if (two == true && tempy == bordery - 6 && tempx == borderx && occupied == true && cki.Key == ConsoleKey.Enter)//If pawn goes two blocks in one move
                        {
                            for (int i = 0; i < 8; i++)//writes the movement you done in the rightside (two block movement)
                            {
                                if (borderx == green_piecesx[i])
                                {

                                    char ascii = Convert.ToChar(97 + i);
                                    Console.SetCursorPosition(55, 10);
                                    Console.Write(ascii);

                                }
                                if (tempy == bordery - 6)
                                {
                                    Console.SetCursorPosition(56, 10);
                                    Console.Write(4);
                                }
                            }

                            break;
                        }

                        else if (tempy == bordery - 3 && tempx == borderx && occupied == true && cki.Key == ConsoleKey.Enter)
                        {
                            for (int i = 0; i <8; i++)//writes the movement you done in the rightside (standart movement)
                            {
                                if (borderx == green_piecesx[i])
                                {

                                    char ascii = Convert.ToChar(97 + i);
                                    Console.SetCursorPosition(55, 10);
                                    Console.Write(ascii);

                                }

                                if (tempy == bordery - 3 * i - 3)
                                {
                                    Console.SetCursorPosition(56, 10);
                                    Console.Write(3 + i);
                                }
                            }


                            break;
                        }

                        else if (take[0] == true && cki.Key == ConsoleKey.Enter)//taking left cross pawn
                        {
                            takenx1 = 0;
                            takeny1 = 0;
                            break;
                        }

                        else if (take[1] == true && cki.Key == ConsoleKey.Enter)//taking right cross pawn
                        {
                            takenx2 = 0;
                            takeny2 = 0;
                            break;
                        }

                        Console.SetCursorPosition(tempx, tempy);
                        Console.Write(piece);
                        Thread.Sleep(50);     // sleep 50 ms                     
                    }
                }

                for (int i = 8; i < 16; i++)//overwriting new locations of the piece
                {
                    if (pawn_cont[i - 8] == true)
                    {
                        green_piecesx[i] = tempx;
                        green_piecesy[i] = tempy;
                        green_piece_symbolls[i] = piece;
                    }
                }

                for (int i = 0; i < green_piecesx.Length; i++)//overwriting new locations of the piece
                {
                    if (take[0] == true && blue_piecesx[i] == borderx - 5 && blue_piecesy[i] == bordery - 3)//taking left cross piece 
                    {
                        blue_piecesx[i] = 0;
                        blue_piecesy[i] = 0;
                        blue_piece_symbolls[i] = (char)0;
                    }

                    if (take[1] == true && blue_piecesx[i] == borderx + 5 && blue_piecesy[i] == bordery - 3)//taking right cross piece
                    {
                        blue_piecesx[i] = 0;
                        blue_piecesy[i] = 0;
                        blue_piece_symbolls[i] = (char)0;
                    }
                }
            }

        }


        static void pawn_movement_blue()
        {
            bool[] pawn_cont = new bool[8];
            bool[] take = new bool[2];//1.)left pawn, 2.)right pawn, 3.)left special, 4.)right special (controls taking an enemy piece oppurtinities)
            bool two = false;
            bool occupied = true; //this bool prevents pieces to overlap
            bool move = true;
            char piece = 'K';
            int takenx1 = 0, takeny1 = 0, takenx2 = 0, takeny2 = 0;

            for (int i = 8; i < 16; i++)
            {
                if (blue_piece_selector_x == blue_piecesx[i] && blue_piece_selector_y == blue_piecesy[i])
                {
                    pawn_cont[i - 8] = true;
                    tempx = blue_piecesx[i];//holds selected piece's x and y temporarly
                    tempy = blue_piecesy[i];
                    piece = blue_piece_symbolls[i];
                }

                else
                {
                    pawn_cont[i - 8] = false;
                }
            }

            int borderx = tempx;
            int bordery = tempy;

            for (int i = 0; i < blue_piecesx.Length; i++)
            {
                if (tempy + 3 == blue_piecesy[i])
                {
                    move = false;
                }

                if (tempy + 3 == green_piecesy[i])
                {
                    move = false;
                }
            }


            for (int i = 0; i < green_piecesx.Length; i++)//taking a enemy piece with pawn
            {
                if (borderx - 5 == green_piecesx[i] && bordery + 3 == green_piecesy[i])//pawn taking left cross piece
                {
                    take[0] = true;
                    takenx1 = green_piecesx[i];
                    takeny1 = green_piecesy[i];
                }

                if (borderx + 5 == green_piecesx[i] && bordery + 3 == green_piecesy[i])//pawn taking right cross piece
                {
                    take[1] = true;
                    takenx2 = green_piecesx[i];
                    takeny2 = green_piecesy[i];
                }
            }


            if (move == true && (blue_piece_selector_x == blue_piecesx[8] && blue_piece_selector_y == blue_piecesy[8]) ||
                (blue_piece_selector_x == blue_piecesx[9] && blue_piece_selector_y == blue_piecesy[9]) ||
                (blue_piece_selector_x == blue_piecesx[10] && blue_piece_selector_y == blue_piecesy[10])
                || (blue_piece_selector_x == blue_piecesx[11] && blue_piece_selector_y == blue_piecesy[11]) ||
                (blue_piece_selector_x == blue_piecesx[12] && blue_piece_selector_y == blue_piecesy[12]) ||
                (blue_piece_selector_x == blue_piecesx[13] && blue_piece_selector_y == blue_piecesy[13])
                || (blue_piece_selector_x == blue_piecesx[14] && blue_piece_selector_y == blue_piecesy[14]) ||
                (blue_piece_selector_x == blue_piecesx[15] && blue_piece_selector_y == blue_piecesy[15]))
            {
                while (true)
                {
                    piece_writer();//Writes piece constantly
                    ConsoleKeyInfo cki;
                    Console.SetCursorPosition(tempx, tempy);

                    if (bordery == 7)
                    {
                        two = true;
                    }

                    if (Console.KeyAvailable)//start of movement
                    {
                        // true: there is a key in keyboard buffer
                        cki = Console.ReadKey(true);       // true: do not write character 

                        if (cki.Key == ConsoleKey.RightArrow && tempx < 40 && (takenx2 != 0 && takeny2 != 0))//If there is a enemy piece that pawn can take it can move sideways
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempx += 5;
                        }

                        if (cki.Key == ConsoleKey.LeftArrow && tempx > 7 && (takenx1 != 0 && takeny1 != 0))//If there is a enemy piece that pawn can take it can move sideways
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempx -= 5;
                        }

                        if (cki.Key == ConsoleKey.DownArrow && tempy < 23)
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempy += 3;
                        }

                        if (cki.Key == ConsoleKey.UpArrow && tempy > 4)
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempy -= 3;
                        }


                        for (int i = 0; i < blue_piecesx.Length; i++) //prevents piece overlap
                        {
                            if (tempx == blue_piecesx[i] && tempy == blue_piecesy[i])
                            {
                                occupied = false;
                                break;
                            }
                        }


                        if (two == true && tempy == bordery + 6 && occupied == true && cki.Key == ConsoleKey.Enter)
                        {
                            for (int i =0; i < 8; i++)//writes the movement you done in the rightside (two block movement)
                            {
                                if (tempx == blue_piecesx[i])
                                {

                                    char ascii = Convert.ToChar(97 + i);
                                    Console.SetCursorPosition(58, 10);
                                    Console.Write(ascii);

                                }
                                if (tempy == bordery + 6)
                                {
                                    Console.SetCursorPosition(59, 10);
                                    Console.Write(5);
                                }
                            }


                            break;
                        }

                        else if (tempy == bordery + 3 && occupied == true && cki.Key == ConsoleKey.Enter)
                        {
                            for (int i =0; i < 8; i++)//writes the movement you done in the rightside (standart movement)
                            {
                                if (tempx == blue_piecesx[i])
                                {

                                    char ascii = Convert.ToChar(97 + i);
                                    Console.SetCursorPosition(58, 10);
                                    Console.Write(ascii);

                                }
                                if (tempy == bordery + 3 * i + 3)
                                {

                                    Console.SetCursorPosition(59, 10);
                                    Console.Write(6 - i);
                                }
                            }


                            break;
                        }

                        else if (take[0] == true && cki.Key == ConsoleKey.Enter)//taking left cross pawn
                        {
                            takenx1 = 0;
                            takeny1 = 0;
                            break;
                        }

                        else if (take[1] == true && cki.Key == ConsoleKey.Enter)//taking right cross pawn
                        {
                            takenx2 = 0;
                            takeny2 = 0;
                            break;
                        }

                        Console.SetCursorPosition(tempx, tempy);
                        Console.Write(piece);
                        Thread.Sleep(50);     // sleep 50 ms

                    }
                }

                for (int i = 8; i < 16; i++)
                {
                    if (pawn_cont[i - 8] == true)
                    {
                        blue_piecesx[i] = tempx;
                        blue_piecesy[i] = tempy;
                        blue_piece_symbolls[i] = piece;
                    }
                }

                for (int i = 0; i < blue_piecesx.Length; i++)
                {

                    if (take[0] == true && green_piecesx[i] == borderx - 5 && green_piecesy[i] == bordery + 3)//left cross piece taken
                    {
                        green_piecesx[i] = 0;
                        green_piecesy[i] = 0;
                        green_piece_symbolls[i] = (char)0;
                    }

                    if (take[1] == true && green_piecesx[i] == borderx + 5 && green_piecesy[i] == bordery + 3)//right cross piece taken
                    {
                        green_piecesx[i] = 0;
                        green_piecesy[i] = 0;
                        green_piece_symbolls[i] = (char)0;
                    }
                }
            }
        }


        static void knight_movement_green()
        {
            bool[] knight_cont = new bool[2];
            bool occupied = true;//prevents piece overlap
            char piece = 'K';//temporary piece symboll holder

            if (green_piece_selector_x == green_piecesx[1] && green_piece_selector_y == green_piecesy[1])
            {
                knight_cont[0] = true;
                tempx = green_piecesx[1];
                tempy = green_piecesy[1];
                piece = green_piece_symbolls[1];
            }

            else if (green_piece_selector_x == green_piecesx[6] && green_piece_selector_y == green_piecesy[6])
            {
                knight_cont[1] = true;
                tempx = green_piecesx[6];
                tempy = green_piecesy[6];
                piece = green_piece_symbolls[6];
            }

            else
            {
                knight_cont[0] = false;
                knight_cont[1] = false;
            }

            int borderx = tempx; //Contains the first value of tempx and tempy
            int bordery = tempy;


            if (knight_cont[0] == true || knight_cont[1] == true)
            {
                while (true)
                {
                    piece_writer();//Writes piece constantly
                    ConsoleKeyInfo cki;
                    Console.SetCursorPosition(tempx, tempy);

                    if (Console.KeyAvailable)
                    {
                        cki = Console.ReadKey(true);

                        if (cki.Key == ConsoleKey.RightArrow && tempx < 40)
                        {   // key and boundary control
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempx += 5;
                        }

                        if (cki.Key == ConsoleKey.LeftArrow && tempx > 7)
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempx -= 5;
                        }

                        if (cki.Key == ConsoleKey.UpArrow && tempy > 4)
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempy -= 3;
                        }

                        if (cki.Key == ConsoleKey.DownArrow && tempy < 23)
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempy += 3;
                        }

                        for (int i = 0; i < green_piecesx.Length; i++) //prevents piece overlap
                        {
                            if (tempx == green_piecesx[i] && tempy == green_piecesy[i])
                            {
                                occupied = false;
                                break;
                            }

                            else
                            {
                                occupied = true;
                            }
                        }

                        if (cki.Key == ConsoleKey.Enter && occupied == true && ((tempx == borderx + 5 && tempy == bordery - 6) || (tempx == borderx - 5 && tempy == bordery - 6) ||
                            (tempx == borderx + 10 && tempy == bordery - 3) || (tempx == borderx - 10 && tempy == bordery - 3) || ((tempx == borderx + 10 && tempy == bordery + 3) ||
                            (tempx == borderx - 10 && tempy == bordery + 3) || (tempx == borderx + 5 && tempy == bordery + 6) || (tempx == borderx - 5 && tempy == bordery + 6))))
                        {
                            
                            
                            break;
                        }

                        Console.SetCursorPosition(tempx, tempy);
                        Console.Write(piece);
                        Thread.Sleep(50);
                    }
                }

                if (knight_cont[0] == true) //overwriting new locations of the piece
                {
                    green_piecesx[1] = tempx;
                    green_piecesy[1] = tempy;
                    green_piece_symbolls[1] = piece;
                }

                else if (knight_cont[1] == true)//overwriting new locations of the piece
                {
                    green_piecesx[6] = tempx;
                    green_piecesy[6] = tempy;
                    green_piece_symbolls[6] = piece;
                }
            }
        }




        static void knight_movement_blue()
        {
            bool[] knight_cont = new bool[2];
            bool occupied = false;//prevents piece overlap
            char piece = 'K';//Temporary piece symboll holder

            if (blue_piece_selector_x == blue_piecesx[1] && blue_piece_selector_y == blue_piecesy[1])
            {
                knight_cont[0] = true;
                tempx = blue_piecesx[1];
                tempy = blue_piecesy[1];
                piece = blue_piece_symbolls[1];
            }

            else if (blue_piece_selector_x == blue_piecesx[6] && blue_piece_selector_y == blue_piecesy[6])
            {
                knight_cont[1] = true;
                tempx = blue_piecesx[6];
                tempy = blue_piecesy[6];
                piece = blue_piece_symbolls[6];
            }

            else
            {
                knight_cont[0] = false;
                knight_cont[1] = false;
            }

            int borderx = tempx; //Contains the first value of tempx and tempy
            int bordery = tempy;


            if (knight_cont[0] == true || knight_cont[1] == true)
            {
                while (true)
                {
                    piece_writer();//Writes piece constantly
                    ConsoleKeyInfo cki;
                    Console.SetCursorPosition(tempx, tempy);

                    if (Console.KeyAvailable)
                    {
                        cki = Console.ReadKey(true);

                        if (cki.Key == ConsoleKey.RightArrow && tempx < 40)
                        {   // key and boundary control
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempx += 5;
                        }

                        if (cki.Key == ConsoleKey.LeftArrow && tempx > 7)
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempx -= 5;
                        }

                        if (cki.Key == ConsoleKey.UpArrow && tempy > 4)
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempy -= 3;
                        }

                        if (cki.Key == ConsoleKey.DownArrow && tempy < 23)
                        {
                            Console.SetCursorPosition(tempx, tempy);
                            Console.WriteLine(".");
                            tempy += 3;
                        }

                        for (int i = 0; i < blue_piecesx.Length; i++) //prevents piece overlap
                        {
                            if (tempx == blue_piecesx[i] && tempy == blue_piecesy[i])
                            {
                                occupied = false;
                                break;
                            }

                            else
                            {
                                occupied = true;
                            }
                        }

                        if (cki.Key == ConsoleKey.Enter && occupied == true && ((tempx == borderx + 5 && tempy == bordery - 6) || (tempx == borderx - 5 && tempy == bordery - 6) ||
                            (tempx == borderx + 10 && tempy == bordery - 3) || (tempx == borderx - 10 && tempy == bordery - 3) || ((tempx == borderx + 10 && tempy == bordery + 3) ||
                            (tempx == borderx - 10 && tempy == bordery + 3) || (tempx == borderx + 5 && tempy == bordery + 6) || (tempx == borderx - 5 && tempy == bordery + 6))))
                        {
                            
                            break;
                            Console.SetCursorPosition(56, 10);
                            Console.WriteLine(occupied);
                        }

                        Console.SetCursorPosition(tempx, tempy);
                        Console.Write(piece);
                        Thread.Sleep(50);
                    }
                }

                if (knight_cont[0] == true)
                {
                    blue_piecesx[1] = tempx;
                    blue_piecesy[1] = tempy;
                    blue_piece_symbolls[1] = piece;
                }

                else if (knight_cont[1] == true)
                {
                    blue_piecesx[6] = tempx;
                    blue_piecesy[6] = tempy;
                    blue_piece_symbolls[6] = piece;
                }
            }
        }


        static void Main(string[] args)
        {
            char[,] a = new char[24, 38]; // array of board shapes          

            int[] numbers = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };
            char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            int counter = 0; //Determines the turn of the players

            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                for (int i = 0; i < a.GetLength(0); i++) //8X8 chess table (it has vertically 2 block space and horizontally 4 block space between pieces)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (i == 0 || i == 23)
                        {
                            a[i, j] = '-';
                        }

                        else if (j == 0 || j == 37)
                        {
                            a[i, j] = '|';
                        }

                        else if (j % 5 == 1 && i % 3 == 1)
                        {
                            a[i, j] = '.';
                        }

                        Console.SetCursorPosition(j + 6, i + 3);
                        Console.Write(a[i, j]);
                    }
                    Console.WriteLine(); //skipping to the next line
                }


                for (int i = 0; i < numbers.Length; i++) //Writes the numbers on the left of the board
                {
                    Console.SetCursorPosition(5, 4 + 3 * i);
                    Console.Write(numbers[i]);

                    Console.SetCursorPosition(44, 4 + 3 * i);
                    Console.Write(numbers[i]);
                }

                for (int i = 0; i < letters.Length; i++) //Writes the letters on the top and bottom of the board
                {
                    Console.SetCursorPosition(7 + 5 * i, 2);
                    Console.Write(letters[i]);

                    Console.SetCursorPosition(7 + 5 * i, 27);
                    Console.Write(letters[i]);
                }

                piece_writer();//Writes pieces into the table

                if (counter % 2 == 0)//First player's trun
                {
                    player1_selection();//Piece selection for player 1
                    pawn_movement_green();
                    knight_movement_green();

                    counter++;
                }

                else//Second player's trun
                {
                    player2_selection();
                    pawn_movement_blue();
                    knight_movement_blue();

                    counter++;
                }

                Console.ReadLine();
            }//Outer while loop



        }





    }
}
