using System.Runtime.InteropServices.ObjectiveC;

namespace Calculator;

public partial class MainPage : ContentPage
{
	int currentState = 1;
    string operatorMath;
    double firstNum,secondNum;

	public MainPage()
	{
		InitializeComponent();
        OnClear(this,null);
	}

	void OnClear(object sender, EventArgs e)
	{
        firstNum= 0;
        secondNum= 0;
        currentState = 1;
        this.result.Text = "0";

	}

    void OnNumberSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;

        if (this.result.Text == "0" || currentState < 0)
        {
            this.result.Text = string.Empty;
            if (currentState < 0)
                currentState *= -1;
        }

        this.result.Text += btnPressed;

        double number;
        if (double.TryParse(this.result.Text, out number))
        {
            this.result.Text = number.ToString();
            if (currentState == 1)
            {
                firstNum = number;
            }
            else
            {
                secondNum = number;
            }
        }
    }

    void OnOperatorSelector (object sender, EventArgs e)
    {
        currentState = -2;
        Button button = (Button)sender;
        string btnPressed = button.Text;
        operatorMath = btnPressed;
    }

    void OnCalculate (object sender, EventArgs e)
    {
        if(currentState == 2)
        {
            var result = Total.Sum(firstNum, secondNum, operatorMath);

            this.result.Text = result.ToString();
            firstNum= result;
            currentState= -1;
        }

    }


}

