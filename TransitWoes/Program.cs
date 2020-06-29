using System;

namespace TransitWoes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Transit Woes
            // https://open.kattis.com/problems/transitwoes
            // time schedule caculations 

            var parameters = EnterFirstLine();

            var myTime = TimeCalculation(parameters);

            var result = ClassInTime(parameters, myTime);

            Console.WriteLine(result);
        }
        private static string ClassInTime(int[] parameters, int yourTime)
        {
            int s = parameters[0];
            int t = parameters[1];
            int n = parameters[2];

            int requiredTime = t - s;
            if (yourTime <= requiredTime)
                return "yes";
            else return "no";
        }

        private static int TimeCalculation(int[] parameters)
        {
            int s = parameters[0];
            int t = parameters[1];
            int n = parameters[2];

            var second = EnterSecondLine(n);
            var third = EnterThirdFourthLine(n);
            var fourth = EnterThirdFourthLine(n);

            int sum = second[0];
            for (int i = 0; i < third.Length; i++)
            {
                if (sum % fourth[i] == 0)
                    sum = sum + third[i] + second[i + 1];
                else
                    sum = sum + third[i] + Math.Abs(fourth[i] - (sum % fourth[i])) + second[i + 1];
            }
            return sum;
        }
        private static int[] EnterThirdFourthLine(int n)
        {
            string[] arr = new string[n];
            int[] res = new int[n];
            try
            {
                arr = Console.ReadLine().Split(' ', n);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = int.Parse(arr[i]);
                }
                if (EnterThirdFourthLineConditions(res) == false)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterThirdFourthLine(n);
            }
            return res;
        }
        private static bool EnterThirdFourthLineConditions(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 1 || nums[i] > 1000)
                    return false;
            }
            return true;
        }

        private static int[] EnterSecondLine(int n)
        {
            string[] arr = new string[n + 1];
            int[] res = new int[n + 1];
            try
            {
                arr = Console.ReadLine().Split(' ', n + 1);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = int.Parse(arr[i]);
                }
                if (SecondLineConditions(res) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterSecondLine(n);
            }
            return res;
        }
        private static bool SecondLineConditions(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0 || nums[i] > 1000)
                    return false;
            }
            return true;
        }
        private static int[] EnterFirstLine()
        {
            int[] res = new int[3] { 0, 0, 0 };
            string[] arr = new string[3] { "", "", "" };
            try
            {
                arr = Console.ReadLine().Split(' ', 3);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = int.Parse(arr[i]);
                }
                if (FirstLineConditions(res) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterFirstLine();
            }
            return res;
        }
        private static bool FirstLineConditions(int[] nums)
        {
            // 0 <= s <= t <= 1000 ////  1 <= n <= 20
            int s = nums[0];
            int t = nums[1];
            int n = nums[2];

            if (s >= 0 && s <= t && t <= 1000 && n >= 1 && n <= 20)
                return true;
            else return false;
        }
    }
}
