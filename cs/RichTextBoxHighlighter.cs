private void HighlightText(RichTextBox myRtb, string word, Color color)
{

    if (word == "")
    {
        return;
    }

    int s_start = myRtb.SelectionStart, startIndex = 0, index;

    while ((index = myRtb.Text.IndexOf(word, startIndex)) != -1)
    {
        myRtb.Select(index, word.Length);
        myRtb.SelectionColor = color;

        startIndex = index + word.Length;
    }

    myRtb.SelectionStart = s_start;
    myRtb.SelectionLength = 0;
    myRtb.SelectionColor = Color.Black;
}
