namespace ForOOPS.StructuralPattern.Decorator
{
    interface IDecorator
    {
        void Display();
        void Operation();
        void SetComponent(Component component);
    }
}