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
	bool IsAlive();
    void Kill();
    void GetHit(int damage);
}
