//This class will only be inherited from
public abstract class EnemyAbstract
{
    //Children will access speed but other scripts cannot
    protected int speed;

    //Every child MUST have a movement method, like an interface
    public abstract void Movement();

    public virtual void Behaviour()
    {
        //Idle
        //Patrol
        //Attack
    }
}

public class Soldier : EnemyAbstract, IDamagable
{
    //I MUST have a movement method
    public override void Movement()
    {
        //This is how soldiers move
    }

    //I CAN have my own version of 'behaviour'
    public override void Behaviour()
    {
        //this is how I ask it to run everything in the parent class, so I'll idle, patrol, attack, etc
        //I don't need to do this though
        base.Behaviour();

        //But I can add my own behaviour in here unique to this child
    }

    //I need to have this method because I have this interface, it must also be public
    public void TakeDamage()
    {
        //reduce health
    }
}

public class Crate : IDamagable
{
    public void TakeDamage()
    {
        //Smash, drop loot
    }
}

public interface IDamagable
{
    void TakeDamage();
}



public class Player
{
    void Hit(object hit)
    {
        EnemyAbstract hitAsEnemy = (EnemyAbstract)hit;
        //alternatively 
        EnemyAbstract hitAsEnemy2 = hit as EnemyAbstract;

        if(hitAsEnemy != null)
        {
            hitAsEnemy.Movement();
        }

        IDamagable damageableHit = (IDamagable)hitAsEnemy;
        if(damageableHit != null)
        {
            damageableHit.TakeDamage();
        }
    }
}