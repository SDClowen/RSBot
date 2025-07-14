using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.ViewModels;

namespace RSBot.Views;

/// <summary>
/// Main window of the application that hosts all controls and views
/// </summary>
public partial class MainWindow : Window
{
    private const double MIN_ZOOM = 1.0;
    private const double MAX_ZOOM = 5.0;
    private const double ZOOM_SPEED = 0.1;
    private const double ZOOM_KEYBOARD_SPEED = 0.1;
    private const double PAN_SPEED = 1.0;

    private double _currentZoom = 1.0;
    private Point _lastPanPosition;
    private bool _isPanning;
    private TransformGroup _transformGroup;
    private ScaleTransform _scaleTransform;
    private TranslateTransform _translateTransform;

    /// <summary>
    /// Initializes a new instance of the MainWindow class
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        LanguageManager.Translate(this);
        DataContext = new MainWindowViewModel(this);

        this.Opened += (_, __) =>
        {
            this.EnableMica(WindowsHelper.DwmSystemBackdropType.Tabbed);
            this.EnableDarkMode(); 
            
            InitializeTransforms();
            SetupZoomAndPan();
        };

        EventManager.FireEvent("OnInitialized");
    }

    /// <summary>
    /// Handles the pointer pressed event to enable window dragging
    /// </summary>
    /// <param name="sender">The event sender</param>
    /// <param name="e">The event arguments</param>
    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);

        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            BeginMoveDrag(e);
    }

    private void InitializeTransforms()
    {
        _transformGroup = new TransformGroup();
        _scaleTransform = new ScaleTransform();
        _translateTransform = new TranslateTransform();

        _transformGroup.Children.Add(_scaleTransform);
        _transformGroup.Children.Add(_translateTransform);

        this.RenderTransform = _transformGroup;
    }

    private void SetupZoomAndPan()
    {
        this.PointerWheelChanged += (s, e) =>
        {
            if (e.KeyModifiers == KeyModifiers.Control)
            {
                var point = e.GetCurrentPoint(this);
                var zoomCenter = point.Position;
                var zoomDelta = e.Delta.Y * ZOOM_SPEED;
                var newZoom = Math.Clamp(_currentZoom + zoomDelta, MIN_ZOOM, MAX_ZOOM);

                if (Math.Abs(_currentZoom - newZoom) > 0.001)
                {
                    ApplyZoom(newZoom, zoomCenter);
                    _currentZoom = newZoom;
                }
            }
        };

        this.KeyDown += (s, e) =>
        {
            if (e.KeyModifiers == KeyModifiers.Control)
            {
                var center = new Point(this.Bounds.Width / 2, this.Bounds.Height / 2);
                switch (e.Key)
                {
                    case Key.OemPlus:
                    case Key.Add:
                        var newZoomIn = Math.Clamp(_currentZoom + ZOOM_KEYBOARD_SPEED, MIN_ZOOM, MAX_ZOOM);
                        if (Math.Abs(_currentZoom - newZoomIn) > 0.001)
                        {
                            ApplyZoom(newZoomIn, center);
                            _currentZoom = newZoomIn;
                        }
                        break;

                    case Key.OemMinus:
                    case Key.Subtract:
                        var newZoomOut = Math.Clamp(_currentZoom - ZOOM_KEYBOARD_SPEED, MIN_ZOOM, MAX_ZOOM);
                        if (Math.Abs(_currentZoom - newZoomOut) > 0.001)
                        {
                            ApplyZoom(newZoomOut, center);
                            _currentZoom = newZoomOut;
                        }
                        break;

                    case Key.D0:
                    case Key.NumPad0:
                        ApplyZoom(1.0, center);
                        _currentZoom = 1.0;
                        break;
                }
            } 
        };

        this.PointerPressed += (s, e) =>
        {
            var point = e.GetCurrentPoint(this);
            if (/*e.KeyModifiers == KeyModifiers.Control && */point.Properties.IsRightButtonPressed ||
                (point.Properties.PointerUpdateKind == PointerUpdateKind.Other && e.Pointer.IsPrimary))
            {
                _isPanning = true;
                _lastPanPosition = point.Position;
                e.Pointer.Capture(this);
            }
        };

        this.PointerReleased += (s, e) =>
        {
            if (_isPanning)
            {
                _isPanning = false;
                e.Pointer.Capture(null);
            }
        };

        this.PointerMoved += (s, e) =>
        {
            if (_isPanning)
            {
                var point = e.GetCurrentPoint(this);
                var delta = point.Position - _lastPanPosition;
                _lastPanPosition = point.Position;

                ApplyPan(delta.X * PAN_SPEED, delta.Y * PAN_SPEED);
            }
        };
    }

    private void ApplyZoom(double newZoom, Point zoomCenter)
    {
        var zoomFactor = newZoom / _currentZoom;
        var pointToCenter = new Point(
            zoomCenter.X - this.Bounds.Width / 2,
            zoomCenter.Y - this.Bounds.Height / 2
        );

        var maxX = Math.Max(0, (this.Bounds.Width * (newZoom - 1)) / 2);
        var maxY = Math.Max(0, (this.Bounds.Height * (newZoom - 1)) / 2);

        var newX = Math.Clamp(_translateTransform.X * zoomFactor + pointToCenter.X * (1 - zoomFactor), -maxX, maxX);
        var newY = Math.Clamp(_translateTransform.Y * zoomFactor + pointToCenter.Y * (1 - zoomFactor), -maxY, maxY);

        _scaleTransform.ScaleX = newZoom;
        _scaleTransform.ScaleY = newZoom;
        _translateTransform.X = newX;
        _translateTransform.Y = newY;
    }

    private void ApplyPan(double deltaX, double deltaY)
    {
        var maxX = Math.Max(0, (this.Bounds.Width * (_currentZoom - 1)) / 2);
        var maxY = Math.Max(0, (this.Bounds.Height * (_currentZoom - 1)) / 2);

        var newX = Math.Clamp(_translateTransform.X + deltaX, -maxX, maxX);
        var newY = Math.Clamp(_translateTransform.Y + deltaY, -maxY, maxY);

        _translateTransform.X = newX;
        _translateTransform.Y = newY;
    }

}