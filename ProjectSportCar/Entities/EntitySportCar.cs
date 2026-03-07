namespace ProjectSportCar.Entities;

/// <summary>
/// Класс-сущность "Спортивный автомобиль"
/// </summary>
public class EntitySportCar : EntityCar
{
	/// <summary>
	/// Дополнительный цвет (для опциональных элементов)
	/// </summary>
	public Color AdditionalColor { get; init; }

	/// <summary>
	/// Признак (опция) наличия обвеса
	/// </summary>
	public bool BodyKit { get; init; }

	/// <summary>
	/// Признак (опция) наличия антикрыла
	/// </summary>
	public bool Wing { get; init; }

	/// <summary>
	/// Признак (опция) наличия гоночной полосы
	/// </summary>
	public bool SportLine { get; init; }

	/// <summary>
	/// Конструктор для инициализации полей объекта-класса спортивного автомобиля
	/// </summary>
	/// <param name="speed">Скорость</param>
	/// <param name="weight">Вес автомобиля</param>
	/// <param name="bodyColor">Основной цвет</param>
	/// <param name="additionalColor">Дополнительный цвет</param>
	/// <param name="bodyKit">Признак наличия обвеса</param>
	/// <param name="wing">Признак наличия антикрыла</param>
	/// <param name="sportLine">Признак наличия гоночной полосы</param>
	public EntitySportCar(int speed, double weight, Color bodyColor, Color additionalColor, bool bodyKit, bool wing, bool sportLine) : base(speed, weight, bodyColor)
	{
		AdditionalColor = additionalColor;
		BodyKit = bodyKit;
		Wing = wing;
		SportLine = sportLine;
	}
}