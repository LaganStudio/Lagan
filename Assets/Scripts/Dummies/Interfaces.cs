///Интерфейс для перемещающихся и прыгающих в 2D пространстве объектов
public interface IMovable
{
    ///Реализция передвижения
    /// <param name="move">Скорость перемещения по оси x-координат.</param>
    void Move(float move);
    ///Реализация прыжка
    void Jump();
}
///Интерфейс для объектов, которым может наносится урон.
public interface IDamageable
{
    ///Реализация метода, который должен возвращать состояние у объекта
	bool IsAlive();
    ///Заготовка метода, который "убивает" объект
    void Kill();
    ///Заготовка метода, который наносит урон, переданный в аргументе
    /// <param name="damage">Урон, который нанесется цели</param>
    void GetHit(int damage);
}
