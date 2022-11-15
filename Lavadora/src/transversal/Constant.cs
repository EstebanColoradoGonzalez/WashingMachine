using System.Security.Policy;

namespace WashingMachineApplication.src.transversal
{
    public class Constant
    {
        public static string EMPTY = "";

        public static string ZERO_HOUR = "00:00";

        public static string LINE_BREAK = "\r\n";
        public static string DOUBLE_LINE_BREAK = "\r\n\r\n";

        public static double ZERO = 0.0;

        public static double SOFT_SLOPT = 0.05;
        public static double SOFT_INTERCEPT = 0.75;

        public static double STRONG_SLOPT = 0.0833;
        public static double STRONG_INTERCEPT = 1.4166;

        public static double BLANKET_SLOPT = 0.1167;
        public static double BLANKET_INTERCEPT = 1.6666;

        public static string WATER_LEVEL_MINIMUM = "MINIMO";
        public static string WATER_LEVEL_LOW = "Bajo";
        public static string WATER_LEVEL_MEDIUM = "Medio";
        public static string WATER_LEVEL_HIGH = "Alto";

        public static string SOFT = "Suave";
        public static string STRONG = "Fuerte";
        public static string BLANKET = "Cobijas";

        public static int TWO_KILOGRAMS = 2;
        public static int THREE_KILOGRAMS = 3;
        public static int FOUR_KILOGRAMS = 4;
        public static int FIVE_KILOGRAMS = 5;

        public static int SOFT_TIME = 3;
        public static int STRONG_TIME = 7;
        public static int BLANKET_TIME = 9;

        public static int MINUTES_PER_HOUR = 60;
    }
}