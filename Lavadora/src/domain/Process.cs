using WashingMachineApplication.src.transversal;

namespace WashingMachineApplication.src.domain
{
    public class Process
    {
        private string process;

        public static Process build()
        {
            return new Process();
        }

        private Process()
        {
            inizializeValues();
        }

        private void inizializeValues()
        {
            this.process = Constant.EMPTY;
        }
        public string getProcess()
        {
            return this.process;
        }

        public void buildWaterLevel(string waterLevel, double value)
        {
            this.process = this.process + "El nivel del agua es " + waterLevel + ", el cual tiene un peso de " + value + " Kilogramos" + Constant.DOUBLE_LINE_BREAK;
        }

        public void buildFunction(double m, double x, double b, string functionType, double function)
        {
            this.process = this.process + "Funcion " + functionType + Constant.DOUBLE_LINE_BREAK +
                                "F(x) = mx + b " + Constant.DOUBLE_LINE_BREAK +
                                "m = " + m + Constant.LINE_BREAK +
                                "x = " + x + Constant.LINE_BREAK +
                                "b = " + b + Constant.DOUBLE_LINE_BREAK +
                                "F(" + x + ") = " + m + "(" + x + ")" + " + " + b + Constant.DOUBLE_LINE_BREAK +
                                "F(" + x + ") = " + function + Constant.DOUBLE_LINE_BREAK;
        }

        public void buildAerocentrifuged(double time, double aerocentrifuged)
        {
            this.process = this.process + "Aerocentrifugado" + Constant.DOUBLE_LINE_BREAK +
                                "Tiempo Extra = " + time + Constant.LINE_BREAK +
                                "F(Tiempo) = " + aerocentrifuged;
        }
    }
}