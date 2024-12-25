using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{
    public static class LINQ
    {
        public static IEnumerator<T> Filter <T>(this IEnumerator<T> baseIter, Predicate<T> predicate)
        {
            return new FilterM<T>(baseIter, predicate);
        }
        public static IEnumerator<T> Skip<T>(this IEnumerator<T> enumerator, int count)
        {
            return new SkipM<T>(enumerator, count);
        }
        public static IEnumerator<T> SkipWhile<T>(this IEnumerator<T> enumerator, Predicate<T> predicate)
        {
            return new SkipWhileM<T>(enumerator, predicate);
        }
        public static IEnumerator<T> Take<T>(this IEnumerator<T> enumerator, int count)
        {
            return new TakeM<T>(enumerator,  count);
        }
        public static IEnumerator<T> TakeWhile<T>(this IEnumerator<T> enumerator, Predicate<T> predicat)
        {
            return new TakeWhileM<T>(enumerator, predicat);
        }
        public static IEnumerator<T> First<T>(this IEnumerator<T> enumerator, Predicate<T> predicat)
        {
            return new FirstM<T>(enumerator, predicat);
        }
        public static IEnumerator<T> FirstOrDefault<T>(this IEnumerator<T> enumerator, Predicate<T> predicat)
        {
            return new FirstOrDefaultM<T>(enumerator, predicat);
        }
        public static IEnumerator<T> Last<T>(this IEnumerator<T> enumerator, Predicate<T> predicat)
        {
            return new LastM<T>(enumerator, predicat);
        }
        public static IEnumerator<T> LastOrDefault<T>(this IEnumerator<T> enumerator, Predicate<T> predicat)
        {
            return new LastOrDefaultM<T>(enumerator, predicat);
        }
        public static IEnumerator<T> Select<T>(this IEnumerator<T> enumerator, Func<T, T> fun)
        {
            return new SelectM<T>(enumerator, fun);
        }
        public static IEnumerator<T> SelectMany<T>(this IEnumerator<T> enumerator, Func<T, IEnumerable<T>> func)
        {
            return new SelectManyM<T>(enumerator, func);
        }
        public static IEnumerator<T> All<T>(this IEnumerator<T> enumerator, Predicate<T> predicate)
        {

            return new AllM<T>(enumerator, predicate);
        }
        public static IEnumerator<T> Any<T>(this IEnumerator<T> enumerator, Predicate<T> predicate)
        {
            return new AnyM<T>(enumerator, predicate);
        }
        public static IEnumerator<T> ToArray<T>(this IEnumerator<T> enumerator)
        {
            return new ToArrayM<T>(enumerator);
        }
        public static IEnumerator<T> ToList<T>(this IEnumerator<T> enumerator)
        {
            return new ToListM<T>(enumerator);
        }
    }

    public class FilterM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Predicate<T> _filter;

        public FilterM(IEnumerator<T> enumerator, Predicate<T> predicate)
        {
            this._enumerator = enumerator;
            this._filter = predicate;
        }
        public T Current => _enumerator.Current;

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            while (_enumerator.MoveNext())
            {
                if (_filter.Invoke(_enumerator.Current))
                {
                    return true;
                }
            }
            return false;
        }
        public void Reset()
        {
        }
    }
    public class SkipM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly int  _count;
        bool _skipped;
        public SkipM(IEnumerator<T> enumerator, int count)
        {
            _enumerator = enumerator;
            _count = count;
            _skipped = false;
        }

        public T Current => _enumerator.Current;

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (!_skipped)
            {
                for (int i = 0; i < _count; i++)
                {
                    if (!_enumerator.MoveNext())
                        return false; 
                }
                _skipped = true;
            }
            if (_enumerator.MoveNext())
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
        }
    }
    public class SkipWhileM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Predicate<T> _predicate;
        bool _skipped;
        public SkipWhileM(IEnumerator<T> enumer, Predicate<T> predicate)
        {
            _enumerator = enumer;
            _predicate = predicate;
            _skipped = false;
        }

        public T Current => _enumerator.Current;

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            while (_enumerator.MoveNext())
            {
                if (_skipped || !_predicate(_enumerator.Current))
                {
                    _skipped = true;
                    return true;
                }

            }
            return false;
        }

        public void Reset()
        {
        }
    }
    public class TakeM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private  int _count;
        bool _taked;
        public TakeM(IEnumerator<T> enumerator, int count)
        {
            _enumerator = enumerator;
            _count = count;
            _taked = true;
        }

        public T Current => _enumerator.Current;

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_count == 0) // Якщо елементи більше не потрібно брати
                return false;

            if (_enumerator.MoveNext()) // Перевіряємо, чи є ще елементи
            {
                _count--; // Зменшуємо лічильник залишених елементів
                return true; // Продовжуємо ітерацію
            }

            return false; // Якщо елементи закінчилися
        }

        public void Reset()
        {
        }
    }
    public class TakeWhileM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Predicate<T> _predicat;

        public TakeWhileM(IEnumerator<T> enumerator, Predicate<T> predicat)
        {
            _enumerator=enumerator;
            _predicat = predicat;
        }

        public T Current => _enumerator.Current;

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            while (_enumerator.MoveNext() && _predicat.Invoke(_enumerator.Current))
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
        }
    }
    public class FirstM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Predicate<T> _predicate;
        bool _first;
        public FirstM(IEnumerator<T> enumerator, Predicate<T> predicate)
        {
            _enumerator = enumerator;
            _predicate = predicate;
            _first = false;
        }

        public T Current => _enumerator.Current;

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            while (_enumerator.MoveNext() && !_first)
            {
                if (_predicate.Invoke(_enumerator.Current) == true)
                {
                    return _first = true;
                }
            }
            return false;

        }

        public void Reset()
        {
        }
    }
    public class FirstOrDefaultM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Predicate<T> _predicate;
        bool _first;
        bool _def;
        public FirstOrDefaultM(IEnumerator<T> enumerator, Predicate<T> predicate)
        {
            _enumerator = enumerator;
            _predicate = predicate;
            _first = false;
            _def = true;
        }
        public T Current
        {
            get 
            {
                if(_first)return _enumerator.Current;
                return default(T);
            }
        }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            while (_enumerator.MoveNext() && !_first)
            {
                if (_predicate.Invoke(_enumerator.Current) == true)
                {
                    _def = false;
                    return _first = true;
                }
            }
            if (_def)
            {
                _def = false;
                return true;
            }
            return _def;

        }

        public void Reset()
        {
        }
    }
    public class LastM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Predicate<T> _predicate;
        private T _last;
        private bool _found;

        public LastM(IEnumerator<T> enumerator, Predicate<T> predicate)
        {
            _enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _found = false;
        }

        public T Current => _last;

        object? IEnumerator.Current => Current;

        // Ініціалізація
        public bool MoveNext()
        {
            while (_enumerator.MoveNext())
            {
                if (_predicate(_enumerator.Current))
                {
                    _last = _enumerator.Current;
                    _found = true;
                }
            }
            if (_found)
            {
                _found = false;
                return true;
            }
            return _found;
        }

        // Скидання
        public void Reset()
        {
            _enumerator.Reset();
            _found = false;
            _last = default(T);
        }

        // Звільнення ресурсів
        public void Dispose()
        {
            _enumerator.Dispose();
        }
    }
    public class LastOrDefaultM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Predicate<T> _predicate;
        private T _last;
        private bool _def;
        private bool _found;

        public LastOrDefaultM(IEnumerator<T> enumerator, Predicate<T> predicate)
        {
            _enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _found = false;
            _last =default(T);
            _def = true;
        }

        public T Current => _last;

        object? IEnumerator.Current => Current;

        // Ініціалізація
        public bool MoveNext()
        {
            while (_enumerator.MoveNext())
            {
                if (_predicate(_enumerator.Current))
                {
                    _last = _enumerator.Current;
                    _found = true;
                }
            }
            if (_found)
            {
                _found = false;
                _def = false;
                return true;
            }
            if (_def)
            {
                _def = false;
                return true;
            }
            return false;
        }

        // Скидання
        public void Reset()
        {
            _enumerator.Reset();
            _found = false;
            _last = default(T);
        }

        // Звільнення ресурсів
        public void Dispose()
        {
            _enumerator.Dispose();
        }
    }
    public class SelectM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Func<T,T> _func;


        public SelectM(IEnumerator<T> enumerator, Func<T,T> fun)
        {
            _enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));
            _func = fun ?? throw new ArgumentNullException(nameof(fun));
        }

        public T Current => _func.Invoke(_enumerator.Current);

        object? IEnumerator.Current => Current;

        // Ініціалізація    
        public bool MoveNext() => _enumerator.MoveNext();

        // Скидання
        public void Reset()
        {
        }

        // Звільнення ресурсів
        public void Dispose()
        {
            _enumerator.Dispose();
        }
    }
    public class SelectManyM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Func<T, IEnumerable<T>> _func;
        private IEnumerator<T> _currentEnumerator;

        public SelectManyM(IEnumerator<T> enumerator, Func<T, IEnumerable<T>> func)
        {
            _enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));
            _func = func ?? throw new ArgumentNullException(nameof(func));
            _currentEnumerator = null!;
        }

        public T Current => _currentEnumerator.Current;

        object? IEnumerator.Current => Current;

        public bool MoveNext()
        {
            // Якщо підколекція пуста або закінчилася
            while (_currentEnumerator == null || !_currentEnumerator.MoveNext())
            {
                if (!_enumerator.MoveNext())
                {
                    return false; // Вихід із зовнішнього enumerator
                }

                // Отримуємо нову підколекцію для поточного елемента
                _currentEnumerator = _func.Invoke(_enumerator.Current).GetEnumerator();
            }

            return true; // Переміщення до наступного елемента у підколекції
        }

        public void Reset()
        {
            throw new NotSupportedException("Reset is not supported.");
        }

        public void Dispose()
        {
            _enumerator.Dispose();
            _currentEnumerator?.Dispose();
        }
    }
    public class AllM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Predicate<T> _predicate;
        private bool _done;
        public AllM(IEnumerator<T> enumerator, Predicate<T> predicate)
        {
            _enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));
            _predicate = predicate;
            _done = true;
        }

        public T Current => _enumerator.Current;

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            while (_enumerator.MoveNext())
            {
                if (!_predicate(_enumerator.Current))
                {
                    _done = false; // Якщо хоча б один елемент не відповідає умові
                    return false; // Завершуємо ітерацію, бо результат вже визначено
                }
            }

            // Якщо всі елементи пройшли перевірку, повертаємо true
            return _done;
        }

    public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    public class AnyM<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly Predicate<T> _predicate;
        private bool _found;

        public AnyM(IEnumerator<T> enumerator, Predicate<T> predicate)
        {
            _enumerator = enumerator;
            _predicate = predicate;
            _found = false;
        }

        public T Current => _enumerator.Current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            while (_enumerator.MoveNext())
            {
                if (_predicate(_enumerator.Current)) // Якщо знайдено елемент, що відповідає умові
                {
                    _found = true;
                    return true;
                }
            }

            return false;
        }

        public void Reset()
        {
        }
    }
    //public class ToArrayM<T> : IEnumerator<T>
    //{
    //    private T[] _array;
    //    private int _position = -1;
    //    public ToArrayM(IEnumerator<T> enumerator)
    //    {
    //        // Створюємо список для зберігання елементів
    //        List<T> tempList = new List<T>();

    //        // Ітеруємо через елементи, що повертає Enumerator, і додаємо їх до списку
    //        while (enumerator.MoveNext())
    //        {
    //            tempList.Add(enumerator.Current);
    //        }

    //        // Перетворюємо список в масив
    //        _array = tempList.ToArray();
    //    }

    //    public T Current => _array[_position];

    //    object IEnumerator.Current => Current;

    //    public bool MoveNext()
    //    {
    //        // Переходимо до наступного елементу
    //        _position++;
    //        return _position < _array.Length;
    //    }

    //    public void Reset()
    //    {
    //        // Повертаємо позицію до початку
    //        _position = -1;
    //    }

    //    public void Dispose()
    //    {
    //        // Можна залишити порожнім, якщо не використовуємо ресурси
    //    }

    //    public T[] ToArray()
    //    {
    //        // Повертає масив з елементами
    //        return _array;
    //    }
    //}
    public class ToArrayM<T> : IEnumerator<T>
    {
        private T[] _array;  // Масив для збереження елементів
        private int _index = -1;  // Індекс для перебору
        private IEnumerator<T> _enumerator;  // Вхідний IEnumerator<T>

        // Конструктор, який приймає IEnumerator<T> і створює масив
        public ToArrayM(IEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
            var tempList = new List<T>();

            // Перебираємо елементи і додаємо їх в список
            while (_enumerator.MoveNext())
            {
                tempList.Add(_enumerator.Current);
            }

            // Перетворюємо список на масив
            _array = tempList.ToArray();
        }

        // Поточний елемент
        public T Current => _array[_index];

        // Метод для отримання поточного елемента (необхідно для IEnumerator)
        object? IEnumerator.Current => Current;

        // Метод MoveNext для перебору елементів
        public bool MoveNext()
        {
            if (_index < _array.Length - 1)
            {
                _index++;
                return true;
            }
            return false;
        }

        // Метод Reset для скидання індексу
        public void Reset()
        {
            _index = -1;
        }

        // Метод Dispose (можна залишити порожнім, якщо немає ресурсів для звільнення)
        public void Dispose() { }
    }
    public class ToListM<T> : IEnumerator<T>
    {
        private List<T> _list; // Список для збереження елементів
        private int _index = -1; // Індекс для перебору
        private IEnumerator<T> _enumerator; // Вхідний IEnumerator<T>

        // Конструктор, який приймає IEnumerator<T> і створює список
        public ToListM(IEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
            _list = new List<T>();

            // Використовуємо MoveNext для проходу по всіх елементах і додаємо їх в список
            while (_enumerator.MoveNext())
            {
                _list.Add(_enumerator.Current);
            }
        }

        // Поточний елемент
        public T Current => _list[_index];

        // Метод для отримання поточного елемента (необхідно для IEnumerator)
        object? IEnumerator.Current => Current;

        // Метод MoveNext для перебору елементів
        public bool MoveNext()
        {
            if (_index < _list.Count - 1)
            {
                _index++;
                return true;
            }
            return false;
        }

        // Метод Reset для скидання індексу
        public void Reset()
        {
            _index = -1;
        }

        // Метод Dispose (можна залишити порожнім, якщо немає ресурсів для звільнення)
        public void Dispose() { }
    }

}
