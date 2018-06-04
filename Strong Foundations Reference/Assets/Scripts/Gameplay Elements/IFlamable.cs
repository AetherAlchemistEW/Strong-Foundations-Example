//This is our interface, any class (or struct) we like can inherit from this (and any other additional class or interface/s)
public interface IFlamable
{
    //But they MUST implement any methods I declare here (they can do whatever they like inside them however)
    void TakeFireDamage();
    //I could make methods with returns and arguments here as well if I like.
}
