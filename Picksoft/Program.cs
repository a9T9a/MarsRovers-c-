using System;
using System.Collections.Generic;

namespace Picksoft
{
    class Program
    {
        static void Main(string[] args)                     // Kullanıcı girişleri
        {
            List<String> new_coord = new List<String>();
            Console.WriteLine("How many rover?");
            int amount_rovers = Convert.ToInt16(Console.ReadLine());
            String[][] rovers = new String[amount_rovers][];
            for (int i = 0; i < amount_rovers; i++)
            {
                rovers[i] = new String[3];
            }

            Console.WriteLine("Upper-Right coordinates of the area");
            String border_line = Console.ReadLine();
            String[] border = border_line.Split(' ');

            for(int i = 0; i < amount_rovers; i++)
            {
                Console.WriteLine("Position of the rover "+(i+1));
                String rover_position = Console.ReadLine().ToUpper();
                String[] rover_coord = rover_position.Split(' ');

                Console.WriteLine("Route of the rover "+(i+1));
                String rover_route = Console.ReadLine().ToUpper();
                char[] rover_line = rover_route.ToCharArray();

                Router router = new Router();

                for(int j = 0; j < rover_line.Length; j++)
                {
                    new_coord = router.Direction(rover_coord, Convert.ToString(rover_line[j]));

                    if(Convert.ToInt16(new_coord[0]) > Convert.ToInt16(border[0]) || Convert.ToInt16(new_coord[1]) > Convert.ToInt16(border[1]))
                    {
                        Console.WriteLine("Rover "+(i+1)+" will be out of the area");
                        break;
                    }
                    else
                    {
                        rover_coord[0] = new_coord[0];
                        rover_coord[1] = new_coord[1];
                        rover_coord[2] = new_coord[2];
                    }
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
        public List<String> Direction(String[] rover_coord, String way)         // Her talimattaki hareketinin belirlenmesi
        {
            List<String> c_list=new List<String>();
            c_list.Clear();

            if (way=="L")
            {
                c_list.Add(rover_coord[0]);
                c_list.Add(rover_coord[1]);
                c_list.Add(face_to(rover_coord[2],way));
            }
            else if (way=="R")
            {
                c_list.Add(rover_coord[0]);
                c_list.Add(rover_coord[1]);
                c_list.Add(face_to(rover_coord[2], way));
            }
            else if (way=="M"){
                c_list = Move_forward(rover_coord);
            }

            return c_list;
        }


        public String face_to(String coord, String way)     //Yönünün belirlenmesi
        {
            List <String> points =new List<string>() { "W", "N", "E", "S" };

            int f_coord = points.IndexOf(coord);

            if (way=="L")
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
            else if (way=="R")
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

        public List<String> Move_forward(String[] coord)        //İleri hareketteki yeni konumunun belirlenmesi
        {
            List<String> list = new List<String>();
            list.Clear();
            if (coord[2]=="W")
            {
                coord[0] = Convert.ToString(Convert.ToInt16(coord[0]) - 1);
            }
            else if (coord[2]=="N")
            {
                coord[1] = Convert.ToString(Convert.ToInt16(coord[1]) + 1);
            }
            else if (coord[2]=="E")
            {
                coord[0] = Convert.ToString(Convert.ToInt16(coord[0]) + 1);
            }
            else if (coord[2]=="S")
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
