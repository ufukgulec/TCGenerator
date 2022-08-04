using System;
using System.Collections.Generic;

namespace TCGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var tcNum = singleGenerator(null);
            Console.WriteLine(String.Format("Tek adet üretilmiş rastgele Tc kimlik numarası: {0} \n", tcNum));

            Console.WriteLine("Rastgele Tc kimlik numarası kaçla başlasın?");
            int first = Convert.ToInt32(Console.ReadLine());
            tcNum = singleGenerator(first);
            Console.WriteLine(String.Format("Tek adet üretilmiş rastgele Tc kimlik numarası: {0}\n", tcNum));

            Console.WriteLine("Kaç tane Tc kimlik numarası istiyorsunuz?");
            int adet = Convert.ToInt32(Console.ReadLine());
            var tcNums = rangeGenerator(adet);

            foreach (var item in tcNums)
            {
                Console.WriteLine(String.Format("-Üretilmiş rastgele Tc kimlik numarası: {0}", item));
            }
        }
        /// <summary>
        /// Bir tane geçerli Tc üretir
        /// </summary>
        /// <returns></returns>
        static long singleGenerator(int? First)
        {
            Random random = new Random();
            List<int> list = new List<int>();

            if (First == null)
            {
                First = random.Next(1, 9);
                list.Add(Convert.ToInt32(First));
            }
            else
            {
                list.Add(Convert.ToInt32(First));
            }



            for (int i = 0; i < 8; i++)
            {
                list.Add(random.Next(0, 9));
            }

            list.Add(((list[0] + list[2] + list[4] + list[6] + list[8]) * 7 + (list[1] + list[3] + list[5] + list[7]) * 9) % 10);
            list.Add(((list[0] + list[2] + list[4] + list[6] + list[8]) * 8) % 10);

            string tc = "";
            foreach (var item in list)
            {
                tc += item.ToString();
            }
            long tcNum = Convert.ToInt64(tc);
            return tcNum;

        }
        /// <summary>
        /// İstenilen adet kadar Tc üretir
        /// </summary>
        /// <param name="count">İstenilen Adet</param>
        /// <returns>Rastgele Tc dizisi</returns>
        static List<long> rangeGenerator(int count)
        {
            Random random = new Random();
            List<long> ids = new List<long>();

            for (int i = 0; i < count; i++)
            {
                List<int> list = new List<int>();

                list.Add(random.Next(1, 9));

                for (int k = 0; k < 8; k++)
                {
                    list.Add(random.Next(0, 9));
                }

                list.Add(((list[0] + list[2] + list[4] + list[6] + list[8]) * 7 + (list[1] + list[3] + list[5] + list[7]) * 9) % 10);
                list.Add(((list[0] + list[2] + list[4] + list[6] + list[8]) * 8) % 10);

                string tc = "";
                foreach (var item in list)
                {
                    tc += item.ToString();
                }
                long tcNum = Convert.ToInt64(tc);
                ids.Add(tcNum);
            }

            return ids;

        }

        /// <summary>
        /// Girilen Tc'nin kontrolünü sağlar.
        /// </summary>
        /// <param name="idNum">Girilen Tc</param>
        /// <returns>Tc formatına uygunsa True döner</returns>
        static bool Control(long idNum)
        {
            List<int> idList = new List<int>();
            for (int i = 0; i < 11; i++)
            {
                idList.Add(Convert.ToInt32(idNum % 10));
                idNum = idNum / 10;
            }
            idList.Reverse();

            int Digit10 = ((idList[0] + idList[2] + idList[4] + idList[6] + idList[8]) * 7 + (idList[1] + idList[3] + idList[5] + idList[7]) * 9) % 10;
            int Digit11 = ((idList[0] + idList[2] + idList[4] + idList[6] + idList[8]) * 8) % 10;


            if (Digit10 == idList[9] && Digit11 == idList[10])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
