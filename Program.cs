using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{



    public class Solution
    {
        private int[,,] jobs2;
        private int maxTime1 = 1000;
        private int datasize1 = 0;
        private int[] squence1;
        private int where1 = 0;
        private int answer1 = 0;
        private int starttime1 = 0;
        private int continuetime1 = 0;

        public int solution(int[,] jobs)
        {
            Console.WriteLine("solution is called");

            jobs2 = new int[maxTime1 + 1, jobs.GetLength(0),1];
            datasize1 = jobs.GetLength(0);
            squence1 = new int[datasize1];
            answer1 = 0;

            int index1 = 0;
            int index2 = maxTime1;

            for (int j = 0; j <= maxTime1; j++)
            {
                index1 = 0;
                for (int i = 0; i < datasize1; i++)
                {
                    if (jobs[i, 0] == j && jobs[i, 1] > 0)
                    {
                        jobs2[j, index1, 0] = jobs[i, 1];
                        index1++;
                        index2 = (index2 > jobs[i, 0]) ? jobs[i, 0] : index2;
                    }
                }
            }

            starttime1 = index2;
            calcurate1(index2, index2);
            makeanswer1();
            return answer1;
        }


        public int calcurate1(int index1, int index2)
        {
            //Console.WriteLine("calcurate1 is called " + index1 + " And " + index2);
            int data1 = maxTime1 + 1;

            int index3 = 0;
            int index4 = 0;

            if (index2 > maxTime1)
                index2 = maxTime1;

            if (index1 > maxTime1)
                index1 = maxTime1;

            for (int j = index1; j <= index2; j++)
                for (int i = 0; i < datasize1; i++)
                {
                    if (jobs2[j, i, 0] != 0)
                    {

                        if (data1 > jobs2[j, i, 0])
                        {
                            index3 = j;
                            index4 = i;
                            data1 = jobs2[j, i, 0];
                        }
                    }
                }

            if (where1 >= datasize1)
                return 1;


            else if (data1 > 0 && data1 <= maxTime1)
            {
                squence1[where1] = data1;
                where1++;

                int data2 = jobs2[index3, index4, 0];

                if (starttime1 > index3)
                    answer1 += starttime1 - index3;

                starttime1 += jobs2[index3, index4, 0];
                jobs2[index3, index4, 1] = 0;

                continuetime1 += data2;
                return calcurate1(index1, continuetime1);
            }


            else
                return calcurate1(index2, index2 + 1);
        }

        public void makeanswer1()
        {
            int datasize2 = datasize1;

            for (int i = 0; i < datasize1; i++)
            {
                answer1 += squence1[i];
                datasize2--;
            }

            answer1 /= datasize1;
        }
    }



    class Program
    {


        static void Main(string[] args) //테스트 환경
        {
            string no = "s";
            Solution solut1 = new Solution();
            int[,] name2;

            while (no != "")
            {
                no = Console.ReadLine();


                string[] name1 = no.Split('$');
                name2 = new int[name1.Length, no.Length / name1.Length];
                int[,] name3 = new int[name1.Length, no.Length / name1.Length];

                for (int i = 0; i < name1.Length; i++)
                {

                    string[] name12 = name1[i].Split(',');

                    for (int j = 0; j < name12.Length; j++)
                    {


                        name2[i, j] = int.Parse(name12[j]);
                    }
                }
                Console.WriteLine("Result" + solut1.solution(name2));
                solut1 = new Solution();
            }
        }

    }
}
