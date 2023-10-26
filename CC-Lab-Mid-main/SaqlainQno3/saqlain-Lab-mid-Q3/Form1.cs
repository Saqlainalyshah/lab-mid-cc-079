namespace Lab_mid_Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string GeneratePassword()
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;

            // Check if first name and last name initials are present
            if (firstName.Length < 1 || lastName.Length < 1)
            {
                MessageBox.Show("Please enter your first and last name to generate a password.");
                return null;
            }

            // Generate two random numbers
            Random random = new Random();
            int num1 = random.Next(10);
            int num2 = random.Next(10);

            // Generate uppercase letter
            char uppercaseChar = (char)random.Next('A', 'Z' + 1);

            // Generate two special characters
            string specialChars = "!@#$%^&*()_-+=<>?";

            char specialChar1 = specialChars[random.Next(specialChars.Length)];
            char specialChar2 = specialChars[random.Next(specialChars.Length)];

            // Combine all the elements to create the password
            string password = string.Format("{0}{1}{2}{3}{4}{5}",
                uppercaseChar, firstName[0], lastName[0], num1, num2, specialChar1, specialChar2);

            // Shuffle the password to make it more secure
            password = ShuffleString(password);

            // Limit the password to a maximum length of 16 characters
            if (password.Length > 16)
                password = password.Substring(0, 16);

            return password;
        }

        private string ShuffleString(string input)
        {
            char[] characters = input.ToCharArray();
            Random random = new Random();
            for (int i = characters.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                char temp = characters[i];
                characters[i] = characters[j];
                characters[j] = temp;
            }
            return new string(characters);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = GeneratePassword();
            if (password != null)
            {
                txtGeneratedPassword.Text = password;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}