# BinarySearch
## Оптимизированный бинарный поиск C#
Поиск ключа и номер элемента ведётся в отсортированном массиве.

```C#
int pr = (key - a[left]) * (key - a[right]);
```
**pr** – Проверяет вхождение ключа в отрезкок массива от *Left* до *Right*, если **pr** < 0, то ключ находится в указанном отрезке, если **pr** > 0, находится за пределами отрезка.

Поиск сводится к тому, что вновь определяется значение серединного элемента в выбранной половине и сравнивается с ключом

Если **pr** < 0, входим в тело *while*, где проверяем, если ключ меньше значения *a[middle]*, то поиск осуществляется в первой половине элементов, иначе — во второй. Если **pr** > 0, возвращаем -1. Проверяем ключ, если его значение равно *a[left]*, возвращаем *left*, иначе *right*.

	
```C#
static int BinSearchKey(int[] a, int left, int right, int key)
{
    int pr = (key - a[left]) * (key - a[right]);
    
    while (pr < 0)
    {
        int middle = left + (right - left) / 2;
        
        if (a[middle] == key) return middle;
        
        if (a[middle] > key)
            right = middle - 1;
        else
            left = middle + 1;
        
        pr = (key - a[left]) * (key - a[right]);
    }
    
    if (pr > 0)
        return -1;
    
    if (key == a[left])
        return left;
    
    return right;
}
```
