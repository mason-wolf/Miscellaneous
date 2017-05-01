using System;
using System.Diagnostics;
using System.IO;

// API for creating HTML (.hta) applications. 

public class Window {

    public string Title;
    public int Width;
    public int Height;
    public bool FullScreen;
    public object Border;
    public object State;
    public object Scroll;
    public enum BorderStyle : int { Thin, None };
    public enum WindowState : int { Normal, Maximize };
    public enum ScrollState : int { No, Auto };
    public bool MaximizeButton;
    public bool MinimizeButton;
    public string BackgroundColor;
    public string BorderColor;

    public void Draw() {

        string[] Header = {
            "<HTA:APPLICATION",
            "Border='" + Border.ToString() + "'",
            "WindowState='" + State.ToString() + "'",
            "Scroll='" + Scroll.ToString() + "'",
            "Navigable='yes'"
            // icon
        };

        string[] Style = {
            "<style type='text/css'> body { background-color: " + BackgroundColor + "; border: 1px solid " + BorderColor + ";}",
            "</style>",
            "<title>" + Title + "</title"
        };

        using (StreamWriter Writer = new StreamWriter("app.hta")) {

            foreach (string parameter in Header) {
                Writer.WriteLine(parameter);
            }

            if (MaximizeButton) {
                Writer.WriteLine("MaximizeButton='yes'");
            }
            else {
                Writer.WriteLine("MaximizeButton='no'");
            }

            if (MinimizeButton) {
                Writer.WriteLine("MinimizeButton='yes'");
            }
            else {
                Writer.WriteLine("MinimizeButton='no'/>");
            }

            foreach (string element in Style) {
                Writer.WriteLine(element);
            }
        }
    }
}

public class HTMLWrapper : Window {

    static void Main() {

        Window Window = new Window();
        Window.Title = "app";
        Window.Width = 500;
        Window.Height = 500;
        Window.FullScreen = false;
        Window.Border = BorderStyle.Thin;
        Window.MaximizeButton = false;
        Window.MinimizeButton = false;
        Window.State = WindowState.Maximize;
        Window.Scroll = ScrollState.No;
        Window.BackgroundColor = "Black";
        Window.BorderColor = "Black";
        Window.Draw();

    }

}
