using WashingMachineApplication.src;
using WashingMachineApplication.src.transversal;
using System;
using System.Windows.Forms;

namespace WashingMachineApplication
{
    public partial class App : Form
    {
        private bool onOffState;
        private bool startPauseState;
        private bool washLaterState;
        private bool minimumState;
        private bool lowState;
        private bool mediumState;
        private bool highState;
        private bool strongState;
        private bool softState;
        private bool blanketState;
        private bool aerocentrifugedState;

        private WashingMachine washingMachine;

        public App()
        {
            InitializeComponent();
            initialize();
        }

        private void onOffButton_Click(object sender, EventArgs e)
        {
            this.onOffState = this.washingMachine.turnOn(this.onOffState);

            if (this.onOffState)
            {
                this.arrowOnOff.Show();
            }
            else
            {
                initialize();
            }
        }

        private void initialize()
        {
            initializeArrows();
            inizializeStates();
            inizializeOutputs();
            inizializeWashingMachine();
        }

        private void initializeArrows()
        {
            this.arrowOnOff.Hide();
            this.arrowStartPause.Hide();
            this.arrowWashLater.Hide();
            this.arrowMinimum.Hide();
            this.arrowLow.Hide();
            this.arrowMedium.Hide();
            this.arrowHigh.Hide();
            this.arrowStrong.Hide();
            this.arrowSoft.Hide();
            this.arrowBlanket.Hide();
            this.arrowAerocentrifuged.Hide();
        }

        private void inizializeStates()
        {
            this.onOffState = false;
            this.startPauseState = false;
            this.washLaterState = false;
            this.minimumState = false;
            this.lowState = false;
            this.mediumState = false;
            this.highState = false;
            this.strongState = false;
            this.softState = false;
            this.blanketState = false;
            this.aerocentrifugedState = false;
        }

        private void inizializeOutputs()
        {
            this.resultTextBox.Clear();
            this.displayTimeTextBox.Text = Constant.ZERO_HOUR;
        }

        private void inizializeWashingMachine()
        {
            this.washingMachine = WashingMachine.build();
        }

        private void startPauseButton_Click(object sender, EventArgs e)
        {
            var canStart = onOffState && (minimumState || lowState || mediumState || highState) && (strongState || softState || blanketState) && aerocentrifugedState && !startPauseState;

            this.startPauseState = this.washingMachine.start(canStart);

            if (this.startPauseState)
            {
                this.arrowStartPause.Show();

                this.washingMachine.evaluateWaterLevel(this.minimumState, this.lowState, this.mediumState, this.highState);
                this.washingMachine.evaluateFunction(this.softState, this.strongState, this.blanketState);
                this.washingMachine.evaluateAerocentrifuged(this.softState, this.strongState, this.blanketState);

                printAerocentrifuged();
                calculateTime();
            }
            else
            {
                this.arrowStartPause.Hide();
            }
        }

        private void printAerocentrifuged()
        {
            this.resultTextBox.Text = this.washingMachine.getFinalProcess();
        }

        private void calculateTime()
        {
            this.displayTimeTextBox.Text = this.washingMachine.calculateTime();
        }

        private void washLaterButton_Click(object sender, EventArgs e)
        {
            if (onOffState && !washLaterState)
            {
                washLaterState = true;
                this.arrowWashLater.Show();
            }
            else
            {
                washLaterState = false;
                this.arrowWashLater.Hide();
            }
        }

        private void minimumButton_Click(object sender, EventArgs e)
        {
            var canStart = onOffState && !startPauseState && !minimumState;

            if (canStart)
            {
                initializeMinimumButton();
                this.arrowMinimum.Show();
            }
            else
            {
                minimumState = false;
                this.arrowMinimum.Hide();
            }
        }

        private void initializeMinimumButton()
        {
            minimumState = true;
            lowState = false;
            mediumState = false;
            highState = false;

            this.arrowLow.Hide();
            this.arrowMedium.Hide();
            this.arrowHigh.Hide();
        }

        private void lowButton_Click(object sender, EventArgs e)
        {
            var canStart = onOffState && !startPauseState && !lowState;

            if (canStart)
            {
                initializeLowButton();
                this.arrowLow.Show();
            }
            else
            {
                lowState = false;
                this.arrowLow.Hide();
            }
        }

        private void initializeLowButton()
        {
            minimumState = false;
            lowState = true;
            mediumState = false;
            highState = false;

            this.arrowMinimum.Hide();
            this.arrowMedium.Hide();
            this.arrowHigh.Hide();
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            var canStart = onOffState && !startPauseState && !mediumState;
            
            if (canStart)
            {
                initializeMediumButton();
                this.arrowMedium.Show();
            }
            else
            {
                mediumState = false;
                this.arrowMedium.Hide();
            }
        }

        private void initializeMediumButton()
        {
            minimumState = false;
            lowState = false;
            mediumState = true;
            highState = false;

            this.arrowMinimum.Hide();
            this.arrowLow.Hide();
            this.arrowHigh.Hide();
        }

        private void highButton_Click(object sender, EventArgs e)
        {
            var canStart = onOffState && !startPauseState && !highState;

            if (canStart)
            {
                initializeHighButton();
                this.arrowHigh.Show();
            }
            else
            {
                highState = false;
                this.arrowHigh.Hide();
            }
        }

        private void initializeHighButton()
        {
            minimumState = false;
            lowState = false;
            mediumState = false;
            highState = true;

            this.arrowMinimum.Hide();
            this.arrowLow.Hide();
            this.arrowMedium.Hide();
        }

        private void strongButton_Click(object sender, EventArgs e)
        {
            var canStart = onOffState && !startPauseState && !strongState;
            
            if (canStart)
            {
                initializeStrongButton();
                this.arrowStrong.Show();
            }
            else
            {
                strongState = false;
                this.arrowStrong.Hide();
            }
        }

        private void initializeStrongButton()
        {
            strongState = true;
            softState = false;
            blanketState = false;

            this.arrowSoft.Hide();
            this.arrowBlanket.Hide();
        }

        private void softButton_Click(object sender, EventArgs e)
        {
            var canStart = onOffState && !startPauseState && !softState;

            if (canStart)
            {
                initializeSoftButton();
                this.arrowSoft.Show();
            }
            else
            {
                softState = false;
                this.arrowSoft.Hide();
            }
        }

        private void initializeSoftButton()
        {
            strongState = false;
            softState = true;
            blanketState = false;

            this.arrowStrong.Hide();
            this.arrowBlanket.Hide();
        }

        private void blanketButton_Click(object sender, EventArgs e)
        {
            var canStart = onOffState && !startPauseState && !blanketState;

            if (canStart)
            {
                initializeBlanketButton();
                this.arrowBlanket.Show();
            }
            else
            {
                blanketState = false;
                this.arrowBlanket.Hide();
            }
        }

        private void initializeBlanketButton()
        {
            strongState = false;
            softState = false;
            blanketState = true;

            this.arrowStrong.Hide();
            this.arrowSoft.Hide();
        }

        private void aerocentrifuguedButton_Click(object sender, EventArgs e)
        {
            var canStart = onOffState && !startPauseState && !aerocentrifugedState;
            
            if (canStart)
            {
                aerocentrifugedState = true;
                this.arrowAerocentrifuged.Show();
            }
            else
            {
                aerocentrifugedState = false;
                this.arrowAerocentrifuged.Hide();
            }
        }
    }
}