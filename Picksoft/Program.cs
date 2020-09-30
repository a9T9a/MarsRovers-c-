using System;
using System.Collections.Generic;

namespace Picksoft
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> new_coord = new List<string>();
            Console.WriteLine("How many rover?");
            int amount_rovers = Convert.ToInt16(Console.ReadLine());
            String[][] rovers = new String[amount_rovers][];
            for (int i = 0; i < amount_rovers; i++)
            {
                rovers[i] = new String[3];
            }

            Console.WriteLine("Upper-Right coordinates of the area");
            String border_line = Console.ReadLine();
            String[] border = border_line.Split(" ");

            for(int i = 0; i < amount_rovers; i++)
            {
                Console.WriteLine("Rover Position");
                String rover_position = Console.ReadLine().ToUpper();
                String[] rover_coord = rover_position.Split(" ");

                Console.WriteLine("Rover route");
                String rover_route = Console.ReadLine().ToUpper();
                String[] rover_line = rover_route.Split("");

                Router router = new Router();

                for(int j = 0; j < rover_line.Length; j++)
                {
                    new_coord = router.Direction(rover_coord, rover_line[i]);
                    /*if(Convert.ToInt16(new_coord[0]) > Convert.ToInt16(border[0]) || Convert.ToInt16(new_coord[1]) > Convert.ToInt16(border[1]))
                    {
                        Console.WriteLine(i + ". rover will be out of the area");
                    }
                    else
                    {
                        rover_coord[0] = new_coord[0];
                        rover_coord[1] = new_coord[1];
                        rover_coord[2] = new_coord[2];
                    }*/
                    rover_coord[0] = new_coord[0];
                    rover_coord[1] = new_coord[1];
                    rover_coord[2] = new_coord[2];
                }
                rovers[i][0] = rover_coord[0];
                rovers[i][1] = rover_coord[1];
                rovers[i][2] = rover_coord[2];
            }

            for (int i = 0; i < amount_rovers; i++)
            {
                Console.WriteLine(rovers[i][0] + " " + rovers[i][1] + " " + rovers[i][2]);
            }

        }
    }

    class Router
    {
        int new_coord;
        public List<String> Direction(String[] rover_coord, String way)
        {
            List<String> c_list=new List<String>();
            c_list.Clear();
            if (way.Equals("L"))
            {
                c_list.Add(rover_coord[0]);
                c_list.Add(rover_coord[1]);
                c_list.Add(face_to(rover_coord[2],way));
            }
            else if (way.Equals("R"))
            {
                c_list.Add(rover_coord[0]);
                c_list.Add(rover_coord[1]);
                c_list.Add(face_to(rover_coord[2], way));
            }
            else if (way.Equals("M")){
                c_list = Move_forward(rover_coord);
            }

            return c_list;
        }


        public String face_to(String coord, String way)
        {
            List <String> points =new List<string>() { "W", "N", "E", "S" };

            int f_coord = points.IndexOf(coord);

            if (way.Equals("L"))
            {
                if (f_coord == 0)
                {
                    new_coord = 3;
                }
                else
                {
                    new_coord = f_coord - 1;
                }
            }
            else if (way.Equals("R"))
            {
                if (f_coord == 3)
                {
                    new_coord = 0;
                }
                else
                {
                    new_coord = f_coord + 1;
                }
            }

            return points[new_coord];
        }

        public List<String> Move_forward(String[] coord)
        {
            List<String> list = new List<String>();
            list.Clear();
            if (coord[2].Equals("W"))
            {
                coord[0] = Convert.ToString(Convert.ToInt16(coord[0]) - 1);
            }
            else if (coord[2].Equals("N"))
            {
                coord[1] = Convert.ToString(Convert.ToInt16(coord[1]) + 1);
            }
            else if (coord[2].Equals("E"))
            {
                coord[0] = Convert.ToString(Convert.ToInt16(coord[0]) + 1);
            }
            else if (coord[2].Equals("S"))
            {
                coord[1] = Convert.ToString(Convert.ToInt16(coord[1]) - 1);
            }
            list.Add(coord[0]);
            list.Add(coord[1]);
            list.Add(coord[2]);
            return list;
        }
    }
}
