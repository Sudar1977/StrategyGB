using System.Collections;
using UnityEngine;

//https://www.youtube.com/watch?v=5pJfrtKiraI

namespace DI
{
    public class Program : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            IBullet bullet = new Bullet();
            IBullet firebullet = new FireBullet();
            Enemy enemy = new Enemy(firebullet);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class Enemy
    {
        IBullet _bullet;
        IBullet bullet = new Bullet();
        IBullet firebullet = new FireBullet();

        public Enemy(IBullet bullet)
        {
            _bullet = bullet;
        }

        void Shoot()
        {
 
            Debug.Log("Выстрелил патрон "+ _bullet.name);
        }
    }

    public class Bullet : IBullet
    {
        int col;
        string nameBullet; 
        public int cols { get => col; set => col = value; }
        public string name { get => nameBullet; set => nameBullet = value; }
    }

    public class FireBullet : IBullet
    {
        int col;
        string nameBullet;
        public int cols { get => col; set => col = value; }
        public string name { get => nameBullet; set => nameBullet = value; }
    }

    public interface IBullet
    {
        int cols { get; set; }
        string name { get; set; }
    }
}