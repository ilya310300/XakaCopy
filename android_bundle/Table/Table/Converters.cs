using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Table
{
    class vc : IMarkupExtension
    {
        public double Value { get; set; }
        public double Factor { get; set; }
        public string Operation { get; set; }
        public bool Change { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            
            if (Change == true)
            {
                double a = Factor;
                Factor = Value;
                Value = a;
            }
            switch (Operation)
            {
                case "+":
                {
                    return Value + Factor;
                }
                case "-":
                {
                    return Value - Factor;
                }
                case "*":
                {
                    return Value * Factor;
                }
                case "/":
                {
                    return Value / Factor;
                }
                default:
                {
                    return Value;
                }
            }
        }
    }
}
