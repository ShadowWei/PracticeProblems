using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumTheory
{
    class NumTheory
    {
        static void Main(string[] args)
        {
            string startInput = Console.ReadLine(); 
            while (true)
            {
                if (string.IsNullOrEmpty(startInput))
                {
                    break;
                }
                else
                {
                    string[] data = startInput.Split(' ');

                    if (data[0].Equals("gcd"))
                    {
                        Console.WriteLine(gcd(long.Parse(data[1]), long.Parse(data[2])));
                    }

                    else if (data[0].Equals("exp"))
                    {
                        Console.WriteLine( exp(long.Parse(data[1]), long.Parse(data[2]), long.Parse(data[3]) ));
                    }

                    else if (data[0].Equals("inverse"))
                    {
                        long i = inverse(long.Parse(data[1]), long.Parse(data[2])); 
                        if (i == -1)
                        {
                            Console.WriteLine("none"); 
                        }
                        else
                        {
                            Console.WriteLine(i);
                        }
                    }

                    else if (data[0].Equals("isprime"))
                    {
                        Console.WriteLine(isprime(long.Parse(data[1])));
                    }

                    else if (data[0].Equals("key"))
                    {
                        long[] result = Key(long.Parse(data[1]), long.Parse(data[2])); 
                        Console.WriteLine(result[0] + " " + result[1] + " " + result[2]);
                    }
                }
               
                startInput = Console.ReadLine(); 
            }
        }

        public static long[] Key(long p, long q)
        {
            long[] result = new long[3];
            long phi = (p-1)*(q-1);
            long e = 2;
            while (true)
            {
                if (gcd(phi, e) == 1)
                {
                    break; 
                }
                e++; 
            }
            result[0] = p * q;
            result[1] = e;
            result[2] = inverse(e, phi); 
            return result; 
        }

        public static long[] Euclid(long a, long b)
        {
            if (b == 0)
            {
                long[] e = new long[] { 1, 0, a };
                return e;
            }
            else
            {
                long[] e = Euclid(b, a % b);
                long[] result = { e[1], e[0] - ((a / b) * e[1]), e[2] };
                return result;
            }
        }

        public static long inverse(long a, long N)
        {
            long[] inver = Euclid(a, N);
            if (inver[2] == 1)
            {
                long i = inver[0] % N;
                if (i < 0)
                {
                    i = i + N; 
                }
                return i; 
            }
            else
            {
                return -1; 
            }
        }

        public static long exp(long x, long y, long N)
        {
            if (y == 0)
            {
                return 1; 
            }
            else
            {
                long z = exp(x, y/2, N);
                if (y % 2 == 0)
                {
                    long zz = ((z % N) * (z % N)) % N; 
                    return zz; 
                }
                else
                {
                    long xzz = x % N * (( (z % N) * (z % N) ) % N) % N ;
                    return xzz;
                }
            }
        }
        public static long gcd(long a, long b)
        {
            if (b == 0)
            {
                return a; 
            }
            else
            {
                long c = a % b;
                if (c < 0)
                {
                    c += b; 
                }
                return gcd(b, c); 
            }
        }

        public static string isprime(long num)
        {
            long i = 2; 
            while (i < 6)
            {
                long nonPrime = exp(i, num -1, num);
                if (nonPrime != 1)
                {
                    return "no"; 
                }
                i++; 
            }
            return "yes"; 
        }
    }
}
