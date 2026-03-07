using ProjectSportCar.Entities;

namespace ProjectSportCar.Drawnings;

/// <summary>
/// Класс, отвечающий за прорисовку и перемещение объекта-сущности
/// </summary>
public class DrawningSportCar : DrawningCar
{
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="speed">Скорость</param>
	/// <param name="weight">Вес</param>
	/// <param name="bodyColor">Основной цвет</param>
	/// <param name="additionalColor">Дополнительный цвет</param>
	/// <param name="bodyKit">Признак наличия обвеса</param>
	/// <param name="wing">Признак наличия антикрыла</param>
	/// <param name="sportLine">Признак наличия гоночной полосы</param>
	public DrawningSportCar(int speed, double weight, Color bodyColor, Color additionalColor, bool bodyKit, bool wing, bool sportLine) : base(10, 10)
	{
		_entityCar = new EntitySportCar(speed, weight, bodyColor, additionalColor, bodyKit, wing, sportLine);
	}

	public override void DrawTransport(Graphics g)
	{
		if (_entityCar is null || _entityCar is not EntitySportCar sportCar || !_startPosX.HasValue || !_startPosY.HasValue)
		{
			return;
		}

		Pen pen = new(Color.Black);
		Brush additionalBrush = new SolidBrush(sportCar.AdditionalColor);

		// обвесы
		if (sportCar.BodyKit)
		{
			// код прорисовки элемента
		}

		// смещаем прорисовку базовой части вправо и вниз, чтобы она корректно наложилась на прорисовку опциональных элементов
		_startPosX += 10;
		_startPosY += 5;
		// вызываем прорисовку базовой части
		base.DrawTransport(g);
		// возвращаем координаты как было
		_startPosX -= 10;
		_startPosY -= 5;

		// спортивная линия
		if (sportCar.SportLine)
		{
			// код прорисовки элемента
		}

		// крыло
		if (sportCar.Wing)
		{
			// код прорисовки элемента
		}
	}
}