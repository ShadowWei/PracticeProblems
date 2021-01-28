using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy
{
    class Galaxy
    {
        static void Main(string[] args)
        {
            string StartingInput = Console.ReadLine();
            string[] inputs = StartingInput.Split(' ');

            int d = Int32.Parse(inputs[0].ToString());
            int k = Int32.Parse(inputs[1].ToString());

            List<star> inputLines = new List<star>();
            int count = 0;
            while (count < k)
            {
                string line = Console.ReadLine();
                string[] xy = line.Split(' ');
                int x = Int32.Parse(xy[0].ToString());
                int y = Int32.Parse(xy[1].ToString());
                star s = new star(x, y);
                inputLines.Add(s);
                count++;
            }

            star galaxy = findMajor(inputLines, d);
            counting(galaxy, inputLines, d); 

            Console.ReadLine(); 
        }

        public static void counting(star sc, List<star> a, int d)
        {
            if (sc.x == -9999 && sc.y == -9999)
            {
                Console.WriteLine("NO");
                return; 
            }

            int count = 0; 
            foreach (star s in a)
            {
                if (distance(sc, s, d))
                {
                    count++; 
                }
            }

            Console.WriteLine(count); 
        } 

        public class star
        {
            public int x;
            public int y;
            public int count;
            public star(int x, int y)
            {
                this.x = x;
                this.y = y;
                count = 0;
            }
        }

        public static bool distance(star s1, star s2, int d)
        {
            return Math.Pow(d, 2) >= Math.Pow((s1.x - s2.x), 2) + Math.Pow((s1.y - s2.y), 2);
        }

        public static star findMajor(List<star> A, int d)
        {
            star nope = new star(-9999, -9999); 
            if (A.Count == 0)
            {
                return nope;
            }
            else if (A.Count == 1)
            {
                return A[0];
            }
            else
            {
                List<star> Anot = new List<star>();

                for (int i = 0; i < A.Count - 1; i = i + 2)
                {
                    if (distance(A[i], A[i + 1], d))
                    {
                        Anot.Add(A[i]);
                    }
                }

                star y;
                if (A.Count % 2 != 0)
                {
                    y = A[A.Count-1];
                }
                else
                {
                    y = nope;
                }

                star x = findMajor(Anot, d);

                //if x is NO 
                if (x.x == -9999 && x.y == -9999)
                {
                    if (A.Count % 2 != 0)
                    {
                        int count = 0;
                        //count occurances of y in A, return y or No as appropraiate 
                        foreach (star s in A)
                        {
                            if (distance(y, s, d))
                            {
                                count++;
                            }
                        }
                        if (count > A.Count / 2)
                        {
                            return y;
                        }
                        return nope;
                    }
                    else
                    {
                        //return "NO" 
                        return nope;
                    }
                }
                else
                {

                    int count = 0;
                    //count occurances of y in A, return y or No as appropraiate 
                    foreach (star s in A)
                    {
                        if (distance(x, s, d))
                        {
                            count++;
                        }
                    }
                    if (count > A.Count / 2)
                    {
                        return x;
                    }
                    return nope;

                }
            }
        }

    }
}
