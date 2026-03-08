namespace ProjectSportCar.CollectionGenericObjects;

/// <summary>
/// Параметризованный набор объектов
/// </summary>
/// <typeparam name="T">Параметр: ограничение - ссылочный тип</typeparam>
public class MassiveGenericObjects<T> : ICollectionGenericObjects<T>
	where T : class
{
	/// <summary>
	/// Массив объектов, которые храним
	/// </summary>
	private T?[] _collection;

	public int CountObjects
	{
		get 
		{
			int count = 0;
			for (int i = 0; i < _collection.Length; ++i)
			{
				if (_collection[i] is not null)
				{
					count++;
				}
			}

			return count;
		}
	}

	public int MaxCount 
	{ 
		set
		{
			if (value > 0)
			{
				Array.Resize(ref _collection, value);
			}
		}
	}

	/// <summary>
	/// Конструктор
	/// </summary>
	public MassiveGenericObjects()
	{
		_collection = [];
	}

	public T? GetObject(int position)
	{
        if (position < 0 || position >= _collection.Length) return null;
        return _collection[position];
	}

	public bool InsertObject(T obj)
	{
		return InsertObject(obj, 0); ;
	}

	public bool InsertObject(T obj, int position)
	{
        if (position < 0 || position >= _collection.Length)
            return false;
        if (_collection[position] == null)
        {
            _collection[position] = obj;
            return true;
        }
        for (int i = position + 1; i < _collection.Length; i++)
            if (_collection[i] == null)
            {
                _collection[i] = obj;
                return true;
            }
        for (int i = position - 1; i >= 0; i--)
            if (_collection[i] == null)
            {
                _collection[i] = obj;
                return true;
            }
        return false;
    }

	public bool RemoveObject(int position)
	{
        if (position < 0 || position >= _collection.Length)
            return false;
        if (_collection[position] == null)
            return false;
        _collection[position] = null;
        return true;
    }
}