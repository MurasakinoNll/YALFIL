namespace mainspline;

public class Entry
{
    public static void Main()
    {
        Random rand = new(1268);
        int pointCount = 20;
        double[] xs1 = new double[pointCount];
        double[] ys1 = new double[pointCount];
        /*for (int i = 1; i < pointCount; i++)
        {
            xs1[i] = xs1[i - 1] + rand.NextDouble() - .5;
            ys1[i] = ys1[i - 1] + rand.NextDouble() - .5;
        }
        (double[] xs2, double[] ys2) = Cubic.InterpolateXY(xs1, ys1, 200);
        var plt = new ScottPlot.Plot(600, 400);
        plt.AddScatter(xs1, ys1, label: "original", markerSize: 7);
        plt.AddScatter(xs2, ys2, label: "interpolated", markerSize: 3);
        plt.Legend();
        plt.SaveFig("interpolation.png");*/
        //interpolate xs1 and ys1 and plot using oxyplot
        (double[] xs2, double[] ys2) = Cubic.InterpolateXY(xs1, ys1, 200);
        var model = new PlotModel { Title = "Interpolation" };
        var series1 = new LineSeries { Title = "Original", MarkerType = MarkerType.Circle };
        var series2 = new LineSeries { Title = "Interpolated", MarkerType = MarkerType.Circle };
        for (int i = 0; i < xs1.Length; i++)
        {
            series1.Points.Add(new DataPoint(xs1[i], ys1[i]));
        }
        for (int i = 0; i < xs2.Length; i++)
        {
            series2.Points.Add(new DataPoint(xs2[i], ys2[i]));
        }
        model.Series.Add(series1);
        model.Series.Add(series2);
        var pngExporter = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
        pngExporter.ExportToFile(model, "interpolation.png");
        

    }
}