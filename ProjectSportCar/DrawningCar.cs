using System.Drawing;
using System.Drawing.Drawing2D;

namespace ProjectSportCar;

/// <summary>
/// Класс, отвечающий за прорисовку и перемещение бомбардировщика
/// </summary>
public class DrawningCar
{
    private EntityCar? _entityCar;
    private int? _startPosX;
    private int? _startPosY;

    // Размеры прорисовки самолёта (не более 150x150)
    private readonly int _drawningCarWidth = 140;
    private readonly int _drawningCarHeight = 80;

    public int? PosX => _startPosX;
    public int? PosY => _startPosY;
    public double? CarStep => _entityCar?.Step;
    public int DrawningCarWidth => _drawningCarWidth;
    public int DrawningCarHeight => _drawningCarHeight;
    public int? EngineCount => _entityCar?.EngineCount;

    public void Init(int speed, double weight, Color bodyColor, int engineCount)
    {
        _entityCar = new EntityCar();
        _entityCar.Init(speed, weight, bodyColor, engineCount);
        _startPosX = null;
        _startPosY = null;
    }

    public void SetPosition(int x, int y)
    {
        _startPosX = x;
        _startPosY = y;
    }

    public void MoveLeft()
    {
        if (_entityCar is null || !_startPosX.HasValue) return;
        _startPosX -= (int)_entityCar.Step;
    }

    public void MoveRight()
    {
        if (_entityCar is null || !_startPosX.HasValue) return;
        _startPosX += (int)_entityCar.Step;
    }

    public void MoveUp()
    {
        if (_entityCar is null || !_startPosY.HasValue) return;
        _startPosY -= (int)_entityCar.Step;
    }

    public void MoveDown()
    {
        if (_entityCar is null || !_startPosY.HasValue) return;
        _startPosY += (int)_entityCar.Step;
    }

    public void DrawTransport(Graphics g)
    {
        if (_entityCar is null || !_startPosX.HasValue || !_startPosY.HasValue)
            return;

        int x = _startPosX.Value;
        int y = _startPosY.Value;

        Color bodyColor = _entityCar.BodyColor;

        using Pen pen = new(Color.Black, 2);
        using Brush bodyBrush = new SolidBrush(bodyColor);
        using Brush cockpitBrush = new SolidBrush(Color.LightBlue);
        using Brush engineBrush = new SolidBrush(Color.DarkGray);
        using Brush tankBrush = new SolidBrush(Color.LightSteelBlue);

        int fuselageLength = 120;
        int fuselageWidth = 24;
        int top = y;
        int bottom = y + fuselageWidth;
        int centerY = y + fuselageWidth / 2;

        // ---------- ФЮЗЕЛЯЖ ----------
        Rectangle fuselage = new Rectangle(x, y, fuselageLength, fuselageWidth);
        g.FillEllipse(bodyBrush, fuselage);
        g.DrawEllipse(pen, fuselage);

        // ---------- ТОПЛИВНЫЕ БАКИ (под крыльями) ----------
        int wingRoot = x + 70; // точка крепления крыльев

        // Бак под левым крылом
        int leftTankX = wingRoot - 10;
        int leftTankY = top - 9;
        Rectangle leftTank = new Rectangle(leftTankX - 18, leftTankY - 5, 36, 10);
        g.FillEllipse(tankBrush, leftTank);
        g.DrawEllipse(pen, leftTank);

        // Бак под правым крылом
        int rightTankX = wingRoot - 10;
        int rightTankY = bottom + 9;
        Rectangle rightTank = new Rectangle(rightTankX - 18, rightTankY - 5, 36, 10);
        g.FillEllipse(tankBrush, rightTank);
        g.DrawEllipse(pen, rightTank);

        // ---------- ДВИГАТЕЛИ (количество зависит от EngineCount) ----------
        int enginesPerWing = _entityCar.EngineCount / 2; // 1, 2 или 3

        // Диапазон двигателей от корня к законцовке: от wingRoot-8 (корень) до wingRoot-22 (законцовка)
        int leftEngineStartX = wingRoot - 10;      // корень (ближе к фюзеляжу)
        int leftEngineEndX = wingRoot - 17;       // законцовка (дальше от фюзеляжа)
        int leftEngineStartY = top - 25;
        int leftEngineEndY = top - 55;

        for (int i = 0; i < enginesPerWing; i++)
        {
            double t = (enginesPerWing == 1) ? 0.0 : (double)i / (enginesPerWing - 1);
            // t = 0 соответствует корню, t = 1 – законцовке
            int engineX = (int)(leftEngineStartX + t * (leftEngineEndX - leftEngineStartX));

            int engineY = (int)(leftEngineStartY + t * (leftEngineEndY - leftEngineStartY));

            Rectangle engine = new Rectangle(engineX, engineY, 12, 8);
            g.FillEllipse(engineBrush, engine);
            g.DrawEllipse(pen, engine);
        }

        int rightEngineStartX = wingRoot - 10;     // корень
        int rightEngineEndX = wingRoot - 17;      // законцовка
        int rightEngineStartY = bottom + 17;
        int rightEngineEndY = bottom + 47;

        for (int i = 0; i < enginesPerWing; i++)
        {
            double t = (enginesPerWing == 1) ? 0.0 : (double)i / (enginesPerWing - 1);
            int engineX = (int)(rightEngineStartX + t * (rightEngineEndX - rightEngineStartX));

            int engineY = (int)(rightEngineStartY + t * (rightEngineEndY - rightEngineStartY));

            Rectangle engine = new Rectangle(engineX, engineY, 12, 8);
            g.FillEllipse(engineBrush, engine);
            g.DrawEllipse(pen, engine);
        }

        // ---------- КРЫЛЬЯ (оба слева, увеличенные) - СКОРРЕКТИРОВАНЫ ----------
        Point[] leftWing = new Point[]
        {
        new Point(wingRoot, top),
        new Point(wingRoot - 15, top - 60),
        new Point(wingRoot - 35, top - 60),
        new Point(wingRoot - 30, top)
        };

        Point[] rightWing = new Point[]
        {
        new Point(wingRoot, bottom),
        new Point(wingRoot - 30, bottom),
        new Point(wingRoot - 35, bottom + 60),
        new Point(wingRoot - 15, bottom + 60)
        };

        g.FillPolygon(bodyBrush, leftWing);
        g.DrawPolygon(pen, leftWing);

        g.FillPolygon(bodyBrush, rightWing);
        g.DrawPolygon(pen, rightWing);

        // ---------- ХВОСТ ----------
        int tailRoot = x + 20;
        Point[] leftTail = new Point[]
        {
        new Point(tailRoot, top + 4),
        new Point(tailRoot - 5, top - 20),
        new Point(tailRoot - 15, top - 20),
        new Point(tailRoot - 10, top + 4)
        };

        Point[] rightTail = new Point[]
        {
        new Point(tailRoot, bottom - 4),
        new Point(tailRoot - 10, bottom - 4),
        new Point(tailRoot - 15, bottom + 20),
        new Point(tailRoot - 5, bottom + 20)
        };

        g.FillPolygon(bodyBrush, leftTail);
        g.DrawPolygon(pen, leftTail);

        g.FillPolygon(bodyBrush, rightTail);
        g.DrawPolygon(pen, rightTail);

        // ---------- КИЛЬ ----------
        Rectangle keel = new Rectangle(x + 15, centerY - 2, 10, 4);
        g.FillRectangle(bodyBrush, keel);
        g.DrawRectangle(pen, keel);

        // ---------- КАБИНА ----------
        Rectangle cockpit = new Rectangle(x + fuselageLength - 38, centerY - 6, 16, 12);
        g.FillEllipse(cockpitBrush, cockpit);
        g.DrawEllipse(pen, cockpit);
    }
}