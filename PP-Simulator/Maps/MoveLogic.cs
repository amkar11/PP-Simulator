using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Simulator.Maps;
    internal class MoveLogic
    {
    public static Point WallNext(Map m, Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return m.Exist(nextPoint) ? nextPoint : p;
    }
    public static Point WallNextDiagonal(Map m, Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return m.Exist(nextPoint) ? nextPoint : p;
    }
}

