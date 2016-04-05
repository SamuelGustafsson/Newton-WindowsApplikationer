using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Assignment_1;
using Microsoft.Expression.Interactivity.Layout;

namespace WPF_Assignment_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Samling 
        List<Grid> gridOnCanvasList = new List<Grid>();
        List<GridElementToCanvas> GridElements = new List<GridElementToCanvas>(); 
        private bool isGridinMove = false;
        private Point selectedShapePoint_Start;
        private Point selectedShapePoint_End;
        private bool firstClick = false;
        private int gridNameCounter = 0;
        private GridElementToCanvas lineFrom = null;
        private GridElementToCanvas lineTo = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        // StatusBar events. 
        private void MouseEnterExitArea(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Exit the Application";
        }

        private void FileExit_CLick(object sender, RoutedEventArgs e)
        {
            //TODO: Gör så att programmet frågar om användaren är säker på att den vill stänga programmet.
            this.Close();
        }

        private void RectangleOption_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.CurrentSelectedshape = Selectedshape.Rectangle;
        }

        private void RombOption_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.CurrentSelectedshape = Selectedshape.Romb;
        }

        private void LineOption_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.CurrentSelectedshape = Selectedshape.Line;
        }

        private void SelectedGridOnCanvas(object sender, MouseButtonEventArgs c)
        {
            if (GlobalVariables.CurrentSelectedshape == Selectedshape.Line)
            {
                return;
            }

            isGridinMove = true;
            Grid ChoosenGridElement = (Grid) sender;
            ChoosenGridElement.CaptureMouse();
            
        }
        
        private void MoveSelectedGrid(object sender, MouseEventArgs e)
        {

            Grid ChoosenGridElement = (Grid)sender;

            if (!isGridinMove) return;

            // get the position of the mouse relative to the Canvas
            var mousePosition = e.GetPosition(canvasDrawingArea);

            // center the rect on the mouse
            double left = mousePosition.X - (ChoosenGridElement.ActualWidth / 2);
            double top = mousePosition.Y - (ChoosenGridElement.ActualHeight/ 2);


            Canvas.SetLeft(ChoosenGridElement, left);
            Canvas.SetTop(ChoosenGridElement, top);

            foreach (var grid in GridElements)
            {
                if (ChoosenGridElement.Name == grid.Name)
                {
                    foreach (var line in grid.StartLine)
                    {
                        line.X1 = left;
                        line.Y1 = top;
                    }
                    foreach (var line in grid.EndLine)
                    {
                        line.X2 = left;
                        line.Y2 = top;
                    }
                }
            }
        }
        private void ReleaseSelectedShape(object sender, MouseButtonEventArgs e)
        {

            isGridinMove = false;

            Grid ChoosenGridElement = (Grid)sender;

            ChoosenGridElement.ReleaseMouseCapture();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Skapar ett grid objekt.
            Grid canvasGridObject = new Grid();
            canvasGridObject.MouseLeftButtonDown += SelectedGridOnCanvas;
            canvasGridObject.MouseMove += MoveSelectedGrid;
            canvasGridObject.MouseLeftButtonUp += ReleaseSelectedShape;
            Shape shapeToRender = null;

            // Tar reda på vilken ShapeVariant vi vill lägga ut.
            switch (GlobalVariables.CurrentSelectedshape)
            {
                case Selectedshape.Romb:
                    shapeToRender = new Rectangle() { Fill = Brushes.BlueViolet, Height = 60, Width = 60 };
                    shapeToRender.LayoutTransform = new RotateTransform(45, 15, 15);
                    break;
                case Selectedshape.Rectangle:
                    shapeToRender = new Rectangle() { Fill = Brushes.Red, Height = 35, Width = 35 };
                    break;
                case Selectedshape.Line:

                    return;
                default:
                    return;
            }
            // Hämtar positionen av det valda grid objektet.
            Canvas.SetTop(canvasGridObject, e.GetPosition(canvasDrawingArea).Y);
            Canvas.SetLeft(canvasGridObject, e.GetPosition(canvasDrawingArea).X);

            // 
            canvasGridObject.MouseLeftButtonDown += new MouseButtonEventHandler(GetPosition_Shape_Start);
            canvasGridObject.MouseLeftButtonUp += new MouseButtonEventHandler(GetPosition_Shape_End);

            canvasGridObject.Children.Add(shapeToRender);


            Point userMousePoint = Mouse.GetPosition(canvasDrawingArea);


            double xCoord, yCoord, xWidth, yHeight;

            bool clickedOnGrid = false;


            foreach (Grid grid in gridOnCanvasList)
            {
                xCoord = Canvas.GetLeft(grid);
                yCoord = Canvas.GetTop(grid);

                xWidth = grid.ActualWidth;
                yHeight = grid.ActualHeight;

                if (xCoord < userMousePoint.X && userMousePoint.X < (xCoord + xWidth) && yCoord < userMousePoint.Y && userMousePoint.Y < (yCoord + yHeight))
                {
                    clickedOnGrid = true;
                }
            }

            GridElementToCanvas gridElement =new GridElementToCanvas();
            gridElement.Name = "gridName" + gridNameCounter;
            canvasGridObject.Name = "gridName" + gridNameCounter;
            gridNameCounter++;

            if (GlobalVariables.CurrentSelectedshape == Selectedshape.Romb)
            {
                gridElement.GridCenterX = e.GetPosition(canvasDrawingArea).X + 30;
                gridElement.GridCenterY = e.GetPosition(canvasDrawingArea).Y + 30;
            }
            else if (GlobalVariables.CurrentSelectedshape == Selectedshape.Rectangle)
            {
                gridElement.GridCenterX = e.GetPosition(canvasDrawingArea).X + 25;
                gridElement.GridCenterY = e.GetPosition(canvasDrawingArea).Y + 30;
            }
            Canvas.SetZIndex(canvasGridObject, (int)99);
            GridElements.Add(gridElement);

            // Ritar ut objektet.
            if (!clickedOnGrid)
            {
                canvasDrawingArea.Children.Add(canvasGridObject);
                gridOnCanvasList.Add(canvasGridObject);
            }

            



        }
        private void GetPosition_Shape_Start(object sender, MouseButtonEventArgs e)
        {
            Grid gridSender = (Grid) sender;
            firstClick = true;
            //todo: kanske en point?
            foreach (var gridElement in GridElements)
            {
                if (gridSender.Name == gridElement.Name)
                {
                    selectedShapePoint_Start = new Point(gridElement.GridCenterX, gridElement.GridCenterY);
                    lineFrom = gridElement;
                }
            }
            


        }
        private void GetPosition_Shape_End(object sender, MouseButtonEventArgs e)
        {
            Grid gridSender = (Grid)sender;

            if (firstClick == true && GlobalVariables.CurrentSelectedshape == Selectedshape.Line)
            {
                foreach (var gridElement in GridElements)
                {
                    if (gridSender.Name == gridElement.Name)
                    {
                        selectedShapePoint_End = new Point(gridElement.GridCenterX, gridElement.GridCenterY);
                        lineTo = gridElement;
                    }
                }
                

                Line newLine = new Line()
                {
                    Stroke = Brushes.Blue,
                    StrokeThickness = 2,
                    X1 = selectedShapePoint_Start.X,
                    Y1 = selectedShapePoint_Start.Y,
                    X2 = selectedShapePoint_End.X,
                    Y2 = selectedShapePoint_End.Y
                };
                Canvas.SetZIndex(newLine, (int) 0);

                lineTo.EndLine.Add(newLine);
                lineFrom.StartLine.Add(newLine);

                canvasDrawingArea.Children.Add(newLine);
                firstClick = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            canvasDrawingArea.Children.Clear();
        }
    }
}
