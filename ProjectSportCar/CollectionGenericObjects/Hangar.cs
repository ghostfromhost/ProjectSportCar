using ProjectSportCar.Drawnings;

namespace ProjectSportCar.CollectionGenericObjects;

/// <summary>
/// Реализация компании - сервис каршеринга
/// </summary>
public class Hangar : AbstractCompany
{
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="pictureWidth">Ширина окна</param>
	/// <param name="pictureHeight">Высота окна</param>
	/// <param name="collection">Коллекция автомобилей</param>
	public Hangar(int pictureWidth, int pictureHeight, ICollectionGenericObjects<DrawningBomber> collection) : base(pictureWidth, pictureHeight, 150, 160, collection)
	{ }

	protected override void DrawBackgound(Graphics g)
	{
        using Pen pen = new(Color.LightGray, 1);
        int cols = (int)(_pictureWidth / _placeSizeWidth);
        int rows = (int)(_pictureHeight / _placeSizeHeight);
        for (int i = 0; i <= cols; i++)
            g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, _pictureHeight);
        for (int i = 0; i <= rows; i++)
            g.DrawLine(pen, 0, i * _placeSizeHeight, _pictureWidth, i * _placeSizeHeight);
    }

	protected override void DrawObjects(Graphics g)
	{
        int cols = (int)(_pictureWidth / _placeSizeWidth);
        int rows = (int)(_pictureHeight / _placeSizeHeight);
        int maxCount = cols * rows;
        for (int i = 0; i < maxCount; i++)
        {
            var bomber = _collection.GetObject(i);
            if (bomber != null)
            {
                int col = i % cols;
                int row = i / cols;
                int x = col * _placeSizeWidth;
                int y = row * _placeSizeHeight;
                int offsetX = (_placeSizeWidth - bomber.DrawningWidth) / 2;
                int offsetY = (_placeSizeHeight - bomber.DrawningHeight) / 2;
                bomber.SetPosition(x + offsetX, y + offsetY);
                bomber.DrawTransport(g);
            }
        }
    }
}