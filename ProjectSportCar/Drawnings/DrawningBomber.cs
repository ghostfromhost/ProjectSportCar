using System.Drawing.Drawing2D;
using ProjectSportCar.Entities;

namespace ProjectSportCar.Drawnings;

/// <summary>
/// Класс для прорисовки и перемещения бомбардировщика (базовый)
/// </summary>
public class DrawningBomber
{
    protected EntityBomber? _entityBomber;
    protected int? _startPosX;
    protected int? _startPosY;

    private readonly int _drawningWidth = 140;
    private readonly int _drawningHeight = 80;

    public int? PosX => _startPosX;
    public int? PosY => _startPosY;
    public double? CarStep => _entityBomber?.Step;
    public int DrawningWidth => _drawningWidth;
    public int DrawningHeight => _drawningHeight;

    // Конструктор без параметров для инициализации полей
    private DrawningBomber()
    {
        _startPosX = null;
        _startPosY = null;
    }

    /// <summary>Основной конструктор для простого бомбардировщика</summary>
    public DrawningBomber(int speed, double weight, Color bodyColor) : this()
    {
        _entityBomber = new EntityBomber(speed, weight, bodyColor);
    }

    /// <summary>Конструктор для наследников (позволяет изменить размеры)</summary>
    protected DrawningBomber(int width, int height) : this()
    {
        _drawningWidth = width;
        _drawningHeight = height;
    }

    public void SetPosition(int x, int y)
    {
        _startPosX = x;
        _startPosY = y;
    }

    public void MoveLeft()
    {
        if (_entityBomber is null || !_startPosX.HasValue) return;
        _startPosX -= (int)_entityBomber.Step;
    }

    public void MoveRight()
    {
        if (_entityBomber is null || !_startPosX.HasValue) return;
        _startPosX += (int)_entityBomber.Step;
    }

    public void MoveUp()
    {
        if (_entityBomber is null || !_startPosY.HasValue) return;
        _startPosY -= (int)_entityBomber.Step;
    }

    public void MoveDown()
    {
        if (_entityBomber is null || !_startPosY.HasValue) return;
        _startPosY += (int)_entityBomber.Step;
    }

    /// <summary>Виртуальный метод отрисовки</summary>
    public virtual void DrawTransport(Graphics g)
    {
        if (_entityBomber is null || !_startPosX.HasValue || !_startPosY.HasValue)
            return;

        int x = _startPosX.Value;
        int y = _startPosY.Value;
        Color bodyColor = _entityBomber.BodyColor;

        using Pen pen = new(Color.Black, 2);
        using Brush bodyBrush = new SolidBrush(bodyColor);
        using Brush cockpitBrush = new SolidBrush(Color.LightBlue);
        using Brush engineBrush = new SolidBrush(Color.DarkGray);

        int fuselageLength = 120;
        int fuselageWidth = 24;
        int top = y;
        int bottom = y + fuselageWidth;
        int centerY = y + fuselageWidth / 2;

        // ----- Фюзеляж -----
        Rectangle fuselage = new(x, y, fuselageLength, fuselageWidth);
        g.FillEllipse(bodyBrush, fuselage);
        g.DrawEllipse(pen, fuselage);

        // ----- Двигатели (всегда 2) -----
        int wingRoot = x + 70;

        // Левое крыло (верхнее) – один двигатель у корня
        int leftEngineX = wingRoot - 10;
        int leftEngineY = top - 25;
        Rectangle leftEngine = new(leftEngineX, leftEngineY, 12, 8);
        g.FillEllipse(engineBrush, leftEngine);
        g.DrawEllipse(pen, leftEngine);

        // Правое крыло (нижнее) – один двигатель у корня
        int rightEngineX = wingRoot - 10;
        int rightEngineY = bottom + 17;
        Rectangle rightEngine = new(rightEngineX, rightEngineY, 12, 8);
        g.FillEllipse(engineBrush, rightEngine);
        g.DrawEllipse(pen, rightEngine);

        // ----- Крылья -----
        Point[] leftWing = new Point[]
        {
            new(wingRoot, top),
            new(wingRoot - 15, top - 60),
            new(wingRoot - 35, top - 60),
            new(wingRoot - 30, top)
        };
        Point[] rightWing = new Point[]
        {
            new(wingRoot, bottom),
            new(wingRoot - 30, bottom),
            new(wingRoot - 35, bottom + 60),
            new(wingRoot - 15, bottom + 60)
        };
        g.FillPolygon(bodyBrush, leftWing);
        g.DrawPolygon(pen, leftWing);
        g.FillPolygon(bodyBrush, rightWing);
        g.DrawPolygon(pen, rightWing);

        // ----- Хвост -----
        int tailRoot = x + 20;
        Point[] leftTail = new Point[]
        {
            new(tailRoot, top + 4),
            new(tailRoot - 5, top - 20),
            new(tailRoot - 15, top - 20),
            new(tailRoot - 10, top + 4)
        };
        Point[] rightTail = new Point[]
        {
            new(tailRoot, bottom - 4),
            new(tailRoot - 10, bottom - 4),
            new(tailRoot - 15, bottom + 20),
            new(tailRoot - 5, bottom + 20)
        };
        g.FillPolygon(bodyBrush, leftTail);
        g.DrawPolygon(pen, leftTail);
        g.FillPolygon(bodyBrush, rightTail);
        g.DrawPolygon(pen, rightTail);

        // ----- Киль -----
        Rectangle keel = new(x + 15, centerY - 2, 10, 4);
        g.FillRectangle(bodyBrush, keel);
        g.DrawRectangle(pen, keel);

        // ----- Кабина -----
        Rectangle cockpit = new(x + fuselageLength - 38, centerY - 6, 16, 12);
        g.FillEllipse(cockpitBrush, cockpit);
        g.DrawEllipse(pen, cockpit);
    }
}