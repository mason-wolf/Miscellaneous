   Timer = new System.Windows.Forms.Timer();
   Timer.Interval = 500;
   Timer.Tick += Ticker;
   Timer.Start();

   StopWatch = new Stopwatch();
   StopWatch.Start();

}

private void Ticker(object sender, EventArgs e)
{
   TimeSpan TimeSpan = StopWatch.Elapsed;
   ElapsedTimeContainer.Text = String.Format("{0:00}:{1:00}:{2:00}", TimeSpan.Hours, TimeSpan.Minutes, TimeSpan.Seconds);
}
