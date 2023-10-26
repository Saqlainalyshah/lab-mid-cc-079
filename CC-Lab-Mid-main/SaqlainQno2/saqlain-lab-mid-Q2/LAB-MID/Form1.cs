namespace LAB_MID
{
    public partial class Form1 : Form
    {
        private string input;
        private int currentPosition;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input = InputTextBox.Text + "$";
            currentPosition = 0;

            if (ParseS())
                OutputLabel.Text = "Valid Expression";
            else
                OutputLabel.Text = "Invalid Expression";
        }

        private bool ParseS()
        {
            // S -> E$
            if (ParseE() && Match('$'))
                return true;

            return false;
        }

        private bool ParseE()
        {
            // E -> T E'
            if (ParseT() && ParseEPrime())
                return true;

            return false;
        }

        private bool ParseEPrime()
        {
            // E' -> + T E' | ε
            if (Match('+') && ParseT() && ParseEPrime())
                return true;

            return true; // epsilon
        }

        private bool ParseT()
        {
            // T -> F T'
            if (ParseF() && ParseTPrime())
                return true;

            return false;
        }

        private bool ParseTPrime()
        {
            // T' -> * F T' | ε
            if (Match('*') && ParseF() && ParseTPrime())
                return true;

            return true; // epsilon
        }

        private bool ParseF()
        {
            // F -> ( E ) | id
            if (Match('(') && ParseE() && Match(')'))
                return true;
            else if (Match("id"))
                return true;

            return false;
        }

        private bool Match(char expected)
        {
            if (currentPosition < input.Length && input[currentPosition] == expected)
            {
                currentPosition++;
                return true;
            }

            return false;
        }

        private bool Match(string expected)
        {
            if (currentPosition + expected.Length <= input.Length && input.Substring(currentPosition, expected.Length) == expected)
            {
                currentPosition += expected.Length;
                return true;
            }

            return false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
