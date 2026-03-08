using ProjectSportCar.Entities;

namespace ProjectSportCar.Drawnings;

/// <summary>
/// Класс для прорисовки улучшенного бомбардировщика (с бомбами и доп. баками)
/// </summary>
public class DrawningUpgradedBomber : DrawningBomber
{
    public DrawningUpgradedBomber(int speed, double weight, Color bodyColor,
                                   Color additionalColor, bool hasBombs, bool hasExtraTanks)
        : base(140, 80)
    {
        _entityBomber = new EntityUpgradedBomber(speed, weight, bodyColor,
                                                  additionalColor, hasBombs, hasExtraTanks);
    }

    public override void DrawTransport(Graphics g)
    {
        if (_entityBomber is null || _entityBomber is not EntityUpgradedBomber upgraded ||
            !_startPosX.HasValue || !_startPosY.HasValue)
            return;

        int x = _startPosX.Value;
        int y = _startPosY.Value;

        int fuselageLength = 120;
        int fuselageWidth = 24;
        int top = y;
        int bottom = y + fuselageWidth;
        int centerY = y + fuselageWidth / 2;
        int wingRoot = x + 70; // точка крепления крыльев

        using Pen pen = new(Color.Black, 2);
        using Brush additionalBrush = new SolidBrush(upgraded.AdditionalColor);
        using Brush tankBrush = new SolidBrush(upgraded.AdditionalColor);

        // ----- Бомбы (если есть) -----
        if (upgraded.HasBombs)
        {
            
                // Бомба под левым крылом
                int leftBombX = wingRoot - 45;
                int leftBombY = top - 38;
                Rectangle leftBomb = new Rectangle(leftBombX, leftBombY - 5, 46, 15);
                g.FillEllipse(tankBrush, leftBomb);
                g.DrawEllipse(pen, leftBomb);

                // Бомба под правым крылом
                int rightBombX = wingRoot - 45;
                int rightBombY = bottom + 38;
                Rectangle rightBomb = new Rectangle(leftBombX, rightBombY - 5, 46, 15);
                g.FillEllipse(tankBrush, rightBomb); 
                g.DrawEllipse(pen, rightBomb);
            
        }

        // ----- Дополнительные топливные баки (если есть) -----
        if (upgraded.HasExtraTanks)
        {
            // Бак под левым крылом
            int leftTankX = wingRoot - 28;
            int leftTankY = top - 9;
            Rectangle leftTank = new Rectangle(leftTankX, leftTankY - 5, 36, 10);
            g.FillEllipse(tankBrush, leftTank);
            g.DrawEllipse(pen, leftTank);

            // Бак под правым крылом
            int rightTankX = wingRoot - 28;
            int rightTankY = bottom + 9;
            Rectangle rightTank = new Rectangle(rightTankX, rightTankY - 5, 36, 10);
            g.FillEllipse(tankBrush, rightTank);
            g.DrawEllipse(pen, rightTank);
        }

        // Базовая отрисовка (фюзеляж, крылья, двигатели)
        base.DrawTransport(g);
    }
}