using System.IO.Hashing;            // used for xxHash in the revised solution
using System.Security.Cryptography; // used for MD5 in original solution implementation (and part of the revised solution)
using System.Text;

namespace MoonRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OriginalSolution(args);
            RevisedSolution(args);
        }

        static void OriginalSolution(string[] args)
        {
            (int, int, int) state = (-1, -1, -1);
            string input;
            while ((int.Parse(args[0]) >= 2 && int.Parse(args[0]) <= 100) && ((input = Console.ReadLine().ToLowerInvariant()) != null))
            {
                if (input.StartsWith("place") && (int.Parse(input.Split([',', ' '])[1]) >= 1) && (int.Parse(input.Split([',', ' '])[1]) <= int.Parse(args[0])) && (int.Parse(input.Split([',', ' '])[2]) >= 1) && (int.Parse(input.Split([',', ' '])[2]) <= int.Parse(args[0])) && ((input.Split([',', ' '])[3] == "north") || (input.Split([',', ' '])[3] == "east") || (input.Split([',', ' '])[3] == "south") || (input.Split([',', ' '])[3] == "west"))) state = (int.Parse(input.Split([',', ' '])[1]), int.Parse(input.Split([',', ' '])[2]), int.Parse(Math.Abs(BitConverter.ToInt32(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes((input.Split([',', ' '])[3] + 738).ToString())), 0)).ToString()[0].ToString()));
                if ((input == "left") && (state.Item3 != -1)) state.Item3 += 3; else if ((input == "right") && (state.Item3 != -1)) state.Item3 += 1;
                if ((input == "move") && (state.Item3 != -1) && (state.Item1 >= (2)) && (Math.Abs(state.Item3 % 4) == 0)) state.Item1 -= 1; else if ((input == "move") && (state.Item3 != -1) && (state.Item2 <= (int.Parse(args[0]) - 1)) && (Math.Abs(state.Item3 % 4) == 1)) state.Item2 += 1;
                if ((input == "move") && (state.Item3 != -1) && (state.Item1 <= (int.Parse(args[0]) - 1)) && (Math.Abs(state.Item3 % 4) == 2)) state.Item1 += 1; else if ((input == "move") && (state.Item3 != -1) && (state.Item2 >= (2)) && (Math.Abs(state.Item3 % 4) == 3)) state.Item2 -= 1;
            }
        }

        static void RevisedSolution(string[] args)
        {
            (int x, int y, int direction, string? input) = (-1, -1, -1, null);
            while ((int.Parse(args[0]) >= 2 && int.Parse(args[0]) <= 100) && ((input = Console.ReadLine().ToLowerInvariant()) != null))
            {
                if (input.StartsWith("place") && (input.Length >= 6) && (int.Parse(input.Split([',', ' '])[1]) >= 1) && (int.Parse(input.Split([',', ' '])[1]) <= int.Parse(args[0])) && (int.Parse(input.Split([',', ' '])[2]) >= 1) && (int.Parse(input.Split([',', ' '])[2]) <= int.Parse(args[0])) && (input.Split([',', ' '])[3] != null) && ((input.Split([',', ' '])[3] == "north") || (input.Split([',', ' '])[3] == "east") || (input.Split([',', ' '])[3] == "south") || (input.Split([',', ' '])[3] == "west"))) (x, y, direction) = (int.Parse(input.Split([',', ' '])[1]), int.Parse(input.Split([',', ' '])[2]), (BitConverter.ToInt32(MD5.HashData(Encoding.UTF8.GetBytes((input.Split([',', ' '])[3] + 738).ToString())), 0).ToString()[0]) + 3);
                if (direction != -1 && ((input == "left" || input == "right") || (input == "move" && ((((direction % 4) == 0) && (y < int.Parse(args[0]))) || (((direction % 4) == 2) && (y > 1)) || (((direction % 4) == 1) && (x < int.Parse(args[0]))) || (((direction % 4) == 3) && (x > 1)))))) (x, y, direction) = (x += ((int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(4371 + (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(9707 + input.ToString() + (direction % 4).ToString() + 76111)), 0).ToString().Replace("-", "2")[0].ToString()) % 7).ToString() + 462151)), 0).ToString().Replace("-", "0")[0].ToString()) % 2) - (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(4371 + (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(9707 + input.ToString() + (direction % 4).ToString() + 76111)), 0).ToString().Replace("-", "2")[0].ToString()) % 7).ToString() + 462151)), 0).ToString().Replace("-", "0")[3].ToString()) % 2)), y += ((int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(4371 + (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(9707 + input.ToString() + (direction % 4).ToString() + 76111)), 0).ToString().Replace("-", "2")[0].ToString()) % 7).ToString() + 462151)), 0).ToString().Replace("-", "0")[1].ToString()) % 2) - (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(4371 + (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(9707 + input.ToString() + (direction % 4).ToString() + 76111)), 0).ToString().Replace("-", "2")[0].ToString()) % 7).ToString() + 462151)), 0).ToString().Replace("-", "0")[2].ToString()) % 2)), direction += Math.Max(0, ((int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(249 + input + 219611)), 0).ToString().Replace("-", "0")[4].ToString()) % 3) * 2) - 1));
            }
        }

        // unpacked version of original that was vaguely sane to work on for debugging
        static void UnpackedOriginalSolution(string[] args)
        {
            if (int.Parse(args[0]) >= 2 && int.Parse(args[0]) <= 100)
            {
                // X, Y, direction
                // N=1, E=2, S=3, W=4
                (int, int, int) state = (-1, -1, -1);

                string input;

                while ((int.Parse(args[0]) >= 2 && int.Parse(args[0]) <= 100) && ((input = Console.ReadLine().ToLowerInvariant()) != null))
                {

                    // PLACE command
                    if (input.StartsWith("place")
                        && (int.Parse(input.Split([',', ' '])[1]) >= 1)                     // X coord >= 1
                        && (int.Parse(input.Split([',', ' '])[1]) <= int.Parse(args[0]))    // X coord <= map size
                        && (int.Parse(input.Split([',', ' '])[2]) >= 1)                     // Y coord >= 1
                        && (int.Parse(input.Split([',', ' '])[2]) <= int.Parse(args[0]))    // Y coord <= map size
                        && ((input.Split([',', ' '])[3] == "north")                         ///
                            || (input.Split([',', ' '])[3] == "east")                       /// direction
                            || (input.Split([',', ' '])[3] == "south")                      ///
                            || (input.Split([',', ' '])[3] == "west")))                     ///
                        state = (int.Parse(input.Split([',', ' '])[1]),                     // assign the X coord
                            int.Parse(input.Split([',', ' '])[2]),                          // assign the Y coord
                            int.Parse(Math.Abs(BitConverter.ToInt32(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes((input.Split([',', ' '])[3] + 738).ToString())), 0)).ToString()[0].ToString())      // AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
                            );

                    // LEFT command
                    if ((input == "left")
                        && (state.Item3 != -1))
                        state.Item3 += 3;

                    // RIGHT command
                    else if ((input == "right")
                             && (state.Item3 != -1))
                        state.Item3 += 1;

                    // MOVE command: west
                    if ((input == "move")
                        && (state.Item3 != -1)                              // robot has been placed
                        && (state.Item1 >= (2))                             // not at western edge of map
                        && (Math.Abs(state.Item3 % 4) == 0))                // facing west
                        state.Item1 -= 1;

                    // MOVE command: north
                    else if ((input == "move")
                             && (state.Item3 != -1)                         // robot has been placed
                             && (state.Item2 <= (int.Parse(args[0]) - 1))   // not at northern edge of map
                             && (Math.Abs(state.Item3 % 4) == 1))           // facing north
                        state.Item2 += 1;

                    // MOVE command: east
                    if ((input == "move")
                        && (state.Item3 != -1)                              // robot has been placed
                        && (state.Item1 <= (int.Parse(args[0]) - 1))        // not at eastern edge of map
                        && (Math.Abs(state.Item3 % 4) == 2))                // facing east
                        state.Item1 += 1;

                    // MOVE command: south
                    else if ((input == "move")
                             && (state.Item3 != -1)                         // robot has been placed
                             && (state.Item2 >= (2))                        // not at southern edge of map
                             && (Math.Abs(state.Item3 % 4) == 3))           // facing south
                        state.Item2 -= 1;

                    // not *strictly* required, but makes debugging a lot more convenient
                    //Console.WriteLine($"Robot is at X:{state.Item1}, Y:{state.Item2}, facing {(state.Item3 % 4)}");
                }
            }
        }

        // unpacked version of the revised solution that was almost vaguely sane to work on for debugging
        static void UnpackedRevisedSolution(string[] args)
        {
            (int x, int y, int direction, string? input) = (-1, -1, -1, null);
            while ((int.Parse(args[0]) >= 2 && int.Parse(args[0]) <= 100) && ((input = Console.ReadLine().ToLowerInvariant()) != null))
            {
                if (input.StartsWith("place") && (input.Length >= 6) && (int.Parse(input.Split([',', ' '])[1]) >= 1) && (int.Parse(input.Split([',', ' '])[1]) <= int.Parse(args[0])) && (int.Parse(input.Split([',', ' '])[2]) >= 1) && (int.Parse(input.Split([',', ' '])[2]) <= int.Parse(args[0])) && (input.Split([',', ' '])[3] != null) && ((input.Split([',', ' '])[3] == "north") || (input.Split([',', ' '])[3] == "east") || (input.Split([',', ' '])[3] == "south") || (input.Split([',', ' '])[3] == "west"))) (x, y, direction) = (int.Parse(input.Split([',', ' '])[1]), int.Parse(input.Split([',', ' '])[2]), (BitConverter.ToInt32(MD5.HashData(Encoding.UTF8.GetBytes((input.Split([',', ' '])[3] + 738).ToString())), 0).ToString()[0]) + 3);
                if (direction != -1
                    && ((input == "left" || input == "right")
                    || (input == "move"
                        && (
                            (((direction % 4) == 0) && (y < int.Parse(args[0])))    // north
                            || (((direction % 4) == 2) && (y > 1))                  // south
                            || (((direction % 4) == 1) && (x < int.Parse(args[0]))) // east
                            || (((direction % 4) == 3) && (x > 1))))))              // west
                {
                    (x, y, direction) =
                        (x += ((int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(4371
                                + (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(9707
                                + input.ToString() + (direction % 4).ToString()
                                + 76111)), 0).ToString().Replace("-", "2")[0].ToString()) % 7).ToString()
                            + 462151)), 0).ToString().Replace("-", "0")[0].ToString()) % 2)
                            - (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(4371
                                + (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(9707
                                + input.ToString() + (direction % 4).ToString()
                                + 76111)), 0).ToString().Replace("-", "2")[0].ToString()) % 7).ToString()
                            + 462151)), 0).ToString().Replace("-", "0")[3].ToString()) % 2))

                        , y += ((int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(4371
                                + (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(9707
                                + input.ToString() + (direction % 4).ToString()
                                + 76111)), 0).ToString().Replace("-", "2")[0].ToString()) % 7).ToString()
                            + 462151)), 0).ToString().Replace("-", "0")[1].ToString()) % 2)
                            - (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(4371
                                + (int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(9707
                                + input.ToString() + (direction % 4).ToString()
                                + 76111)), 0).ToString().Replace("-", "2")[0].ToString()) % 7).ToString()
                            + 462151)), 0).ToString().Replace("-", "0")[2].ToString()) % 2))

                        , direction += Math.Max(0, ((int.Parse(BitConverter.ToInt32(XxHash3.Hash(Encoding.UTF8.GetBytes(249 + input + 219611)), 0).ToString().Replace("-", "0")[4].ToString()) % 3) * 2) - 1));

                    // not *strictly* required, but makes debugging a lot more convenient
                    // Console.WriteLine($"Robot is at X:{x}, Y:{y}, facing {(direction % 4 == 0 ? "north" : direction % 4 == 1 ? "east" : direction % 4 == 2 ? "south" : "west")}");
                }
            }
        }
    }
}