using ProjectSportCar.Drawnings;

namespace ProjectSportCar.CollectionGenericObjects;

/// <summary>
/// Абстракция компании, хранящий коллекцию некого типа, наследника IMoveableObject
/// </summary>
public abstract class AbstractCompany
{
	/// <summary>
	/// Размер места (ширина)
	/// </summary>
	protected readonly int _placeSizeWidth;

	/// <summary>
	/// Размер места (высота)
	/// </summary>
	protected readonly int _placeSizeHeight;

	/// <summary>
	/// Ширина окна
	/// </summary>
	protected readonly int _pictureWidth;

	/// <summary>
	/// Высота окна
	/// </summary>
	protected readonly int _pictureHeight;

	/// <summary>
	/// Коллекция
	/// </summary>
	protected ICollectionGenericObjects<DrawningBomber> _collection;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="pictureWidth">Ширина окна</param>
	/// <param name="pictureHeight">Высота окна</param>
	/// <param name="placeSizeWidth">Размер места (ширина)</param>
	/// <param name="placeSizeHeight">Размер места (высота)</param>
	/// <param name="collection">Коллекция</param>
	public AbstractCompany(int pictureWidth, int pictureHeight, int placeSizeWidth, int placeSizeHeight, ICollectionGenericObjects<DrawningBomber> collection)
	{
		_pictureWidth = pictureWidth;
		_pictureHeight = pictureHeight;
		_placeSizeWidth = placeSizeWidth;
		_placeSizeHeight = placeSizeHeight;
		_collection = collection;
		_collection.MaxCount = CalcMaxCount();
	}

	/// <summary>
	/// Перегрузка оператора сложения для класса
	/// </summary>
	/// <param name="company">Компания</param>
	/// <param name="car">Добавляемый объект</param>
	/// <returns>true - операция прошла успешно, false - операция завершилась неудачно</returns>
	public static bool operator +(AbstractCompany company, DrawningBomber bomber) => company._collection.InsertObject(bomber);

	/// <summary>
	/// Перегрузка оператора удаления для класса
	/// </summary>
	/// <param name="company">Компания</param>
	/// <param name="position">Номер удаляемого объекта</param>
	/// <returns>true - операция прошла успешно, false - операция завершилась неудачно</returns>
	public static bool operator -(AbstractCompany company, int position) => company._collection.RemoveObject(position);

	/// <summary>
	/// Получение случайного объекта из коллекции
	/// </summary>
	/// <returns>Объект из коллекции</returns>
	public DrawningBomber? GetRandomObject()
	{
		Random random = new();
		int maxCount = CalcMaxCount();
		DrawningBomber? drawningBomber = null;
		int counter = 10;
		while (drawningBomber is null)
		{
			drawningBomber = _collection.GetObject(random.Next(0, maxCount));
			counter--;
			if (counter == 0)
			{
				break;
			}
		}

		return drawningBomber;
	}

	/// <summary>
	/// Вывод всей коллекции
	/// </summary>
	/// <returns></returns>
	public Bitmap? Show()
	{
		Bitmap bitmap = new(_pictureWidth, _pictureHeight);
		Graphics graphics = Graphics.FromImage(bitmap);
		DrawBackgound(graphics);
		DrawObjects(graphics);
		return bitmap;
	}

	/// <summary>
	/// Вывод заднего фона
	/// </summary>
	/// <param name="g"></param>
	protected abstract void DrawBackgound(Graphics g);

	/// <summary>
	/// Расстановка и прорисовка объектов
	/// </summary>
	/// <param name="g"></param>
	protected abstract void DrawObjects(Graphics g);

	/// <summary>
	/// Вычисление максимального количества элементов, который можно разместить в окне
	/// </summary>
	private int CalcMaxCount() => (int)(Math.Truncate((double)_pictureWidth / _placeSizeWidth) * Math.Truncate((double)_pictureHeight / _placeSizeHeight));
}