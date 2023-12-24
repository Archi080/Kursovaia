using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BreaststrokeAnimation
{
    public partial class MainWindow : Window
    {
        bool IsAnimationCreated = false;
        // создаем анимации
        DoubleAnimation rotateAnimation = new DoubleAnimation
        {
            From = 200,
            To = 135,
            Duration = TimeSpan.FromSeconds(2),
            AutoReverse = false,
            RepeatBehavior = RepeatBehavior.Forever
        };
        DoubleAnimation rotateAnimation1 = new DoubleAnimation
        {
            From = 160,
            To = 225,
            Duration = TimeSpan.FromSeconds(2),
            AutoReverse = false,
            RepeatBehavior = RepeatBehavior.Forever
        };

        DoubleAnimation rotateAnimation3 = new DoubleAnimation
        {
            From = 90,
            To = 30,
            Duration = TimeSpan.FromSeconds(2),
            AutoReverse = false,
            RepeatBehavior = RepeatBehavior.Forever
        };
        DoubleAnimation rotateAnimation4 = new DoubleAnimation
        {
            From = 270,
            To = 330,
            Duration = TimeSpan.FromSeconds(2),
            AutoReverse = false,
            RepeatBehavior = RepeatBehavior.Forever,
        };
        DoubleAnimation waterAnimation1 = new DoubleAnimation
        {
            From = 0,
            To = 400,
            Duration = TimeSpan.FromSeconds(2),
            AutoReverse = false,
            RepeatBehavior = RepeatBehavior.Forever,
        };
        // Создаем голову пловца
        Ellipse head = new Ellipse
        {
            Width = 35,
            Height = 35,
            Fill = Brushes.Blue
        };

        // Создаем туловище пловца
        Rectangle body = new Rectangle
        {
            Width = 10,
            Height = 50,
            Fill = Brushes.Blue
        };

        // Создаем руки пловца
        Line arm = new Line
        {
            X1 = 0,
            Y1 = 0,
            X2 = 20,
            Y2 = 40,
            Stroke = Brushes.Blue,
            StrokeThickness = 5
        };

        Line arm1 = new Line
        {
            X1 = 0,
            Y1 = 0,
            X2 = -20,
            Y2 = 40,
            Stroke = Brushes.Blue,
            StrokeThickness = 5
        };

        // Создаем ноги пловца (линии)
        Line leg1 = new Line
        {
            X1 = 0,
            Y1 = 0,
            X2 = 20,
            Y2 = 40,
            Stroke = Brushes.Blue,
            StrokeThickness = 5
        };

        Line leg2 = new Line
        {
            X1 = 0,
            Y1 = 0,
            X2 = -20,
            Y2 = 40,
            Stroke = Brushes.Blue,
            StrokeThickness = 5
        };
        // создаем бортики бассейна 
        Line bort1 = new Line
        {
            X1 = 0,
            Y1 = 0,
            X2 = 0,
            Y2 = 400,
            Stroke = Brushes.Red,
            StrokeThickness = 5
        };
        Line bort2 = new Line
        {
            X1 = 0,
            Y1 = 0,
            X2 = 0,
            Y2 = 400,
            Stroke = Brushes.Red,
            StrokeThickness = 5
        };
        // создаем водные потоки
        Line water1 = new Line
        {
            X1 = 0,
            Y1 = 0,
            X2 = 0,
            Y2 = 30,
            Stroke = Brushes.Blue,
            StrokeThickness = 5
        };
        Line water2 = new Line
        {
            X1 = 5,
            Y1 = 10,
            X2 = 5,
            Y2 = 40,
            Stroke = Brushes.Blue,
            StrokeThickness = 5
        };
        Line water3 = new Line
        {
            X1 = 10,
            Y1 = 150,
            X2 = 10,
            Y2 = 180,
            Stroke = Brushes.Blue,
            StrokeThickness = 5
        };
        Line water4 = new Line
        {
            X1 = 15,
            Y1 = 160,
            X2 = 15,
            Y2 = 190,
            Stroke = Brushes.Blue,
            StrokeThickness = 5
        };
        public MainWindow()
        {
            InitializeComponent();
            CreateBreaststrokeAnimation();

        }

        private void CreateBreaststrokeAnimation()
        {
            

            // Добавляем элементы на Canvas
            canvas.Children.Add(head);
            canvas.Children.Add(body);
            canvas.Children.Add(arm);
            canvas.Children.Add(arm1);
            canvas.Children.Add(leg1);
            canvas.Children.Add(leg2);
            canvas.Children.Add(bort1);
            canvas.Children.Add(bort2);
            canvas.Children.Add(water1);
            canvas.Children.Add(water2);
            canvas.Children.Add(water3);
            canvas.Children.Add(water4);

            // Устанавливаем начальное положение головы в середину
            Canvas.SetLeft(head, 238);
            Canvas.SetTop(head, 70);

            // Устанавливаем начальное положение туловища
            Canvas.SetLeft(body, 250);
            Canvas.SetTop(body, 100);

            // Устанавливаем начальное положение ног
            Canvas.SetLeft(leg1, 255);
            Canvas.SetTop(leg1, 145);

            Canvas.SetLeft(leg2, 255);
            Canvas.SetTop(leg2, 145);

            // Устанавливаем начальное положение рук
            Canvas.SetLeft(arm, 250);
            Canvas.SetTop(arm, 110);

            Canvas.SetLeft(arm1, 260);
            Canvas.SetTop(arm1, 110);
            // Устанавливаем начальное положение бортиков бассейна и водных потоков

            Canvas.SetLeft(bort1, 160);
            Canvas.SetTop(bort1, 0);

            Canvas.SetLeft(bort2, 350);
            Canvas.SetTop(bort2, 0);

            Canvas.SetLeft(water1, 200);
            Canvas.SetTop(water1, 50);

            Canvas.SetLeft(water2, 180);
            Canvas.SetTop(water2, 50);

            Canvas.SetLeft(water3, 300);
            Canvas.SetTop(water3, 110);

            Canvas.SetLeft(water4, 310);
            Canvas.SetTop(water4, 120);

            // Привязываем анимацию к RotateTransform линии
            RotateTransform rotateTransform = new RotateTransform();
            arm.RenderTransform = rotateTransform;

            RotateTransform rotateTransform1 = new RotateTransform();
            arm1.RenderTransform = rotateTransform1;

            RotateTransform rotateTransform3 = new RotateTransform();
            leg1.RenderTransform = rotateTransform3;

            RotateTransform rotateTransform4 = new RotateTransform();
            leg2.RenderTransform = rotateTransform4;

            // Привязываем анимацию к свойству Angle RotateTransform
            Storyboard.SetTarget(rotateAnimation, rotateTransform);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("Angle"));

            Storyboard.SetTarget(rotateAnimation1, rotateTransform1);
            Storyboard.SetTargetProperty(rotateAnimation1, new PropertyPath("Angle"));

            Storyboard.SetTarget(rotateAnimation3, rotateTransform1);
            Storyboard.SetTargetProperty(rotateAnimation3, new PropertyPath("Angle"));

            Storyboard.SetTarget(rotateAnimation4, rotateTransform1);
            Storyboard.SetTargetProperty(rotateAnimation4, new PropertyPath("Angle"));

            Storyboard.SetTarget(waterAnimation1, water1);
            Storyboard.SetTargetProperty(waterAnimation1, new PropertyPath(Canvas.TopProperty));

            Storyboard.SetTarget(waterAnimation1, water2);
            Storyboard.SetTargetProperty(waterAnimation1, new PropertyPath(Canvas.TopProperty));

            Storyboard.SetTarget(waterAnimation1, water3);
            Storyboard.SetTargetProperty(waterAnimation1, new PropertyPath(Canvas.TopProperty));

            Storyboard.SetTarget(waterAnimation1, water4);
            Storyboard.SetTargetProperty(waterAnimation1, new PropertyPath(Canvas.TopProperty));

            // Создаем объект Storyboard и добавляем к нему анимации
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(rotateAnimation);
            storyboard.Children.Add(rotateAnimation1);
            storyboard.Children.Add(rotateAnimation3);
            storyboard.Children.Add(rotateAnimation4);
            storyboard.Children.Add(waterAnimation1);

            // Запускаем анимации
            arm.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
            arm1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation1);
            leg1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation3);
            leg2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation4);

            water1.BeginAnimation(Canvas.TopProperty, waterAnimation1);
            water2.BeginAnimation(Canvas.TopProperty, waterAnimation1);
            water3.BeginAnimation(Canvas.TopProperty, waterAnimation1);
            water4.BeginAnimation(Canvas.TopProperty, waterAnimation1);

            IsAnimationCreated = true;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsAnimationCreated == false) { return; }
            rotateAnimation.Duration = TimeSpan.FromSeconds(e.NewValue);
            rotateAnimation1.Duration = TimeSpan.FromSeconds(e.NewValue);
            rotateAnimation3.Duration = TimeSpan.FromSeconds(e.NewValue);
            rotateAnimation4.Duration = TimeSpan.FromSeconds(e.NewValue);
            waterAnimation1.Duration = TimeSpan.FromSeconds(e.NewValue);

            arm.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
            arm1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation1);
            leg1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation3);
            leg2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation4);

            water1.BeginAnimation(Canvas.TopProperty, waterAnimation1);
            water2.BeginAnimation(Canvas.TopProperty, waterAnimation1);
            water3.BeginAnimation(Canvas.TopProperty, waterAnimation1);
            water4.BeginAnimation(Canvas.TopProperty, waterAnimation1);;
        }
    }
}