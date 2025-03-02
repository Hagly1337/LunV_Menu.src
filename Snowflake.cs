using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUNYNE
{
    internal class Snowflake
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Size { get; set; }
        public float Speed { get; set; }

        public Snowflake(float x, float y, float size, float speed)
        {
            X = x;
            Y = y;
            Size = size;
            Speed = speed;
        }

        public void Fall()
        {
            Y += Speed;
            if (Y > 540) // Предполагаем, что высота формы 600
            {
                Y = 0;
                X = new Random().Next(0, 800); // Перезапускаем снежинку с нового места
            }
        }
    }
}

