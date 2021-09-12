using CA.SharedKernel.Domain;
using CA.Todos.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace CA.Todos.Domain.ValueObjects
{
    public class Color : ValueObject
    {
        static Color()
        {

        }

        private Color()
        {

        }

        private Color(string code)
        {
            Code = code;
        }

        public static Color From(string code)
        {
            var color = new Color { Code = code };

            if (!SupportedColours.Contains(color))
            {
                throw new UnsupportedColorException(code);
            }

            return color;
        }

        public string Code { get; private set; }

        #region Color Codes

        public static Color White => new Color("#FFFFFF");

        public static Color Red => new Color("#FF5733");

        public static Color Orange => new Color("#FFC300");

        public static Color Yellow => new Color("#FFFF66");

        public static Color Green => new Color("#CCFF99");

        public static Color Blue => new Color("#6666FF");

        public static Color Purple => new Color("#9966CC");

        public static Color Grey => new Color("#999999");

        #endregion

        #region Operators

        public static implicit operator string(Color color)
        {
            return color.ToString();
        }

        public static explicit operator Color(string code)
        {
            return From(code);
        }

        #endregion

        protected static IEnumerable<Color> SupportedColours
        {
            get
            {
                yield return White;
                yield return Red;
                yield return Orange;
                yield return Yellow;
                yield return Green;
                yield return Blue;
                yield return Purple;
                yield return Grey;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}