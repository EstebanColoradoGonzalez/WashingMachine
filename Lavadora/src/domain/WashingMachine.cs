using WashingMachineApplication.src.domain;
using WashingMachineApplication.src.transversal;

namespace WashingMachineApplication.src
{
    public class WashingMachine
    {
        private double waterLevel;
        private double function;
        private double aerocentrifuged;

        private Process process;

        public static WashingMachine build()
        {
            return new WashingMachine();
        }

        private WashingMachine()
        {
            inizializeValues();
        }

        public bool turnOn(bool onOffState)
        {
            if (onOffState)
            {
                inizializeValues();

                return false;
            }

            return true;
        }

        private void inizializeValues()
        {
            this.waterLevel = Constant.ZERO;
            this.function = Constant.ZERO;
            this.aerocentrifuged = Constant.ZERO;
            this.process = Process.build();
        }

        public bool start(bool canStart)
        {
            if (!canStart)
            {
                return false;
            }

            return true;
        }

        public void evaluateWaterLevel(bool minimumState, bool lowState, bool mediumState, bool highState)
        {
            string waterLevelText = Constant.EMPTY;

            if (minimumState)
            {
                this.waterLevel = Constant.TWO_KILOGRAMS;

                waterLevelText = Constant.WATER_LEVEL_MINIMUM;
            }
            else if (lowState)
            {
                this.waterLevel = Constant.THREE_KILOGRAMS;

                waterLevelText = Constant.WATER_LEVEL_LOW;
            }
            else if (mediumState)
            {
                this.waterLevel = Constant.FOUR_KILOGRAMS;

                waterLevelText = Constant.WATER_LEVEL_MEDIUM;
            }
            else if (highState)
            {
                this.waterLevel = Constant.FIVE_KILOGRAMS;

                waterLevelText = Constant.WATER_LEVEL_HIGH;
            }

            this.process.buildWaterLevel(waterLevelText, this.waterLevel);
        }

        public void evaluateFunction(bool softState, bool strongState, bool blanketState)
        {
            string functionTypeText = Constant.EMPTY;
            double m = Constant.ZERO;
            double x = Constant.ZERO;
            double b = Constant.ZERO;

            if (softState)
            {
                m = Constant.SOFT_SLOPT;
                x = this.waterLevel;
                b = Constant.SOFT_INTERCEPT;

                functionTypeText = Constant.SOFT;

                this.function = (m * x) + b;
            }
            else if (strongState)
            {
                m = Constant.STRONG_SLOPT;
                x = this.waterLevel;
                b = Constant.STRONG_INTERCEPT;

                functionTypeText = Constant.STRONG;

                this.function = (m * x) + b;
            }
            else if (blanketState)
            {
                m = Constant.BLANKET_SLOPT;
                x = this.waterLevel;
                b = Constant.BLANKET_INTERCEPT;

                functionTypeText = Constant.BLANKET;

                this.function = (m * x) + b;
            }

            this.process.buildFunction(m, x, b, functionTypeText, this.function);
        }

        public void evaluateAerocentrifuged(bool softState, bool strongState, bool blanketState)
        {
            double time = Constant.ZERO;

            if (softState)
            {
                time = Constant.SOFT_TIME;

                this.aerocentrifuged = this.function + (time / Constant.MINUTES_PER_HOUR);
            }
            else if (strongState)
            {
                time = Constant.STRONG_TIME;

                this.aerocentrifuged = this.function + (time / Constant.MINUTES_PER_HOUR);
            }
            else if (blanketState)
            {
                time = Constant.BLANKET_TIME;

                this.aerocentrifuged = this.function + (time / Constant.MINUTES_PER_HOUR);
            }

            this.process.buildAerocentrifuged(time, this.aerocentrifuged);
        }

        public string getFinalProcess()
        {
            return this.process.getProcess();
        }

        public string calculateTime()
        {
            var hours = (int)this.aerocentrifuged;
            var decimalPart = this.aerocentrifuged - hours;
            var minutes = (int)(decimalPart * Constant.MINUTES_PER_HOUR);

            return hours + ":" + minutes;
        }
    }
}