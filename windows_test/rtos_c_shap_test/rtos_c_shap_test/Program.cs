using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;



namespace rtos_c_shap_test
{
    internal class Program
    {
        static SerialPort Serialport1 = new SerialPort();
        static Stopwatch _Stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            byte[] return_value = { 0x00};

            Serialport1 = new SerialPort("COM3", 2000000, Parity.None, 8);
            Serialport1.Open();

            double ex_lMilliseconds = 0;
            byte[] input_c = {0x41};

            for(int i=0;i<1000;i++)
            {
                Serialport1.ReadExisting();
            }

            for (int i = 0; i < 1000; i++)
            {
                input_c[0] = input_c[0]+=1;
                if(input_c[0]>0x4A)
                {
                    input_c[0] = 0x41;
                }
                _Stopwatch.Start();
                Serialport1.Write(Encoding.Default.GetString(input_c));
                Serialport1.Read(return_value, 0, 1);
                _Stopwatch.Stop();
                long lElapsedTicks = _Stopwatch.ElapsedTicks;
                long lTicksPerSecond = Stopwatch.Frequency;
                double lMilliseconds = 1000.0 * (double)lElapsedTicks / (double)lTicksPerSecond;
                double delta = lMilliseconds - ex_lMilliseconds;
                ex_lMilliseconds = lMilliseconds;

                if (input_c[0] == return_value[0])
                {
                    string str_return_char = Encoding.Default.GetString(return_value);
                    Console.WriteLine(i+str_return_char+":"+delta.ToString("F3") + " ms ");
                }else
                {
                    Console.WriteLine("FAILD: input="+ input_c[0] + ",result = " + return_value[0]);
                }
                //Thread.Sleep(0);
            }
            Serialport1.Close();
            Console.ReadLine(); 
        }
    }
}
