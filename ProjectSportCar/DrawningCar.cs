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
    private readonly int _drawningCarWidth = 120;
    private readonly int _drawningCarHeight = 60;

    /// <summary>Левая координата</summary>
    public int? PosX => _startPosX;

    /// <summary>Верхняя координата</summary>
    public int? PosY => _startPosY;

    /// <summary>Шаг перемещения</summary>
    public double? CarStep => _entityCar?.Step;

    /// <summary>Ширина самолёта</summary>
    public int DrawningCarWidth => _drawningCarWidth;

    /// <summary>Высота самолёта</summary>
    public int DrawningCarHeight => _drawningCarHeight;

    /// <summary>Количество двигателей</summary>
    public int? EngineCount => _entityCar?.EngineCount;

    /// <summary>
    /// Инициализация свойств
    /// </summary>
    public void Init(int speed, double weight, Color bodyColor, int engineCount)
    {
        _entityCar = new EntityCar();
        _entityCar.Init(speed, weight, bodyColor, engineCount);
        _startPosX = null;
        _startPosY = null;
    }

    /// <summary>Установка позиции</summary>
    public void SetPosition(int x, int y)
    {
        _startPosX = x;
        _startPosY = y;
    }

    /// <summary>Сдвиг влево</summary>
    public void MoveLeft()
    {
        if (_entityCar is null || !_startPosX.HasValue) return;
        _startPosX -= (int)_entityCar.Step;
    }

    /// <summary>Сдвиг вправо</summary>
    public void MoveRight()
    {
        if (_entityCar is null || !_startPosX.HasValue) return;
        _startPosX += (int)_entityCar.Step;
    }

    /// <summary>Сдвиг вверх</summary>
    public void MoveUp()
    {
        if (_entityCar is null || !_startPosY.HasValue) return;
        _startPosY -= (int)_entityCar.Step;
    }

    /// <summary>Сдвиг вниз</summary>
    public void MoveDown()
    {
        if (_entityCar is null || !_startPosY.HasValue) return;
        _startPosY += (int)_entityCar.Step;
    }

    /// <summary>
    /// Прорисовка бомбардировщика (вид сбоку)
    /// </summary>
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
        using Brush tankBrush = new SolidBrush(Color.LightSteelBlue); // для топливных баков

        int fuselageLength = 120;
        int fuselageWidth = 24;

        int top = y;
        int bottom = y + fuselageWidth;
        int centerY = y + fuselageWidth / 2;

        // ---------- ФЮЗЕЛЯЖ ----------
        Rectangle fuselage = new Rectangle(x, y, fuselageLength, fuselageWidth);
        g.FillEllipse(bodyBrush, fuselage);
        g.DrawEllipse(pen, fuselage);

        // ---------- ДВИГАТЕЛИ (под крыльями, рисуем до крыльев) ----------
        int wingRoot = x + 70; // точка крепления крыльев

        // Двигатель под левым (верхним) крылом
        int leftEngineX = wingRoot - 6;
        int leftEngineY = top - 22;
        Rectangle leftEngine = new Rectangle(leftEngineX - 7, leftEngineY - 5, 14, 10);
        g.FillEllipse(engineBrush, leftEngine);
        g.DrawEllipse(pen, leftEngine);

        // Двигатель под правым (нижним) крылом
        int rightEngineX = wingRoot - 6;
        int rightEngineY = bottom + 22;
        Rectangle rightEngine = new Rectangle(rightEngineX - 7, rightEngineY - 5, 14, 10);
        g.FillEllipse(engineBrush, rightEngine);
        g.DrawEllipse(pen, rightEngine);

        // ---------- ТОПЛИВНЫЕ БАКИ (под крыльями, вытянутые по горизонтали) ----------
        // Бак под левым крылом
        int leftTankX = wingRoot - 10;          // центр бака по X
        int leftTankY = top - 9;               // чуть ниже двигателя, под крылом
        Rectangle leftTank = new Rectangle(leftTankX - 18, leftTankY - 5, 36, 10);
        g.FillEllipse(tankBrush, leftTank);
        g.DrawEllipse(pen, leftTank);

        // Бак под правым крылом
        int rightTankX = wingRoot - 10;
        int rightTankY = bottom + 9;
        Rectangle rightTank = new Rectangle(rightTankX - 18, rightTankY - 5, 36, 10);
        g.FillEllipse(tankBrush, rightTank);
        g.DrawEllipse(pen, rightTank);

        // ---------- КРЫЛЬЯ (оба слева) ----------
        Point[] leftWing =
        {
        new Point(wingRoot, top),
        new Point(wingRoot - 10, top - 45),
        new Point(wingRoot - 25, top - 45),
        new Point(wingRoot - 15, top)
    };

        Point[] rightWing =
        {
        new Point(wingRoot, bottom),
        new Point(wingRoot - 15, bottom),
        new Point(wingRoot - 25, bottom + 45),
        new Point(wingRoot - 10, bottom + 45)
    };

        g.FillPolygon(bodyBrush, leftWing);
        g.DrawPolygon(pen, leftWing);

        g.FillPolygon(bodyBrush, rightWing);
        g.DrawPolygon(pen, rightWing);

        // ---------- ХВОСТ ----------
        int tailRoot = x + 20;

        Point[] leftTail =
        {
        new Point(tailRoot, top + 4),
        new Point(tailRoot - 5, top - 20),
        new Point(tailRoot - 15, top - 20),
        new Point(tailRoot - 10, top + 4)
    };

        Point[] rightTail =
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