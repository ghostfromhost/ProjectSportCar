namespace ProjectSportCar.Entities;

/// <summary>
/// Класс-сущность "Улучшенный бомбардировщик" (с бомбами и доп. баками)
/// </summary>
public class EntityUpgradedBomber : EntityBomber
{
    /// <summary>Дополнительный цвет для опциональных элементов</summary>
    public Color AdditionalColor { get; init; }

    /// <summary>Наличие бомб</summary>
    public bool HasBombs { get; init; }

    /// <summary>Наличие дополнительных топливных баков</summary>
    public bool HasExtraTanks { get; init; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public EntityUpgradedBomber(int speed, double weight, Color bodyColor,
                                Color additionalColor, bool hasBombs, bool hasExtraTanks)
        : base(speed, weight, bodyColor)
    {
        AdditionalColor = additionalColor;
        HasBombs = hasBombs;
        HasExtraTanks = hasExtraTanks;
    }
}