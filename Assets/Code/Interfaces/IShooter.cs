namespace GameProgramming1
{
    public interface IShooter
    {
        void Shoot(int projectileLayer);

        void ProjectileHit(Projectile projectile);
    }
}