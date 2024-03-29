using System.Data;

namespace BorderControl;

public partial class ThisIsBorderingInsanity : ContentPage
{
	public ThisIsBorderingInsanity()
	{
		InitializeComponent();
	}

    private void Print(object sender, EventArgs e)
    {
		Button btn = (Button)sender;
		lbl.Text += btn.Text;
    }
	private void MethodPrint(object sender, EventArgs e)
	{
        Button btn = (Button)sender;
        if (lbl.Text.Length > 0 && (lbl.Text[lbl.Text.Length - 1] != '.'
			&& lbl.Text[lbl.Text.Length - 1] != '+'
			&& lbl.Text[lbl.Text.Length - 1] != '-'
			&& lbl.Text[lbl.Text.Length - 1] != '*'
			&& lbl.Text[lbl.Text.Length - 1] != '/'
			&& lbl.Text[lbl.Text.Length - 1] != '%'))
		{
            lbl.Text += btn.Text;
        }
		else if (lbl.Text.Length == 0 && btn.Text == "-")
		{
            lbl.Text += btn.Text;
        }
	}
	private void Delete(object sender, EventArgs e)
	{
		if (lbl.Text.Length>0) lbl.Text=lbl.Text.Remove(lbl.Text.Length-1);
	}
	private void Reset(object sender, EventArgs e)
	{
		lbl.Text = "";
	}
	private void Calculate(object sender, EventArgs e)
	{
        if (lbl.Text.Length > 0 && (lbl.Text[lbl.Text.Length - 1] == '.'
            || lbl.Text[lbl.Text.Length - 1] == '+'
            || lbl.Text[lbl.Text.Length - 1] == '-'
            || lbl.Text[lbl.Text.Length - 1] == '*'
            || lbl.Text[lbl.Text.Length - 1] == '/'
            || lbl.Text[lbl.Text.Length - 1] == '%'))
        {
            lbl.Text = lbl.Text.Remove(lbl.Text.Length - 1);
        }
        try
        {
            lbl.Text = $"{new DataTable().Compute(lbl.Text, null)}";
        }
        catch
        {
            lbl.Text = "Error";
        }
    }
}